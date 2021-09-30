using System;
using System.Collections.Generic;
using UnityEngine;
using WhizzBang.Data;
using WhizzBang.Inventories;

namespace WhizzBang.UI
{
    public class InventoryUI : MonoBehaviour
    {
        private readonly Dictionary<ItemData, ItemCellUI> _itemCellUiDictionary = new Dictionary<ItemData, ItemCellUI>();
        
        [SerializeField] private Inventory inventory;
        [SerializeField] private ItemCellUI itemCellUIPrefab;

        private void Start()
        {
            inventory.AddedItemEvent.AddListener(AddItemOnUI);
            inventory.RemovedItemEvent.AddListener(RemoveItemFromUI);
        }

        private void AddItemOnUI(ItemCell itemCell)
        {
            if (_itemCellUiDictionary.TryGetValue(itemCell.Data, out ItemCellUI inventoryCellUI))
            {
                inventoryCellUI.Set(itemCell.ItemCount);
                return;
            }

            var itemCellUI = Instantiate(itemCellUIPrefab, transform);
            itemCellUI.Set(itemCell.ItemCount, itemCell.Data);
            _itemCellUiDictionary.Add(itemCell.Data, itemCellUI);
        }
        
        private void RemoveItemFromUI(ItemCell itemCell)
        {
            if (!_itemCellUiDictionary.TryGetValue(itemCell.Data, out ItemCellUI itemCellUI))
            {
                Debug.Log("UI-item you are trying to remove not found");
                return;
            }

            if (itemCell.ItemCount > 0)
            {
                itemCellUI.Set(itemCell.ItemCount);
            }
            else
            {
                Destroy(itemCellUI.gameObject);
                _itemCellUiDictionary.Remove(itemCell.Data);
            }
        }

        private void OnDestroy()
        {
            inventory.AddedItemEvent.RemoveListener(AddItemOnUI);
            inventory.AddedItemEvent.RemoveListener(RemoveItemFromUI);
        }
    }
}
