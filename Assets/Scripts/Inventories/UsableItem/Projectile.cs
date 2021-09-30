using UnityEngine;
using WhizzBang.Inputs;
using WhizzBang.Player;

namespace WhizzBang.Inventories.UsableItem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : UsableItem
    {
        [SerializeField] private Rigidbody projectileRigidbody;
        [SerializeField] private Trajectory trajectory;
        [SerializeField] private float flightTime;

        private Vector3 _velocity;
        
        public override void OnMouseHold(HoldMouseInformation holdMouseInformation)
        {
            if (hands == null)
            {
                Debug.Log("Item should be initialized");
                return;
            }
            if(!holdMouseInformation.IsHit)
                return;
            
            _velocity = CalculateVelocity(holdMouseInformation.RaycastHit.point,transform.position, flightTime);
            trajectory.Visualize(_velocity, transform, holdMouseInformation.RaycastHit.point, flightTime);
            transform.rotation = Quaternion.LookRotation(_velocity);
        }
        
        public override void OnMouseButtonUp()
        {
            if(hands == null)
                Debug.Log("Item should be initialized");
            
            trajectory.gameObject.SetActive(false);
            hands.Realise();
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.AddForce(_velocity, ForceMode.VelocityChange);
        }

        private Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
        {
            var distance = target - origin;
            var distanceXZ = distance;
            distanceXZ.y = 0f;
     
            var lenghtY = distance.y;
            var lenghtXZ = distanceXZ.magnitude;
            var velocityXZ = lenghtXZ / time;
            var velocityY = (lenghtY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);
     
            Vector3 result = distanceXZ.normalized;
            result *= velocityXZ;
            result.y = velocityY;
     
            return result;
        }
    }
}
