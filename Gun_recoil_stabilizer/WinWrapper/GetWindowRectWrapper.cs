using System;
using System.Runtime.InteropServices;

namespace Gun_recoil_stabilizer.WinWrapper
{
    static class GetWindowRectWrapper
    {
        //
        // DLL imports
        //
        #region DLL imports

        // GetCursorPos API import 
        [DllImport("User32.Dll")]
        public static extern IntPtr GetDesktopWindow();

        // GetCursorPos API import
        [DllImport("User32.Dll")]
        private static extern int GetWindowRect(IntPtr cHWnd, ref WinRect rRect);

        #endregion

        //
        // Static methods
        //
        #region Static methods

        // Get window rectangle
        public static bool GetWindowRectangle(IntPtr cHWnd,
                                              ref WinRect rRect)
        {
            return (GetWindowRect(cHWnd, ref rRect) != WinBool.FALSE);
        }

        #endregion
    }
}
