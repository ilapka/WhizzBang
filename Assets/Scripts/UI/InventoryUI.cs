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

        private void AddItemOnUI(ItemData itemData, int count)
        {
            if (_itemCellUiDictionary.TryGetValue(itemData, out InventoryCellUI inventoryCellUI))
            {
                inventoryCellUI.SetItem(count);
                return;
            }

            var itemCellUI = Instantiate(inventoryCellUIPrefab, transform);
            itemCellUI.SetItem(count, itemData);
            _itemCellUiDictionary.Add(itemData, itemCellUI);
        }
        
        private void RemoveItemFromUI(ItemData itemData, int count)
        {
            if (!_itemCellUiDictionary.TryGetValue(itemData, out InventoryCellUI inventoryCellUI))
            {
                Debug.Log("UI-item you are trying to remove not found");
                return;
            }

            if (count > 0)
            {
                inventoryCellUI.SetItem(count);
            }
            else
            {
                Destroy(inventoryCellUI);
                _itemCellUiDictionary.Remove(itemData);
            }
        }

        private void OnDestroy()
        {
            inventory.AddedItemEvent.RemoveListener(AddItemOnUI);
            inventory.AddedItemEvent.RemoveListener(RemoveItemFromUI);
        }
    }
}
