
namespace Gun_recoil_stabilizer
{
    partial class Main_window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Stabilizer_toggle_keybinding_label = new System.Windows.Forms.Label();
            this.Stabilizer_toggle_keybinding_combobox = new System.Windows.Forms.ComboBox();
            this.Increase_stabilization_combobox = new System.Windows.Forms.ComboBox();
            this.Increase_stabilization_label = new System.Windows.Forms.Label();
            this.Decrease_stabilization_label = new System.Windows.Forms.Label();
            this.Stabilization_rate_label = new System.Windows.Forms.Label();
            this.Decrease_stabilization_combobox = new System.Windows.Forms.ComboBox();
            this.Stabilization_rate_numericupdown = new System.Windows.Forms.NumericUpDown();
            this.seconds_label1 = new System.Windows.Forms.Label();
            this.Stabilizer_type_label = new System.Windows.Forms.Label();
            this.Stabilizer_type_combobox = new System.Windows.Forms.ComboBox();
            this.data_import_spray_pattern_button = new System.Windows.Forms.Button();
            this.data_import_spray_pattern_label = new System.Windows.Forms.Label();
            this.auto_off_stabilisation_label = new System.Windows.Forms.Label();
            this.auto_off_stabilisation_numericupdown = new System.Windows.Forms.NumericUpDown();
            this.seconds_label = new System.Windows.Forms.Label();
            this.Start_button = new System.Windows.Forms.Button();
            this.Error_message = new System.Windows.Forms.Label();
            this.Increase_clear_button = new System.Windows.Forms.Button();
            this.Decrease_clear_button = new System.Windows.Forms.Button();
            this.Stabilizer_toggle_clear_button = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Copy_error_button = new System.Windows.Forms.Button();
            this.imported_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Stabilization_rate_numericupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auto_off_stabilisation_numericupdown)).BeginInit();
            this.SuspendLayout();
            // 
            // Stabilizer_toggle_keybinding_label
            // 
            this.Stabilizer_toggle_keybinding_label.AutoSize = true;
            this.Stabilizer_toggle_keybinding_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stabilizer_toggle_keybinding_label.Location = new System.Drawing.Point(25, 205);
            this.Stabilizer_toggle_keybinding_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Stabilizer_toggle_keybinding_label.Name = "Stabilizer_toggle_keybinding_label";
            this.Stabilizer_toggle_keybinding_label.Size = new System.Drawing.Size(300, 31);
            this.Stabilizer_toggle_keybinding_label.TabIndex = 2;
            this.Stabilizer_toggle_keybinding_label.Text = "Stabilizer toggle keybinding";
            // 
            // Stabilizer_toggle_keybinding_combobox
            // 
            this.Stabilizer_toggle_keybinding_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Stabilizer_toggle_keybinding_combobox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stabilizer_toggle_keybinding_combobox.FormattingEnabled = true;
            this.Stabilizer_toggle_keybinding_combobox.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "PRTSC",
            "SCRLK",
            "PAUSE",
            "INS",
            "HOME",
            "DEL",
            "END",
            "PGUP",
            "PGDN",
            "ARROW UP",
            "ARROW LEFT",
            "ARROW DOWN",
            "ARROW RIGHT",
            "NUMLK",
            "BACKSPACE",
            "LEFT/RIGHT ENTER",
            "LEFT SHIFT",
            "RIGHT SHIFT",
            "LEFT CTRL",
            "RIGHT CTRL",
            "LEFT ALT",
            "RIGHT ALT",
            "WINDOWS KEY",
            "CAPSLOCK",
            "ESC",
            "TAB",
            "SPACE",
            "`",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "-",
            "=",
            "[",
            "]",
            "\\",
            ";",
            "\'",
            ",",
            ".",
            "/",
            "Numpad 0",
            "Numpad 1",
            "Numpad 2",
            "Numpad 3",
            "Numpad 4",
            "Numpad 5",
            "Numpad 6",
            "Numpad 7",
            "Numpad 8",
            "Numpad 9",
            "Numpad /",
            "Numpad *",
            "Numpad -",
            "Numpad +",
            "Numpad .",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "Right Click",
            "Middle Click",
            "Mouse Thumb 1",
            "Mouse Thumb 2"});
            this.Stabilizer_toggle_keybinding_combobox.Location = new System.Drawing.Point(325, 202);
            this.Stabilizer_toggle_keybinding_combobox.Margin = new System.Windows.Forms.Padding(4);
            this.Stabilizer_toggle_keybinding_combobox.Name = "Stabilizer_toggle_keybinding_combobox";
            this.Stabilizer_toggle_keybinding_combobox.Size = new System.Drawing.Size(154, 36);
            this.Stabilizer_toggle_keybinding_combobox.TabIndex = 3;
            this.Stabilizer_toggle_keybinding_combobox.Tag = "";
            this.Stabilizer_toggle_keybinding_combobox.SelectedIndexChanged += new System.EventHandler(this.Stabilizer_toggle_keybinding_combobox_SelectedIndexChanged);
            // 
            // Increase_stabilization_combobox
            // 
            this.Increase_stabilization_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Increase_stabilization_combobox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Increase_stabilization_combobox.FormattingEnabled = true;
            this.Increase_stabilization_combobox.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "PRTSC",
            "SCRLK",
            "PAUSE",
            "INS",
            "HOME",
            "DEL",
            "END",
            "PGUP",
            "PGDN",
            "ARROW UP",
            "ARROW LEFT",
            "ARROW DOWN",
            "ARROW RIGHT",
            "NUMLK",
            "BACKSPACE",
            "LEFT/RIGHT ENTER",
            "LEFT SHIFT",
            "RIGHT SHIFT",
            "LEFT CTRL",
            "RIGHT CTRL",
            "LEFT ALT",
            "RIGHT ALT",
            "WINDOWS KEY",
            "CAPSLOCK",
            "ESC",
            "TAB",
            "SPACE",
            "`",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "-",
            "=",
            "[",
            "]",
            "\\",
            ";",
            "\'",
            ",",
            ".",
            "/",
            "Numpad 0",
            "Numpad 1",
            "Numpad 2",
            "Numpad 3",
            "Numpad 4",
            "Numpad 5",
            "Numpad 6",
            "Numpad 7",
            "Numpad 8",
            "Numpad 9",
            "Numpad /",
            "Numpad *",
            "Numpad -",
            "Numpad +",
            "Numpad .",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "Right Click",
            "Middle Click",
            "Mouse Thumb 1",
            "Mouse Thumb 2"});
            this.Increase_stabilization_combobox.Location = new System.Drawing.Point(599, 77);
            this.Increase_stabilization_combobox.Margin = new System.Windows.Forms.Padding(4);
            this.Increase_stabilization_combobox.Name = "Increase_stabilization_combobox";
            this.Increase_stabilization_combobox.Size = new System.Drawing.Size(177, 36);
            this.Increase_stabilization_combobox.TabIndex = 7;
            this.Increase_stabilization_combobox.SelectedIndexChanged += new System.EventHandler(this.Increase_stabilization_combobox_SelectedIndexChanged);
            // 
            // Increase_stabilization_label
            // 
            this.Increase_stabilization_label.AutoSize = true;
            this.Increase_stabilization_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Increase_stabilization_label.Location = new System.Drawing.Point(471, 78);
            this.Increase_stabilization_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Increase_stabilization_label.Name = "Increase_stabilization_label";
            this.Increase_stabilization_label.Size = new System.Drawing.Size(98, 31);
            this.Increase_stabilization_label.TabIndex = 6;
            this.Increase_stabilization_label.Text = "Increase";
            // 
            // Decrease_stabilization_label
            // 
            this.Decrease_stabilization_label.AutoSize = true;
            this.Decrease_stabilization_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Decrease_stabilization_label.Location = new System.Drawing.Point(471, 129);
            this.Decrease_stabilization_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Decrease_stabilization_label.Name = "Decrease_stabilization_label";
            this.Decrease_stabilization_label.Size = new System.Drawing.Size(107, 31);
            this.Decrease_stabilization_label.TabIndex = 9;
            this.Decrease_stabilization_label.Text = "Decrease";
            // 
            // Stabilization_rate_label
            // 
            this.Stabilization_rate_label.AutoSize = true;
            this.Stabilization_rate_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stabilization_rate_label.Location = new System.Drawing.Point(453, 19);
            this.Stabilization_rate_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Stabilization_rate_label.Name = "Stabilization_rate_label";
            this.Stabilization_rate_label.Size = new System.Drawing.Size(185, 31);
            this.Stabilization_rate_label.TabIndex = 4;
            this.Stabilization_rate_label.Text = "Stabilization rate";
            // 
            // Decrease_stabilization_combobox
            // 
            this.Decrease_stabilization_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Decrease_stabilization_combobox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Decrease_stabilization_combobox.FormattingEnabled = true;
            this.Decrease_stabilization_combobox.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "PRTSC",
            "SCRLK",
            "PAUSE",
            "INS",
            "HOME",
            "DEL",
            "END",
            "PGUP",
            "PGDN",
            "ARROW UP",
            "ARROW LEFT",
            "ARROW DOWN",
            "ARROW RIGHT",
            "NUMLK",
            "BACKSPACE",
            "LEFT/RIGHT ENTER",
            "LEFT SHIFT",
            "RIGHT SHIFT",
            "LEFT CTRL",
            "RIGHT CTRL",
            "LEFT ALT",
            "RIGHT ALT",
            "WINDOWS KEY",
            "CAPSLOCK",
            "ESC",
            "TAB",
            "SPACE",
            "`",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "-",
            "=",
            "[",
            "]",
            "\\",
            ";",
            "\'",
            ",",
            ".",
            "/",
            "Numpad 0",
            "Numpad 1",
            "Numpad 2",
            "Numpad 3",
            "Numpad 4",
            "Numpad 5",
            "Numpad 6",
            "Numpad 7",
            "Numpad 8",
            "Numpad 9",
            "Numpad /",
            "Numpad *",
            "Numpad -",
            "Numpad +",
            "Numpad .",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "Right Click",
            "Middle Click",
            "Mouse Thumb 1",
            "Mouse Thumb 2"});
            this.Decrease_stabilization_combobox.Location = new System.Drawing.Point(599, 129);
            this.Decrease_stabilization_combobox.Margin = new System.Windows.Forms.Padding(4);
            this.Decrease_stabilization_combobox.Name = "Decrease_stabilization_combobox";
            this.Decrease_stabilization_combobox.Size = new System.Drawing.Size(177, 36);
            this.Decrease_stabilization_combobox.TabIndex = 10;
            this.Decrease_stabilization_combobox.SelectedIndexChanged += new System.EventHandler(this.Decrease_stabilization_combobox_SelectedIndexChanged);
            // 
            // Stabilization_rate_numericupdown
            // 
            this.Stabilization_rate_numericupdown.AutoSize = true;
            this.Stabilization_rate_numericupdown.DecimalPlaces = 3;
            this.Stabilization_rate_numericupdown.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stabilization_rate_numericupdown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Stabilization_rate_numericupdown.Location = new System.Drawing.Point(646, 12);
            this.Stabilization_rate_numericupdown.Margin = new System.Windows.Forms.Padding(4);
            this.Stabilization_rate_numericupdown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Stabilization_rate_numericupdown.Name = "Stabilization_rate_numericupdown";
            this.Stabilization_rate_numericupdown.Size = new System.Drawing.Size(130, 38);
            this.Stabilization_rate_numericupdown.TabIndex = 5;
            this.Stabilization_rate_numericupdown.Tag = "Stabilization_rate_numericupdown_tag";
            this.Stabilization_rate_numericupdown.ValueChanged += new System.EventHandler(this.Stabilization_rate_numericupdown_ValueChanged);
            // 
            // seconds_label1
            // 
            this.seconds_label1.AutoSize = true;
            this.seconds_label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.seconds_label1.Location = new System.Drawing.Point(784, 25);
            this.seconds_label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.seconds_label1.Name = "seconds_label1";
            this.seconds_label1.Size = new System.Drawing.Size(56, 17);
            this.seconds_label1.TabIndex = 15;
            this.seconds_label1.Text = "seconds";
            // 
            // Stabilizer_type_label
            // 
            this.Stabilizer_type_label.AutoSize = true;
            this.Stabilizer_type_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stabilizer_type_label.Location = new System.Drawing.Point(25, 19);
            this.Stabilizer_type_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Stabilizer_type_label.Name = "Stabilizer_type_label";
            this.Stabilizer_type_label.Size = new System.Drawing.Size(187, 31);
            this.Stabilizer_type_label.TabIndex = 0;
            this.Stabilizer_type_label.Text = "Type of Stabilizer";
            // 
            // Stabilizer_type_combobox
            // 
            this.Stabilizer_type_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Stabilizer_type_combobox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stabilizer_type_combobox.FormattingEnabled = true;
            this.Stabilizer_type_combobox.Items.AddRange(new object[] {
            "Vertical",
            "Spray Pattern"});
            this.Stabilizer_type_combobox.Location = new System.Drawing.Point(220, 18);
            this.Stabilizer_type_combobox.Margin = new System.Windows.Forms.Padding(4);
            this.Stabilizer_type_combobox.Name = "Stabilizer_type_combobox";
            this.Stabilizer_type_combobox.Size = new System.Drawing.Size(184, 36);
            this.Stabilizer_type_combobox.TabIndex = 1;
            this.Stabilizer_type_combobox.SelectedIndexChanged += new System.EventHandler(this.Stabilizer_type_combobox_SelectedIndexChanged);
            // 
            // data_import_spray_pattern_button
            // 
            this.data_import_spray_pattern_button.Enabled = false;
            this.data_import_spray_pattern_button.Location = new System.Drawing.Point(325, 79);
            this.data_import_spray_pattern_button.Name = "data_import_spray_pattern_button";
            this.data_import_spray_pattern_button.Size = new System.Drawing.Size(105, 36);
            this.data_import_spray_pattern_button.TabIndex = 11;
            this.data_import_spray_pattern_button.Text = "browse";
            this.data_import_spray_pattern_button.UseVisualStyleBackColor = true;
            this.data_import_spray_pattern_button.Click += new System.EventHandler(this.data_import_spray_pattern_button_Click);
            // 
            // data_import_spray_pattern_label
            // 
            this.data_import_spray_pattern_label.AutoSize = true;
            this.data_import_spray_pattern_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.data_import_spray_pattern_label.Location = new System.Drawing.Point(25, 78);
            this.data_import_spray_pattern_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.data_import_spray_pattern_label.Name = "data_import_spray_pattern_label";
            this.data_import_spray_pattern_label.Size = new System.Drawing.Size(293, 31);
            this.data_import_spray_pattern_label.TabIndex = 12;
            this.data_import_spray_pattern_label.Text = "Data import (spray pattern)";
            // 
            // auto_off_stabilisation_label
            // 
            this.auto_off_stabilisation_label.AutoSize = true;
            this.auto_off_stabilisation_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.auto_off_stabilisation_label.Location = new System.Drawing.Point(25, 148);
            this.auto_off_stabilisation_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.auto_off_stabilisation_label.Name = "auto_off_stabilisation_label";
            this.auto_off_stabilisation_label.Size = new System.Drawing.Size(226, 31);
            this.auto_off_stabilisation_label.TabIndex = 13;
            this.auto_off_stabilisation_label.Text = "Auto off stabilisation";
            // 
            // auto_off_stabilisation_numericupdown
            // 
            this.auto_off_stabilisation_numericupdown.DecimalPlaces = 3;
            this.auto_off_stabilisation_numericupdown.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.auto_off_stabilisation_numericupdown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.auto_off_stabilisation_numericupdown.InterceptArrowKeys = false;
            this.auto_off_stabilisation_numericupdown.Location = new System.Drawing.Point(259, 146);
            this.auto_off_stabilisation_numericupdown.Margin = new System.Windows.Forms.Padding(4);
            this.auto_off_stabilisation_numericupdown.Name = "auto_off_stabilisation_numericupdown";
            this.auto_off_stabilisation_numericupdown.Size = new System.Drawing.Size(117, 38);
            this.auto_off_stabilisation_numericupdown.TabIndex = 11;
            this.auto_off_stabilisation_numericupdown.Tag = "auto_off_stabilisation_numericupdown_tag";
            this.auto_off_stabilisation_numericupdown.ValueChanged += new System.EventHandler(this.auto_off_stabilisation_numericupdown_ValueChanged);
            // 
            // seconds_label
            // 
            this.seconds_label.AutoSize = true;
            this.seconds_label.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.seconds_label.Location = new System.Drawing.Point(384, 159);
            this.seconds_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.seconds_label.Name = "seconds_label";
            this.seconds_label.Size = new System.Drawing.Size(56, 17);
            this.seconds_label.TabIndex = 14;
            this.seconds_label.Text = "seconds";
            // 
            // Start_button
            // 
            this.Start_button.BackColor = System.Drawing.Color.Red;
            this.Start_button.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Start_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Start_button.Location = new System.Drawing.Point(599, 175);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(183, 73);
            this.Start_button.TabIndex = 16;
            this.Start_button.Text = "Start";
            this.Start_button.UseVisualStyleBackColor = false;
            this.Start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // Error_message
            // 
            this.Error_message.AutoSize = true;
            this.Error_message.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Error_message.ForeColor = System.Drawing.Color.Crimson;
            this.Error_message.Location = new System.Drawing.Point(36, 269);
            this.Error_message.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error_message.Name = "Error_message";
            this.Error_message.Size = new System.Drawing.Size(0, 25);
            this.Error_message.TabIndex = 17;
            this.Error_message.Visible = false;
            // 
            // Increase_clear_button
            // 
            this.Increase_clear_button.Enabled = false;
            this.Increase_clear_button.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Increase_clear_button.Location = new System.Drawing.Point(795, 82);
            this.Increase_clear_button.Name = "Increase_clear_button";
            this.Increase_clear_button.Size = new System.Drawing.Size(48, 27);
            this.Increase_clear_button.TabIndex = 18;
            this.Increase_clear_button.Text = "clear";
            this.Increase_clear_button.UseVisualStyleBackColor = true;
            this.Increase_clear_button.Click += new System.EventHandler(this.Increase_clear_button_Click);
            // 
            // Decrease_clear_button
            // 
            this.Decrease_clear_button.Enabled = false;
            this.Decrease_clear_button.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Decrease_clear_button.Location = new System.Drawing.Point(795, 133);
            this.Decrease_clear_button.Name = "Decrease_clear_button";
            this.Decrease_clear_button.Size = new System.Drawing.Size(48, 27);
            this.Decrease_clear_button.TabIndex = 19;
            this.Decrease_clear_button.Text = "clear";
            this.Decrease_clear_button.UseVisualStyleBackColor = true;
            this.Decrease_clear_button.Click += new System.EventHandler(this.Decrease_clear_button_Click);
            // 
            // Stabilizer_toggle_clear_button
            // 
            this.Stabilizer_toggle_clear_button.Enabled = false;
            this.Stabilizer_toggle_clear_button.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stabilizer_toggle_clear_button.Location = new System.Drawing.Point(486, 205);
            this.Stabilizer_toggle_clear_button.Name = "Stabilizer_toggle_clear_button";
            this.Stabilizer_toggle_clear_button.Size = new System.Drawing.Size(48, 27);
            this.Stabilizer_toggle_clear_button.TabIndex = 20;
            this.Stabilizer_toggle_clear_button.Text = "clear";
            this.Stabilizer_toggle_clear_button.UseVisualStyleBackColor = true;
            this.Stabilizer_toggle_clear_button.Click += new System.EventHandler(this.Stabilizer_toggle_clear_button_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Copy_error_button
            // 
            this.Copy_error_button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Copy_error_button.Location = new System.Drawing.Point(36, 297);
            this.Copy_error_button.Name = "Copy_error_button";
            this.Copy_error_button.Size = new System.Drawing.Size(94, 29);
            this.Copy_error_button.TabIndex = 21;
            this.Copy_error_button.Text = "copy error";
            this.Copy_error_button.UseVisualStyleBackColor = true;
            this.Copy_error_button.Visible = false;
            this.Copy_error_button.Click += new System.EventHandler(this.Copy_error_button_Click);
            // 
            // imported_label
            // 
            this.imported_label.AutoSize = true;
            this.imported_label.BackColor = System.Drawing.Color.White;
            this.imported_label.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.imported_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.imported_label.Location = new System.Drawing.Point(307, 118);
            this.imported_label.Name = "imported_label";
            this.imported_label.Size = new System.Drawing.Size(133, 17);
            this.imported_label.TabIndex = 22;
            this.imported_label.Text = "successfully imported";
            this.imported_label.Visible = false;
            // 
            // Main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 338);
            this.Controls.Add(this.imported_label);
            this.Controls.Add(this.Copy_error_button);
            this.Controls.Add(this.Stabilizer_toggle_clear_button);
            this.Controls.Add(this.Decrease_clear_button);
            this.Controls.Add(this.Increase_clear_button);
            this.Controls.Add(this.Error_message);
            this.Controls.Add(this.Start_button);
            this.Controls.Add(this.seconds_label1);
            this.Controls.Add(this.seconds_label);
            this.Controls.Add(this.Stabilization_rate_numericupdown);
            this.Controls.Add(this.Stabilizer_toggle_keybinding_combobox);
            this.Controls.Add(this.Decrease_stabilization_combobox);
            this.Controls.Add(this.auto_off_stabilisation_numericupdown);
            this.Controls.Add(this.Stabilization_rate_label);
            this.Controls.Add(this.Decrease_stabilization_label);
            this.Controls.Add(this.Stabilizer_toggle_keybinding_label);
            this.Controls.Add(this.Increase_stabilization_label);
            this.Controls.Add(this.auto_off_stabilisation_label);
            this.Controls.Add(this.Increase_stabilization_combobox);
            this.Controls.Add(this.data_import_spray_pattern_label);
            this.Controls.Add(this.data_import_spray_pattern_button);
            this.Controls.Add(this.Stabilizer_type_label);
            this.Controls.Add(this.Stabilizer_type_combobox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main_window";
            this.Text = "public ";
            ((System.ComponentModel.ISupportInitialize)(this.Stabilization_rate_numericupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auto_off_stabilisation_numericupdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Stabilizer_toggle_keybinding_label;
        private System.Windows.Forms.ComboBox Stabilizer_toggle_keybinding_combobox;
        private System.Windows.Forms.ComboBox Increase_stabilization_combobox;
        private System.Windows.Forms.Label Increase_stabilization_label;
        private System.Windows.Forms.Label Decrease_stabilization_label;
        private System.Windows.Forms.Label Stabilization_rate_label;
        private System.Windows.Forms.ComboBox Decrease_stabilization_combobox;
        private System.Windows.Forms.NumericUpDown Stabilization_rate_numericupdown;
        private System.Windows.Forms.Label seconds_label1;
        private System.Windows.Forms.Label Stabilizer_type_label;
        private System.Windows.Forms.ComboBox Stabilizer_type_combobox;
        private System.Windows.Forms.Button data_import_spray_pattern_button;
        private System.Windows.Forms.Label data_import_spray_pattern_label;
        private System.Windows.Forms.Label auto_off_stabilisation_label;
        private System.Windows.Forms.NumericUpDown auto_off_stabilisation_numericupdown;
        private System.Windows.Forms.Label seconds_label;
        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.Label Error_message;
        private System.Windows.Forms.Button Increase_clear_button;
        private System.Windows.Forms.Button Decrease_clear_button;
        private System.Windows.Forms.Button Stabilizer_toggle_clear_button;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button Copy_error_button;
        private System.Windows.Forms.Label imported_label;
    }
}

