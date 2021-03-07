using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Configurable_Harvest
{
	public static class Log
    {
        private static string _filename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "cfg_harvest.log");
        private static List<string> _logLines = new List<string>();
        private static HashSet<string> _loggedMineRock5 = new HashSet<string>();
        private static HashSet<string> _loggedMineRock = new HashSet<string>();
        private static HashSet<string> _loggedDropOnDestroyed = new HashSet<string>();

        private static void LogString(string s)
        {
            File.AppendAllLines(_filename, new[] { $"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}] {s}" });
        }

        public static void LogOnce(MineRock5 m)
        {
            if (PluginConfig.EnableResourceLogging && _loggedMineRock5.Add(m.m_name))
            {
                LogString(StringHelper.MineRock5ToString(m));
            }
        }
        public static void LogOnce(MineRock m)
        {
            if (PluginConfig.EnableResourceLogging && _loggedMineRock.Add(m.m_name))
            {
                LogString(StringHelper.MineRockToString(m));
            }
        }
        public static void LogOnce(DropOnDestroyed d)
        {
            if (PluginConfig.EnableResourceLogging && _loggedDropOnDestroyed.Add(d.name))
            {
                LogString(StringHelper.DropOnDestroyedToString(d));
            }
        }

    }
}
