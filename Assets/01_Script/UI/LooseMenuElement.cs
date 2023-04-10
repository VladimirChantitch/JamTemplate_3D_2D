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

namespace ui.template
{
    public class LooseMenuElement : AbstractTemplateElement
    {
        public new class UxmlFactory : UxmlFactory<LooseMenuElement, LooseMenuElement.UxmlTraits> { }

        public LooseMenuElement() { }

        public event Action onBackToMainMenu;

        Button btn_back_to_main;

        public void Init()
        {
            BindButtons();
        }

        private void BindButtons()
        {
            btn_back_to_main = this.Q<Button>("btn_back_to_main");

            btn_back_to_main.clicked += () => onBackToMainMenu?.Invoke();
        }
    }
}
