using System;
using System.Configuration;

namespace Manabind
{
    public static class AppSettings
    {
        #region MapFiles

        public static string MapFileLocation { get => ConfigurationManager.AppSettings["MapFileLocation"]; }

        #endregion

        #region Window

        public static int WindowWidth { get => Int32.Parse(ConfigurationManager.AppSettings["WindowWidth"]); }

        public static int WindowHeight { get => Int32.Parse(ConfigurationManager.AppSettings["WindowHeight"]); }

        #endregion

        #region XmlFiles

        public static string UIDefinitionPath { get => ConfigurationManager.AppSettings["UIDefinitionPath"]; }

        public static string MenuUIFileName { get => ConfigurationManager.AppSettings["MenuUIFileName"]; }

        public static string PlayUIFileName { get => ConfigurationManager.AppSettings["PlayUIFileName"];  }

        public static string EditorUIFileName { get => ConfigurationManager.AppSettings["EditorUIFileName"]; }

        public static string OptionsUIFileName { get => ConfigurationManager.AppSettings["OptionsUIFileName"]; }

        #endregion

        #region Board

        public static string DefaultBoardWidth { get => ConfigurationManager.AppSettings["DefaultBoardWidth"]; }

        public static string DefaultBoardHeight { get => ConfigurationManager.AppSettings["DefaultBoardHeight"]; }

        #endregion
    }
}
