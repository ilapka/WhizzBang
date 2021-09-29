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

        public UnityEvent<ItemData> AddedItemEvent;
        public UnityEvent<ItemData> RemovedItemEvent;

        public void Add(ItemData itemData)
        {
            if (_itemDataCellDictionary.TryGetValue(itemData, out InventoryCell inventoryCell))
            {
                inventoryCell.ItemCount++;
            }
            else
            {
                _itemDataCellDictionary.Add(itemData, new InventoryCell(){ ItemCount = 1 });
            }
            
            AddedItemEvent.Invoke(itemData);
        }

        public void Remove(ItemData itemData)
        {
            if (!_itemDataCellDictionary.TryGetValue(itemData, out InventoryCell inventoryCell))
            {
                Debug.Log("The item you are trying to remove not found");
                return;
            }
            
            inventoryCell.ItemCount--;
            if (inventoryCell.ItemCount <= 0)
            {
                _itemDataCellDictionary.Remove(itemData);
            }
            
            RemovedItemEvent.Invoke(itemData);
        }
    }
}