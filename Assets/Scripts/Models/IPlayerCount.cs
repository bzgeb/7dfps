using UnityEngine;
using System.Collections;

public interface IPlayerCount {
    int Count { get; }
    void Reset();
    void OnPlayerJoined();
    void OnPlayerQuit();
}
