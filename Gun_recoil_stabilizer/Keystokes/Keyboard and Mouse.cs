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
        public static bool Continous_Run { get; private set; }

        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(Int32 i);  //ref : https://hackmag.com/coding/diy-keylogger/

        private static Task Keyboard_Mouse_Key_Extractor()
        {
            
            #region useless
            //while (Continous_Run)
            //{

            //    Thread.Sleep(Data_of_form.Stabilization_rate);
            //    Console.Clear();

            //    if (GetAsyncKeyState(1) != 0)  //1 is for LButton   check up "public enum Keys"
            //    {
            //        //this means left click has been pressed

            //        //DO THE STABILISATION

            //        Console.WriteLine("mouse clicked");
            //    }

            //}
            #endregion

            #region to_view_what_is_being_clicked
            List<Keys> pressed_set = new List<Keys>();

            while (Continous_Run)
            {
                Thread.Sleep(Data_of_form.Stabilization_rate);
                //Console.Clear();

                for (int i = 0; i <= 254; i++)
                {
                    int state = GetAsyncKeyState(i);
                    if (state != 0)
                    {
                        if (pressed_set.Contains((Keys)i) == false)  //key is going to be pressed
                        {
                            Console.WriteLine(((Keys)i).ToString() + "pressed");
                            pressed_set.Add((Keys)i);
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
                            Console.WriteLine(((Keys)i).ToString() + "released");
                            pressed_set.Remove((Keys)i);
                        } 
                    }
                }
                #endregion
            }


            return Task.CompletedTask;
        }



        public static Task START(decimal Auto_off_stabilization, decimal Stabilization_rate, int precision_for_stabilization_time, string Increase_stabilization_rate_key, string Decrease_stablilization_rate_key, string Stabilizer_toggle_key) //, string Increase_stabilization_rate_key, string Decrease_stablilization_rate_key, string Stabilizer_toggle_key
        {
            //public static int Auto_off_stabilization { get; set; } = 0;

            //public static int Stabilization_rate { get; set; } = 0;

                    //public static Keys Increase_stabilization_rate_key { get; set; }

                    //public static Keys Decrease_stablilization_rate_key { get; set; }

                    //public static Keys Stabilizer_toggle_key { get; set; }

            Continous_Run = true;

            Data_of_form.Auto_off_stabilization = (int)(Auto_off_stabilization * (decimal)Math.Pow(10, precision_for_stabilization_time));

            Data_of_form.Stabilization_rate = (int)(Stabilization_rate * (decimal)Math.Pow(10, precision_for_stabilization_time));

            Data_of_form.String_to_Keys_and_store(Increase_stabilization_rate_key, Decrease_stablilization_rate_key, Stabilizer_toggle_key);


            Keyboard_Mouse_Key_Extractor();

            return Task.CompletedTask;
        }

        public static void STOP()
        {
            Continous_Run = false;
        }

    }

}
