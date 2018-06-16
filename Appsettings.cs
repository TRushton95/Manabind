using System.Configuration;

namespace Manabind
{
    public static class Appsettings
    {
        public static string MenuUIFileName { get => ConfigurationManager.AppSettings["MenuUIFileName"]; }

        public static string UIDefinitionPath { get => ConfigurationManager.AppSettings["UIDefinitionPath"]; }
    }
}
