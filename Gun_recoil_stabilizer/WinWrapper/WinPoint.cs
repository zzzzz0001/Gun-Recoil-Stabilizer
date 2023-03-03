using System.Runtime.InteropServices;

namespace Gun_recoil_stabilizer.WinWrapper
{
    //
    // Windows POINT equivalent structure
    //
    [StructLayout(LayoutKind.Sequential)]
    struct WinPoint
    {
        public int mX;
        public int mY;
    }
}
