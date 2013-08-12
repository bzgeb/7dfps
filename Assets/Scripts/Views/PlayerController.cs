using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Camera cam;
    public float raycastDistance;
    public LayerMask clickLayerMask;
    public string clickableTag;

    Transform camTransform;

    void Start() {
        camTransform = cam.transform;
    }
	
	// Update is called once per frame
	void Update () {
        if ( Input.GetMouseButtonDown(0) ) {
            Ray inputRay = new Ray( camTransform.position, camTransform.forward );
            RaycastHit hit;

            if ( Physics.Raycast ( inputRay, out hit, raycastDistance, clickLayerMask ) ) {
                if ( hit.collider.CompareTag( clickableTag ) ) {
                    hit.collider.SendMessage( "OnClick", gameObject );
                }
            }
        }	
	}
}
