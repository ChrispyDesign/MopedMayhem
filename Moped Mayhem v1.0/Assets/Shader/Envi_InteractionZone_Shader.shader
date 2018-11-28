// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|emission-5935-OUT,clip-6442-OUT;n:type:ShaderForge.SFN_Time,id:782,x:31165,y:32551,varname:node_782,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8488,x:31348,y:32675,varname:node_8488,prsc:2|A-782-T,B-261-OUT;n:type:ShaderForge.SFN_Sin,id:6211,x:31510,y:32675,varname:node_6211,prsc:2|IN-8488-OUT;n:type:ShaderForge.SFN_RemapRange,id:4310,x:31675,y:32675,varname:node_4310,prsc:2,frmn:-1,frmx:1,tomn:1,tomx:0|IN-6211-OUT;n:type:ShaderForge.SFN_Multiply,id:2598,x:32116,y:32697,varname:node_2598,prsc:2|A-604-OUT,B-6291-OUT;n:type:ShaderForge.SFN_Multiply,id:604,x:31914,y:32599,varname:node_604,prsc:2|A-6985-RGB,B-6551-OUT;n:type:ShaderForge.SFN_Color,id:6985,x:31673,y:32438,ptovrint:False,ptlb:Emission color,ptin:_Emissioncolor,varname:node_6985,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.4165225,c3:0.9926471,c4:1;n:type:ShaderForge.SFN_Slider,id:6551,x:31527,y:32601,ptovrint:False,ptlb:Emission Amount,ptin:_EmissionAmount,varname:node_6551,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:261,x:31006,y:32693,ptovrint:False,ptlb:Pusle speed,ptin:_Puslespeed,varname:node_261,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_TexCoord,id:135,x:30782,y:32887,varname:node_135,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_UVTile,id:3679,x:31022,y:33032,varname:node_3679,prsc:2|UVIN-135-UVOUT,WDT-4915-OUT,HGT-5900-OUT,TILE-1543-OUT;n:type:ShaderForge.SFN_Vector1,id:4915,x:30783,y:33038,varname:node_4915,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:5900,x:30783,y:33093,varname:node_5900,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:1543,x:30785,y:33155,varname:node_1543,prsc:2|A-4873-T,B-6097-OUT;n:type:ShaderForge.SFN_Time,id:4873,x:30590,y:33116,varname:node_4873,prsc:2;n:type:ShaderForge.SFN_Slider,id:6097,x:30455,y:33261,ptovrint:False,ptlb:Panning speed,ptin:_Panningspeed,varname:node_6097,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.166,max:1;n:type:ShaderForge.SFN_Add,id:1892,x:31239,y:33031,varname:node_1892,prsc:2|A-3679-UVOUT,B-7913-OUT;n:type:ShaderForge.SFN_TexCoord,id:849,x:30442,y:33344,varname:node_849,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Rotator,id:912,x:30634,y:33343,varname:node_912,prsc:2|UVIN-849-UVOUT;n:type:ShaderForge.SFN_Length,id:8528,x:30802,y:33343,varname:node_8528,prsc:2|IN-912-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7913,x:31010,y:33343,varname:node_7913,prsc:2|A-8528-OUT,B-8483-OUT;n:type:ShaderForge.SFN_Slider,id:8483,x:30645,y:33489,ptovrint:False,ptlb:Wave intensity,ptin:_Waveintensity,varname:node_8483,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.07409929,max:1;n:type:ShaderForge.SFN_Tex2dAsset,id:7658,x:31239,y:33185,ptovrint:False,ptlb:Shader_Alpha,ptin:_Shader_Alpha,varname:node_7658,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cb784caff240e9e478c9a02417672126,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8810,x:31499,y:33032,varname:node_8810,prsc:2,tex:cb784caff240e9e478c9a02417672126,ntxv:0,isnm:False|UVIN-1892-OUT,TEX-7658-TEX;n:type:ShaderForge.SFN_Desaturate,id:6442,x:32302,y:33033,varname:node_6442,prsc:2|COL-9331-OUT;n:type:ShaderForge.SFN_Multiply,id:7580,x:31916,y:33033,varname:node_7580,prsc:2|A-8810-RGB,B-9430-OUT;n:type:ShaderForge.SFN_TexCoord,id:927,x:31011,y:33488,varname:node_927,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:3125,x:31009,y:33652,varname:node_3125,prsc:2|A-1186-OUT,B-9278-OUT;n:type:ShaderForge.SFN_Slider,id:9278,x:30595,y:33621,ptovrint:False,ptlb:Bar slider,ptin:_Barslider,varname:node_9278,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6755243,max:1;n:type:ShaderForge.SFN_Vector1,id:1186,x:30794,y:33694,varname:node_1186,prsc:2,v1:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:7122,x:31251,y:33600,varname:node_7122,prsc:2|IN-927-V,IMIN-9278-OUT,IMAX-3125-OUT,OMIN-9454-OUT,OMAX-8144-OUT;n:type:ShaderForge.SFN_Vector1,id:9454,x:31006,y:33810,varname:node_9454,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:8144,x:31010,y:33869,varname:node_8144,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:1523,x:31500,y:33210,varname:node_1523,prsc:2|IN-7122-OUT;n:type:ShaderForge.SFN_OneMinus,id:9430,x:31669,y:33210,varname:node_9430,prsc:2|IN-1523-OUT;n:type:ShaderForge.SFN_OneMinus,id:9331,x:32107,y:33033,varname:node_9331,prsc:2|IN-7580-OUT;n:type:ShaderForge.SFN_Vector1,id:1308,x:30418,y:33497,varname:node_1308,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Clamp,id:6291,x:31914,y:32851,varname:node_6291,prsc:2|IN-4310-OUT,MIN-5376-OUT,MAX-6216-OUT;n:type:ShaderForge.SFN_Slider,id:5376,x:31507,y:32869,ptovrint:False,ptlb:Dark Min,ptin:_DarkMin,varname:node_5376,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9,max:1;n:type:ShaderForge.SFN_Slider,id:6216,x:31509,y:32966,ptovrint:False,ptlb:Light Max,ptin:_LightMax,varname:node_6216,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Lerp,id:5935,x:32290,y:32809,varname:node_5935,prsc:2|A-2598-OUT,B-2598-OUT,T-3013-VFACE;n:type:ShaderForge.SFN_FaceSign,id:3013,x:32088,y:32882,varname:node_3013,prsc:2,fstp:0;proporder:6985-6551-261-6097-8483-7658-9278-5376-6216;pass:END;sub:END;*/

Shader "Shader Forge/Envi_InteractionZone_Shader" {
    Properties {
        _Emissioncolor ("Emission color", Color) = (0,0.4165225,0.9926471,1)
        _EmissionAmount ("Emission Amount", Range(0, 1)) = 1
        _Puslespeed ("Pusle speed", Range(0, 1)) = 0.8
        _Panningspeed ("Panning speed", Range(0, 1)) = 0.166
        _Waveintensity ("Wave intensity", Range(0, 1)) = 0.07409929
        _Shader_Alpha ("Shader_Alpha", 2D) = "bump" {}
        _Barslider ("Bar slider", Range(0, 1)) = 0.6755243
        _DarkMin ("Dark Min", Range(0, 1)) = 0.9
        _LightMax ("Light Max", Range(0, 1)) = 1
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Emissioncolor;
            uniform float _EmissionAmount;
            uniform float _Puslespeed;
            uniform float _Panningspeed;
            uniform float _Waveintensity;
            uniform sampler2D _Shader_Alpha; uniform float4 _Shader_Alpha_ST;
            uniform float _Barslider;
            uniform float _DarkMin;
            uniform float _LightMax;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_4915 = (-1.0);
                float4 node_4873 = _Time + _TimeEditor;
                float node_1543 = (node_4873.g*_Panningspeed);
                float2 node_3679_tc_rcp = float2(1.0,1.0)/float2( node_4915, 1.0 );
                float node_3679_ty = floor(node_1543 * node_3679_tc_rcp.x);
                float node_3679_tx = node_1543 - node_4915 * node_3679_ty;
                float2 node_3679 = (i.uv0 + float2(node_3679_tx, node_3679_ty)) * node_3679_tc_rcp;
                float4 node_4440 = _Time + _TimeEditor;
                float node_912_ang = node_4440.g;
                float node_912_spd = 1.0;
                float node_912_cos = cos(node_912_spd*node_912_ang);
                float node_912_sin = sin(node_912_spd*node_912_ang);
                float2 node_912_piv = float2(0.5,0.5);
                float2 node_912 = (mul(i.uv0-node_912_piv,float2x2( node_912_cos, -node_912_sin, node_912_sin, node_912_cos))+node_912_piv);
                float2 node_1892 = (node_3679+(length(node_912)*_Waveintensity));
                float4 node_8810 = tex2D(_Shader_Alpha,TRANSFORM_TEX(node_1892, _Shader_Alpha));
                float node_9454 = 0.0;
                clip(dot((1.0 - (node_8810.rgb*(1.0 - saturate((node_9454 + ( (i.uv0.g - _Barslider) * (1.0 - node_9454) ) / ((0.0+_Barslider) - _Barslider)))))),float3(0.3,0.59,0.11)) - 0.5);
////// Lighting:
////// Emissive:
                float4 node_782 = _Time + _TimeEditor;
                float3 node_2598 = ((_Emissioncolor.rgb*_EmissionAmount)*clamp((sin((node_782.g*_Puslespeed))*-0.5+0.5),_DarkMin,_LightMax));
                float3 emissive = lerp(node_2598,node_2598,isFrontFace);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
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
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_4915 = (-1.0);
                float4 node_4873 = _Time + _TimeEditor;
                float node_1543 = (node_4873.g*_Panningspeed);
                float2 node_3679_tc_rcp = float2(1.0,1.0)/float2( node_4915, 1.0 );
                float node_3679_ty = floor(node_1543 * node_3679_tc_rcp.x);
                float node_3679_tx = node_1543 - node_4915 * node_3679_ty;
                float2 node_3679 = (i.uv0 + float2(node_3679_tx, node_3679_ty)) * node_3679_tc_rcp;
                float4 node_7335 = _Time + _TimeEditor;
                float node_912_ang = node_7335.g;
                float node_912_spd = 1.0;
                float node_912_cos = cos(node_912_spd*node_912_ang);
                float node_912_sin = sin(node_912_spd*node_912_ang);
                float2 node_912_piv = float2(0.5,0.5);
                float2 node_912 = (mul(i.uv0-node_912_piv,float2x2( node_912_cos, -node_912_sin, node_912_sin, node_912_cos))+node_912_piv);
                float2 node_1892 = (node_3679+(length(node_912)*_Waveintensity));
                float4 node_8810 = tex2D(_Shader_Alpha,TRANSFORM_TEX(node_1892, _Shader_Alpha));
                float node_9454 = 0.0;
                clip(dot((1.0 - (node_8810.rgb*(1.0 - saturate((node_9454 + ( (i.uv0.g - _Barslider) * (1.0 - node_9454) ) / ((0.0+_Barslider) - _Barslider)))))),float3(0.3,0.59,0.11)) - 0.5);
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Emissioncolor;
            uniform float _EmissionAmount;
            uniform float _Puslespeed;
            uniform float _DarkMin;
            uniform float _LightMax;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_782 = _Time + _TimeEditor;
                float3 node_2598 = ((_Emissioncolor.rgb*_EmissionAmount)*clamp((sin((node_782.g*_Puslespeed))*-0.5+0.5),_DarkMin,_LightMax));
                o.Emission = lerp(node_2598,node_2598,isFrontFace);
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
