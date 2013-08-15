Shader "Custom/Unlit-Color-NoFog" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1) 
    }
    Category {
        Lighting Off
        ZWrite On

        SubShader {
            // Tags { "Queue"="Geometry+1" }
            Tags {"Queue"="Transparent-1" "IgnoreProjector"="False" "RenderType"="Transparent"}
            // LOD 100
            // Blend SrcAlpha OneMinusSrcAlpha
        
            Pass {
                Fog { Mode OFF }
                SetTexture [_] {
                    constantColor [_Color]
                    Combine constant
                }
            }

        }
    }
    FallBack "Diffuse"
}
