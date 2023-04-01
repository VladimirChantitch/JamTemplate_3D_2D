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

        public void Awake()
        {
            if (ui_Doc == null) GetComponent<UIDocument>();
        }

        public void ChangeUITemplate()
        {
            ui_Doc.visualTreeAsset = ResourcesManager.Instance.GetTemplate();
            currentRoot = ui_Doc.rootVisualElement;
            RebindUI(ResourcesManager.Instance.GameState);
        }

        private void RebindUI(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.None:
                    break;
                case GameState.Playing:
                    break;
                case GameState.Loading:
                    break;
                case GameState.Win:
                    break;
                case GameState.Loose:
                    break;
            }
        }
    }
}

