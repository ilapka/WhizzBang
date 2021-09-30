using UnityEngine;
using WhizzBang.Inventories.UsableItem;

namespace WhizzBang.Data
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "WhizzBang/ItemData", order = 0)]
    public class ItemData : ScriptableObject
    {
        public UsableItem usableItemPrefab;
        public Sprite itemUISprite;
    }
}