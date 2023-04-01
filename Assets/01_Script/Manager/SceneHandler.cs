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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace scene
{
    public class SceneHandler : MonoBehaviour
    {
        /// <summary>
        /// If you wish to have some stuff taken care of befor leaving the scene
        /// </summary>
        public UnityEvent onLoadANewScene = new UnityEvent();

        /// <summary>
        /// Load a new scene based on the wanted game scene
        /// </summary>
        /// <param name="gameScene"></param>
        public void LoadScene(GameScene gameScene)
        {
            onLoadANewScene?.Invoke();
            SceneManager.LoadScene(ResourcesManager.Instance.GetScene(gameScene));
        }
    }
}
