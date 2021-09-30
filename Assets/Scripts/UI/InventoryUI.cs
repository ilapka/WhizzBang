using System;
using System.Collections.Generic;
using UnityEngine;
using WhizzBang.Data;
using WhizzBang.Inventories;

namespace WhizzBang.UI
{
    public class InventoryUI : MonoBehaviour
    {
        private readonly Dictionary<ItemData, InventoryCellUI> _itemCellUiDictionary = new Dictionary<ItemData, InventoryCellUI>();
        
        [SerializeField] private Inventory inventory;
        [SerializeField] private InventoryCellUI inventoryCellUIPrefab;

        private void Start()
        {
            inventory.AddedItemEvent.AddListener(AddItemOnUI);
            inventory.AddedItemEvent.AddListener(RemoveItemFromUI);
        }

        private void AddItemOnUI(ItemCell itemCell)
        {
            if (_itemCellUiDictionary.TryGetValue(itemCell.Data, out InventoryCellUI inventoryCellUI))
            {
                inventoryCellUI.Init(itemCell.ItemCount);
                return;
            }

            var itemCellUI = Instantiate(inventoryCellUIPrefab, transform);
            itemCellUI.Init(itemCell.ItemCount, itemCell.Data);
            _itemCellUiDictionary.Add(itemCell.Data, itemCellUI);
        }
        
        private void RemoveItemFromUI(ItemCell itemCell)
        {
            if (!_itemCellUiDictionary.TryGetValue(itemCell.Data, out InventoryCellUI inventoryCellUI))
            {
                Debug.Log("UI-item you are trying to remove not found");
                return;
            }

            if (itemCell.ItemCount > 0)
            {
                inventoryCellUI.Init(itemCell.ItemCount);
            }
            else
            {
                Destroy(inventoryCellUI);
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
