namespace Configurable_Harvest
{
	public class DropTableDropDataMod
    {
        public string ItemName { get; set; }
        public float Weight { get; set; }
        public int StackMin { get; set; }
        public int StackMax { get; set; }

        public DropTable.DropData CreateFrom(DropTable.DropData data)
        {
            DropTable.DropData itemData = new DropTable.DropData();
            itemData.m_item = data.m_item;
            itemData.m_weight = Weight;
            itemData.m_stackMin = StackMin;
            itemData.m_stackMax = StackMax;
            return itemData;
        }
    }
}
