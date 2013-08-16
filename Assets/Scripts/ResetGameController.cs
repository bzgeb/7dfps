using UnityEngine;
using System.Collections;

public class ResetGameController : MonoBehaviour {
    public float resetTime;

    void OnEnable() {
        EventManager.Register( "OnHunterWins", OnHunterWins );
        EventManager.Register( "OnGathererWins", OnGathererWins );
    }

    void OnDisable() {
        EventManager.Deregister( "OnHunterWins", OnHunterWins );
        EventManager.Deregister( "OnGathererWins", OnGathererWins );
    }

    void OnHunterWins( params object[] args ) {
        StartCoroutine( OnGameOver() );
    }

    void OnGathererWins( params object[] args ) {
        StartCoroutine( OnGameOver() );
    }

    IEnumerator OnGameOver() {
        float elapsed = 0;

        while ( elapsed < resetTime ) {
           elapsed += Time.deltaTime; 
           yield return null;
        }

        Application.LoadLevel( 0 );
    } 
}
