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
        public static extern IntPtr GetDesktopWindow();     //ref : https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdesktopwindow

        // GetCursorPos API import
        [DllImport("User32.Dll")]
        private static extern int GetWindowRect(IntPtr cHWnd, ref WinRect rRect);   //ref : https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowrect
                                                //first parameter - A handle to the window.
                                                //second parameter - A pointer to a RECT structure that receives the screen coordinates of the
                                                //                   upper-left and lower-right corners of the window.

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
