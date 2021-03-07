using HarmonyLib;
using System;

namespace Configurable_Harvest
{
	[HarmonyPatch]
    public class Patcher
    {

        // DropOnDestroyed: name=MineRock_Tin(Clone), m_dropWhenDestroyed=m_dropChance=1, m_dropMin=3, m_dropMax=4, m_oneOfEach=False, m_drops=[m_item=TinOre, m_stackMin=1, m_stackMax=1, m_weight=1]
        [HarmonyPrefix]
        [HarmonyPatch(typeof(DropOnDestroyed), "Awake")]
        private static void DropOnDestroyed_Prefix(ref DropOnDestroyed __instance)
        {
            if (__instance.name == "MineRock_Tin(Clone)" && PluginConfig.Tin.Enabled)
            {
                if (__instance.m_dropWhenDestroyed != null)
                {
                    try
                    {
                        PluginConfig.Tin.ModifyDropTable(__instance.m_dropWhenDestroyed);
                    }
                    catch (Exception ex)
					{
                        ConfigurableHarvestPlugin.LogInfo(BepInEx.Logging.LogLevel.Error, $"Failed applying modification to Tin: {ex.ToString()}");
					}
                }
            }
            //[3/7/2021 12:11 PM] [DropOnDestroyed] name=MineRock_Obsidian(Clone), m_dropWhenDestroyed=m_dropChance=1, m_dropMin=5, m_dropMax=8, m_oneOfEach=False, m_drops=[m_item=Obsidian, m_stackMin=1, m_stackMax=1, m_weight=1]
            if (__instance.name == "MineRock_Obsidian(Clone)" && PluginConfig.Obsidian.Enabled)
			{
                if (__instance.m_dropWhenDestroyed != null)
                {
                    try
                    {
                        PluginConfig.Obsidian.ModifyDropTable(__instance.m_dropWhenDestroyed);
                    }
                    catch (Exception ex)
                    {
                        ConfigurableHarvestPlugin.LogInfo(BepInEx.Logging.LogLevel.Error, $"Failed applying modification to Obsidian: {ex.ToString()}");
                    }
                }
            }
            Log.LogOnce(__instance);
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MineRock), "Start")]
        private static void MineRock_Prefix(ref MineRock __instance)
		{
            Log.LogOnce(__instance);
		}

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MineRock5), "Start")]
        private static void MineRock5_Prefix(ref MineRock5 __instance)
        {
            Log.LogOnce(__instance);
            if (__instance.m_name == "$piece_deposit_copper" && PluginConfig.Copper.Enabled)
            {
                if (__instance.m_dropItems != null)
                {
                    try
                    {
                        PluginConfig.Copper.ModifyDropTable(__instance.m_dropItems);
                    }
                    catch (Exception ex)
					{
                        ConfigurableHarvestPlugin.LogInfo(BepInEx.Logging.LogLevel.Error, $"Failed applying modification to Copper: {ex.ToString()}");
                    }
                }
            }
            //name=mudpile2_frac(Clone), m_name=$piece_mudpile, m_dropItems=m_dropChance=0.2, m_dropMin=1, m_dropMax=1, m_oneOfEach=False, m_drops=[m_item=IronScrap, m_stackMin=1, m_stackMax=1, m_weight=5],[m_item=WitheredBone, m_stackMin=1, m_stackMax=1, m_weight=1],[m_item=LeatherScraps, m_stackMin=1, m_stackMax=1, m_weight=1]
            if (__instance.m_name == "$piece_mudpile" && PluginConfig.Iron.Enabled)
            {
                if (__instance.m_dropItems != null)
                {
                    try
                    {
                        PluginConfig.Iron.ModifyDropTable(__instance.m_dropItems);
                    }
                    catch (Exception ex)
					{
                        ConfigurableHarvestPlugin.LogInfo(BepInEx.Logging.LogLevel.Error, $"Failed applying modification to Iron: {ex.ToString()}");
                    }
                }
            }
        }

    }
}
