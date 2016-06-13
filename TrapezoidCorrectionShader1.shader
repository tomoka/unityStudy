Shader "Custom/TrapezoidCorrectionShader1"
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

            sampler2D _MainTex;

            fixed4 frag(v2f IN) : SV_Target
            {
                // ここからUの計算
                float4 lt = _LT;
                float4 rt = _RT;
                float4 lb = _LB;
                float4 rb = _RB;

                float2 texcoord = IN.texcoord.xy;
                float y = 1 - texcoord.y;

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
                // ここまで
                
                half4 color = (tex2D(_MainTex, texcoord) + _TextureSampleAdd) * IN.color;

                if (_UseClipRect)
                    color *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                
                if (_UseAlphaClip)
                    clip (color.a - 0.001);
                    
                return color;
            }
        ENDCG
        }
    }
}