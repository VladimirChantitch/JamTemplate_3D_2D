using Realms;
using savesystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCRUD
{
    protected Realm realmInstance; 

    public AbstractCRUD()
    {
        realmInstance = RealmSaveManager.Instance.Realm;
    }
}
