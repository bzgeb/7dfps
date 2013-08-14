using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour {
    public Camera cam;
    public Score score; 

    Rect GetScreenRect() {
        Rect r = new Rect();

        r.x = cam.rect.x * Screen.width;
        r.y = cam.rect.y * Screen.height;
        r.width = cam.rect.width * Screen.width;
        r.height = cam.rect.height * Screen.height;

        return r;
    }

    void OnGUI() {
        Rect screenRect = GetScreenRect();

        // display a simple 'Health' HUD
        GUI.Box(new Rect(10, Screen.height - screenRect.y - 30, 100, 22), "Stash: " + (int)score.Stash);
    }
}
