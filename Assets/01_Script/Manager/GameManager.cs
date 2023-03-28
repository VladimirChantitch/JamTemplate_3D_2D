using sound;
using ui;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game_manager
{
    public class GameManager : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] UI_Manager uiManager = null;
        [SerializeField] SoundManager soundManager = null;
        [SerializeField] PlayerManager playerManager = null;

        GameState gameState;
        GameSubState gameSubState;

        private void Awake()
        {
            if (uiManager == null) uiManager = GetComponentInChildren<UI_Manager>();
            if (soundManager == null) soundManager = GetComponentInChildren<SoundManager>();
            if (playerManager == null) playerManager = FindObjectOfType<PlayerManager>();

            gameState = ResourcesManager.Instance.State;
            gameSubState = ResourcesManager.Instance.SubState;
        }

        private void Start()
        {
            BindUI_Events();
            BindPlayer_Events();
            BindSound_Events();
        }

        private void BindSound_Events()
        {
            throw new NotImplementedException();
        }

        private void BindPlayer_Events()
        {
            throw new NotImplementedException();
        }

        private void BindUI_Events()
        {
            throw new NotImplementedException();
        }
    }
}


