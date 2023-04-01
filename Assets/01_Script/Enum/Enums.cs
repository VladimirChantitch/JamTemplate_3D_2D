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

/// <summary>
/// One state per scene
/// </summary>
public enum GameScene
{
    None_scene,
    Start_scene,
    Main_scene,
    End_Scene
}

/// <summary>
/// Your scene can take one state at a time 
/// </summary>
public enum GameState
{
    None,
    Playing,
    Loading,
    Win,
    Loose
}
