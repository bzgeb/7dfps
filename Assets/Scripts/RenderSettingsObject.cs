using UnityEngine;
public class RenderSettingsObject : ScriptableObject {
    public Color ambientLight; 
    public float flareStrength; 
    public bool fog;
    public Color fogColor;
    public float fogDensity;
    public float fogEndDistance;
    public FogMode fogMode;   
    public float fogStartDistance;
    public float haloStrength;
    public Material skybox;
}