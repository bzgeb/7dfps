using UnityEngine;

public class ScoreController : MonoBehaviour {
    public Score score;
    void OnEnable() {
        EventManager.Register( "OnStashedObject", OnStashedObject );
    } 

    void OnDisable() {
        EventManager.Deregister( "OnStashedObject", OnStashedObject );
    }

    void OnStashedObject( params object[] args ) {
        score.Stash = score.Stash + 1;
    }
}