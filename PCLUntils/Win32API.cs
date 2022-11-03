using System;
using System.Runtime.InteropServices;

namespace PCLUntils
{
    public sealed class Win32API
    {
        [DllImport("user32.dll", EntryPoint = "OpenClipboard")]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll", EntryPoint = "EmptyClipboard")]
        public static extern bool EmptyClipboard();
        [DllImport("user32.dll", EntryPoint = "CloseClipboard")]
        public static extern bool CloseClipboard();
        [DllImport("user32.dll", EntryPoint = "SetClipboardData")]
        public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hData);
    }
}