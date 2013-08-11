using UnityEngine;
using System.Collections;

public class PlayerCount : MonoBehaviour, IPlayerCount {
    private int count;
    public int Count {
        get {
            return count;
        }
        private set {
            count = Mathf.Max( 0, value );
        }
    }

    void OnEnable() {
        EventManager.Register( "RequestPlayerCount", RequestPlayerCount );
    }

    void OnDisable() {
        EventManager.Deregister( "RequestPlayerCount", RequestPlayerCount );
    }

    void RequestPlayerCount( params object[] args ) {
        EventManager.Push( "DispatchPlayerCount", Count );
    }

    public void OnPlayerJoined() {
        Count = Count + 1;
    }

    public void OnPlayerQuit() {
        Count = Count - 1;
    }

    public void Reset() {
        Count = 0;
    }
}
