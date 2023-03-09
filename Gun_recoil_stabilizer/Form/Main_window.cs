using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gun_recoil_stabilizer.Speific_Data_Storage;
using Gun_recoil_stabilizer.Keystokes;
using System.Runtime.InteropServices;

namespace Gun_recoil_stabilizer
{
    public partial class Main_window : Form
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public bool Check_Stabilization_rate_Continous_run { get; set; }
        public bool Toggle_Stop_Continous_run { get; set; }

        public Main_window()
        {
            InitializeComponent();
            AllocConsole();
        }

        private async void Start_button_Click(object sender, EventArgs e)
        {
            if (Start_button.Text == "Start")
            {
                Start_function();
            }

            else if (Start_button.Text == "Started")
            {
                Stop_function();
            }
        }

        private void data_import_spray_pattern_button_Click(object sender, EventArgs e)    //button to browse
        {
            error(reset_visibility: true);  //this is used because when you click browse but do not select anything, only the visibily should go off which could be turned back on

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "CSV|*.csv";   //restricting to csv uses only

            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.  Right after this code, the browser window pop up

            if (result == DialogResult.OK) // Test result
            {
                error(fullreset: true);  //which basically measn that 

                imported_label.Visible = false;
                Data_of_form.Clear();

                string file = openFileDialog.FileName;   //variable file will be containing the fully defined path of the csv file
                string state = null;
                try
                {
                    var temp = File.ReadLines(file).ToList();

                    imported_label.Visible = false;
                    Data_of_form.Clear();

                    if (temp[0] != "")   //provided soemthing in the csv file
                        state = Data_of_form.ADD(temp);  //adding it to ram directly

                    else   //provided nothing in the csv file
                    {
                        error("CSV file provided is empty");
                    }
                        
                    
                }
                catch (IOException ex)
                {
                    error(ex.Message);
                    return;
                }

                catch (Exception ex)
                {
                    error(ex.Message);
                    return;
                }

                if (state != null)  //there has been a parsing error in Scatter_plot_file_readdata.ADD(List<string> input)
                {
                    error(state);
                }
                else  //evenything went fine in importing
                {
                    imported_label.Visible = true;
                }
            }

            else if (result == DialogResult.Cancel)
            {
                if (Error_message.Text != "")
                    error(visible: true);
            }
        }

        #region my_functions

        private bool validation()  //created by me
        {
            if (Stabilizer_toggle_keybinding_combobox.AccessibilityObject.Value == null)  //this means that nothing is being selected in Stabilizer toggle keybiding type which is a necessary thing
            {
                error("Stabilizer togggle Keymap is not selected (recommended key -> F2)");
                return false;
            }

            //CHECK IF ALL 3 DROP DOWNS VALUES ARE DIFFERENT

            if ((Increase_stabilization_combobox.AccessibilityObject.Value == Decrease_stabilization_combobox.AccessibilityObject.Value) && Increase_stabilization_combobox.AccessibilityObject.Value != null)
            {
                error("Increase Keymap and Decrese Keymap are same");
                return false;
            }

            if ((Increase_stabilization_combobox.AccessibilityObject.Value == Stabilizer_toggle_keybinding_combobox.AccessibilityObject.Value) && Increase_stabilization_combobox.AccessibilityObject.Value != null)
            {
                error("Increase Keymap and Stabilizer toggle Keymap are same");
                return false;
            }

            if ((Decrease_stabilization_combobox.AccessibilityObject.Value == Stabilizer_toggle_keybinding_combobox.AccessibilityObject.Value) && Decrease_stabilization_combobox.AccessibilityObject.Value != null)
            {
                error("Decrease Keymap and Stabilizer toggle Keymap are same");
                return false;
            }

            //CHECK IF TYPE OF STABILISER IS ALSO SELECTED

            if (Stabilizer_type_combobox.AccessibilityObject.Value == "CHOOSE")
            {
                error("Choose atleast one type of Stabilizer");
                return false;
            }

            //validating the file
            else if (Stabilizer_type_combobox.AccessibilityObject.Value == "Spray Pattern")
            {
                if (Data_of_form.Dataset_chosen == false)   //which means that dataset is not given
                {
                    error("Please provide a valid dataset to use the Stablizer : Spray Pattern");
                    return false;
                }

                else if (Data_of_form.CSV_STORAGE.Count == 0)
                {
                    error("Please provide atleast one row of dataset to use the Stablizer : Spray Pattern");
                    return false;
                }
            }


            return true;
        }

        /// <summary>
        /// Deals with Error showing
        /// </summary>
        /// <param name="error_string">Send the error to be displayed</param>
        /// <param name="fullreset">Reset Visiblity and the text</param>
        /// <param name="reset_visibility">Reset Visiblity</param>
        /// <param name="visible">Send True if you want to make error stuff visible</param>
        public void error(string error_string = null, bool fullreset = false, bool reset_visibility = false, bool visible = false)
        {
            if (fullreset == true)
            {

                Error_message.Text = "";
                Error_message.Visible = false;
                Copy_error_button.Visible = false;
            }

            else if (reset_visibility == true)
            {
                Error_message.Visible = false;
                Copy_error_button.Visible = false;
            }

            else if (visible == true)
            {
                Error_message.Visible = true;
                Copy_error_button.Visible = true;
            }

            else   //this means that error is being applied
            {
                if (error_string.Length > 80)
                    error_string = error_string.Substring(0, 80) + ".....";
                Error_message.Text = error_string;
                Error_message.Visible = true;
                Copy_error_button.Visible = true;
            }

        }

        public void Start_function()
        {
            error(fullreset: true);
            if (validation() == true)
            {
                Start_button.Text = "Started";
                Start_button.BackColor = Color.Green;


                //now keep on tracking on mouse left click to trigger the Recoil Stabilizer

                Console.WriteLine(Increase_stabilization_combobox.Text);

                var t1 = Increase_stabilization_combobox.Text;
                var t2 = Decrease_stabilization_combobox.Text;
                var t3 = Stabilizer_toggle_keybinding_combobox.Text;

                //this is going to run a fucntion that starts a function which captures keys pressed of keybaord and mouse constantly and then we can do further function there
                Task.Run(() => Keyboard_and_Mouse.START(auto_off_stabilisation_numericupdown.Value, Stabilization_rate_numericupdown.Value, Stabilization_rate_numericupdown.DecimalPlaces, t1, t2, t3));  //direcly sending the values of t1 t2 t3 causes the function not to run

                //but somehow the below code which is in synchronous run perfectly fine without t1, t2, t3
                //Keyboard_and_Mouse.START(auto_off_stabilisation_numericupdown.Value, Stabilization_rate_numericupdown.Value, Stabilization_rate_numericupdown.DecimalPlaces, Increase_stabilization_combobox.Text, Decrease_stabilization_combobox.Text, Stabilizer_toggle_keybinding_combobox.Text);


                //another thread to check if any changes occured to stabilization_rate
                Check_Stabilization_rate_Continous_run = true;
                Task.Run(() => Check_Stabilization_rate());   //sending the instance as this is used to edit the value of form

                
                Keyboard_and_Mouse.Toggle_stop = false;  //this initialises the value
                Toggle_Stop_Continous_run = true;
                //a thread to see if toggle_stop was true, if it is, then we can change the button property of Start back to Red
                Task.Run(() => Toggle_Stop());

            }
        }

        public void Stop_function()
        {
            Start_button.Text = "Start";
            Start_button.BackColor = Color.Red;
            Keyboard_and_Mouse.STOP();
            Check_Stabilization_rate_Continous_run = false;
            Toggle_Stop_Continous_run = false;
        }

        public Task Check_Stabilization_rate()
        {
            while (Check_Stabilization_rate_Continous_run)
            {
                var power = Math.Pow(10, Stabilization_rate_numericupdown.DecimalPlaces);
                int form_rate = (int)( Stabilization_rate_numericupdown.Value * (decimal)power );
                int stablization_rate = Data_of_form.Stabilization_rate;
                if (stablization_rate != form_rate)
                {
                    try
                    {
                        Stabilization_rate_numericupdown.Value = (decimal)stablization_rate / (decimal)power;
                    }
                    catch (Exception e)
                    {

                    }
                    Stabilization_rate_numericupdown.Refresh();

                }
            }
            return Task.CompletedTask;
        }

        public Task Toggle_Stop()
        {
            while (Toggle_Stop_Continous_run)
            {
                if (Keyboard_and_Mouse.Toggle_stop == true)
                {
                    Toggle_Stop_Continous_run = false;
                    Check_Stabilization_rate_Continous_run = false;
                    Start_button.Text = "Start";
                    Start_button.BackColor = Color.Red;
                }
            }

            return Task.CompletedTask;
        }
        #endregion
    }
}
