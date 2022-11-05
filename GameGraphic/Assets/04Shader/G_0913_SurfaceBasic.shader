Shader "Custom/G_0913_SurfaceBasic"
{
    Properties
    {
        //1.������Ƽ ����
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _Alpha("Alpha", Range(0,1)) = 0.5
    }
    SubShader
    {
        //2.�±׼���
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        LOD 200

        CGPROGRAM
        //3. #pragma ����� �׸��� ����
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
            //4.��������
        sampler2D _MainTex;

        //5.Input����ü ����
        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        half _Alpha;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        //6.�����Լ� �ۼ�
        void surf (Input IN, inout SurfaceOutputStandard o)
        {                           //����°��

            //o.Albedo = float3(0,0,1);
            o.Emission = fixed3(0, 0, 1);
            o.Alpha = _Alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
