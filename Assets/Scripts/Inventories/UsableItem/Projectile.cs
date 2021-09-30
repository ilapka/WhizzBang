using System;
using UnityEngine;
using WhizzBang.Calculators;
using WhizzBang.Inputs;
using WhizzBang.Interfaces;
using WhizzBang.Player;
using Random = UnityEngine.Random;

namespace WhizzBang.Inventories.UsableItem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : UsableItem
    {
        [Header("Flying settings")]
        [SerializeField] private Rigidbody projectileRigidbody;
        [SerializeField] private Trajectory trajectory;
        [SerializeField] private float flightTime;

        [Header("Explosion settings")]
        [SerializeField] private float explosionRadius;
        [SerializeField] private LayerMask damageLayer;
        [SerializeField] private int minDamage;
        [SerializeField] private int maxDamage;
        [SerializeField] private ParticleSystem explosionEffect;

        private Vector3 _velocity;
        private bool _launched;
        private bool _exploded;
        
        public override void OnMouseHold(HoldMouseInformation holdMouseInformation)
        {
            if (hands == null)
            {
                Debug.Log("Item should be initialized");
                return;
            }
            if(!holdMouseInformation.IsHit)
                return;
            
            _velocity = SpatialCalculator.GetVelocityToFlyOnTarget(holdMouseInformation.RaycastHit.point,transform.position, flightTime);
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
            _launched = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            if(!_launched || _exploded) return;
            _exploded = true;
            Explode();
        }

        private void Explode()
        {
            explosionEffect.gameObject.SetActive(true);
            explosionEffect.Play();
            
            var coveredObjects = Physics.OverlapSphere(transform.position ,explosionRadius, damageLayer);
            foreach (var coveredObject in coveredObjects)
            {
                if(coveredObject.TryGetComponent<IHaveHealth>(out IHaveHealth healthObject))
                {
                    healthObject.TakeDamage(Random.Range(minDamage, maxDamage));
                }
            }
            
            Destroy(gameObject, explosionEffect.main.duration);
        }
    }
}
