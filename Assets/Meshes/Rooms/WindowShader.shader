Shader "Unlit/WindowShader"
{
    Properties
    {
        _MainTex ("Space Texture", 2D) = "white" {}
        _Interior("Interior Texture", 2D) = "white" {}
        _Scale("Scale", Float) = 0.5
        _Brightness("Brightness", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            sampler2D _Interior;
            float4 _MainTex_ST;
            float _Scale;
            float _Brightness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }

            struct fragmentOutput {
                float4 color : SV_Target;
                float zvalue : SV_Depth;
            };

            fragmentOutput frag (v2f i)
            {
                fragmentOutput o;
                // sample the texture
                o.color = (tex2D(_MainTex, i.screenPos.xy * _Scale) * 0.5
                + tex2D(_MainTex, lerp(i.screenPos.xy, i.uv, 0.13) * _Scale * 0.6) * 0.8
                + tex2D(_MainTex, lerp(i.screenPos.xy, i.uv, 0.25) * _Scale * 0.3) * 0.95
                + max(1.0 - i.uv.x + i.uv.y, 0.1) * 0.05 * float4(0.650, 0.811, 0.949, 0)) * _Brightness;
                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, o.color);
                return o;
            }
            ENDCG
        }
    }
}
