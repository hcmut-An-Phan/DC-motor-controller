
namespace DCMotorEncoderApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gr_feedBack = new System.Windows.Forms.GroupBox();
            this.chart_fb = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddl_baudrate = new System.Windows.Forms.ComboBox();
            this.ddl_name = new System.Windows.Forms.ComboBox();
            this.radio_x1 = new System.Windows.Forms.RadioButton();
            this.gr_options = new System.Windows.Forms.GroupBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.radio_x4 = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.edit_position = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.slider_postion = new System.Windows.Forms.TrackBar();
            this.text_status = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edit_d = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edit_i = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edit_p = new System.Windows.Forms.TextBox();
            this.btn_pid = new System.Windows.Forms.Button();
            this.gr_feedBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_fb)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gr_options.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_postion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // gr_feedBack
            // 
            this.gr_feedBack.Controls.Add(this.chart_fb);
            this.gr_feedBack.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gr_feedBack.Location = new System.Drawing.Point(12, 12);
            this.gr_feedBack.Name = "gr_feedBack";
            this.gr_feedBack.Size = new System.Drawing.Size(516, 348);
            this.gr_feedBack.TabIndex = 1;
            this.gr_feedBack.TabStop = false;
            this.gr_feedBack.Text = "Feedback";
            // 
            // chart_fb
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_fb.ChartAreas.Add(chartArea2);
            this.chart_fb.Location = new System.Drawing.Point(7, 22);
            this.chart_fb.Name = "chart_fb";
            this.chart_fb.Size = new System.Drawing.Size(503, 320);
            this.chart_fb.TabIndex = 0;
            this.chart_fb.Text = "chart_fb";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_close);
            this.groupBox2.Controls.Add(this.btn_open);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ddl_baudrate);
            this.groupBox2.Controls.Add(this.ddl_name);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 365);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(358, 118);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serial";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(192, 73);
            this.btn_close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(68, 27);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(69, 73);
            this.btn_open.Margin = new System.Windows.Forms.Padding(2);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(68, 27);
            this.btn_open.TabIndex = 6;
            this.btn_open.Text = "Open";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baudrate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // ddl_baudrate
            // 
            this.ddl_baudrate.FormattingEnabled = true;
            this.ddl_baudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "115200"});
            this.ddl_baudrate.Location = new System.Drawing.Point(244, 38);
            this.ddl_baudrate.Margin = new System.Windows.Forms.Padding(2);
            this.ddl_baudrate.Name = "ddl_baudrate";
            this.ddl_baudrate.Size = new System.Drawing.Size(89, 24);
            this.ddl_baudrate.TabIndex = 3;
            // 
            // ddl_name
            // 
            this.ddl_name.FormattingEnabled = true;
            this.ddl_name.Location = new System.Drawing.Point(74, 37);
            this.ddl_name.Margin = new System.Windows.Forms.Padding(2);
            this.ddl_name.Name = "ddl_name";
            this.ddl_name.Size = new System.Drawing.Size(82, 24);
            this.ddl_name.TabIndex = 2;
            // 
            // radio_x1
            // 
            this.radio_x1.AutoSize = true;
            this.radio_x1.Location = new System.Drawing.Point(26, 34);
            this.radio_x1.Name = "radio_x1";
            this.radio_x1.Size = new System.Drawing.Size(41, 20);
            this.radio_x1.TabIndex = 3;
            this.radio_x1.TabStop = true;
            this.radio_x1.Text = "x1";
            this.radio_x1.UseVisualStyleBackColor = true;
            this.radio_x1.CheckedChanged += new System.EventHandler(this.radio_x1_Checked);
            // 
            // gr_options
            // 
            this.gr_options.Controls.Add(this.btn_reset);
            this.gr_options.Controls.Add(this.radio_x4);
            this.gr_options.Controls.Add(this.radio_x1);
            this.gr_options.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gr_options.Location = new System.Drawing.Point(374, 365);
            this.gr_options.Name = "gr_options";
            this.gr_options.Size = new System.Drawing.Size(154, 116);
            this.gr_options.TabIndex = 4;
            this.gr_options.TabStop = false;
            this.gr_options.Text = "Options";
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(44, 73);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(2);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(68, 27);
            this.btn_reset.TabIndex = 8;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // radio_x4
            // 
            this.radio_x4.AutoSize = true;
            this.radio_x4.Location = new System.Drawing.Point(94, 34);
            this.radio_x4.Name = "radio_x4";
            this.radio_x4.Size = new System.Drawing.Size(41, 20);
            this.radio_x4.TabIndex = 4;
            this.radio_x4.TabStop = true;
            this.radio_x4.Text = "x4";
            this.radio_x4.UseVisualStyleBackColor = true;
            this.radio_x4.CheckedChanged += new System.EventHandler(this.radio_x4_Checked);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.edit_position);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.slider_postion);
            this.groupBox6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(534, 12);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(112, 298);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Position (deg)";
            // 
            // edit_position
            // 
            this.edit_position.Location = new System.Drawing.Point(22, 265);
            this.edit_position.Margin = new System.Windows.Forms.Padding(2);
            this.edit_position.Name = "edit_position";
            this.edit_position.Size = new System.Drawing.Size(73, 22);
            this.edit_position.TabIndex = 7;
            this.edit_position.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edit_position_KeyPress);
            this.edit_position.Leave += new System.EventHandler(this.edit_position_Confirm);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 240);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "-360";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "360";
            // 
            // slider_postion
            // 
            this.slider_postion.Location = new System.Drawing.Point(37, 36);
            this.slider_postion.Margin = new System.Windows.Forms.Padding(2);
            this.slider_postion.Maximum = 360;
            this.slider_postion.Minimum = -360;
            this.slider_postion.Name = "slider_postion";
            this.slider_postion.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.slider_postion.Size = new System.Drawing.Size(45, 203);
            this.slider_postion.TabIndex = 4;
            this.slider_postion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider_postion_MouseUp);
            // 
            // text_status
            // 
            this.text_status.AutoSize = true;
            this.text_status.ForeColor = System.Drawing.Color.Red;
            this.text_status.Location = new System.Drawing.Point(8, 489);
            this.text_status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.text_status.Name = "text_status";
            this.text_status.Size = new System.Drawing.Size(90, 13);
            this.text_status.TabIndex = 8;
            this.text_status.Text = "Application status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.edit_d);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.edit_i);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.edit_p);
            this.groupBox1.Controls.Add(this.btn_pid);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(534, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 168);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 92);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "D";
            // 
            // edit_d
            // 
            this.edit_d.Location = new System.Drawing.Point(33, 90);
            this.edit_d.Margin = new System.Windows.Forms.Padding(2);
            this.edit_d.Name = "edit_d";
            this.edit_d.Size = new System.Drawing.Size(68, 22);
            this.edit_d.TabIndex = 13;
            this.edit_d.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edit_d_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "I";
            // 
            // edit_i
            // 
            this.edit_i.Location = new System.Drawing.Point(33, 58);
            this.edit_i.Margin = new System.Windows.Forms.Padding(2);
            this.edit_i.Name = "edit_i";
            this.edit_i.Size = new System.Drawing.Size(68, 22);
            this.edit_i.TabIndex = 11;
            this.edit_i.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edit_i_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "P";
            // 
            // edit_p
            // 
            this.edit_p.Location = new System.Drawing.Point(33, 29);
            this.edit_p.Margin = new System.Windows.Forms.Padding(2);
            this.edit_p.Name = "edit_p";
            this.edit_p.Size = new System.Drawing.Size(68, 22);
            this.edit_p.TabIndex = 9;
            this.edit_p.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edit_p_KeyPress);
            // 
            // btn_pid
            // 
            this.btn_pid.Location = new System.Drawing.Point(22, 123);
            this.btn_pid.Margin = new System.Windows.Forms.Padding(2);
            this.btn_pid.Name = "btn_pid";
            this.btn_pid.Size = new System.Drawing.Size(68, 27);
            this.btn_pid.TabIndex = 8;
            this.btn_pid.Text = "Set";
            this.btn_pid.UseVisualStyleBackColor = true;
            this.btn_pid.Click += new System.EventHandler(this.btn_pid_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.text_status);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.gr_options);
            this.Controls.Add(this.gr_feedBack);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gr_feedBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_fb)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gr_options.ResumeLayout(false);
            this.gr_options.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_postion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox gr_feedBack;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_fb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddl_baudrate;
        private System.Windows.Forms.ComboBox ddl_name;
        private System.Windows.Forms.RadioButton radio_x1;
        private System.Windows.Forms.GroupBox gr_options;
        private System.Windows.Forms.RadioButton radio_x4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox edit_position;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar slider_postion;
        private System.Windows.Forms.Label text_status;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edit_d;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edit_i;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edit_p;
        private System.Windows.Forms.Button btn_pid;
    }
}

