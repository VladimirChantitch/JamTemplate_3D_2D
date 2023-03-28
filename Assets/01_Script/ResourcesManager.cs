using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is their for you get info about your data
/// ex : scene state, so, ect... 
/// Its a singleton only one can be activated at a time
/// </summary>
public class ResourcesManager : MonoBehaviour
{
    #region singleton
    public static ResourcesManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [Header("State")]
    [SerializeField] GameState state;
    /// <summary>
    /// The actual state of your game
    /// </summary>
    public GameState State { get => state; }

}
