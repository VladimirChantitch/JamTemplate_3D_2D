using Realms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerRealm : RealmObject
{
    [PrimaryKey]
    public int Id { get; set; }

    public InventoryRealm InventoryRealm { get; set; }
}
