using System.Runtime.InteropServices;

namespace Gun_recoil_stabilizer.WinWrapper
{
    //
    // Windows RECT equivalent structure 
    //
    [StructLayout(LayoutKind.Sequential)]
    struct WinRect
    {
        public int mLeft;
        public int mTop;
        public int mRight;
        public int mBottom;
    }
}
