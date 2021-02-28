using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Configurable_Harvest
{
    public static class StringHelper
    {
        public static string DropOnDestroyedToString(DropOnDestroyed x)
        {
            return $"name={x.name}, m_dropWhenDestroyed={DropTableToString(x.m_dropWhenDestroyed)}";

        }
        public static string MineRockToString(MineRock x)
        {
            return $"name={x.name}, m_name={x.m_name}, m_dropItems={DropTableToString(x.m_dropItems)}";
        }

        public static string MineRock5ToString(MineRock5 x)
        {
            return $"name={x.name}, m_name={x.m_name}, m_dropItems={DropTableToString(x.m_dropItems)}";
        }

        public static string DropTableToString(DropTable x)
        {
            if (x == null) return "";
            return $"m_dropChance={x.m_dropChance}, m_dropMin={x.m_dropMin}, m_dropMax={x.m_dropMax}, m_oneOfEach={x.m_oneOfEach}, m_drops={DropListToString(x.m_drops)}";
        }

        public static string DropListToString(List<DropTable.DropData> x)
        {
            if (x == null || x.Count == 0) return "";
            return string.Join(",", x.Select(a => DropDataToString(a)));
        }

        public static string DropDataToString(DropTable.DropData x)
        {
            return $"[m_item={GameObjectToString(x.m_item)}, m_stackMin={x.m_stackMin}, m_stackMax={x.m_stackMax}, m_weight={x.m_weight}]";
        }

        public static string GameObjectToString(GameObject x)
        {
            return $"{x.name}";
        }
    }
}
