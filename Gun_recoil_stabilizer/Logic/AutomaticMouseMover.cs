using Gun_recoil_stabilizer.WinHelper;
using System.Windows.Forms;

namespace Gun_recoil_stabilizer.Logic
{
    class AutomaticMouseMover
    {
        //
        // Constants
        //
        #region Constants

        // Default moving pixel
        private const int DEFAULT_MOVING_PIXEL = 5;

        #endregion

        //
        // Enumeratives
        //
        #region Enumeratives

        // Moving directions
        private enum eMovingDirections
        {
            BACKWARD,
            FORWARD,
        }

        #endregion

        //
        // Members
        //
        #region Members

        // Last cursor position
        private CursorPosition mLastCursorPos;
        // Moving pixels amount
        private int mMovingPixel;
        // Moving direction
        private eMovingDirections mMovingDir;

        #endregion

        //
        // Public methods
        //
        #region Public methods

        // Constructor
        public AutomaticMouseMover()
        {
            Initialize(DEFAULT_MOVING_PIXEL);
        }

        // Initialize
        public void Initialize(int cMovingPixel)
        {
            mMovingDir = eMovingDirections.FORWARD;
            mMovingPixel = cMovingPixel;
            mLastCursorPos = CursorHelper.GetCurrentPosition();
        }

        // Move mouse
        public void MoveMouse()
        {
            // Get current position
            var curr_pos = CursorHelper.GetCurrentPosition();

            // Move cursor only if position is not changed, in order to not disturb if the user is working
            if (curr_pos == mLastCursorPos)
            {
                // Get pixel movement depending on the direction
                int mov_pixel_rel = (mMovingDir == eMovingDirections.BACKWARD) ? (-1 * mMovingPixel) : mMovingPixel;
                // Move cursor
                MoveCursor(mov_pixel_rel);
                // Update moving direction
                UpdateMovingDir();
            }

            // Reset last cursor position
            mLastCursorPos = CursorHelper.GetCurrentPosition();
        }

        #endregion

        //
        // Private methods
        //
        #region Private methods

        // Move cursor
        private void MoveCursor(int cDeltaPixel)
        {
            // adjust the deltas in the opposite direction if they are outside of bounds. This means we won't
            // try to move the cursor outside the available display area.


            // scan through the available screens
            var position = CursorHelper.GetCurrentPosition();
            var xDelta = cDeltaPixel;
            var yDelta = cDeltaPixel;
            var newX = position.X + xDelta;
            var newY = position.Y + yDelta;
            foreach (var screen in Screen.AllScreens)
            {
                // is this the screen the cursor is on
                var bounds = screen.Bounds;
                if (position.X >= bounds.X && position.X <= (bounds.X + bounds.Width))
                {
                    // this is our screen check if the delta will put us out
                    if (newX < bounds.X || newX > bounds.Right)
                    {
                        xDelta = -xDelta;
                    }
                    if (newY < bounds.Y || newY > bounds.Bottom)
                    {
                        yDelta = -yDelta;
                    }

                    // we don't need to scan through the rest
                    break;
                }
            }

            CursorHelper.SetPositionRelative(xDelta, yDelta);
        }

        // Update moving direction
        private void UpdateMovingDir()
        {
            if (mMovingDir == eMovingDirections.BACKWARD)
            {
                mMovingDir = eMovingDirections.FORWARD;
            }
            else
            {
                mMovingDir = eMovingDirections.BACKWARD;
            }
        }

        #endregion
    }
}
