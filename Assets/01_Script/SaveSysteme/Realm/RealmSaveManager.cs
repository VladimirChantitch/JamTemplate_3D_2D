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


using Realms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace savesystem
{
    /// <summary>
    /// Realm db getter
    /// </summary>
    public class RealmSaveManager : MonoBehaviour
    {
        Realm realm;

        private void OnEnable()
        {
            var config = new RealmConfiguration
            {
                ShouldDeleteIfMigrationNeeded = true,
            };
            realm = Realm.GetInstance(config);
            //You can alwaysadd your crud instanciation here
        }

        private void OnDisable()
        {
            realm.Dispose();
        }



#if UNITY_EDITOR
        [SerializeField] bool deleteDB;
        private void Update()
        {
            if (deleteDB)
            {
                deleteDB = false;
                removeAllInDb();
            }
        }

        void removeAllInDb()
        {
            realm.Write(() =>
            {
                realm.RemoveAll();
            });
        }
#endif
    }
}


