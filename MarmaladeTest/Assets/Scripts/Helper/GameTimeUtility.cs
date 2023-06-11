using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTimeUtility
{
    public static bool _isPaused = false;
    public static float _deltaTime { get { return _isPaused ? 0 : Time.deltaTime; } }
}
