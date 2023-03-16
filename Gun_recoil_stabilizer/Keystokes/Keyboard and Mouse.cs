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
        public static bool Mouse_Key_Extractor_Continous_Run { get; set; }

        public static bool Mouse_click_Continous_Run { get; set; }

        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(Int32 i);

        private static Task Mouse_extractor()
        {
            bool pressed_set = false;

            while (Mouse_Key_Extractor_Continous_Run)
            {
                int state = GetAsyncKeyState(1);
                if (state != 0)
                {
                    if (pressed_set == false)  //key is going to be pressed
                    {
                        pressed_set = true;


                        Console.WriteLine(Keys.LButton + " pressed");
                        Mouse_click_Continous_Run = true;

                        //auto off stabilization stuff
                        CancellationTokenSource source = new CancellationTokenSource();
                        source.CancelAfter(Data_of_form.Auto_off_stabilization);

                        if (Data_of_form.Auto_off_stabilization == 0)
                        {
                            Task.Run(() => Mouse_click());
                        }
                        else
                            Task.Run(() => Mouse_click(source.Token), source.Token);
                    }
                }
                else  //not pressed
                {
                    if (pressed_set == true)
                    {
                        Mouse_click_Continous_Run = false;

                        Console.WriteLine(Keys.LButton.ToString() + " released. Key value = " + 1);
                        pressed_set = false;
                    }
                }
            }

            return Task.CompletedTask;
        }

        public static Task Keyboard_Key_Extractor()
        {
            List<Keys> pressed_set = new List<Keys>();

            while (true)
            {
                var hotkey = Data_of_form.Keys_inc_dec_tog_int.ToList(); //has to do ToList() as we dont need copy by reference as it could break the foreach loop if the variable change while its running
                foreach (var i in hotkey)
                {
                    if (i == -1)
                        continue;
                    int state = GetAsyncKeyState(i);

                    if (state != 0)
                    {
                        if (pressed_set.Contains((Keys)i) == false)  //key is going to be pressed
                        {
                            pressed_set.Add((Keys)i);

                            if (i == Data_of_form.Stabilizer_toggle_key_int)
                            {
                                if (Data_of_form.Status == true)
                                    Task.Run(() => STOP());
                                else
                                    Task.Run(() => START_from_button_action_delegate());
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
                    }

                    else  //not pressed
                    {
                        if (pressed_set.Contains((Keys)i) == true)
                        {
                            Console.WriteLine(((Keys)i).ToString() + " released. Key value = " + i);
                            pressed_set.Remove((Keys)i);
                        }
                    }

                }
            }

        }

        public static Task Mouse_click(CancellationToken token = default)
        {
            WinHelper.CursorPosition position = CursorHelper.GetCurrentPosition();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Position = " + position.X + " x " + position.Y);

            if (Data_of_form.Stabilizer_type == 1)
            {
                while (Mouse_click_Continous_Run == true)
                {
                    //getting of initial position
                    int total_x_moved = 0;
                    int total_y_moved = 0;


                    foreach (var line in Data_of_form.Spray_Data_points)
                    {
                        if (token != default && token.IsCancellationRequested == true)
                            return Task.CompletedTask;

                        Thread.Sleep(Data_of_form.Stabilization_rate);   //this is needed as first bullet should go out

                        if (token != default && token.IsCancellationRequested == true)
                            return Task.CompletedTask;

                        int xDelta = 0, yDelta = 0;

                        xDelta = (int)line[0];
                        yDelta = (int)line[1];

                        
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
                    //Thread.Sleep(timeout: );

                    position = CursorHelper.GetCurrentPosition();
                    Console.WriteLine("Position = " + position.X + " x " + position.Y);

                }
            }

            else if (Data_of_form.Stabilizer_type == 0)
            {
                while (Mouse_click_Continous_Run == true)
                {
                    //getting of initial position
                    int total_x_moved = 0;
                    int total_y_moved = 0;


                    foreach (var line in Data_of_form.Vertical_Data_points)
                    {
                        if (token != default && token.IsCancellationRequested == true)
                            return Task.CompletedTask;

                        Thread.Sleep(Data_of_form.Stabilization_rate);   //this is needed as first bullet should go out

                        if (token != default && token.IsCancellationRequested == true)
                            return Task.CompletedTask;

                        int xDelta = 0, yDelta = 0;

                        xDelta = 0;
                        yDelta = line;


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
                    //Thread.Sleep(timeout: );

                    position = CursorHelper.GetCurrentPosition();
                    Console.WriteLine("Position = " + position.X + " x " + position.Y);

                }
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
        public static Task START()
        {
            Mouse_Key_Extractor_Continous_Run = true;

            Mouse_extractor();

            return Task.CompletedTask;
        }

        public static Task STOP()
        {
            Mouse_Key_Extractor_Continous_Run = false;
            Mouse_click_Continous_Run = false;

            Data_of_form.formcontrol.Invoke(Data_of_form.formcontrol.Stop_delegate);

            return Task.CompletedTask;
        }

        public static Task START_from_button_action_delegate()
        {
            Data_of_form.formcontrol.Invoke(Data_of_form.formcontrol.Start_function_delegate);
            return Task.CompletedTask;
        }

        public static void REFRESH_STABILIZATION_NUMERICUPDOWN()
        {
            Data_of_form.formcontrol.Invoke(Data_of_form.formcontrol.Refresh_delegate);
        }
    }

}
