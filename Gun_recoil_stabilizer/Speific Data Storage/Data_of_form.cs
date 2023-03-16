﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gun_recoil_stabilizer;
using Gun_recoil_stabilizer.Keystokes;

namespace Gun_recoil_stabilizer.Speific_Data_Storage
{
    public static class Data_of_form
    {
        public static Main_window formcontrol { get; set; }
        public static bool Status { get; set; } = false;     //false means stopped, true means started

        //List<dynamic>   ->   we put int[] in the dynamic part
        public static List<dynamic> CSV_STORAGE { get; private set; } = new List<dynamic>();

        public static bool Dataset_chosen { get; private set; } = false;

        public static int Stabilizer_type { get; set; } = -1;     //Stabilizer_type -> 0 = vertical   1 = Spray Pattern

        public static int Auto_off_stabilization { get; set; } = 0;

        public static int Stabilization_rate { get; set; } = 0;

        public static int Increase_stabilization_rate_key_int { get; set; }

        public static int Decrease_stabililization_rate_key_int { get; set; }

        public static int Stabilizer_toggle_key_int { get; set; }

        public static bool Precise_point_check_box { get; set; }

        public static List<int> Keys_inc_dec_tog_int { get; set; } = new List<int>()
        {
            -1, -1, -1
        };

        //public static Task Keyboard_extractor_task { get; set; } = null;

        [Obsolete("This Method is Deprecated")]
        public static void ADD(Tuple<int, int> input)
        {
            CSV_STORAGE.Add(input);
            Dataset_chosen = true;
        }

        public static string ADD(List<string> input)
        {
            Clear_uploaded_docs();
            bool error_happened = false;

            //header check
            var header = input[0];
            var headers = header.Split(',');
            foreach (var item in headers)
            {
                try
                {
                    int.Parse(item);
                }
                catch
                {
                    //error occurued
                    //which means that the first line is a header
                    input.RemoveAt(0);
                    break;
                }
            }

            List<dynamic> returned_data = new List<dynamic>();

            switch (Stabilizer_type)
            {
                case 0:
                    {
                        returned_data = Stabilizers.Stabilizer_reading.Vertical_stabilizer(input);
                    }
                    break;
                case 1:
                    {
                        returned_data = Stabilizers.Stabilizer_reading.Spray_pattern_stabilizer(input);
                    }
                    break;
            }

            error_happened = returned_data[0];
            CSV_STORAGE = returned_data[1];
            Dataset_chosen = returned_data[2];
            

            if (error_happened == true)
                return "Error happened during importing, glitchy values have been replaced by 0";

            return null;
        }

        public static void Clear_uploaded_docs()
        {
            CSV_STORAGE = new List<dynamic>();
            Dataset_chosen = false;
        }

        public static void String_to_Keys_and_store(string Increase_stabilization_rate_key_ = null, string Decrease_stablilization_rate_key_ = null, string Stabilizer_toggle_key_ = null)
        {
            //if not started, starting up the keyboard_extractor function
            //if (Keyboard_extractor_task == null)
            //    Keyboard_extractor_task = Task.Run(() => Keyboard_and_Mouse.Keyboard_Key_Extractor());   //this would run forever

            //   Increase_stabilization_rate_key = Increase_stabilization_rate_key_;

            //finding the byte value of it

            if (Increase_stabilization_rate_key_ != "" && Increase_stabilization_rate_key_ != null)
            {
                Increase_stabilization_rate_key_int = Mapping_from_myname_to_key_valuye[Increase_stabilization_rate_key_];

                Keys_inc_dec_tog_int[0] = Increase_stabilization_rate_key_int;
            }
            

            if (Decrease_stablilization_rate_key_ != "" && Decrease_stablilization_rate_key_ != null)
            {
                Decrease_stabililization_rate_key_int = Mapping_from_myname_to_key_valuye[Decrease_stablilization_rate_key_];
               
                Keys_inc_dec_tog_int[1] = Decrease_stabililization_rate_key_int;
            }
            

            if (Stabilizer_toggle_key_ != "" && Stabilizer_toggle_key_ != null)
            {
                Stabilizer_toggle_key_int = Mapping_from_myname_to_key_valuye[Stabilizer_toggle_key_];

                Keys_inc_dec_tog_int[2] = Stabilizer_toggle_key_int;
            }
            
        }

        public static Dictionary<string, int> Mapping_from_myname_to_key_valuye { get; private set; } = new Dictionary<string, int>()
        {
            #region keyboard_commands

            #region F's
            { "F1", 112 },
            { "F2", 113 },
            { "F3", 114 },
            { "F4", 115 },
            { "F5", 116 },
            { "F6", 117 },
            { "F7", 118 },
            { "F8", 119 },
            { "F9", 120 },
            { "F10", 121 },
            { "F11", 122 },
            { "F12", 123 },
            #endregion

            #region cluster_of_stuff
            { "PRTSC", 44 },
            { "SCRLK", 145 },
            { "PAUSE", 19 },
            { "INS", 45 },
            { "HOME", 36 },
            { "DEL", 46 },
            { "END", 35 },
            { "PGUP", 33 },
            { "PGDN", 34 },
            #endregion

            #region arrow_marks
            { "ARROW UP", 38 },
            { "ARROW LEFT", 37 },
            { "ARROW DOWN", 40 },
            { "ARROW RIGHT", 39 },
            #endregion

            #region other_non_printable_characters
            { "NUMLK", 144 },
            { "BACKSPACE", 8 },
            { "LEFT/RIGHT ENTER", 13 },
            { "LEFT SHIFT", 160 },  //we are ignoring 16
            { "RIGHT SHIFT", 161 },  //we are ignoring 16
            { "LEFT CTRL", 162 },  //we are ignoring 17
            { "RIGHT CTRL", 163 },  //we are ignoring 17
            { "LEFT ALT", 164 },  //we are ignoring 18
            { "RIGHT ALT", 165 },  //we are ignoring 17, 18, 162
            { "WINDOWS KEY", 91 },
            { "CAPSLOCK", 20 },
            { "ESC", 27 },
            #endregion

            #region Printable_characters
            { "TAB", 9 },
            { "SPACE", 32 },
            { "`", 192 },

            #region numbers_on_top_of_alphabets
            { "1", 49 },
            { "2", 50 },
            { "3", 51 },
            { "4", 52 },
            { "5", 53 },
            { "6", 54 },
            { "7", 55 },
            { "8", 56 },
            { "9", 57 },
            { "0", 48 },
            #endregion

            #region seen_on_the_centre_of_keyboard
            { "-", 189 },
            { "=", 187 },
            { "[", 219 },
            { "]", 221 },
            { @"\", 220 },   //backslash is a escape character, so use @ before the string start or use double backslash
            { ";", 186 },
            { "'", 222 },
            { ",", 188 },
            { ".", 190 },
            { "/", 191 },
            #endregion

            #region number_pad
            { "Numpad 0", 96 },
            { "Numpad 1", 97 },
            { "Numpad 2", 98 },
            { "Numpad 3", 99 },
            { "Numpad 4", 100 },
            { "Numpad 5", 101 },
            { "Numpad 6", 102 },
            { "Numpad 7", 103 },
            { "Numpad 8", 104 },
            { "Numpad 9", 105 },
            { "Numpad /", 111 },
            { "Numpad *", 106 },
            { "Numpad -", 109 },
            { "Numpad +", 107 },
            { "Numpad .", 110 },
            #endregion

            #region Alphabets
            { "A", 65 },
            { "B", 66 },
            { "C", 67 },
            { "D", 68 },
            { "E", 69 },
            { "F", 70 },
            { "G", 71 }, 
            { "H", 72 },
            { "I", 73 },
            { "J", 74 },
            { "K", 75 },
            { "L", 76 },
            { "M", 77 },
            { "N", 78 },
            { "O", 79 },
            { "P", 80 },
            { "Q", 81 },
            { "R", 82 },
            { "S", 83 },
            { "T", 84 },
            { "U", 85 },
            { "V", 86 },
            { "W", 87 },
            { "X", 88 },
            { "Y", 89 },
            { "Z", 90 },
            #endregion

            #endregion

            #endregion

            #region mouse_commands

            { "Left Click", 1 },   //this one is important
            { "Right Click", 2 },
            { "Middle Click", 4 },
            { "Mouse Thumb 1", 5 },
            { "Mouse Thumb 2", 6 }

            #endregion
        };
    }
}
