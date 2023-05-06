using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<InventorySlot> items = new List<InventorySlot>();
        [SerializeField] private short wSize = 4;
        [SerializeField] private short hSize = 4;

        InventoryCRUD inventoryCRUD = null;
        [SerializeField] long ownerId;

        private void Awake()
        {
            inventoryCRUD = new InventoryCRUD();
        }

        public void Init(long ownerId)
        {
            this.ownerId = ownerId;
            inventoryCRUD.SetRealmObject(ownerId);
        }

        public void AddItem(ItemSO item, int amount)
        {
            if (items.Find(i => i.ItemSO == item) is InventorySlot existingSlot)
            {
                existingSlot.AddAmount(amount);
            }
            else
            {
                items.Add(new InventorySlot(
                    item : item,
                    amount : amount
                ));
            }
        }

        public bool RemoveItem(ItemSO item, int amount)
        {
            if (items.Find(i => i.ItemSO == item) is InventorySlot existingSlot)
            {
                switch (existingSlot.RemoveAmount(amount))
                {
                    case SlotReturnState.Empty:
                        items.Remove(existingSlot);
                        //UpdateRealm
                        return true;
                    case SlotReturnState.RemoveSuccess:
                        return true;
                    case SlotReturnState.RemoveFailure:
                        return false;
                }
            }
            return false;   
        }

        [Serializable]
        public class InventorySlot
        {
            public InventorySlot(ItemSO item, int amount)
            {
                this.itemSO = item;
                this.amount = amount;
            }

            [SerializeField] ItemSO itemSO = null;
            [SerializeField] int amount = 0;

            public ItemSO ItemSO { get => itemSO;  }
            public int Amount { get => amount; }

            public void AddAmount(int amount)
            {
                this.amount += amount;
            }

            public SlotReturnState RemoveAmount(int amount)
            {
                if (this.amount < amount)
                {
                    return SlotReturnState.RemoveFailure;
                }
                else
                {
                    this.amount -= amount;
                    if (this.amount == 0)
                    {
                        return SlotReturnState.Empty;
                    }
                    return SlotReturnState.RemoveSuccess;
                }
            }
        }

        public enum SlotReturnState
        {
            Empty,
            RemoveSuccess,
            RemoveFailure
        }
    }
}

