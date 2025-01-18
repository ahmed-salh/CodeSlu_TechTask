using System;
using UnityEngine;

public class GameplayEventsHandler : MonoBehaviour
{
    public static Action<int> onScoreChange;

    public static Action onGameOver;

    public static Action onGameStart;

    public static Action onGamePause;

    public static Action onGameUnPause;

    public static Action onScore;

}
