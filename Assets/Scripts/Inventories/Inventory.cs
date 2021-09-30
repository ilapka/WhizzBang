using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using WhizzBang.Data;

namespace WhizzBang.Inventories
{
    public class Inventory : MonoBehaviour
    {
        private readonly List<ItemCell> _itemsCellList = new List<ItemCell>();
        
        public UnityEvent<ItemCell> AddedItemEvent;
        public UnityEvent<ItemCell> RemovedItemEvent;

        public void AddItem(ItemData itemData)
        {
            var itemCell = _itemsCellList.Find(cell => cell.Data == itemData);
            if (itemCell == null)
            {
                itemCell = new ItemCell(itemData, _itemsCellList.Count);
                _itemsCellList.Add(itemCell);
            }
            itemCell.Increase();
            AddedItemEvent.Invoke(itemCell);
        }

        public void RemoveItem(ItemData itemData)
        {
            var itemCell = _itemsCellList.Find(cell => cell.Data == itemData);
            if (itemCell == null)
            {
                Debug.Log("The item you are trying to remove not found");
                return;
            }
            itemCell.Decrease();
            if (itemCell.ItemCount <= 0)
            {
                _itemsCellList.Remove(itemCell);
            }
            RemovedItemEvent.Invoke(itemCell);
        }

        public bool GetNextItem(ItemCell currentItemCell, out ItemCell nextItemCell)
        {
            var currentCellIndex = _itemsCellList.IndexOf(currentItemCell);
            currentCellIndex++;
            if (_itemsCellList.Count <= 0 || _itemsCellList.Count <= currentCellIndex)
            {
                nextItemCell = null;
                return false;
            }
            
            nextItemCell = _itemsCellList[currentCellIndex];
            return true;
        }
        
        public bool GetPreviousItem(ItemCell currentItemCell, out ItemCell previousNextItemCell)
        {
            var currentCellIndex = _itemsCellList.IndexOf(currentItemCell);
            currentCellIndex--;
            if (_itemsCellList.Count <= 0 || currentCellIndex < 0)
            {
                previousNextItemCell = null;
                return false;
            }
            
            previousNextItemCell = _itemsCellList[currentCellIndex];
            return true;
        }

        public bool GetSameOrNextItem(ItemCell currentItemCell, out ItemCell sameOrNextItemCell)
        {
            var currentCellIndex = _itemsCellList.IndexOf(currentItemCell);
            if (_itemsCellList.Count <= 0)
            {
                sameOrNextItemCell = null;
                return false;
            }
            currentCellIndex = Mathf.Clamp(currentCellIndex, 0, _itemsCellList.Count - 1);
            sameOrNextItemCell = _itemsCellList[currentCellIndex];
            return true;
        }
    }
}