Shader "Custom/TrapezoidCorrectionShader1-3"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255

        _ColorMask ("Color Mask", Float) = 15
    }

    SubShader
    {
        Tags
        { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }
        
        Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp] 
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask [_ColorMask]

        Pass
        {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "UnityUI.cginc"
            
            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                float2 position : TEXCOORD1;
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                half2 texcoord  : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                float2 position : TEXCOORD2;
            };
            
            fixed4 _Color;
            fixed4 _TextureSampleAdd;
    
            bool _UseClipRect;
            float4 _ClipRect;

            bool _UseAlphaClip;

            float4 _LT;
            float4 _RT;
            float4 _LB;
            float4 _RB;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.worldPosition = IN.vertex;
                OUT.vertex = mul(UNITY_MATRIX_MVP, OUT.worldPosition);

                OUT.texcoord = IN.texcoord;
                
                #ifdef UNITY_HALF_TEXEL_OFFSET
                OUT.vertex.xy += (_ScreenParams.zw-1.0)*float2(-1,1);
                #endif
                
                OUT.color = IN.color * _Color;
                OUT.position = IN.position;
                return OUT;
            }

            /**
             * プロジェクトション行列の積をZ以外を定数としてyを計算し、
             * 0～1の間に正規化する関数
             * 変換元座標は[x, y, z] = [0, 1, z]として計算
             * @param inZ 0～1のZ値(UVのyを指定)
             * @return 計算結果
             */
            float  ease( float inZ )
            {
                // プロジェクション行列の変換結果のyの項をz値を元に計算する
                // -1.1682333052は適当な定数(=cot(画角))
                // 1.001001001も適当な定数(=zf/(zf-zn))
                float fov = -1.1682333052;
                float z = 1.001001001 * (1 - inZ) + 1;
                float invFov = 1 / fov;
                float y = (fov / z) * invFov;

                // 0～1に正規化
                // zが1のときの最大値
                float maxValue = (fov / (1.001001001 + 1)) * invFov;
                // 最小値を0に
                float c = y - maxValue;
                // 最大値を1に
                return c / (1 - maxValue);
            }

            sampler2D _MainTex;

            fixed4 frag(v2f IN) : SV_Target
            {
                float4 lt = _LT;
                float4 rt = _RT;
                float4 lb = _LB;
                float4 rb = _RB;

                float2 texcoord = IN.texcoord.xy;
                float y = 1 - texcoord.y;

                texcoord.y = ease( texcoord.y );

                // 左辺の点を求める
                // V[LT-LB]
                float left = (lb.x - lt.x) * y + lt.x;

                // 右辺の点を求める
                // V[RT-RB]
                float right = (rb.x - rt.x) * y + rt.x;

                left = (IN.position.x - left);
                right = (right - IN.position.x);

                float x = left / (left + right);
                texcoord.x = x;

                half4 color = (tex2D(_MainTex, texcoord) + _TextureSampleAdd) * IN.color;

                if (_UseClipRect)
                    color *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                
                if (_UseAlphaClip)
                    clip (color.a - 0.001);
                    
                //float x1 = texcoord.x;
                //color = fixed4( x1, x1, x1, 1 );

                return color;
            }
        ENDCG
        }
    }
}