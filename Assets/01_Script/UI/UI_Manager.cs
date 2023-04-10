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
using ui.template;
using UnityEngine;
using UnityEngine.UIElements;

namespace ui
{
    [RequireComponent(typeof(UIDocument))]
    public class UI_Manager : MonoBehaviour
    {
        [SerializeField] UIDocument ui_Doc = null;
        VisualElement currentRoot = null;
        AbstractTemplateElement currentTemplate = null;

        public event Action<GameScene> onStartGame;
        public event Action<GameScene> onBackToMain;

        public void Awake()
        {
            if (ui_Doc == null) GetComponent<UIDocument>();
        }

        public void ChangeUITemplate()
        {
            VisualTreeAsset visualTreeAsset = ResourcesManager.Instance.GetTemplate();
            if (visualTreeAsset != null)
            {
                ui_Doc.visualTreeAsset = visualTreeAsset;
                currentRoot = ui_Doc.rootVisualElement;
                RebindUI(ResourcesManager.Instance.GameState);
            }
        }

        private void RebindUI(GameState gameState)
        {
            currentTemplate = currentRoot.Q<AbstractTemplateElement>();
            if (currentTemplate != null)
            {
                switch (currentTemplate)
                {
                    case StartMenuElement startMenuElement:
                        InitStartMenu(startMenuElement);
                        break;
                    case WinMenuElement winMenuElement:
                        InitWinMenu(winMenuElement);
                        break;
                    case LooseMenuElement looseMenuElement:
                        InitLooseMenu(looseMenuElement);
                        break;
                }
            }
            else
            {
                Debug.Log($"<color=red> YOU GOT NO aBSTRACT TEMPLATE ELEMENT </color>" +
                    $"<color=green> please make one</color>");
            }
        }

        private void InitLooseMenu(LooseMenuElement looseMenuElement)
        {
            looseMenuElement.Init();
            looseMenuElement.onBackToMainMenu += () => onBackToMain?.Invoke(GameScene.Start_scene);
        }

        private void InitWinMenu(WinMenuElement winMenuElement)
        {
            winMenuElement.Init();
            winMenuElement.onBackToMainMenu += () => onBackToMain?.Invoke(GameScene.Start_scene);
        }

        private void InitStartMenu(StartMenuElement startMenuElement)
        {
            startMenuElement.Init();
            startMenuElement.onStartButton += () => onStartGame?.Invoke(GameScene.Main_scene);
        }
    }
}

