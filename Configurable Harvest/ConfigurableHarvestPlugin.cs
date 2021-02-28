using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace Configurable_Harvest
{
    [BepInPlugin("dk.mft_dev.configurable_harvest", "Configurable Harvest", "1.0.0.0")]
    [BepInProcess("valheim.exe")]
    public class ConfigurableHarvestPlugin: BaseUnityPlugin
    {
        private Harmony _h;
		void Awake()
        {
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
