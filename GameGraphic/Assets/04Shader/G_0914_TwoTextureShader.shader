Shader "Custom/G_0914_TwoTextureShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2 ("Albedo (RGB)", 2D) = "white" {}
        _MainTex3 ("Albedo (RGB)", 2D) = "white" {}
        _Ratio ("ratio", Range(0,1)) = 0
        _Ratio2 ("ratio", Range(0,1)) = 0
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _MainTex2;
        sampler2D _MainTex3;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
            float2 uv_MainTex3;
        };

        half _Glossiness;
        half _Metallic;
        fixed _Ratio;
        fixed _Ratio2;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c2 = tex2D (_MainTex2, IN.uv_MainTex2) * _Color;
            fixed4 c3 = tex2D (_MainTex3, IN.uv_MainTex3) * _Color;
            //두 장의 텍스쳐 섞기
            // + 세 장의 텍스쳐 섞기 : 이 경우 앞의 연산결과를 다시 이용 
            //텍스쳐를 섞는 것은 곱연산
            //섞는 비율은 선형 보간으로 결정
            o.Albedo = lerp(c.rgb, c2.rgb,_Ratio);
            o.Albedo = lerp(o.Albedo, c3.rgb, _Ratio2);
            //위의 보간함수는 다음과 같음 o.Albedo = (1.0f - _Ratio) * c.rgb + _Ratio * c2.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
