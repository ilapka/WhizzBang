using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WhizzBang.Data;

namespace WhizzBang.Inventories
{
    public struct InventoryCell
    {
        public int ItemCount;
    }

    public class Inventory : MonoBehaviour
    {
        private readonly Dictionary<ItemData, InventoryCell> _itemDataCellDictionary = new Dictionary<ItemData, InventoryCell>();

        public UnityEvent<ItemData, int> AddedItemEvent;
        public UnityEvent<ItemData, int> RemovedItemEvent;

        public void Add(ItemData itemData)
        {
            int currentItemCount;
            if (_itemDataCellDictionary.TryGetValue(itemData, out InventoryCell inventoryCell))
            {
                currentItemCount = ++inventoryCell.ItemCount;
            }
            else
            {
                currentItemCount = 1;
                _itemDataCellDictionary.Add(itemData, new InventoryCell(){ ItemCount = currentItemCount });
            }
            
            AddedItemEvent.Invoke(itemData, currentItemCount);
        }

        public void Remove(ItemData itemData)
        {
            if (!_itemDataCellDictionary.TryGetValue(itemData, out InventoryCell inventoryCell))
            {
                Debug.Log("The item you are trying to remove not found");
                return;
            }
            
            var currentItemCount = --inventoryCell.ItemCount;
            if (inventoryCell.ItemCount <= 0)
            {
                _itemDataCellDictionary.Remove(itemData);
            }
            
            RemovedItemEvent.Invoke(itemData, currentItemCount);
        }
    }
}