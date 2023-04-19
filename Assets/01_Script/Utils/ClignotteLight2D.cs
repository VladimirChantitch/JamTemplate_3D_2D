
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
using UnityEngine.Rendering.Universal;

public class ClignotteLight2D : MonoBehaviour
{
    [SerializeField] Light2D currentLight;
    [SerializeField] float speed;
    bool isDecreasing;
    [SerializeField] float min = 0;
    [SerializeField] float max = 2;

    private void Awake()
    {
        if (currentLight == null)
        {
            currentLight = GetComponent<Light2D>();
        }
    }

    private void Update()
    {
        if (isDecreasing)
        {
            currentLight.intensity -= Time.deltaTime * speed;
            if (currentLight.intensity <= min)
            {
                isDecreasing = false;
            }
        }
        else
        {
            currentLight.intensity += Time.deltaTime * speed;
            if (currentLight.intensity >= max)
            {
                currentLight.intensity = max;
                isDecreasing = true;
            }
        }
    }
}
