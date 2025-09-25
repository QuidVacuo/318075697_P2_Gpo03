Shader "Custom/TextureUV"
{
    Properties
    {
      _MainTex("Texture",2D)="white"{}
      _Color("Color",Color)=(1,1,1,1)
    }
    
    SubShader
    {
      Tags { "RenderType"="Opaque" 
             "Queue"="Geometry" 
           }
      ZWrite on
      Pass
      {
        CGPROGRAM
        #pragma vertex vertexShader
        #pragma fragment fragmentShader

        #include "UnityCG.cginc"

        uniform sampler2D _MainTex;
        uniform float4 _MainTex_ST;
        uniform float4 _Color;
        
        struct vertexInput
        {
           float4 vertex:POSITION;
           float2 uv:TEXCOORD0;
        };

        struct vertexOutPut
        {
           float4 position:SV_POSITION;
           float2 uv:TEXCOORD0;
        };

        vertexOutPut vertexShader(vertexInput i)
        {
            vertexOutPut o;
            o.position=UnityObjectToClipPos(i.vertex);
            //o.uv=i.uv;
            //o.uv=(i.uv*_MainTex_ST.xy+_MainTex_ST.zw);
            o.uv=TRANSFORM_TEX(i.uv,_MainTex);
            return o;
        }

        fixed4 fragmentShader(vertexOutPut o):SV_TARGET
        {
             fixed4 col=tex2D(_MainTex,o.uv)*_Color;
             return col;
        }


        ENDCG
      }
      
    }

    Fallback ""
}
