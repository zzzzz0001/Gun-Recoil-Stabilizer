using System.Runtime.InteropServices;

namespace Gun_recoil_stabilizer.WinWrapper
{
    //
    // Windows RECT equivalent structure 
    //

    //this is being used in GetWindowRect() in class GetWindowRectWrapper      ref : https://learn.microsoft.com/en-us/windows/win32/api/windef/ns-windef-rect
    [StructLayout(LayoutKind.Sequential)]
    struct WinRect    //ref : https://learn.microsoft.com/en-us/windows/win32/api/windef/ns-windef-rect
    {
        public int mLeft;
        public int mTop;
        public int mRight;
        public int mBottom;
    }
}
