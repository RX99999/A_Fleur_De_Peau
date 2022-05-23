
float4 text_out;


void Grayscale_float(float3 input, out float output)
{
    float r = input[0];
    float g = input[1];
    float b = input[2];
    output = (r + g + b) * 0.33;

}



void Unity_Multiply_float4_float4(float4 A, float4 B, out float4 Out)
{
Out = A * B;
}

void Unity_ColorMask_float(float3 In, float3 MaskColor, float Range, float Fuzziness, out float4 Out)
{
    float Distance = abs(distance(MaskColor, In));
    Out = saturate(1 - abs((Distance - Range)) / max(Fuzziness, 1e-5));
}

void Unity_ColorMask_float4(float4 In, float4 MaskColor, float Range, float Fuzziness, out float4 Out)
{
    float Distance = abs(distance(MaskColor, In));
    Out = saturate(1 - abs((Distance - Range)) / max(Fuzziness, 1e-5));
}

void Unity_Lerp_float4(float4 A, float4 B, float4 T, out float4 Out)
{
    Out = lerp(A, B, T);
}

void Unity_Add_float4(float4 A, float4 B, out float4 Out)
{
    Out = A + B;
}

void Unity_ColorspaceConversion_RGBverslineaire(float4 pine, out float4 nout)
{
    float4 linearRGBLo = pine / 12.92;;
    float4 linearRGBHi = pow(max(abs((pine + 0.055) / 1.055), 1.192092896e-07), float4(2.4, 2.4, 2.4,2.4));
    nout = float4(pine <= 0.04045) ? linearRGBLo : linearRGBHi;
}

void Unity_ColorspaceConversion_line_RGB(float4 In, out float4 Out)
{
    float4 sRGBLo = In * 12.92;
    float4 sRGBHi = (pow(max(abs(In), 1.192092896e-07), float4(1.0 / 2.4, 1.0 / 2.4, 1.0 / 2.4,1.0/2.4)) * 1.055) - 0.055;
    Out = float4(In <= 0.0031308) ? sRGBLo : sRGBHi;
}

void Unity_ColorspaceConversion_HSV_RGB_float(float4 In, out float3 Out)
{
    float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    float3 P = abs(frac(In.xxx + K.xyz) * 6.0 - K.www);
    Out = In.z * lerp(K.xxx, saturate(P - K.xxx), In.y);
}

void Unity_ColorspaceConversion_RGB_LINE(float3 In, out float3 Out)
{
    float3 linearRGBLo = In / 12.92;;
    float3 linearRGBHi = pow(max(abs((In + 0.055) / 1.055), 1.192092896e-07), float3(2.4, 2.4, 2.4));
    Out = float3(In <= 0.04045) ? linearRGBLo : linearRGBHi;
}

void Unity_ColorspaceConversion_RGB_HSV(float4 In, out float4 Out)
{
    float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
    float4 P = lerp(float4(In.bg, K.wz), float4(In.gb, K.xy), step(In.b, In.g));
    float4 Q = lerp(float4(P.xyw, In.r), float4(In.r, P.yzx), step(P.x, In.r));
    float D = Q.x - min(Q.w, Q.y);
    float  E = 1e-10;
    Out = float4(abs(Q.z + (Q.w - Q.y)/(6.0 * D + E)), D / (Q.x + E), Q.x,1);
}

void ourFct_float(float4 text_entree, float4 alphamask,UnityTexture2D Colors,UnityTexture2D GreyVals, out float4 Out){



//Loading the wholes input values to know where there's some changes to apply 
    int i;
    float4 colors[256];    

//For now, we can call the variations by their proper place in the array
    for(i = 0; i<256;i++){
        colors[i] =Colors.Load(int3(i,0,0));
    }

    

//###########################CST TO TUNE
//Used in the colorMask function -> Fuzziness allow us to prevent color border effect
//Range tuning allow to define the range arround the specific grey value that is allowed to work 
    float range =0.001;
    float fuzziness =0.05;


/////////////////////////////////////
    float4 text_entree_hsv;
    float4 mask;
    float4 colorchanged;
    float4 total;
    float4 lerped;
    float4 colorsact;
    float4 lerp = float4(0,0,0,0);
    float4 col;
    for(i=0;i<255;i++){

        if(i == 0){
            float4 greycol = GreyVals.Load(int3(i,0,0));
            col = colors[i];
           Unity_ColorspaceConversion_RGB_HSV(col,colorsact);  
            Unity_ColorspaceConversion_RGB_HSV(text_entree,text_entree_hsv);
            //Creation du mask
  
            
            Unity_ColorMask_float4(alphamask, greycol, range,fuzziness,mask);

            Unity_Multiply_float4_float4(text_entree,float4(col)*100, colorchanged);
            //Unity_Add_float4(text_entree_hsv,colorsact,colorchanged); 
            Unity_Lerp_float4(lerp,colorchanged,mask,lerped);
            Unity_Add_float4(text_entree,lerped,total); 
        }
        else{ 
            float4 greycol = GreyVals.Load(int3(i,0,0));
            col = colors[i];
           // Unity_ColorspaceConversion_RGB_HSV(col,colorsact);  
            //Unity_ColorspaceConversion_RGB_HSV(text_entree,text_entree_hsv);
            //Creation du mask
            
            Unity_ColorMask_float4(alphamask, greycol, range,fuzziness,mask);

            Unity_Multiply_float4_float4(text_entree,float4(col)*100, colorchanged);
            //Unity_Add_float4(text_entree_hsv,colorsact,colorchanged); 
            Unity_Lerp_float4(lerp,colorchanged,mask,lerped);
            Unity_Add_float4(total,lerped,total); 
        }
    }

 


    
    Out =total;
    

 
}

// #endif // GRAYSCALE_INCLUDED