namespace NUMC.Handler
{
    public class Handler
    {
        public static event LoadSetting LoadSetting;

        public static void LoadSettings(string path)
        {
            LoadSetting(path);
        }
    }

    public delegate void LoadSetting(string path);
}