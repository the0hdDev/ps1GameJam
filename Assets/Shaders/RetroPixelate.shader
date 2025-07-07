Shader "Hidden/RetroPixelate"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _PixelSize("Pixel Size", Float) = 8
    }
    SubShader
    {
        Pass
        {
            ZTest Always Cull Off ZWrite Off
            Fog { Mode Off }

            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _PixelSize;

            fixed4 frag(v2f_img i) : SV_Target
            {
                // UV in größere Blöcke quantisieren
                float2 blockUV = floor(i.uv / (_PixelSize * _MainTex_TexelSize.xy)) * (_PixelSize * _MainTex_TexelSize.xy);
                return tex2D(_MainTex, blockUV);
            }
            ENDCG
        }
    }
}
