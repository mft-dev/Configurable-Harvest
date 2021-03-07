using BepInEx.Configuration;
using System.Collections.Generic;

namespace Configurable_Harvest
{
	public static class PluginConfig
    {
		#region INI Entry Description strings
		private const string DropChanceDesc = "The chance that the drop table will select an entry. Factor range from 0 to 1. 1 meaning 1=100%, 0=0%, 0.5=50%";
        private const string OneOfEachDesc = "Determines if the drop table should yield one of each or use RNG to select an entry based on it's weight. If this setting is true, the DropMin and DropMax must match the number of entries in the drop table, otherwise the game will only drop the items with highest weight, in order.";
        private const string DropMinDesc = "The minimum number of times RNG is rolled to determine which drop from the drop table is yielded";
        private const string DropMaxDesc = "The maximum number of times RNG is rolled to determine which drop from the drop table is yielded";
        private const string DropDataWeightDesc = "The weight the drop table entry has in the RNG decision. Higher means more likely";
        private const string DropDataMinStackDesc = "The minimum stack size of this drop table entry";
        private const string DropDataMaxStackDesc = "The maximum stack size of this drop table entry";
		public static bool EnableResourceLogging { get; private set; }
		#endregion
		public static DropTableMod Tin { get; set; }
        public static DropTableMod Copper { get; set; }
        public static DropTableMod Iron { get; set; }
        public static DropTableMod Obsidian { get; set; }

        public static void LoadConfiguration(ConfigFile cfg)
        {
            #region Plugin Config
            
            EnableResourceLogging = cfg.Bind("Plugin", "Log Resources Found", false, "Writes a log entry every time a new resource is discovered by the plugin. Used for development. Log file is written to 'cfg_harvest.log' in the Plugins folder").Value;

            #endregion

            #region Tin Config
            // DropOnDestroyed: name=MineRock_Tin(Clone), m_dropWhenDestroyed=m_dropChance=1, m_dropMin=3, m_dropMax=4, m_oneOfEach=False, m_drops=[m_item=TinOre, m_stackMin=1, m_stackMax=1, m_weight=1]
            Tin = new DropTableMod()
            {
                Enabled = cfg.Bind("Tin", "Enabled", false, "Enable changes for tin deposits").Value,
                DropChance = cfg.Bind("Tin", "DropChance", 1.0f, DropChanceDesc).Value,
                OneOfEach = cfg.Bind("Tin", "DropTable OneOfEach", false, OneOfEachDesc).Value,
                DropMin = cfg.Bind("Tin", "DropTable DropMin", 3, DropMinDesc).Value,
                DropMax = cfg.Bind("Tin", "DropTable DropMax", 4, DropMaxDesc).Value,
                Entries = new List<DropTableDropDataMod>()
                {
                    new DropTableDropDataMod()
                    {
                        ItemName = "TinOre",
                        Weight = cfg.Bind("Tin", "DropTable Stone Weight", 1.0f, DropDataWeightDesc).Value,
                        StackMin = cfg.Bind("Tin", "DropTable TinOre Min", 1, DropDataMinStackDesc).Value,
                        StackMax = cfg.Bind("Tin", "DropTable TinOre Max", 1, DropDataMaxStackDesc).Value,
                    }
                }
            };

            #endregion

            #region Copper Config
            Copper = new DropTableMod()
            {
                Enabled = cfg.Bind("Copper", "Enabled", false, "Enable changes for copper deposits").Value,
                DropChance = cfg.Bind("Copper", "DropChance", 1.0f, DropChanceDesc).Value,
                OneOfEach = cfg.Bind("Copper", "DropTable OneOfEach", false, OneOfEachDesc).Value,
                DropMin = cfg.Bind("Copper", "DropTable DropMin", 2, DropMinDesc).Value,
                DropMax = cfg.Bind("Copper", "DropTable DropMax", 4, DropMaxDesc).Value,
                Entries = new List<DropTableDropDataMod>()
                {
                    new DropTableDropDataMod()
                    {
                        ItemName = "Stone",
                        Weight = cfg.Bind("Copper", "DropTable Stone Weight", 1.0f, DropDataWeightDesc).Value,
                        StackMin = cfg.Bind("Copper", "DropTable Stone Min", 1, DropDataMinStackDesc).Value,
                        StackMax = cfg.Bind("Copper", "DropTable Stone Max", 1, DropDataMaxStackDesc).Value,
                    },
                    new DropTableDropDataMod()
                    {
                        ItemName = "CopperOre",
                        Weight = cfg.Bind("Copper", "DropTable CopperOre Weight", 0.5f, DropDataWeightDesc).Value,
                        StackMin = cfg.Bind("Copper", "DropTable CopperOre Min", 1, DropDataMinStackDesc).Value,
                        StackMax = cfg.Bind("Copper", "DropTable CopperOre Max", 1, DropDataMaxStackDesc).Value,
                    }
                }
            };
            #endregion

            #region Iron Config
            //name=mudpile2_frac(Clone), m_name=$piece_mudpile, m_dropItems=m_dropChance=0.2, m_dropMin=1, m_dropMax=1, m_oneOfEach=False, m_drops=[m_item=IronScrap, m_stackMin=1, m_stackMax=1, m_weight=5],[m_item=WitheredBone, m_stackMin=1, m_stackMax=1, m_weight=1],[m_item=LeatherScraps, m_stackMin=1, m_stackMax=1, m_weight=1]

            Iron = new DropTableMod()
            {
                Enabled = cfg.Bind("Iron", "Enabled", false, "Enable changes for iron deposits").Value,
                DropChance = cfg.Bind("Iron", "DropChance", 0.2f, DropChanceDesc).Value,
                OneOfEach = cfg.Bind("Iron", "DropTable OneOfEach", false, OneOfEachDesc).Value,
                DropMin = cfg.Bind("Iron", "DropTable DropMin", 1, DropMinDesc).Value,
                DropMax = cfg.Bind("Iron", "DropTable DropMax", 1, DropMaxDesc).Value,
                Entries = new List<DropTableDropDataMod>()
                {
                    new DropTableDropDataMod()
                    {
                        ItemName = "IronScrap",
                        Weight = cfg.Bind("Iron", "DropTable IronScrap Weight", 5f, DropDataWeightDesc).Value,
                        StackMin = cfg.Bind("Iron", "DropTable IronScrap Min", 1, DropDataMinStackDesc).Value,
                        StackMax = cfg.Bind("Iron", "DropTable IronScrap Max", 1, DropDataMaxStackDesc).Value,
                    },
                    new DropTableDropDataMod()
                    {
                        ItemName = "WitheredBone",
                        Weight = cfg.Bind("Iron", "DropTable WitheredBone Weight", 1.0f, DropDataWeightDesc).Value,
                        StackMin = cfg.Bind("Iron", "DropTable WitheredBone Min", 1, DropDataMinStackDesc).Value,
                        StackMax = cfg.Bind("Iron", "DropTable WitheredBone Max", 1, DropDataMaxStackDesc).Value,
                    },
                    new DropTableDropDataMod()
                    {
                        ItemName = "LeatherScraps",
                        Weight = cfg.Bind("Iron", "DropTable LeatherScraps Weight", 1.0f, DropDataWeightDesc).Value,
                        StackMin = cfg.Bind("Iron", "DropTable LeatherScraps Min", 1, DropDataMinStackDesc).Value,
                        StackMax = cfg.Bind("Iron", "DropTable LeatherScraps Max", 1, DropDataMaxStackDesc).Value,
                    }
                }
            };
            #endregion

            #region Osbidian Config
            //[3/7/2021 12:11 PM] [DropOnDestroyed] name=MineRock_Obsidian(Clone), m_dropWhenDestroyed=m_dropChance=1, m_dropMin=5, m_dropMax=8, m_oneOfEach=False, m_drops=[m_item=Obsidian, m_stackMin=1, m_stackMax=1, m_weight=1]

            Obsidian = new DropTableMod()
            {
                Enabled = cfg.Bind("Obsidian", "Enabled", false, "Enable changes for obsidian deposits").Value,
                DropChance = cfg.Bind("Obsidian", "DropChance", 1.0f, DropChanceDesc).Value,
                OneOfEach = cfg.Bind("Obsidian", "DropTable OneOfEach", false, OneOfEachDesc).Value,
                DropMin = cfg.Bind("Obsidian", "DropTable DropMin", 5, DropMinDesc).Value,
                DropMax = cfg.Bind("Obsidian", "DropTable DropMax", 8, DropMaxDesc).Value,
                Entries = new List<DropTableDropDataMod>()
                {
                    new DropTableDropDataMod()
                    {
                        ItemName = "TinOre",
                        Weight = cfg.Bind("Obsidian", "DropTable Obsidian Weight", 1.0f, DropDataWeightDesc).Value,
                        StackMin = cfg.Bind("Obsidian", "DropTable Obsidian Min", 1, DropDataMinStackDesc).Value,
                        StackMax = cfg.Bind("Obsidian", "DropTable Obsidian Max", 1, DropDataMaxStackDesc).Value,
                    }
                }
            };


            #endregion
        }

    }
}
