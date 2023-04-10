/*   
    GameJam template for unity project
    Copyright (C) 2023  VladimirChantitch-MarmotteQuantique

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// This class is there for you get info about your data
/// ex : scene state, so, ect... 
/// Its a singleton only one can be activated at a time
/// Its a don't destroy on load aswell
/// </summary>
public class ResourcesManager : MonoBehaviour
{
    #region singleton
    public static ResourcesManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            Instance = this;
        }
        else
        {
            Instance = this; 
        }
    }
    #endregion

    #region State
    [Header("State")]
    [SerializeField] GameScene sceneState;
    [SerializeField] GameState gameState;

    /// <summary>
    /// The actual state of your game
    /// </summary>
    public GameScene SceneState { get => sceneState; }

    /// <summary>
    /// The actual sub state of your game
    /// </summary>
    public GameState GameState { get => gameState; }

    public void ChangeSubState(GameState subState)
    {
        this.gameState = subState;
    }
    #endregion

    #region Scene
    [Header("Scenes")]
    [SerializeField] scene_binding[] scenes;

    /// <summary>
    /// To get the scene corresponding to your scene enum
    /// </summary>
    /// <returns>returns null if no scene can be found</returns>
    public string GetScene(GameScene gameScene)
    {
        if (scenes != null)
        {
            for(int i = 0; i< scenes.Length; i++)
            {
                if (scenes[i].GameScene == gameScene)
                {
                    return scenes[i].SCENE_NAME;
                }
                else
                {
                    Debug.Log($"<color=red> THE SCENE YOU ARE TYING TO LOAD DOSEN4T EXIST </color>");
                }
            }
        }
        return null;
    }

    [Serializable]
    public class scene_binding
    {
        [SerializeField] GameScene scene;
        [SerializeField] string scene_name;

        public GameScene GameScene { get => scene;  }
        public string SCENE_NAME { get => scene_name;  }
    }
    #endregion

    #region UI
    [Header("UI_templates")]
    [SerializeField] template_binding[] templates;

    /// <summary>
    /// To get the Region corresponding to your scene enum
    /// </summary>
    /// <returns>  returns null if no template can be found</returns>
    public VisualTreeAsset GetTemplate(GameState gameState)
    {
        if (templates != null)
        {
            for(int i = 0; i< templates.Length; i++)
            {
                if (templates[i].State == gameState)
                {
                    return templates[i].Template;
                }
            }
        }
        else
        {
            Debug.Log($"<color=red> THE TEMPLATE YOU ARE TYING TO LOAD DOSEN4T EXIST </color>");
        }
        return null;
    }

    /// <summary>
    /// To get the Region corresponding to your Game State
    /// </summary>
    /// <returns>  returns null if no template can be found</returns>
    public VisualTreeAsset GetTemplate()
    {
        if (templates != null)
        {
            for (int i = 0; i < templates.Length; i++)
            {
                if (templates[i].State == gameState)
                {
                    return templates[i].Template;
                }
            }
        }
        else
        {
            Debug.Log($"<color=red> THE TEMPLATE YOU ARE TYING TO LOAD DOSEN4T EXIST </color>");
        }
        return null;
    }

    [Serializable]
    public class template_binding
    {
        [SerializeField] GameState gameState;
        [SerializeField] VisualTreeAsset template;

        public GameState State { get => gameState;  }
        public VisualTreeAsset Template { get => template; }
    }
    #endregion
}
