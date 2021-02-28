using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurable_Harvest
{
    public class DropTableMod
    {
        public bool Enabled { get; set; }
        public float DropChance { get; set; }
        public int DropMin { get; set; }
        public int DropMax { get; set; }
        public bool OneOfEach { get; set; }
        public List<DropTableDropDataMod> Entries { get; set; }

        public void ModifyDropTable(DropTable dt)
        {
            dt.m_dropChance = DropChance;
            dt.m_dropMin = DropMin;
            dt.m_dropMax = DropMax;
            dt.m_oneOfEach = OneOfEach;

            foreach (var dtDesc in Entries)
            {
                int dataIndex = dt.m_drops.FindIndex(x => x.m_item.name == dtDesc.ItemName);
                if (dataIndex >= 0 && dataIndex < dt.m_drops.Count)
                {
                    dt.m_drops[dataIndex] = dtDesc.CreateFrom(dt.m_drops[dataIndex]);
                }
            }
        }
    }
}
