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

namespace inputs
{
    public class InputManager : MonoBehaviour
    {
        Inputs inputs = null;

        /// <summary>
        /// An event triggered when the interact input is pressed
        /// NB : You can also use a unity event if you want to 
        ///     add subscribers directly in the scene, but keep in
        ///     mind that unity event are 100 times slower.
        /// </summary>
        public event Action onInteractPressed;

        private void Awake()
        {
            inputs = new Inputs();
        }

        private void OnEnable()
        {
            inputs.Enable();

            BindInputs();
        }

        private void BindInputs()
        {
            inputs.Interaction.Interact.performed += i => onInteractPressed?.Invoke();
        }

        private void OnDisable()
        {
            inputs?.Disable();
        }
    }
}

