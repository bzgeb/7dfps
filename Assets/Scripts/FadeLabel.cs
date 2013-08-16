using UnityEngine;
using System.Collections;

public class FadeLabel : MonoBehaviour {
    public float fadeStartTime;
    public float fadeOutTime;
    UILabel label;

    public float Alpha {
        get {
            return label.color.a;
        }

        set {
            Color newColor = label.color;
            newColor.a = value;
            label.color = newColor;
        }
    }
	// Use this for initialization
	void Start () {
        label = GetComponent<UILabel>();
        Invoke( "FadeOut", fadeStartTime );	
	}

    void FadeOut() {
        StartCoroutine( Fade(fadeOutTime) );
    }

    IEnumerator Fade( float fadeTime ) {
        float elapsed = 0;
        float startAlpha = Alpha;
        float endAlpha = 1 - Alpha;

        while ( elapsed < fadeTime ) {
            Alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed);
            elapsed += Time.deltaTime;

            yield return null;
        }

        Alpha = endAlpha;
    }
}
