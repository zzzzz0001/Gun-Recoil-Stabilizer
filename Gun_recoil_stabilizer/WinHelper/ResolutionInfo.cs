using Gun_recoil_stabilizer.WinWrapper;

namespace Gun_recoil_stabilizer.WinHelper
{
    // 
    // Resolution info structure
    //
    class ResolutionInfo
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

        // Height
        private int mHeight;
        // Width
        private int mWidth;

        #endregion

        //
        // Public methods
        //
        #region Public methods

        // Constructor - Empty
        public ResolutionInfo()
        {
            Invalidate();
        }

        // Constructor - From dimensions
        public ResolutionInfo(int cHeight,
                              int cWidth)
        {
            mHeight = cHeight;
            mWidth = cWidth;
        }

        // Constructor - From Windows RECT structure
        public ResolutionInfo(WinRect pRect)
        {
            mHeight = pRect.mBottom;
            mWidth = pRect.mRight;
        }

        // Invalidate 
        public void Invalidate()
        {
            mHeight = INVALID_VALUE;
            mWidth = INVALID_VALUE;
        }

        // Get if invalidated
        public bool IsInvalidated()
        {
            return ((mHeight == INVALID_VALUE) && (mWidth == INVALID_VALUE));
        }

        #endregion

        //
        // Properties
        //
        #region Properties

        // Height property
        public int Height
        {
            get { return mHeight; }
        }

        // Width property
        public int Width
        {
            get { return mWidth; }
        }

        #endregion
    }
}
