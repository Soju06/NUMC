namespace NUMC.Macro
{
    public interface IMacroModule
    {
        string BUTTON_NAME { get; }

        bool GET_FULL_CODE { get; }

        char MODULE_NAME { get; }

        bool SHOW_DIALOG(ref string[] FULL_CODE, out string NAME, out string RCODE);

        bool CODE_RESULT(string DATA, ref string[] FULL_CODE, out string NAME, out string RCODE);

        void RUN_CODE(string DATA, ref string[] FULL_CODE, ref long CURRENT_LINE);
    }
}