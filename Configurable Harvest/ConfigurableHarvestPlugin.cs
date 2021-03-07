using BepInEx;
using HarmonyLib;
using System;

namespace Configurable_Harvest
{
	[BepInPlugin("dk.mft_dev.configurable_harvest", "Configurable Harvest", "1.0.0.0")]
    [BepInProcess("valheim.exe")]
    public class ConfigurableHarvestPlugin: BaseUnityPlugin
    {
        private Harmony _h;
        private static Action<BepInEx.Logging.LogLevel, string> _logger = null;
        public static void LogInfo(BepInEx.Logging.LogLevel l, string info)
		{
            if (_logger != null)
			{
                _logger(l, info);
			}
		}

		void Awake()
        {
            _logger = (l, s) => Logger.Log(l, s);
            Logger.LogInfo("Configurable Harvest: Awake");
            PluginConfig.LoadConfiguration(Config);
            _h = new Harmony("mod.configurable_harvest");
            _h.PatchAll();
        }

        void OnDestroy()
		{
            Logger.LogInfo("Configurable Harvest: OnDestroy");
            _h.UnpatchSelf();
		}

    }
}
