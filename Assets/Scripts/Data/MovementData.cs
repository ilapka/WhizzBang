using UnityEngine;

namespace WhizzBang.Data
{
    [CreateAssetMenu(fileName = "Movement Data", menuName = "WhizzBang/MovementData", order = 0)]
    public class MovementData : ScriptableObject
    {
        [Range(0f, 70f)]
        public float speed;
        public LayerMask obstaclesLayerMask;
    }
}