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
            while (Mouse_click_Continous_Run)
            {
                Console.WriteLine("hehe" + Data_of_form.Stabilization_rate);



                Thread.Sleep(Data_of_form.Stabilization_rate);
            }


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
