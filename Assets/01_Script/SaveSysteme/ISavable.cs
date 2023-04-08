using savesystem.dto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace savesystem
{
    public interface ISavable
    {
        public Dto Save();

        public void Load(Dto dto); 
    }
}
