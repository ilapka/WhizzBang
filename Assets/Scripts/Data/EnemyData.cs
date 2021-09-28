using UnityEngine;

namespace WhizzBang.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "WhizzBang/EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        public float health;
    }
}