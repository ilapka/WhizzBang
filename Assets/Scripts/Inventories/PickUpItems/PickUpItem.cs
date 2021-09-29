using UnityEngine;
using WhizzBang.Data;

namespace WhizzBang.Inventories.PickUpItems
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public abstract class PickUpItem : MonoBehaviour
    {
        [SerializeField] protected ItemData itemData;
        [SerializeField] protected ParticleSystem pickUpEffect;
        public virtual ItemData PickUp()
        {
            pickUpEffect.Play();
            Destroy(gameObject, pickUpEffect.main.duration);
            return itemData;
        }
    }
}
