using System;
using System.Configuration;

namespace Manabind
{
    public static class AppSettings
    {
        #region Window

        public static int WindowWidth { get => Int32.Parse(ConfigurationManager.AppSettings["WindowWidth"]); }

        public static int WindowHeight { get => Int32.Parse(ConfigurationManager.AppSettings["WindowHeight"]); }

        #endregion

        #region XmlFiles

        public static string UIDefinitionPath { get => ConfigurationManager.AppSettings["UIDefinitionPath"]; }

        public static string MenuUIFileName { get => ConfigurationManager.AppSettings["MenuUIFileName"]; }

        public static string PlayUIFileName { get => ConfigurationManager.AppSettings["PlayUIFileName"];  }

        public static string OptionsUIFileName { get => ConfigurationManager.AppSettings["OptionsUIFileName"]; }

        public static string HelpUIFileName { get => ConfigurationManager.AppSettings["HelpUIFileName"]; }

        #endregion
    }
}
