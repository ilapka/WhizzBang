using UnityEngine;
using WhizzBang.Player;

namespace WhizzBang.Inventories.UsableItem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : UsableItem
    {
        [SerializeField] private Rigidbody _rigidbody;

        public override void OnMouseHold()
        {
            if(hands == null)
                Debug.Log("Item should be initialized");
        }
        public override void OnMouseButtonUp()
        {
            if(hands == null)
                Debug.Log("Item should be initialized");
            
            hands.Realise();
            _rigidbody.isKinematic = false;
        }
    }
}
