using UnityEngine;
using WhizzBang.Player;

namespace WhizzBang.Inventories.UsableItem
{
    public abstract class UsableItem : MonoBehaviour
    {
        protected Hands hands;

        public virtual void Init(Hands hands)
        {
            this.hands = hands;
        }

        public abstract void OnMouseHold();
        public abstract void OnMouseButtonUp();
    }
}
