using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gun_recoil_stabilizer;

namespace Gun_recoil_stabilizer.Speific_Data_Storage
{
    public static class Data_of_form
    {
        public static List<Tuple<int, int>> CSV_STORAGE { get; private set; } = new List<Tuple<int, int>>();

        public static bool Dataset_chosen { get; private set; } = false;

        public static int Auto_off_stabilization { get; set; } = 0;

        public static int Stabilization_rate { get; set; } = 0;

        public static Keys Increase_stabilization_rate_key { get; set; }

        public static Keys Decrease_stablilization_rate_key { get; set; }

        public static Keys Stabilizer_toggle_key { get; set; }

        public static void ADD(Tuple<int, int> input)
        {
            CSV_STORAGE.Add(input);
            Dataset_chosen = true;
        }

        public static string ADD(List<string> input)
        {
            Clear();

            foreach (var piece in input)
            {
                var pieces = piece.Split(',');

                if (pieces.Count() != 2)
                {
                    //this means we sent more paramters for no reason column wise

                    return "Please provide two values per row sperated by comma";
                }
                try
                {
                    Tuple<int, int> item = new Tuple<int, int>(int.Parse(pieces[0].Trim()), int.Parse(pieces[1].Trim()));
                    CSV_STORAGE.Add(item);
                    Dataset_chosen = true;
                }

                catch (Exception e)
                {
                    if (e.Message == "Input string was not in a correct format.")
                        return "One or more of the numbers in the csv file cannot be parsed to a number";

                    return e.Message;
                }
            }

            return null;
        }

        public static void Clear()
        {
            CSV_STORAGE = new List<Tuple<int, int>>();
            Dataset_chosen = false;
        }

        public static void String_to_Keys_and_store(string Increase_stabilization_rate_key_ = null, string Decrease_stablilization_rate_key_ = null, string Stabilizer_toggle_key_ = null)
        {

        }



    }
}
