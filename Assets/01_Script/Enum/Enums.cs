using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// One state per scene
/// </summary>
public enum GameState
{
    None,
    Start,
    Game
}

/// <summary>
/// Your scene can take one state at a time 
/// </summary>
public enum GameSubState
{
    None,
    Playing,
    Loading,
    Win,
    Loose
}
