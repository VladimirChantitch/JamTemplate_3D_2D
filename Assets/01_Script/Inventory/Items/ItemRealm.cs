using Realms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRealm : RealmObject
{
    [PrimaryKey]
    public long Id { get; set; }
}
