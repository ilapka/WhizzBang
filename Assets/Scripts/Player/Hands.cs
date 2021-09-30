using System;
using UnityEngine;
using WhizzBang.Data;
using WhizzBang.Inputs;
using WhizzBang.Inventories;

namespace WhizzBang.Player
{
    public class Hands : MonoBehaviour
    {
        [SerializeField] private InputShell inputShell;
        [SerializeField] private Inventory inventory;
        [SerializeField] private Transform handContainer;

        private GameObject _currentItem;
        private ItemCell _currentItemCell;
        
        private void Start()
        {
            inventory.AddedItemEvent.AddListener(itemData => TakeItem(itemData, false));
            inputShell.RightArrowButtonDown.AddListener(TakeNextItem);
            inputShell.LeftArrowButtonDown.AddListener(TakePreviousItem);
        }
        
        private void TakeItem(ItemCell itemCell, bool overrideCurrent)
        {
            if (!overrideCurrent && _currentItem != null) return;

            Destroy(_currentItem);
            _currentItemCell = itemCell;
            _currentItem = Instantiate(itemCell.Data.prefab, handContainer);
        }
        
        private void TakeNextItem()
        {
            if(!inventory.GetNextItem(_currentItemCell.Index, out var nextItemCell))
                return;
            TakeItem(nextItemCell,true);
        }

        private void TakePreviousItem()
        {
            if(!inventory.GetPreviousItem(_currentItemCell.Index, out var nextItemCell))
                return;
            TakeItem(nextItemCell,true);
        }
        
        /*
        public void UseCurrentItem()
        {
            if(_currentItem == null) return;
            
            //... _currentItem ...
            
            inventory.RemoveItem(_currentItemData);
            //Take
            TakeNextItem();
        }*/
    }
}
