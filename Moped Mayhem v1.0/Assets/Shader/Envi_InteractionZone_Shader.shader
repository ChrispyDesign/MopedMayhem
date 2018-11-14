// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-6665-RGB,spec-358-OUT,gloss-6945-OUT,emission-3435-OUT,clip-9331-OUT;n:type:ShaderForge.SFN_Color,id:6665,x:32387,y:32171,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.4206893,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:358,x:31834,y:32196,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:31623,y:32308,ptovrint:False,ptlb:Roughness,ptin:_Roughness,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Time,id:782,x:31143,y:32689,varname:node_782,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8488,x:31349,y:32837,varname:node_8488,prsc:2|A-782-T,B-261-OUT;n:type:ShaderForge.SFN_Sin,id:6211,x:31550,y:32838,varname:node_6211,prsc:2|IN-8488-OUT;n:type:ShaderForge.SFN_RemapRange,id:4310,x:31753,y:32835,varname:node_4310,prsc:2,frmn:-1,frmx:1,tomn:1,tomx:0|IN-6211-OUT;n:type:ShaderForge.SFN_Fresnel,id:1248,x:31926,y:32838,varname:node_1248,prsc:2|EXP-4310-OUT;n:type:ShaderForge.SFN_Multiply,id:2598,x:32139,y:32724,varname:node_2598,prsc:2|A-604-OUT,B-1248-OUT;n:type:ShaderForge.SFN_Multiply,id:604,x:31933,y:32683,varname:node_604,prsc:2|A-6985-RGB,B-6551-OUT;n:type:ShaderForge.SFN_Color,id:6985,x:31681,y:32523,ptovrint:False,ptlb:Emission color,ptin:_Emissioncolor,varname:node_6985,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.4165225,c3:0.9926471,c4:1;n:type:ShaderForge.SFN_Slider,id:6551,x:31498,y:32720,ptovrint:False,ptlb:Emission Amount,ptin:_EmissionAmount,varname:node_6551,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.162389,max:1;n:type:ShaderForge.SFN_Slider,id:261,x:31007,y:32848,ptovrint:False,ptlb:Pusle speed,ptin:_Puslespeed,varname:node_261,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_OneMinus,id:6945,x:31944,y:32308,varname:node_6945,prsc:2|IN-1813-OUT;n:type:ShaderForge.SFN_TexCoord,id:135,x:30764,y:32884,varname:node_135,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_UVTile,id:3679,x:31004,y:33029,varname:node_3679,prsc:2|UVIN-135-UVOUT,WDT-4915-OUT,HGT-5900-OUT,TILE-1543-OUT;n:type:ShaderForge.SFN_Vector1,id:4915,x:30765,y:33035,varname:node_4915,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:5900,x:30765,y:33090,varname:node_5900,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:1543,x:30767,y:33152,varname:node_1543,prsc:2|A-4873-T,B-6097-OUT;n:type:ShaderForge.SFN_Time,id:4873,x:30572,y:33113,varname:node_4873,prsc:2;n:type:ShaderForge.SFN_Slider,id:6097,x:30437,y:33258,ptovrint:False,ptlb:Panning speed,ptin:_Panningspeed,varname:node_6097,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.166,max:1;n:type:ShaderForge.SFN_Add,id:1892,x:31221,y:33028,varname:node_1892,prsc:2|A-3679-UVOUT,B-7913-OUT;n:type:ShaderForge.SFN_TexCoord,id:849,x:30425,y:33335,varname:node_849,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Rotator,id:912,x:30616,y:33340,varname:node_912,prsc:2|UVIN-849-UVOUT;n:type:ShaderForge.SFN_Length,id:8528,x:30784,y:33340,varname:node_8528,prsc:2|IN-912-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7913,x:30992,y:33340,varname:node_7913,prsc:2|A-8528-OUT,B-8483-OUT;n:type:ShaderForge.SFN_Slider,id:8483,x:30627,y:33486,ptovrint:False,ptlb:Wave intensity,ptin:_Waveintensity,varname:node_8483,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.07409929,max:1;n:type:ShaderForge.SFN_Tex2dAsset,id:7658,x:31216,y:33186,ptovrint:False,ptlb:Shader_Alpha,ptin:_Shader_Alpha,varname:node_7658,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2794ef8036ab3ed4fb3fac5ca36eab9a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8810,x:31508,y:33037,varname:node_8810,prsc:2,tex:2794ef8036ab3ed4fb3fac5ca36eab9a,ntxv:0,isnm:False|UVIN-1892-OUT,TEX-7658-TEX;n:type:ShaderForge.SFN_Desaturate,id:6442,x:31688,y:33039,varname:node_6442,prsc:2|COL-8810-RGB;n:type:ShaderForge.SFN_Multiply,id:7580,x:31925,y:33038,varname:node_7580,prsc:2|A-6442-OUT,B-9430-OUT;n:type:ShaderForge.SFN_TexCoord,id:927,x:30580,y:33565,varname:node_927,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:3125,x:30771,y:33751,varname:node_3125,prsc:2|A-1186-OUT,B-9278-OUT;n:type:ShaderForge.SFN_Slider,id:9278,x:30357,y:33720,ptovrint:False,ptlb:Bar slider,ptin:_Barslider,varname:node_9278,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1280734,max:1;n:type:ShaderForge.SFN_Vector1,id:1186,x:30556,y:33793,varname:node_1186,prsc:2,v1:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:7122,x:31013,y:33699,varname:node_7122,prsc:2|IN-927-V,IMIN-9278-OUT,IMAX-3125-OUT,OMIN-9454-OUT,OMAX-8144-OUT;n:type:ShaderForge.SFN_Vector1,id:9454,x:30768,y:33909,varname:node_9454,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:8144,x:30772,y:33968,varname:node_8144,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:1523,x:31216,y:33453,varname:node_1523,prsc:2|IN-7122-OUT;n:type:ShaderForge.SFN_OneMinus,id:9430,x:31497,y:33328,varname:node_9430,prsc:2|IN-1523-OUT;n:type:ShaderForge.SFN_OneMinus,id:9331,x:32116,y:33038,varname:node_9331,prsc:2|IN-7580-OUT;n:type:ShaderForge.SFN_Add,id:3435,x:32378,y:32761,varname:node_3435,prsc:2|A-5493-OUT,B-2598-OUT,C-6341-VFACE;n:type:ShaderForge.SFN_Slider,id:3540,x:31837,y:32560,ptovrint:False,ptlb:node_3540,ptin:_node_3540,varname:node_3540,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3786073,max:1;n:type:ShaderForge.SFN_Multiply,id:5493,x:32245,y:32595,varname:node_5493,prsc:2|A-6665-RGB,B-3540-OUT;n:type:ShaderForge.SFN_FaceSign,id:6341,x:32237,y:32926,varname:node_6341,prsc:2,fstp:0;proporder:6665-358-1813-6985-6551-261-6097-8483-7658-9278-3540;pass:END;sub:END;*/

Shader "Shader Forge/Envi_InteractionZone_Shader" {
    Properties {
        _Color ("Color", Color) = (0,0.4206893,1,1)
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Roughness ("Roughness", Range(0, 1)) = 0.8
        _Emissioncolor ("Emission color", Color) = (0,0.4165225,0.9926471,1)
        _EmissionAmount ("Emission Amount", Range(0, 1)) = 0.162389
        _Puslespeed ("Pusle speed", Range(0, 1)) = 1
        _Panningspeed ("Panning speed", Range(0, 1)) = 0.166
        _Waveintensity ("Wave intensity", Range(0, 1)) = 0.07409929
        _Shader_Alpha ("Shader_Alpha", 2D) = "white" {}
        _Barslider ("Bar slider", Range(0, 1)) = 0.1280734
        _node_3540 ("node_3540", Range(0, 1)) = 0.3786073
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _Metallic;
            uniform float _Roughness;
            uniform float4 _Emissioncolor;
            uniform float _EmissionAmount;
            uniform float _Puslespeed;
            uniform float _Panningspeed;
            uniform float _Waveintensity;
            uniform sampler2D _Shader_Alpha; uniform float4 _Shader_Alpha_ST;
            uniform float _Barslider;
            uniform float _node_3540;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float node_4915 = (-1.0);
                float4 node_4873 = _Time + _TimeEditor;
                float node_1543 = (node_4873.g*_Panningspeed);
                float2 node_3679_tc_rcp = float2(1.0,1.0)/float2( node_4915, 1.0 );
                float node_3679_ty = floor(node_1543 * node_3679_tc_rcp.x);
                float node_3679_tx = node_1543 - node_4915 * node_3679_ty;
                float2 node_3679 = (i.uv0 + float2(node_3679_tx, node_3679_ty)) * node_3679_tc_rcp;
                float4 node_3163 = _Time + _TimeEditor;
                float node_912_ang = node_3163.g;
                float node_912_spd = 1.0;
                float node_912_cos = cos(node_912_spd*node_912_ang);
                float node_912_sin = sin(node_912_spd*node_912_ang);
                float2 node_912_piv = float2(0.5,0.5);
                float2 node_912 = (mul(i.uv0-node_912_piv,float2x2( node_912_cos, -node_912_sin, node_912_sin, node_912_cos))+node_912_piv);
                float2 node_1892 = (node_3679+(length(node_912)*_Waveintensity));
                float4 node_8810 = tex2D(_Shader_Alpha,TRANSFORM_TEX(node_1892, _Shader_Alpha));
                float node_9454 = 0.0;
                clip((1.0 - (dot(node_8810.rgb,float3(0.3,0.59,0.11))*(1.0 - saturate((node_9454 + ( (i.uv0.g - _Barslider) * (1.0 - node_9454) ) / ((0.0+_Barslider) - _Barslider)))))) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = (1.0 - _Roughness);
                float perceptualRoughness = 1.0 - (1.0 - _Roughness);
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float3 diffuseColor = _Color.rgb; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_782 = _Time + _TimeEditor;
                float3 emissive = ((_Color.rgb*_node_3540)+((_Emissioncolor.rgb*_EmissionAmount)*pow(1.0-max(0,dot(normalDirection, viewDirection)),(sin((node_782.g*_Puslespeed))*-0.5+0.5)))+isFrontFace);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _Metallic;
            uniform float _Roughness;
            uniform float4 _Emissioncolor;
            uniform float _EmissionAmount;
            uniform float _Puslespeed;
            uniform float _Panningspeed;
            uniform float _Waveintensity;
            uniform sampler2D _Shader_Alpha; uniform float4 _Shader_Alpha_ST;
            uniform float _Barslider;
            uniform float _node_3540;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_4915 = (-1.0);
                float4 node_4873 = _Time + _TimeEditor;
                float node_1543 = (node_4873.g*_Panningspeed);
                float2 node_3679_tc_rcp = float2(1.0,1.0)/float2( node_4915, 1.0 );
                float node_3679_ty = floor(node_1543 * node_3679_tc_rcp.x);
                float node_3679_tx = node_1543 - node_4915 * node_3679_ty;
                float2 node_3679 = (i.uv0 + float2(node_3679_tx, node_3679_ty)) * node_3679_tc_rcp;
                float4 node_9664 = _Time + _TimeEditor;
                float node_912_ang = node_9664.g;
                float node_912_spd = 1.0;
                float node_912_cos = cos(node_912_spd*node_912_ang);
                float node_912_sin = sin(node_912_spd*node_912_ang);
                float2 node_912_piv = float2(0.5,0.5);
                float2 node_912 = (mul(i.uv0-node_912_piv,float2x2( node_912_cos, -node_912_sin, node_912_sin, node_912_cos))+node_912_piv);
                float2 node_1892 = (node_3679+(length(node_912)*_Waveintensity));
                float4 node_8810 = tex2D(_Shader_Alpha,TRANSFORM_TEX(node_1892, _Shader_Alpha));
                float node_9454 = 0.0;
                clip((1.0 - (dot(node_8810.rgb,float3(0.3,0.59,0.11))*(1.0 - saturate((node_9454 + ( (i.uv0.g - _Barslider) * (1.0 - node_9454) ) / ((0.0+_Barslider) - _Barslider)))))) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = (1.0 - _Roughness);
                float perceptualRoughness = 1.0 - (1.0 - _Roughness);
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float3 diffuseColor = _Color.rgb; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Panningspeed;
            uniform float _Waveintensity;
            uniform sampler2D _Shader_Alpha; uniform float4 _Shader_Alpha_ST;
            uniform float _Barslider;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_4915 = (-1.0);
                float4 node_4873 = _Time + _TimeEditor;
                float node_1543 = (node_4873.g*_Panningspeed);
                float2 node_3679_tc_rcp = float2(1.0,1.0)/float2( node_4915, 1.0 );
                float node_3679_ty = floor(node_1543 * node_3679_tc_rcp.x);
                float node_3679_tx = node_1543 - node_4915 * node_3679_ty;
                float2 node_3679 = (i.uv0 + float2(node_3679_tx, node_3679_ty)) * node_3679_tc_rcp;
                float4 node_7574 = _Time + _TimeEditor;
                float node_912_ang = node_7574.g;
                float node_912_spd = 1.0;
                float node_912_cos = cos(node_912_spd*node_912_ang);
                float node_912_sin = sin(node_912_spd*node_912_ang);
                float2 node_912_piv = float2(0.5,0.5);
                float2 node_912 = (mul(i.uv0-node_912_piv,float2x2( node_912_cos, -node_912_sin, node_912_sin, node_912_cos))+node_912_piv);
                float2 node_1892 = (node_3679+(length(node_912)*_Waveintensity));
                float4 node_8810 = tex2D(_Shader_Alpha,TRANSFORM_TEX(node_1892, _Shader_Alpha));
                float node_9454 = 0.0;
                clip((1.0 - (dot(node_8810.rgb,float3(0.3,0.59,0.11))*(1.0 - saturate((node_9454 + ( (i.uv0.g - _Barslider) * (1.0 - node_9454) ) / ((0.0+_Barslider) - _Barslider)))))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _Metallic;
            uniform float _Roughness;
            uniform float4 _Emissioncolor;
            uniform float _EmissionAmount;
            uniform float _Puslespeed;
            uniform float _node_3540;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_782 = _Time + _TimeEditor;
                o.Emission = ((_Color.rgb*_node_3540)+((_Emissioncolor.rgb*_EmissionAmount)*pow(1.0-max(0,dot(normalDirection, viewDirection)),(sin((node_782.g*_Puslespeed))*-0.5+0.5)))+isFrontFace);
                
                float3 diffColor = _Color.rgb;
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - (1.0 - _Roughness);
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
