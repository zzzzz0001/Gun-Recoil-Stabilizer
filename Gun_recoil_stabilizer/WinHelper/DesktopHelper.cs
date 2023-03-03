using System;
using Gun_recoil_stabilizer.WinWrapper;

namespace Gun_recoil_stabilizer.WinHelper
{
    //
    // Desktop resolution helper
    //
    static class DesktopHelper
    {
        //
        // Static methods
        //
        #region Static methods

        // Get desktop resolution
        public static ResolutionInfo GetResolution()
        {
            IntPtr desktop_hwnd = GetWindowRectWrapper.GetDesktopWindow();

            var desktop_rect = new WinRect();
            if (!GetWindowRectWrapper.GetWindowRectangle(desktop_hwnd, ref desktop_rect))
            {
                return new ResolutionInfo();
            }
            else
            {
                return new ResolutionInfo(desktop_rect);
            }
        }

        #endregion
    }
}
