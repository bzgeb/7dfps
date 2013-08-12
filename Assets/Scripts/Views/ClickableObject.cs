using UnityEngine;
using System.Collections;

public class ClickableObject : MonoBehaviour {
    void OnClick( GameObject clicker ) {
        Debug.Log("Clicked");
    }
}
