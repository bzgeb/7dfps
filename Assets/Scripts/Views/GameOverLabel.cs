using UnityEngine;
using System.Collections;

public class GameOverLabel : MonoBehaviour {
    UILabel label;
    void Start() {
        label = GetComponent<UILabel>();
        label.text = "";
    }

    void OnEnable() {
        EventManager.Register( "OnHunterWins", OnHunterWins );
        EventManager.Register( "OnGathererWins", OnHunterWins );
    }

    void OnDisable() {
        EventManager.Deregister( "OnHunterWins", OnHunterWins );
        EventManager.Deregister( "OnGathererWins", OnHunterWins );
    }

    void OnHunterWins( params object[] args ) {
        label.text = "Game Over\nHunter Wins";
    }

    void OnGathererWins( params object[] args ) {
        label.text = "Game Over\nGatherer Wins";
    }
}
