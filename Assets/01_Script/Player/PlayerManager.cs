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

using inputs;
using savesystem;
using savesystem.dto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class PlayerManager : MonoBehaviour, ISavable
    {
        [SerializeField] InputManager inputManager;

        [SerializeField] string Name;

        private void Start()
        {
            SubscriteToInputs();
        }

        private void SubscriteToInputs()
        {
            if (inputManager != null)
            {
                inputManager.onInteractPressed += () => OnInteract();
            }
            else
            {
                Debug.Log($"<color=red> NO INPUT MANAGER IN PLAYER MANAGER</color>");
            }
        }

        private void OnInteract()
        {
            Debug.Log("Interact");
        }

        public Dto Save()
        {
            return new PlayerDto() { Name = Name };
        }

        public void Load(Dto dto)
        {
            if (dto is PlayerDto playerDto)
            {
                Name = playerDto.Name;
            }
        }
    }
}

