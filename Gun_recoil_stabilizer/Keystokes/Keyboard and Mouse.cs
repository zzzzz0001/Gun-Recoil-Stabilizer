using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;

using Gun_recoil_stabilizer.WinWrapper;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Input;
using System.IO;
using Gun_recoil_stabilizer.Speific_Data_Storage;
using Gun_recoil_stabilizer.WinHelper;

namespace Gun_recoil_stabilizer.Keystokes
{
    public class Keyboard_and_Mouse
    {
        public static bool Keyboard_Mouse_Key_Extractor_Continous_Run { get; set; }

        public static bool Mouse_click_Continous_Run { get; set; }

        public static Main_window formcontrol { get; set; }

        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(Int32 i);  //ref : https://hackmag.com/coding/diy-keylogger/

        private static Task Keyboard_Mouse_Key_Extractor()
        {
            #region track_keymap_we_applied_in_form_and_left_click_of_mouse
            List<Keys> pressed_set = new List<Keys>();

            while (Keyboard_Mouse_Key_Extractor_Continous_Run)
            {
                foreach (var i in Data_of_form.Keys_inc_dec_tog_leftclick_int)  //no need to run through everything
                {
                    if (i == -1)
                        continue;
                    int state = GetAsyncKeyState(i);
                    if (state != 0)
                    {
                        if (pressed_set.Contains((Keys)i) == false)  //key is going to be pressed
                        {
                            //Console.WriteLine(((Keys)i).ToString() + " pressed. Key value = " + i);
                            pressed_set.Add((Keys)i);

                            if (i == 1)
                            {
                                Console.WriteLine((Keys)1 + " pressed");
                                Mouse_click_Continous_Run = true;
                                
                                //CancellationTokenRegistration canceltoken = new CancellationTokenRegistration();

                                Task.Run(() => Mouse_click());
                            }
                            else if (i == Data_of_form.Stabilizer_toggle_key_int)
                            {
                                STOP();
                            }
                            else if (i == Data_of_form.Increase_stabilization_rate_key_int)
                            {
                                Data_of_form.Stabilization_rate += 1; //this can change the data in Date_of_form and a thread would be running in Main_window.cs file which can check and change it in the form
                                REFRESH_STABILIZATION_NUMERICUPDOWN();
                            }
                            else //the last one can only be decrease stabilisation
                            {
                                if (Data_of_form.Stabilization_rate > 0)
                                {
                                    Data_of_form.Stabilization_rate -= 1;  //this can change the data in Date_of_form and a thread would be running in Main_window.cs file which can check and change it in the form
                                    REFRESH_STABILIZATION_NUMERICUPDOWN();
                                }
                            }
                        }

                        else  //Key has been pressed already
                        {
                            //ignore mulitple of them
                        }
                    }
                    else  //not pressed
                    {
                        if (pressed_set.Contains((Keys)i) == true)
                        {
                            if (i == 1)
                            {
                                Mouse_click_Continous_Run = false;
                            }

                            Console.WriteLine(((Keys)i).ToString() + " released. Key value = " + i);
                            pressed_set.Remove((Keys)i);
                        }
                    }
                }
            }
            #endregion

            #region to_view_what_is_being_clicked
            //List<Keys> pressed_set = new List<Keys>();

            //while (Continous_Run)
            //{
            //    //var sw = File.AppendText(@"C:\Users\Roshan\Desktop\from author\keylogger.txt");

            //    Thread.Sleep(Data_of_form.Stabilization_rate);
            //    //Console.Clear();

            //    for (int i = 0; i <= 254; i++)
            //    {

            //        int state = GetAsyncKeyState(i);
            //        if (state != 0)
            //        {
            //            if (pressed_set.Contains((Keys)i) == false)  //key is going to be pressed
            //            {
            //                Console.WriteLine(((Keys)i).ToString() + " pressed. Key value = " + i);
            //                pressed_set.Add((Keys)i);
            //                //sw.WriteLine(((Keys)i).ToString() + "    " + i);

            //            }

            //            else  //Key has been pressed already
            //            {
            //                //ignore mulitple of them
            //            }
            //        }
            //        else  //not pressed
            //        {
            //            if (pressed_set.Contains((Keys)i) == true)
            //            {
            //                Console.WriteLine(((Keys)i).ToString() + " released. Key value = " + i);
            //                pressed_set.Remove((Keys)i);
            //            }
            //        }
            //    }

            //    //sw.Close();

            //}
            #endregion

            return Task.CompletedTask;
        }

        public static Task Mouse_click()
        {
            WinHelper.CursorPosition position = CursorHelper.GetCurrentPosition();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Position = " + position.X + " x " + position.Y);
            while (Mouse_click_Continous_Run)
            {
                //getting of initial position
                int total_x_moved = 0;
                int total_y_moved = 0;

                //fixation of recoil

                foreach (var line in Data_of_form.CSV_STORAGE)
                {
                    Thread.Sleep(Data_of_form.Stabilization_rate);   //this is needed as first bullet should go out

                    var xDelta = (int)line[0];
                    var yDelta = (int)line[1];

                    //var newX = position.X + xDelta;
                    //var newY = position.Y + yDelta;
                    //foreach (var screen in Screen.AllScreens)
                    //{
                    //    // is this the screen the cursor is on
                    //    var bounds = screen.Bounds;
                    //    if (position.X >= bounds.X && position.X <= (bounds.X + bounds.Width))
                    //    {
                    //        // this is our screen check if the delta will put us out
                    //        if (newX < bounds.X || newX > bounds.Right)
                    //        {
                    //            xDelta = -xDelta;
                    //        }
                    //        if (newY < bounds.Y || newY > bounds.Bottom)
                    //        {
                    //            yDelta = -yDelta;
                    //        }

                    //        // we don't need to scan through the rest
                    //        break;
                    //    }
                    //}

                    #region anti_anti_cheat_movement_mouse
                    int loop_run = 0;
                    loop_run = Math.Max(Math.Abs(xDelta), Math.Abs(yDelta));

                    total_x_moved += xDelta;
                    total_y_moved += xDelta;

                    while (loop_run > 0)
                    {
                        int x, y;
                        
                        if (xDelta > 0)
                        {
                            xDelta--;
                            x = 1;
                        }
                        else if (xDelta == 0)
                            x = 0;
                        else
                        {
                            xDelta++;
                            x = -1;
                        }

                        if (yDelta > 0)
                        {
                            yDelta--;
                            y = 1;
                        }
                        else if (yDelta == 0)
                            y = 0;
                        else
                        {
                            yDelta++;
                            y = -1;
                        }

                        CursorHelper.SetPositionRelative(x, y);
                        loop_run--;
                    }

                    #endregion

                    Console.WriteLine("Total x moved = " + total_x_moved + "     Total y moved = " + total_y_moved);

                }

                Thread.Sleep(Data_of_form.Stabilization_rate);

                CursorHelper.SetPositionAbsolute(position);

                position = CursorHelper.GetCurrentPosition();
                Console.WriteLine("Position = " + position.X + " x " + position.Y);

                //dont forget to deal with auto off stabilization



            }

            //while (true)
            //{
            //    Thread.Sleep(150);
            //    Console.Clear();
            //    var position = CursorHelper.GetCurrentPosition();
            //    Console.WriteLine("X = " + position.X + "      Y = " + position.Y);
            //}


            return Task.CompletedTask;
        }



        /// <summary>
        /// (Run by Start_function() defined in Main_window.cs (form code)
        /// </summary>
        /// <param name="Auto_off_stabilization"></param>
        /// <param name="Stabilization_rate"></param>
        /// <param name="precision_for_stabilization_time"></param>
        /// <param name="Increase_stabilization_rate_key"></param>
        /// <param name="Decrease_stablilization_rate_key"></param>
        /// <param name="Stabilizer_toggle_key"></param>
        /// <returns></returns>
        public static Task START(decimal Auto_off_stabilization, decimal Stabilization_rate, int precision_for_stabilization_time, Main_window form) //, string Increase_stabilization_rate_key, string Decrease_stablilization_rate_key, string Stabilizer_toggle_key
        {
            Keyboard_Mouse_Key_Extractor_Continous_Run = true;

            formcontrol = form;

            Data_of_form.Auto_off_stabilization = (int)(Auto_off_stabilization * (decimal)Math.Pow(10, precision_for_stabilization_time));

            Data_of_form.Stabilization_rate = (int)(Stabilization_rate * (decimal)Math.Pow(10, precision_for_stabilization_time));


            Keyboard_Mouse_Key_Extractor();

            return Task.CompletedTask;
        }

        public static void STOP()
        {
            Keyboard_Mouse_Key_Extractor_Continous_Run = false;
            Mouse_click_Continous_Run = false;

            formcontrol.Invoke(formcontrol.Stop_delegate);

            //also make sure the colour and text changes back as it could be triggered from the toggle key
        }

        public static void REFRESH_STABILIZATION_NUMERICUPDOWN()
        {
            formcontrol.Invoke(formcontrol.Refresh_delegate);
        }
    }

}
