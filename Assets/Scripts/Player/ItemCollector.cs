using System;
using UnityEngine;
using WhizzBang.Inventories;
using WhizzBang.Inventories.PickUpItems;

namespace WhizzBang.Player
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class ItemCollector : MonoBehaviour
    {
        [SerializeField] private Inventory _playerInventory;
        [SerializeField] private CapsuleCollider _capsuleCollider;
        [SerializeField] private float _collectionRadius;

        private void Start()
        {
            _capsuleCollider.radius = _collectionRadius;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PickUpItem pickUpItem)) return;
            _playerInventory.AddItem(pickUpItem.PickUp());
        }
    }
}
