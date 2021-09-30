using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using WhizzBang.Data;
using WhizzBang.Inputs;
using WhizzBang.Inventories;
using WhizzBang.Inventories.UsableItem;

namespace WhizzBang.Player
{
    public class Hands : MonoBehaviour
    {
        [SerializeField] private InputShell inputShell;
        [SerializeField] private Inventory inventory;
        [SerializeField] private Transform handContainer;

        private UsableItem _currentItem;
        private ItemCell _currentItemCell;
        
        private void Start()
        {
            inventory.AddedItemEvent.AddListener(itemData => Take(itemData, false));
            inputShell.RightArrowButtonDownEvent.AddListener(NextItem);
            inputShell.LeftArrowButtonDownEvent.AddListener(PreviousItem);
            inputShell.HoldMouseButtonEvent.AddListener(OnMouseHold);
            inputShell.MouseButtonUpEvent.AddListener(OnMouseButtonUp);
        }
        
        private void Take(ItemCell itemCell, bool overrideCurrent)
        {
            if (!overrideCurrent && _currentItem != null) return;

            if(_currentItem != null) Destroy(_currentItem.gameObject);
            _currentItemCell = itemCell;
            _currentItem = Instantiate(itemCell.Data.usableItemPrefab, handContainer);
            _currentItem.Init(this);
        }
        
        public void Realise()
        {
            if(_currentItemCell == null) return;

            inventory.RemoveItem(_currentItemCell.Data);
            _currentItem.transform.SetParent(null);
            _currentItem = null;
            
            if(!inventory.GetSameOrNextItem(_currentItemCell, out ItemCell sameOrNextItemCell))
                return;

            Take(sameOrNextItemCell, true);
        }
        
        private void NextItem()
        {
            if(_currentItemCell == null) return;
            
            if(!inventory.GetNextItem(_currentItemCell, out var nextItemCell))
                return;
            Take(nextItemCell,true);
        }

        private void PreviousItem()
        {
            if(_currentItemCell == null) return;
            
            if(!inventory.GetPreviousItem(_currentItemCell, out var previousItemCell))
                return;
            Take(previousItemCell,true);
        }
        
        private void OnMouseHold(HoldMouseInformation holdMouseInformation)
        {
            if(_currentItem == null) return;

            _currentItem.OnMouseHold(holdMouseInformation);
        }
        
        private void OnMouseButtonUp()
        {
            if(_currentItem == null) return;

            _currentItem.OnMouseButtonUp();
        }
    }
}
