using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using WhizzBang.Data;

namespace WhizzBang.Inventories
{
    public struct ItemCell
    {
        public int ItemCount;
        public ItemData Data;
        public int Index;
    }

    public class Inventory : MonoBehaviour
    {
        private readonly List<ItemCell> _itemsCellList = new List<ItemCell>();
        
        public UnityEvent<ItemCell> AddedItemEvent;
        public UnityEvent<ItemCell> RemovedItemEvent;

        public void AddItem(ItemData itemData)
        {
            var itemCell = _itemsCellList.Find(cell => cell.Data == itemData);
            if (itemCell.Data != null)
            {
                itemCell.ItemCount++;
            }
            else
            {
                itemCell.Index = _itemsCellList.Count;
                itemCell.Data = itemData;
                itemCell.ItemCount = 1;
                _itemsCellList.Add(itemCell);
            }
            AddedItemEvent.Invoke(itemCell);
        }

        public void RemoveItem(ItemData itemData)
        {
            var itemCell = _itemsCellList.Find(cell => cell.Data == itemData);
            if (itemCell.Data == null)
            {
                Debug.Log("The item you are trying to remove not found");
                return;
            }

            itemCell.ItemCount--;
            if (itemCell.ItemCount <= 0)
            {
                _itemsCellList.Remove(itemCell);
            }
            RemovedItemEvent.Invoke(itemCell);
        }

        public bool GetNextItem(int currentCellIndex, out ItemCell nextItemCell)
        {
            if (_itemsCellList.Count <= 0 || _itemsCellList.Count <= ++currentCellIndex)
            {
                nextItemCell = default;
                return false;
            }
            
            nextItemCell = _itemsCellList[currentCellIndex];
            return true;
        }
        
        public bool GetPreviousItem(int currentCellIndex, out ItemCell previousNextItemCell)
        {
            if (_itemsCellList.Count <= 0 || --currentCellIndex < 0)
            {
                previousNextItemCell = default;
                return false;
            }
            
            previousNextItemCell = _itemsCellList[currentCellIndex];
            return true;
        }
    }
}