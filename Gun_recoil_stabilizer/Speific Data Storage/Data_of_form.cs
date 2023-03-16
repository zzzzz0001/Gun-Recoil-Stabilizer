using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gun_recoil_stabilizer;
using Gun_recoil_stabilizer.Keystokes;
using Newtonsoft.Json.Linq;

namespace Gun_recoil_stabilizer.Speific_Data_Storage
{
    public static class Data_of_form
    {
        public static Main_window formcontrol { get; set; }
        public static bool Status { get; set; } = false;     //false means stopped, true means started

        //List<dynamic>   ->   we put int[] in the dynamic part
        public static List<dynamic> Spray_Data_points { get; private set; } = new List<dynamic>();

        public static List<int> Vertical_Data_points { get; private set; } = new List<int>();

        public static bool Dataset_chosen { get; private set; } = false;

        public static int Stabilizer_type { get; set; } = -1;     //Stabilizer_type -> 0 = vertical   1 = Spray Pattern

        public static int Auto_off_stabilization { get; set; } = 0;

        public static int Stabilization_rate { get; set; } = 0;

        public static int Increase_stabilization_rate_key_int { get; set; } = -1;

        public static int Decrease_stabililization_rate_key_int { get; set; } = -1;

        public static int Stabilizer_toggle_key_int { get; set; } = -1;

        public static List<int> Keys_inc_dec_tog_int { get; set; } = new List<int>()
        {
            -1, -1, -1
        };


        public static string ADD(string input)
        {
            Clear_uploaded_docs();
            bool error_happened = false;

            JObject item = new JObject();
            try
            {
                item = JObject.Parse(input);
            }
            catch (Exception E)
            {
                return E.Message;
            }
            

            if (item.SelectToken("Stabilizer_toggle_keybinding") != null)
                String_to_Keys_and_store(Stabilizer_toggle_key_: item.SelectToken("Stabilizer_toggle_keybinding").ToString());

            if (item.SelectToken("Stabilization_increase_keybinding") != null)
                String_to_Keys_and_store(Increase_stabilization_rate_key_: item.SelectToken("Stabilization_increase_keybinding").ToString());

            if (item.SelectToken("Stabilization_decrease_keybinding") != null)
                String_to_Keys_and_store(Decrease_stablilization_rate_key_: item.SelectToken("Stabilization_decrease_keybinding").ToString());
            
            if (item.SelectToken("Stabilization_rate") != null)
                Stabilization_rate = int.Parse(item.SelectToken("Stabilization_rate").ToString());

            if (item.SelectToken("Auto_off_stabilization") != null)
                Auto_off_stabilization = int.Parse(item.SelectToken("Auto_off_stabilization").ToString());

            if (item.SelectToken("GameName") != null)
                formcontrol.Text = item.SelectToken("GameName").ToString();

            if (item.SelectToken("GunName") != null)
                if (formcontrol.Text != "public")  //this is default one, if its not, then we should concat
                    formcontrol.Text = formcontrol.Text + " -> " + item.SelectToken("GunName").ToString();
                else
                    formcontrol.Text = item.SelectToken("GunName").ToString();

            var spray_points = JArray.Parse(item.SelectToken("Spray_data_points").ToString());
            foreach (var spray_point in spray_points)
            {
                List<int> spray_point_int = new List<int>();
                foreach (var spray_point_ in spray_point)
                {
                    try
                    {
                        spray_point_int.Add(int.Parse(spray_point_.ToString()));
                    }
                    catch
                    {
                        error_happened = true;
                        spray_point_int.Add(0);
                    }
                }


                Spray_Data_points.Add(spray_point_int);
            }

            var vertical_points = JArray.Parse(item.SelectToken("Vertical_data_points").ToString());
            foreach (var vertical_point in vertical_points)
            {
                try
                {
                    Vertical_Data_points.Add(int.Parse(vertical_point.ToString()));
                }
                catch
                {
                    error_happened = true;
                    Vertical_Data_points.Add(0);
                }
            }

            Dataset_chosen = true;

            if (error_happened == true)
                return "Error happened during importing, glitchy values have been replaced by 0";

            return null;
        }

        public static void Clear_uploaded_docs()
        {
            Spray_Data_points = new List<dynamic>();
            Dataset_chosen = false;
        }

        public static void String_to_Keys_and_store(string Increase_stabilization_rate_key_ = null, string Decrease_stablilization_rate_key_ = null, string Stabilizer_toggle_key_ = null)
        {
            if (Increase_stabilization_rate_key_ != "" && Increase_stabilization_rate_key_ != null)
            {
                Increase_stabilization_rate_key_int = Mapping_from_myname_to_key_value[Increase_stabilization_rate_key_];

                Keys_inc_dec_tog_int[0] = Increase_stabilization_rate_key_int;
            }
            

            if (Decrease_stablilization_rate_key_ != "" && Decrease_stablilization_rate_key_ != null)
            {
                Decrease_stabililization_rate_key_int = Mapping_from_myname_to_key_value[Decrease_stablilization_rate_key_];
               
                Keys_inc_dec_tog_int[1] = Decrease_stabililization_rate_key_int;
            }
            

            if (Stabilizer_toggle_key_ != "" && Stabilizer_toggle_key_ != null)
            {
                Stabilizer_toggle_key_int = Mapping_from_myname_to_key_value[Stabilizer_toggle_key_];

                Keys_inc_dec_tog_int[2] = Stabilizer_toggle_key_int;
            }
            
        }

        public static Dictionary<string, int> Mapping_from_myname_to_key_value { get; private set; } = new Dictionary<string, int>()
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

            { "Left Click", 1 },
            { "Right Click", 2 },
            { "Middle Click", 4 },
            { "Mouse Thumb 1", 5 },
            { "Mouse Thumb 2", 6 }

            #endregion
        };

        public static Dictionary<int, string> Mapping_from_key_value_to_myname { get; private set; } = new Dictionary<int, string>()
        {
            #region keyboard_commands

            #region F's

            { 112, "F1" },
            { 113, "F2" },
            { 114, "F3" },
            { 115, "F4" },
            { 116, "F5" },
            { 117, "F6" },
            { 118, "F7" },
            { 119, "F8" },
            { 120, "F9" },
            { 121, "F10" },
            { 122, "F11" },
            { 123, "F12" },
            #endregion

            #region cluster_of_stuff
            { 44, "PRTSC" },
            { 145, "SCRLK" },
            { 19,"PAUSE" },
            { 45, "INS" },
            { 36, "HOME"},
            { 46, "DEL" },
            { 35, "END" },
            { 33, "PGUP" },
            { 34, "PGDN" },
            #endregion

            #region arrow_marks
            { 38, "ARROW UP" },
            { 37, "ARROW LEFT" },
            { 40, "ARROW DOWN" },
            { 39, "ARROW RIGHT" },
            #endregion

            #region other_non_printable_characters
            { 144, "NUMLK" },
            { 8, "BACKSPACE" },
            { 13, "LEFT/RIGHT ENTER" },
            { 160, "LEFT SHIFT" },  //we are ignoring 16
            { 161, "RIGHT SHIFT" },  //we are ignoring 16
            { 162, "LEFT CTRL" },  //we are ignoring 17
            { 163, "RIGHT CTRL" },  //we are ignoring 17
            { 164, "LEFT ALT" },  //we are ignoring 18
            { 165, "RIGHT ALT" },  //we are ignoring 17, 18, 162
            { 91, "WINDOWS KEY" },
            { 20, "CAPSLOCK" },
            { 27, "ESC" },
            #endregion

            #region Printable_characters
            { 9, "TAB" },
            { 32, "SPACE" },
            { 192, "`" },

            #region numbers_on_top_of_alphabets
            { 49, "1" },
            { 50, "2" },
            { 51, "3" },
            { 52, "4" },
            { 53, "5" },
            { 54, "6" },
            { 55, "7" },
            { 56, "8" },
            { 57, "9" },
            { 48, "0" },
            #endregion

            #region seen_on_the_centre_of_keyboard
            { 189, "-" },
            { 187, "=" },
            { 219, "[" },
            { 221, "]" },
            { 220, @"\" },   //backslash is a escape character, so use @ before the string start or use double backslash
            { 186, ";" },
            { 222, "'" },
            { 188, "," },
            { 190, "." },
            { 191, "/" },
            #endregion

            #region number_pad
            { 96, "Numpad 0" },
            { 97, "Numpad 1" },
            { 98, "Numpad 2" },
            { 99, "Numpad 3" },
            { 100, "Numpad 4" },
            { 101, "Numpad 5" },
            { 102, "Numpad 6" },
            { 103, "Numpad 7" },
            { 104, "Numpad 8" },
            { 105, "Numpad 9" },
            { 111, "Numpad /" },
            { 106, "Numpad *" },
            { 109, "Numpad -" },
            { 107, "Numpad +" },
            { 110, "Numpad ." },
            #endregion

            #region Alphabets
            { 65, "A" },
            { 66, "B" },
            { 67, "C" },
            { 68, "D" },
            { 69, "E" },
            { 70, "F" },
            { 71, "G" },
            { 72, "H" },
            { 73, "I" },
            { 74, "J" },
            { 75, "K" },
            { 76, "L" },
            { 77, "M" },
            { 78, "N" },
            { 79, "O" },
            { 80, "P" },
            { 81, "Q" },
            { 82, "R" },
            { 83, "S" },
            { 84, "T" },
            { 85, "U" },
            { 86, "V" },
            { 87, "W" },
            { 88, "X" },
            { 89, "Y" },
            { 90, "Z" },
            #endregion

            #endregion

            #endregion

            #region mouse_commands

            { 1, "Left Click" },
            { 2, "Right Click" },
            { 4, "Middle Click" },
            { 5, "Mouse Thumb 1" },
            { 6, "Mouse Thumb 2" }

            #endregion
        };
    }
}
