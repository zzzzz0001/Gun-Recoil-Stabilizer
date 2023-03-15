using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_recoil_stabilizer.Stabilizers
{
    static class Stabilizer_reading
    {

        public static List<dynamic> Spray_pattern_stabilizer(List<string> input)
        {
            bool error_happened = false;
            List<dynamic> CSV_STORAGE = new List<dynamic>();
            bool Dataset_chosen = false;

            foreach (var piece in input)
            {
                List<int> to_add = new List<int>();

                var split_items = piece.Split(',').ToList();

                if (split_items.Count() == 1)
                {
                    split_items.Add("0");
                }

                foreach (var temp in split_items)
                {
                    try
                    {
                        to_add.Add(int.Parse(temp));  //parsing to see if all the values are proper numbers
                    }
                    catch (Exception e)
                    {
                        to_add.Add(0);
                        error_happened = true;
                    }
                }

                CSV_STORAGE.Add(to_add.ToArray());
                Dataset_chosen = true;
            }

            return new List<dynamic>()
                        {
                            error_happened,
                            CSV_STORAGE,
                            Dataset_chosen
                        };
        }


        public static List<dynamic> Vertical_stabilizer(List<string> input)
        {
            bool error_happened = false;
            List<dynamic> CSV_STORAGE = new List<dynamic>();
            bool Dataset_chosen = false;

            foreach (var piece in input)
            {
                try
                {
                    CSV_STORAGE.Add(int.Parse(piece));
                }
                catch (Exception)
                {
                    error_happened = true;
                    CSV_STORAGE.Add(0);
                }

                Dataset_chosen = true;
            }

            return new List<dynamic>()
                        {
                            error_happened,
                            CSV_STORAGE,
                            Dataset_chosen
                        };
        }
    }
}
