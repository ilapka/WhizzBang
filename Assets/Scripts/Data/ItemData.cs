using UnityEngine;

namespace WhizzBang.Data
{
    [CreateAssetMenu(fileName = "ProjectileItemData", menuName = "WhizzBang/ProjectileItemData", order = 0)]
    public class ProjectileItemData : ItemData
    {
        public GameObject projectilePrefab;
    }
}