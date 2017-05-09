namespace NumLock
{
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    class Keyboard
    {
        [DllImport("user32.dll")]
        internal static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll")]
#pragma warning disable IDE1006 // Naming Styles
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
#pragma warning restore IDE1006 // Naming Styles

        public static void PressKeyboardButton(Keys keyCode)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;

            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        public static bool CheckState(Keys key)
        {
            return GetKeyState((int)key) == 1;
        }
    }
}
