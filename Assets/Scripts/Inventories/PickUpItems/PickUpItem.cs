using UnityEngine;
using WhizzBang.Data;
using WhizzBang.Spawners;

namespace WhizzBang.Inventories.PickUpItems
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class PickUpItem : SpawnableObject
    {
        [SerializeField] protected ItemData itemData;
        [SerializeField] protected GameObject itemMesh;
        [SerializeField] protected ParticleSystem pickUpEffect;
        public virtual ItemData PickUp()
        {
            itemMesh.gameObject.SetActive(false);
            pickUpEffect.gameObject.SetActive(true);
            pickUpEffect.Play();
            Destroy(gameObject, pickUpEffect.main.duration);
            return itemData;
        }
    }
}
