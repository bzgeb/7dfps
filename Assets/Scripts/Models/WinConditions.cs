using UnityEngine;
using System.Collections;

public class WinConditions : MonoBehaviour {
    public Score gathererScore;
    public float gathererLives;
    public float scoreToWin;

    void OnEnable() {
        EventManager.Register( "OnKilled", OnKilled );
        EventManager.Register( "OnStashedObject", OnStashedObject );
    }

    void OnDisable() {
        EventManager.Deregister( "OnKilled", OnKilled );
        EventManager.Deregister( "OnStashedObject", OnStashedObject );
    }

    void OnKilled( params object[] args ) {
        --gathererLives;

        if ( gathererLives < 1 ) {
            EventManager.Push( "OnHunterWins" );
        }
    }

    void OnStashedObject( params object[] args ) {
        float stash = gathererScore.Stash;

        if ( stash >= scoreToWin ) {
            EventManager.Push( "OnGathererWins" ); 
        }
    }
}
