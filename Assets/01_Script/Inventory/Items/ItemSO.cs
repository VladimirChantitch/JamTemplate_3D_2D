using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[CreateAssetMenu(menuName = "item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] string itemName = "item";
    [SerializeField] Sprite sprite = null;
    [SerializeField] short hSize = 1;
    [SerializeField] short wSize = 1;
    [SerializeField] long id = -1;

    public (short,short) GetShape()
    {
        return (hSize,wSize);
    }

    public ItemSO Clone()
    {
        ItemSO clonedItem = CreateInstance<ItemSO>();
        clonedItem.hSize = (short)hSize;
        clonedItem.wSize = (short)wSize;
        clonedItem.itemName = itemName;
        clonedItem.sprite = sprite;
        Register(clonedItem);
        clonedItem.id = id;
        return clonedItem;
    }   

    private void Register(ItemSO item)
    {
        if (id == -1)
        {
            id = Random.Range(0,hSize);
        }
        ResourcesManager.Instance.AddResource(item);
    }
}
