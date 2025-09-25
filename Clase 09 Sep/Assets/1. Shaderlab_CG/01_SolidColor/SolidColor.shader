//01 Añadimos la locación del shader
Shader "Custom/SolidColor"
{
    //02 Añadimos las propiedades
    Properties 
    {
        _Color("Main Color",Color)=(1,1,1,1) //Color en RGBA
    }

    //03 Añadimos el subshader
    SubShader
    {
        //04 Añadimos el pass
        Pass
        {
            
            //05 Codigo CG
            CGPROGRAM
             //Aqui va el codigo CG
            //PRAGMAS concatenizan con la tarjeta grafica
            #pragma vertex vertexShader
            #pragma fragment fragmentShader

            uniform fixed4 _Color;//Conexion con el color para que cambie dinamicamente
           
            //VertexInput
            struct vertexInput
            {
               fixed4 vertex:POSITION;
            };
            //VertexOutput
              struct vertexOutPut
            {
              fixed4 position:SV_POSITION;
              fixed4 color:COLOR;
            };
            //Vertex Shader
            vertexOutPut vertexShader(vertexInput i)
            {
               vertexOutPut o;
               o.position=UnityObjectToClipPos(i.vertex);//Pasamos de local space a projection space
               o.color=_Color;
               return o;
            }
            //Fragment Shader
            fixed4 fragmentShader(vertexOutPut o):SV_TARGET //Se asigna de manera directa el pixel Output con el SV_TARGET
            {
              return o.color;
            }
        

            ENDCG

        }
    }

    //06 Fallback
    Fallback "Mobile/VertexLit"

}
