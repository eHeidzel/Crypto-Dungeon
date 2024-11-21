Shader "Custom/VHSEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ScanLineIntensity ("Scan Line Intensity", Range(0.5, 1)) = 0.5
        _Distortion ("Distortion", Range(0, 0.1)) = 0.004
        _LinesCount ("LinesCount", Range(0, 500)) = 100
        _Slider ("Slider", Range(0, 1)) = 1
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _ScanLineIntensity;
            float _Distortion;
            float _LinesCount;
            float _Slider;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 offset = float2(0, sin(i.uv.y * 100 + _Time.y * 2) * _Distortion);
                fixed4 col = tex2D(_MainTex, i.uv + offset);

                if (floor(i.uv.y * _LinesCount) % 2 == 0)
                    col.rgb *= _ScanLineIntensity;

                col.a *= (1 - _Slider); 

                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
