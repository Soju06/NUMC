using NUMC.Script;

namespace NUMC.Plugin.Runtime
{
    public interface IRuntimeDialog
    {
        bool ShowDialog(RuntimeScript runtimeScript, KeyObject obj);
    }
}