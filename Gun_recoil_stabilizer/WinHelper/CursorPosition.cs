using System;
using Gun_recoil_stabilizer.WinWrapper;

namespace Gun_recoil_stabilizer.WinHelper
{
    //
    // Position structure
    //

    //they uses fucntion made in WinWrapper to make simpler functions
    class CursorPosition         //constructor used in GetCurrentPosition() function in CursorHelper
    {
        //
        // Constants
        //
        #region Constants

        // Invalid value
        private const int INVALID_VALUE = -1;

        #endregion

        //
        // Members
        //
        #region Members

        // X
        private int mX;
        // Y
        private int mY;

        #endregion

        //
        // Public methods
        //
        #region Public methods

        // Constructor - Empty
        public CursorPosition()
        {
            Invalidate();
        }

        // Constructor - From position
        public CursorPosition(int cX,
                              int cY)
        {
            MoveToAbsolute(cX, cY);
        }

        // Constructor - From Windows POINT structure
        public CursorPosition(WinPoint cPoint)
        {
            MoveToAbsolute(cPoint.mX, cPoint.mY);
        }

        // Invalidate
        public void Invalidate()
        {
            mX = INVALID_VALUE;
            mY = INVALID_VALUE;
        }

        // Get if invalidated
        public bool IsInvalidated()
        {
            return ((mX == INVALID_VALUE) && (mY == INVALID_VALUE));
        }

        // Move to absolute position
        public void MoveToAbsolute(int cX,
                                   int cY)
        {
            mX = cX;
            mY = cY;
        }

        // Move to relative position
        public void MoveToRelative(int cDeltaX,
                                   int cDeltaY)
        {
            mX += cDeltaX;
            mY += cDeltaY;
        }

        // Equal operator
        public static bool operator ==(CursorPosition cPos1,
                                       CursorPosition cPos2)
        {
            return ((cPos1.mX == cPos2.mX) && (cPos1.mY == cPos2.mY));
        }

        // Not equal operator
        public static bool operator !=(CursorPosition cPos1,
                                       CursorPosition cPos2)
        {
            return !(cPos1 == cPos2);
        }

        #endregion

        //
        // Properties
        //
        #region Properties

        // X property
        public int X
        {
            get { return mX; }
        }

        // Y property
        public int Y
        {
            get { return mY; }
        }

        #endregion
    }
}
