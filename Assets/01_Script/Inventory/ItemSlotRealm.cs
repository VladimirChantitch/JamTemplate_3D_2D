using Realms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotRealm : RealmObject
{
    [PrimaryKey]
    public long id { get; set; }

    public ItemRealm itemRealm { get; set; }
    public int amount { get; set; }
}
