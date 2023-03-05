using System;
using System.Runtime.InteropServices;

namespace Gun_recoil_stabilizer.WinWrapper
{
    static class SendInputWrapper
    {
        //
        // DLL imports
        //
        #region DLL imports

        // SendInput API import
        [DllImport("User32.dll")]  //user32.dll is a module that contains Windows API functions related the Windows user interface
        private static extern uint SendInput(uint cNumInputs, ref Input rInputs, int cSize);
        //The function returns the number of events that it successfully inserted into the keyboard or mouse input stream. If the function
        //returns zero, the input was already blocked by another thread.

        #endregion

        //
        // Enumeratives
        //
        #region Enumeratives

        // Input types 
        public enum eInputTypes : int
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2,
        }

        // Mouse event flags
        [Flags]
        public enum eMouseEventFlags : uint
        {
            MOUSEEVENTF_MOVE = 0x0001,
            MOUSEEVENTF_LEFTDOWN = 0x0002,
            MOUSEEVENTF_LEFTUP = 0x0004,
            MOUSEEVENTF_RIGHTDOWN = 0x0008,
            MOUSEEVENTF_RIGHTUP = 0x0010,
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,
            MOUSEEVENTF_MIDDLEUP = 0x0040,
            MOUSEEVENTF_XDOWN = 0x0080,
            MOUSEEVENTF_XUP = 0x0100,
            MOUSEEVENTF_WHEEL = 0x0800,
            MOUSEEVENTF_VIRTUALDESK = 0x4000,
            MOUSEEVENTF_ABSOLUTE = 0x8000
        }

        #endregion

        //
        // Structures
        //
        #region Structures

        // Windows INPUT equivalent structure
        [StructLayout(LayoutKind.Sequential)]
        public struct Input
        {
            public eInputTypes mType;
            public InputUnion mData;

            //this has two information becuase of the definition of the second parameter of the function SendInput defined in User32.dll
            //here is the syntax      ref : https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-input

            //typedef struct tagINPUT {
            //                          DWORD type;
            //                          union {
            //                                      MOUSEINPUT mi;
            //                                      KEYBDINPUT ki;
            //                                      HARDWAREINPUT hi;
            //                                  }
            //                          DUMMYUNIONNAME;
            //                         }
        }

        // Windows union equivalent structure
        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)]
            public HardwareInput mHi;
            [FieldOffset(0)]
            public KeyDbInput mKi;
            [FieldOffset(0)]
            public MouseInput mMi;
        }

        // Windows HARDWAREINPUT equivalent structure
        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            //ref : https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-keybdinput

            public uint mMsg;
            public ushort mParamL;
            public ushort mParamH;
        }

        // Windows KEYBDINPUT equivalent structure
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyDbInput
        {
            //ref : https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-hardwareinput

            public ushort mVk;
            public ushort mScan;
            public uint mFlags;
            public uint mTime;
            public IntPtr mExtraInfo;
        }

        // Windows MOUSEINPUT equivalent structure
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            //ref : https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mouseinput

            public int mX;

            //The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the
            //value of the dwFlags member. Absolute data is specified as the x coordinate of the mouse; relative data is specified as
            //the number of pixels moved.

            public int mY;

            //The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the
            //value of the dwFlags member. Absolute data is specified as the y coordinate of the mouse; relative data is specified as
            //the number of pixels moved.

            public uint mMouseData;

            //If dwFlags contains MOUSEEVENTF_WHEEL, then mouseData specifies the amount of wheel movement.A positive value indicates
            //that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward,
            //toward the user.One wheel click is defined as WHEEL_DELTA, which is 120.

            //Windows Vista: If dwFlags contains MOUSEEVENTF_HWHEEL, then dwData specifies the amount of wheel movement. A positive
            //value indicates that the wheel was rotated to the right; a negative value indicates that the wheel was rotated to the
            //left. One wheel click is defined as WHEEL_DELTA, which is 120.

            //If dwFlags does not contain MOUSEEVENTF_WHEEL, MOUSEEVENTF_XDOWN, or MOUSEEVENTF_XUP, then mouseData should be zero.

            //If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then mouseData specifies which X buttons were pressed or released.
            //This value may be any combination of the following flags.

            //XBUTTON1            Set if the first X button is pressed or released.
            //0x0001	

            //XBUTTON2            Set if the second X button is pressed or released.
            //0x0002

            public eMouseEventFlags mFlags;

            //A set of bit flags that specify various aspects of mouse motion and button clicks.The bits in this member can be any
            //reasonable combination of the following values.

            //The bit flags that specify mouse button status are set to indicate changes in status, not ongoing conditions.For example,
            //if the left mouse button is pressed and held down, MOUSEEVENTF_LEFTDOWN is set when the left button is first pressed,
            //but not for subsequent motions. Similarly MOUSEEVENTF_LEFTUP is set only when the button is first released.

            //You cannot specify both the MOUSEEVENTF_WHEEL flag and either MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP flags simultaneously
            //in the dwFlags parameter, because they both require use of the mouseData field.

            //MOUSEEVENTF_MOVE                  Movement occurred.
            //0x0001

            //MOUSEEVENTF_LEFTDOWN              The left button was pressed.
            //0x0002

            //MOUSEEVENTF_LEFTUP                The left button was released.
            //0x0004

            //MOUSEEVENTF_RIGHTDOWN             The right button was pressed.
            //0x0008

            //MOUSEEVENTF_RIGHTUP               The right button was released.
            //0x0010

            //MOUSEEVENTF_MIDDLEDOWN            The middle button was pressed.
            //0x0020

            //MOUSEEVENTF_MIDDLEUP              The middle button was released.
            //0x0040

            //MOUSEEVENTF_XDOWN                 An X button was pressed.
            //0x0080

            //MOUSEEVENTF_XUP                   An X button was released.
            //0x0100

            //MOUSEEVENTF_WHEEL                 The wheel was moved, if the mouse has a wheel.The amount of movement is specified in mouseData.
            //0x0800

            //MOUSEEVENTF_HWHEEL                The wheel was moved horizontally, if the mouse has a wheel.The amount of movement is specified in mouseData.
            //0x1000	                        Windows XP/2000: This value is not supported.

            //MOUSEEVENTF_MOVE_NOCOALESCE       The WM_MOUSEMOVE messages will not be coalesced.The default behavior is to coalesce WM_MOUSEMOVE messages.
            //0x2000	                        Windows XP/2000: This value is not supported.

            //MOUSEEVENTF_VIRTUALDESK           Maps coordinates to the entire desktop. Must be used with MOUSEEVENTF_ABSOLUTE.
            //0x4000

            //MOUSEEVENTF_ABSOLUTE              The dx and dy members contain normalized absolute coordinates.If the flag is not set, dxand dy contain
            //0x8000	                        relative data (the change in position since the last reported position). This flag can be set, or not
            //set, regardless of what kind of mouse or other pointing device, if any, is connected to the system.
            //For further information about relative mouse motion, see the following Remarks section.

            public uint mTime;

            //The time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp.

            public IntPtr mExtraInfo;
            
            //An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information.

        }

        #endregion

        //
        // Static methods
        //
        #region Static methods

        // Send input
        public static bool SendInput(Input cInput)
        {
            return (SendInput(1, ref cInput, Marshal.SizeOf(new Input())) != WinBool.FALSE);
                            //1 here means only 1 input
                            //second argument is the actual task
                            //Last argument here is the size, in bytes, of an INPUT structure.
        }

        #endregion
    }
}
