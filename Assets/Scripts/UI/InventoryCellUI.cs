using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WhizzBang.Data;

namespace WhizzBang.UI
{
    public class InventoryCellUI : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI itemCount;

        public void Init(int count, ItemData itemData = null)
        {
            if(itemData != null)
                itemImage.sprite = itemData.itemUISprite;
            
            itemCount.text = count.ToString();
        }
    }
}
