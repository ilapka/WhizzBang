using UnityEngine;

namespace WhizzBang.Calculators
{
    public static class SpatialCalculator 
    {
        public static Vector3 GetVelocityToFlyOnTarget(Vector3 target, Vector3 origin, float time)
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
