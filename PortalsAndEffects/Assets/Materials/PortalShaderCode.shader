Shader "Custom/PortalShaderCode"
{
    Properties
    {
        _InactiveColour("Inactive Colour", Color) = (1, 1, 1, 1)
    }
        SubShader
    {
        Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        LOD 100
        Lighting Off
        Cull Off
        ZWrite On
        ZTest Less

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _InactiveColour;
            int displayMask; // set to 1 to display texture, otherwise will draw test colour

            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }
            

            fixed4 frag(v2f i) : SV_Target
            {
                /*i.screenPos /= i.screenPos.w;
                fixed4 col = tex2D(_MainTex, float2(i.screenPos.x, i.screenPos.y));

                col *= displayMask + _MainTex * (1 - displayMask);

                return col;*/


                float2 uv = i.screenPos.xy / i.screenPos.w;
                fixed4 portalCol = tex2D(_MainTex, uv);
                return portalCol * displayMask + _InactiveColour * (1 - displayMask);
            }
            ENDCG
        }
    }
        //Fallback "Standard" // for shadows
}
