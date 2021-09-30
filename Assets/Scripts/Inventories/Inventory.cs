using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using WhizzBang.Data;

namespace WhizzBang.Inventories
{
    public class ItemCell
    {
        public ItemCell(ItemData data, int index)
        {
            Data = data;
            Index = index;
        }

        public void Increase() => ItemCount++;
        public void Decrease() => ItemCount--;
        
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
            if (itemCell.Data == null)
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

        public bool GetNextItem(int currentCellIndex, out ItemCell nextItemCell)
        {
            if (_itemsCellList.Count <= 0 || _itemsCellList.Count <= ++currentCellIndex)
            {
                nextItemCell = null;
                return false;
            }
            
            nextItemCell = _itemsCellList[currentCellIndex];
            return true;
        }
        
        public bool GetPreviousItem(int currentCellIndex, out ItemCell previousNextItemCell)
        {
            if (_itemsCellList.Count <= 0 || --currentCellIndex < 0)
            {
                previousNextItemCell = null;
                return false;
            }
            
            previousNextItemCell = _itemsCellList[currentCellIndex];
            return true;
        }

        public bool GetSameOrNextItem(int currentCellIndex, out ItemCell sameOrNextItemCell)
        {
            if (_itemsCellList.Count <= 0)
            {
                sameOrNextItemCell = null;
                return false;
            }

            if (_itemsCellList.Count == currentCellIndex)
                currentCellIndex--;
            

            sameOrNextItemCell = _itemsCellList[currentCellIndex];
            return true;
        }
    }
}