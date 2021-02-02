namespace NUMC.Design.Controls
{
    public sealed class Consts
    {
        public static int Padding = 10;

        public static int ScrollBarSize = 15;
        public static int ArrowButtonSize = 15;
        public static int MinimumThumbSize = 30;

        public static int CheckBoxSize = 12;
        public static int RadioButtonSize = 12;
    }

    public enum ControlState
    {
        Normal,
        Hover,
        Pressed
    }

    public enum MessageBoxButtons
    {
        Ok,
        Close,
        OkCancel,
        YesNo,
        YesNoCancel,
        AbortRetryIgnore,
        RetryCancel
    }
}