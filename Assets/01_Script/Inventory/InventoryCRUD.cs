using Realms;
using savesystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCRUD : AbstractCRUD
{
    InventoryRealm currentInventoryRealm = null;

    public InventoryCRUD() : base()
    {

    }

    internal bool SetRealmObject(long ownerId)
    {
        currentInventoryRealm = realmInstance.Find<OwnerRealm>(ownerId).InventoryRealm;
        if (currentInventoryRealm != null)
        {
            return true;
        }else
        {
            return false;
        }
    }
}
