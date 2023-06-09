﻿using System;
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
using System.Threading;

namespace Gun_recoil_stabilizer
{
    public partial class Main_window : Form
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        //https://learn.microsoft.com/en-gb/dotnet/desktop/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls?view=netframeworkdesktop-4.8
        public delegate void Stop_delegate_function();
        public Stop_delegate_function Stop_delegate;

        public delegate void Start_function_delegate_for_toggle_start();
        public Start_function_delegate_for_toggle_start Start_function_delegate;

        public delegate void Refresh_stabilization_numericupdown();
        public Refresh_stabilization_numericupdown Refresh_delegate;

        public Main_window()
        {
            InitializeComponent();
            AllocConsole();

            Stop_delegate = new Stop_delegate_function(Stop_function);
            Refresh_delegate = new Refresh_stabilization_numericupdown(REFRESH_STABILIZATION_NUMERICUPDOWN_function);
            Start_function_delegate = new Start_function_delegate_for_toggle_start(Start_function);

            Data_of_form.formcontrol = this;

            //while (true)
            //{
            //    foreach (var screen in Screen.AllScreens)
            //    {
            //        Console.WriteLine("Device name = " + screen.DeviceName);
            //        Console.WriteLine("X = " + screen.Bounds.X + "      Y = " + screen.Bounds.Y);
            //        Console.WriteLine("Width = " + screen.Bounds.Width + "      Height = " + screen.Bounds.Height);
            //    }

            //    WinHelper.CursorPosition position = WinHelper.CursorHelper.GetCurrentPosition();
            //    Console.WriteLine("Mouse position X = " + position.X + "     Y = " + position.Y);

            //    Thread.Sleep(150);
            //    Console.Clear();
            //}


            //Console.WriteLine(Stabilizer_toggle_keybinding_combobox.SelectedIndex);   //this gives -1 which means nothing is selected

        }

        #region event_triggers
        private async void Start_button_Click(object sender, EventArgs e)
        {
            if (Start_button.Text == "Start")
            {
                Console.Clear();
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

            /*openFileDialog.Filter = "CSV|*.csv";*/   //restricting to csv uses only
            openFileDialog.Filter = "JSON|*.json";

            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.  Right after this code, the browser window pop up

            if (result == DialogResult.OK) // Test result
            {
                error(fullreset: true);  //which basically measn that 

                imported_label.Visible = false;
                Data_of_form.Clear_uploaded_docs();

                string file = openFileDialog.FileName;
                string state = null;
                try
                {
                    //var temp = File.ReadLines(file).ToList();
                    var temp = File.ReadAllText(file);

                    imported_label.Visible = false;
                    Data_of_form.Clear_uploaded_docs();

                    Data_of_form.ADD(temp);

                    REFRESH_FORM_AFTER_JSON_IMPORT();

                    //if (temp[0] != "")   //provided soemthing in the csv file
                    //    state = Data_of_form.ADD(temp);  //adding it to ram directly

                    //else   //provided nothing in the csv file
                    //{
                    //    error("CSV file provided is empty");
                    //}
                        
                    
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

        #region combobox_select_auto_trigger
        private void Stabilizer_toggle_keybinding_combobox_SelectedIndexChanged(object sender, EventArgs e)  //fires when i select anything
        {
            Data_of_form.String_to_Keys_and_store(Stabilizer_toggle_key_: Stabilizer_toggle_keybinding_combobox.Text);
            Stabilizer_toggle_clear_button.Enabled = true;
        }

        private void Increase_stabilization_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data_of_form.String_to_Keys_and_store(Increase_stabilization_rate_key_: Increase_stabilization_combobox.Text);
            Increase_clear_button.Enabled = true;
        }

        private void Decrease_stabilization_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data_of_form.String_to_Keys_and_store(Decrease_stablilization_rate_key_: Decrease_stabilization_combobox.Text);
            Decrease_clear_button.Enabled = true;
        }

        #endregion

        private void auto_off_stabilisation_numericupdown_ValueChanged(object sender, EventArgs e)
        {
            //this only works when the increase or decrease button is being pressed which is inbuilt on numbericupdown
            //this will not get trigger if you type it directly

            Data_of_form.Auto_off_stabilization = (int)((double)auto_off_stabilisation_numericupdown.Value * Math.Pow(10, auto_off_stabilisation_numericupdown.DecimalPlaces));

        }

        private void Stabilization_rate_numericupdown_ValueChanged(object sender, EventArgs e)
        {
            Data_of_form.Stabilization_rate = (int)((double)Stabilization_rate_numericupdown.Value * Math.Pow(10, Stabilization_rate_numericupdown.DecimalPlaces));
        }

        private void Stabilizer_toggle_clear_button_Click(object sender, EventArgs e)
        {
            Stabilizer_toggle_keybinding_combobox.SelectedIndex = -1;
            Stabilizer_toggle_keybinding_combobox.Refresh();
            Stabilizer_toggle_clear_button.Enabled= false;

            Data_of_form.Keys_inc_dec_tog_int[2] = -1;
        }

        private void Increase_clear_button_Click(object sender, EventArgs e)
        {
            Increase_stabilization_combobox.SelectedIndex = -1;
            Increase_stabilization_combobox.Refresh();
            Increase_clear_button.Enabled = false;

            Data_of_form.Keys_inc_dec_tog_int[0] = -1;
        }

        private void Decrease_clear_button_Click(object sender, EventArgs e)
        {
            Decrease_stabilization_combobox.SelectedIndex = -1;
            Decrease_stabilization_combobox.Refresh();
            Decrease_clear_button.Enabled = false;

            Data_of_form.Keys_inc_dec_tog_int[1] = -1;
        }

        private void Copy_error_button_Click(object sender, EventArgs e)
        {
            if (Error_message.Text != "" && Error_message.Visible == true)  //error is not empty
            {
                Clipboard.SetText(Error_message.Text);
            }
        }

        private void Stabilizer_type_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Stabilizer_type_combobox.SelectedIndex != -1)
            {
                data_import_spray_pattern_button.Enabled = true;
                Data_of_form.Stabilizer_type = Stabilizer_type_combobox.SelectedIndex;
            }
                
        }

        #endregion

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

            if (Stabilizer_type_combobox.SelectedIndex == -1)
            {
                error("Choose at least one type of Stabilizer");
                return false;
            }

            //validating the file
            if (Data_of_form.Dataset_chosen == false)   //which means that dataset is not given
            {
                error("Please provide a valid dataset to use the Stablizer : " + Stabilizer_type_combobox.AccessibilityObject.Value);
                return false;
            }

            else if (Data_of_form.Spray_Data_points.Count == 0)
            {
                error("Please provide atleast one row of dataset to use the Stablizer : " + Stabilizer_type_combobox.AccessibilityObject.Value);
                return false;
            }
            //else if (Stabilizer_type_combobox.AccessibilityObject.Value == "Spray Pattern")
            //{
            //    if (Data_of_form.Dataset_chosen == false)   //which means that dataset is not given
            //    {
            //        error("Please provide a valid dataset to use the Stablizer : Spray Pattern");
            //        return false;
            //    }

            //    else if (Data_of_form.CSV_STORAGE.Count == 0)
            //    {
            //        error("Please provide atleast one row of dataset to use the Stablizer : Spray Pattern");
            //        return false;
            //    }
            //}


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

                //diable all 3 clear button and changing option for stabilizer and the importing button
                Stabilizer_toggle_clear_button.Enabled = false;
                Increase_clear_button.Enabled = false;
                Decrease_clear_button.Enabled = false;
                Stabilizer_type_combobox.Enabled = false;
                data_import_spray_pattern_button.Enabled = false;


                //filled out the Data_of_forms first
                Data_of_form.Auto_off_stabilization = (int)(auto_off_stabilisation_numericupdown.Value * (decimal)Math.Pow(10, Stabilization_rate_numericupdown.DecimalPlaces));
                Data_of_form.Stabilization_rate = (int)(Stabilization_rate_numericupdown.Value * (decimal)Math.Pow(10, Stabilization_rate_numericupdown.DecimalPlaces));
                Data_of_form.Status = true;

                //this is going to run a function that starts a function which captures keys pressed of keybaord and mouse constantly and then we can do further function there
                Task.Run(() => Keyboard_and_Mouse.START());


            }
        }

        public void Stop_function()
        {
            Start_button.Text = "Start";
            Start_button.BackColor = Color.Red;
            Keyboard_and_Mouse.Mouse_Key_Extractor_Continous_Run = false;
            Keyboard_and_Mouse.Mouse_click_Continous_Run = false;
            Data_of_form.Status = false;

            Stabilizer_toggle_clear_button.Enabled = true;
            Increase_clear_button.Enabled = true;
            Decrease_clear_button.Enabled = true;
            Stabilizer_type_combobox.Enabled = true;
            data_import_spray_pattern_button.Enabled = true;


        }

        public void REFRESH_STABILIZATION_NUMERICUPDOWN_function()
        {
            Stabilization_rate_numericupdown.Value = (decimal)(Data_of_form.Stabilization_rate/Math.Pow(10, Stabilization_rate_numericupdown.DecimalPlaces));

            Stabilization_rate_numericupdown.Update();


        }

        public void REFRESH_FORM_AFTER_JSON_IMPORT()
        {
            this.auto_off_stabilisation_numericupdown.Value = (decimal)Data_of_form.Auto_off_stabilization/(decimal)Math.Pow(10, this.auto_off_stabilisation_numericupdown.DecimalPlaces);
            this.Stabilization_rate_numericupdown.Value = (decimal)Data_of_form.Stabilization_rate/(decimal)Math.Pow(10, this.Stabilization_rate_numericupdown.DecimalPlaces);

            if(Data_of_form.Increase_stabilization_rate_key_int != -1)
                this.Increase_stabilization_combobox.Text = Data_of_form.Mapping_from_key_value_to_myname[Data_of_form.Increase_stabilization_rate_key_int];

            if(Data_of_form.Decrease_stabililization_rate_key_int != -1)
                this.Decrease_stabilization_combobox.Text = Data_of_form.Mapping_from_key_value_to_myname[Data_of_form.Decrease_stabililization_rate_key_int];

            if(Data_of_form.Stabilizer_toggle_key_int != -1)
                this.Stabilizer_toggle_keybinding_combobox.Text = Data_of_form.Mapping_from_key_value_to_myname[Data_of_form.Stabilizer_toggle_key_int];
        }


        #endregion

    }
}
