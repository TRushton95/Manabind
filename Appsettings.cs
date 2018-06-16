using System.Configuration;

namespace Manabind
{
    public static class AppSettings
    {
        public static string UIDefinitionPath { get => ConfigurationManager.AppSettings["UIDefinitionPath"]; }

        public static string MenuUIFileName { get => ConfigurationManager.AppSettings["MenuUIFileName"]; }
    }
}
