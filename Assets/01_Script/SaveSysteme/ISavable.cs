using data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace savesystem
{
    public interface ISavable
    {
        public Data Save();

        public void Load(); 
    }
}
