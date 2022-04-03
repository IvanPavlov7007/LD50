Shader "Custom/RoomSurfaceShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _FogColor("Fog Color", Color) = (0.3, 0.4, 0.7, 1.0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        Cull Off

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows finalcolor:mycolor vertex:myvert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            fixed facing : VFACE;
            half fog;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)
        
        void myvert(inout appdata_full v, out Input data)
        {
            UNITY_INITIALIZE_OUTPUT(Input, data);
            float4 hpos = UnityObjectToClipPos(v.vertex);
            hpos.xy /= hpos.w;
            data.fog = min(1, dot(hpos.xy, hpos.xy) * 0.5);
        }

        fixed4 _FogColor;
        void mycolor(Input IN, SurfaceOutputStandard o, inout fixed4 color)
        {
            if (IN.facing < .5) {
                color *= 0;
            }
            color.rgb = lerp(color.rgb, _FogColor.rgb, IN.fog);
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Smoothness = dot(o.Normal, float3(0, 1, 0));
            o.Alpha = c.a;
            if (IN.facing < .5) {
                o.Albedo = 0;
                o.Metallic = 0;
                o.Smoothness = 0;
                o.Alpha = 0;
            }
        }
        ENDCG
    }
    FallBack "Diffuse"
}
