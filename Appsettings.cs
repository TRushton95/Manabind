using System;
using System.Configuration;

namespace Manabind
{
    public static class AppSettings
    {
        public static int WindowWidth { get => Int32.Parse(ConfigurationManager.AppSettings["WindowWidth"]); }

        public static int WindowHeight { get => Int32.Parse(ConfigurationManager.AppSettings["WindowHeight"]); }

        public static string UIDefinitionPath { get => ConfigurationManager.AppSettings["UIDefinitionPath"]; }

        public static string MenuUIFileName { get => ConfigurationManager.AppSettings["MenuUIFileName"]; }
    }
}
