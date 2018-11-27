// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:6,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:4,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-2185-OUT,olcol-410-RGB;n:type:ShaderForge.SFN_Color,id:7241,x:32051,y:32697,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Fresnel,id:7988,x:31925,y:32886,varname:node_7988,prsc:2|NRM-2242-OUT,EXP-4425-OUT;n:type:ShaderForge.SFN_Add,id:2185,x:32428,y:32830,varname:node_2185,prsc:2|A-7241-RGB,B-1549-OUT;n:type:ShaderForge.SFN_NormalVector,id:2242,x:31668,y:32832,prsc:2,pt:False;n:type:ShaderForge.SFN_ValueProperty,id:4425,x:31755,y:33045,ptovrint:False,ptlb:node_4425,ptin:_node_4425,varname:node_4425,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ConstantClamp,id:4270,x:32100,y:32918,varname:node_4270,prsc:2,min:0,max:0.5|IN-7988-OUT;n:type:ShaderForge.SFN_Clamp01,id:1549,x:32276,y:32986,varname:node_1549,prsc:2|IN-4270-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1385,x:32428,y:33038,ptovrint:False,ptlb:node_1385,ptin:_node_1385,varname:node_1385,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Color,id:410,x:32261,y:33164,ptovrint:False,ptlb:node_410,ptin:_node_410,varname:node_410,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:7241-4425-1385-410;pass:END;sub:END;*/

Shader "Shader Forge/OutlineShader" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _node_4425 ("node_4425", Float ) = 1
        _node_1385 ("node_1385", Float ) = 0.1
        _node_410 ("node_410", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float _node_4425;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float node_7988 = pow(1.0-max(0,dot(i.normalDir, viewDirection)),_node_4425);
                float3 emissive = (_Color.rgb+saturate(clamp(node_7988,0,0.5)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
