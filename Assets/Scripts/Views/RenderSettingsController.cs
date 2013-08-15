using UnityEngine;
using System.Collections;

public class RenderSettingsController : MonoBehaviour {
    public Color ambientLight;
    public float flareStrength;
    public bool fog;
    public Color fogColor;
    public float fogDensity;
    public float fogEndDistance;
    public float fogStartDistance;
    public float haloStrength;

    void Awake() {
        ambientLight = RenderSettings.ambientLight; 
        flareStrength = RenderSettings.flareStrength;
        fog = RenderSettings.fog;
        fogColor = RenderSettings.fogColor;
        fogDensity = RenderSettings.fogDensity;
        fogEndDistance = RenderSettings.fogEndDistance;
        fogStartDistance = RenderSettings.fogStartDistance;
        haloStrength = RenderSettings.haloStrength;
    }

	void Update () {
        RenderSettings.ambientLight = ambientLight;
        RenderSettings.flareStrength = flareStrength;
        RenderSettings.fog = fog;
        RenderSettings.fogColor = fogColor;
        RenderSettings.fogDensity = fogDensity;
        RenderSettings.fogEndDistance = fogEndDistance;
        RenderSettings.fogStartDistance = fogStartDistance;
        RenderSettings.haloStrength = haloStrength;
	}
}
