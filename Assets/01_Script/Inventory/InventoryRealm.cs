using Realms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRealm : RealmObject
{
    [PrimaryKey]
    public int Id { get; set; }

    public ItemSlotRealm[] slots { get; set; }
    public short wSize { get; set; }
    public short hSize { get; set; }
}
