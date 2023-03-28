using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    #region singleton
    public static ResourcesManager Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] GameState state;
    public GameState State { get => state; }

}
