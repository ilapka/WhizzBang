using WhizzBang.Data;

namespace WhizzBang.Inventories
{
    public class ItemCell
    {
        public ItemCell(ItemData data, int index)
        {
            Data = data;
        }

        public void Increase() => ItemCount++;
        public void Decrease() => ItemCount--;
        
        public int ItemCount;
        public ItemData Data;
    }
}