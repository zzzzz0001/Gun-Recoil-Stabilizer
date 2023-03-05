using System.Runtime.InteropServices;

namespace Gun_recoil_stabilizer.WinWrapper
{
    //
    // Windows POINT equivalent structure
    //

    //this is being used in the function GetCursorPos() in class CursorWrapper.   ref : https://learn.microsoft.com/en-us/windows/win32/api/windef/ns-windef-point
    [StructLayout(LayoutKind.Sequential)]
    struct WinPoint
    {
        public int mX;
        public int mY;
    }
}
