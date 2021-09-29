using UnityEngine;
using WhizzBang.Inventories;
using WhizzBang.Inventories.PickUpItems;

namespace WhizzBang.Player
{
    [RequireComponent(typeof(Collider))]
    public class ItemCollector : MonoBehaviour
    {
        [SerializeField] private Inventory _playerInventory;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PickUpItem pickUpItem)) return;
            _playerInventory.Add(pickUpItem.PickUp());
        }
    }
}
