using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DCMotorEncoderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool closeSignal = true;

        string dataReceived;
        byte[] tempBytes;
        int timerTick = 0;
        int loop = 0;
        int timerData = 0;
        float dataX = 0;
        float dataY = 0;
        float setPoint = 0;
        int timeout = 2;
        bool timerDataEnable = false;

        string portName;
        int baudrate;

        byte[] bytesReceived;

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] portsName = SerialPort.GetPortNames();
            ddl_name.Items.AddRange(portsName);
            //Default value for baudrate
            ddl_baudrate.SelectedItem = "9600";
            edit_position.Text = slider_postion.Value.ToString();

            timer.Interval = 100;
            timer.Start();

            edit_p.Text = "0";
            edit_i.Text = "0";
            edit_d.Text = "0";

            //Khoi tao thong so cho Chart
            chart_fb.Series.Clear();
            chart_fb.Titles.Add("Feedback of angular response over time");
            var chartArea = chart_fb.ChartAreas[0];
            chartArea.AxisX.LabelStyle.Format = "";
            chartArea.AxisY.LabelStyle.Format = "";
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = true;
            chartArea.AxisY.LabelStyle.IsEndLabelVisible = true;
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisX.Maximum = 100;
            chartArea.AxisY.Maximum = 100;
            chartArea.AxisX.Interval = 20;
            chartArea.AxisY.Interval = 20;
            chartArea.AxisX.Title = "Time (ms*100)";
            chartArea.AxisY.Title = "Angular (o)";
            chart_fb.Series.Add("Feedback");
            chart_fb.Series["Feedback"].ChartType = SeriesChartType.Line;
            chart_fb.Series["Feedback"].Color = Color.Red;
            chart_fb.Series["Feedback"].BorderWidth = 2;
            chart_fb.Series["Feedback"].IsVisibleInLegend = false;

            chart_fb.Series.Add("SetPoint");
            chart_fb.Series["SetPoint"].ChartType = SeriesChartType.Line;
            chart_fb.Series["SetPoint"].Color = Color.Blue;
            chart_fb.Series["SetPoint"].BorderWidth = 2;
            chart_fb.Series["SetPoint"].IsVisibleInLegend = false;
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            closeSignal = false;
            try
            {
                serialPort.PortName = ddl_name.Text;
                portName = serialPort.PortName;
                serialPort.BaudRate = Convert.ToInt32(ddl_baudrate.Text);
                baudrate = serialPort.BaudRate;

                serialPort.Open();
                text_status.Text = "Port opened!";
                text_status.ForeColor = Color.Green;
                radio_x4.Checked = true;

                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            closeSignal = true;
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                text_status.Text = "Port closed!";
                text_status.ForeColor = Color.Red;
                radio_x1.Checked = false;
                radio_x4.Checked = false;
                timer.Stop();
                this.Invoke(new EventHandler(btn_reset_Click));
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            loop++;
            if (loop % 10 == 0)
            {
                string[] portsName = SerialPort.GetPortNames();
                if (portsName.Length != 0)
                {
                    if (!portsName.SequenceEqual(ddl_name.Items.Cast<string>()))
                    {
                        ddl_name.Items.Clear();
                        ddl_name.Items.AddRange(portsName.Distinct().ToArray());
                    }
                }
                else
                {
                    ddl_name.Items.Clear();
                }

                if (!serialPort.IsOpen && !closeSignal)
                {
                    timerTick++;
                    serialPort.PortName = portName;
                    serialPort.BaudRate = baudrate;

                    try
                    {
                        serialPort.Open();
                        timerTick = 0;
                        text_status.Text = "Port opened!";
                        text_status.ForeColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (timerTick <= 5)
                            text_status.Text = $"Port closed suddenly!";
                        else
                            text_status.Text = $"Trying to reconnect to serial port: {timerTick}s";
                        text_status.ForeColor = Color.Red;
                        //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (serialPort.IsOpen)
            {
                dataX++;
                this.Invoke(new Action(() => PlotChart(dataX, dataY)));
            }

            if (timerDataEnable && serialPort.IsOpen)
            {
                timerData++;
                //if (timerData >= 2)
                //{
                //    text_status.Text = $"Waiting data from serial port: {timerData / 1000}s";
                //    text_status.ForeColor = Color.Red;
                //}
                if (timerData > timeout)
                {
                    text_status.Text = $"Abort the current data frame due to expired time ({timeout * 100}ms)!";
                    text_status.ForeColor = Color.Red;
                    timerDataEnable = false;
                    timerData = 0;
                    tempBytes = null;
                }
            }
        }

        private void slider_postion_MouseUp(object sender, MouseEventArgs e)
        {
            edit_position.Text = slider_postion.Value.ToString();
            setPoint = slider_postion.Value;
            if (serialPort.IsOpen)
            {
                byte[] frame = new DataFrame().SetPointFrame(slider_postion.Value);
                this.Invoke(new Action(() => SendFrame(frame)));
            }
            else
            {
                text_status.Text = "Serial port has not been connected";
                text_status.ForeColor = Color.Red;
            }
        }

        private void edit_position_Confirm(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(edit_position.Text, out value))
            {
                if (!(value >= -360 && value <= 360))
                {
                    value = value % 360;
                    value = value < -360 ? value + 360 : (value > 360 ? value - 360 : value);
                }

                setPoint = value;
                slider_postion.Value = (int)value;
                value = (float)Math.Round(value, 1);
                if (serialPort.IsOpen)
                {
                    byte[] frame = new DataFrame().SetPointFrame(value);
                    this.Invoke(new Action(() => SendFrame(frame)));
                }
                else
                {
                    text_status.Text = "Serial port has not been connected";
                    text_status.ForeColor = Color.Red;
                }
            }
        }

        private void edit_position_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && edit_position.Text.IndexOf('.') != -1)
                e.Handled = true;

            if (!Char.IsDigit(ch) & ch != 8 && ch != 46 && ch != (char)Keys.Enter && ch != '-')
                e.Handled = true;

            float value;
            if (!e.Handled && float.TryParse(edit_position.Text, out value))
            {
                text_status.Text = text_status.Text.Contains("Error: Entry number is not valid") ? "" : text_status.Text;
            }
            else
            {
                text_status.Text = "Error: Entry number is not valid";
            }

            if (!e.Handled && float.TryParse(edit_position.Text, out value) && ch == (char)Keys.Enter)
            {
                this.Invoke(new EventHandler(edit_position_Confirm));
            }
        }

        private void radio_x4_Checked(object sender, EventArgs e)
        {
            if (serialPort.IsOpen && radio_x4.Checked)
            {
                byte[] frame = new DataFrame().SetModeFrame(4);
                this.Invoke(new Action(() => SendFrame(frame)));
            }
            else
            {
                text_status.Text = "Serial port has not been connected";
                text_status.ForeColor = Color.Red;
            }
        }

        private void radio_x1_Checked(object sender, EventArgs e)
        {
            if (serialPort.IsOpen && radio_x1.Checked)
            {
                byte[] frame = new DataFrame().SetModeFrame(1);
                this.Invoke(new Action(() => SendFrame(frame)));
            }
            else
            {
                text_status.Text = "Serial port has not been connected";
                text_status.ForeColor = Color.Red;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            chart_fb.Series["Feedback"].Points.Clear();
            text_status.Text = "";
            edit_position.Text = "0";
            slider_postion.Value = 0;
            radio_x1.Checked = false;
            radio_x4.Checked = false;
            edit_p.Text = "0";
            edit_i.Text = "0";
            edit_d.Text = "0";
            dataX = 0;
            dataY = 0;
            var chartArea = chart_fb.ChartAreas[0];
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisX.Maximum = 100;
            chartArea.AxisY.Maximum = 100;
            chartArea.AxisX.Interval = 20;
            chartArea.AxisY.Interval = 20;
        }

        private void edit_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && edit_p.Text.IndexOf('.') != -1)
                e.Handled = true;

            if (!Char.IsDigit(ch) & ch != 8 && ch != 46 && ch != (char)Keys.Enter && ch != '-')
                e.Handled = true;

            float value;
            if (!e.Handled && float.TryParse(edit_p.Text, out value))
            {
                text_status.Text = text_status.Text.Contains("Error: Entry number is not valid") ? "" : text_status.Text;
            }
            else
            {
                text_status.Text = "Error: Entry number is not valid";
            }
        }

        private void edit_i_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && edit_i.Text.IndexOf('.') != -1)
                e.Handled = true;

            if (!Char.IsDigit(ch) & ch != 8 && ch != 46 && ch != (char)Keys.Enter && ch != '-')
                e.Handled = true;

            float value;
            if (!e.Handled && float.TryParse(edit_i.Text, out value))
            {
                text_status.Text = text_status.Text.Contains("Error: Entry number is not valid") ? "" : text_status.Text;
            }
            else
            {
                text_status.Text = "Error: Entry number is not valid";
            }
        }

        private void edit_d_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && edit_d.Text.IndexOf('.') != -1)
                e.Handled = true;

            if (!Char.IsDigit(ch) & ch != 8 && ch != 46 && ch != (char)Keys.Enter && ch != '-')
                e.Handled = true;

            float value;
            if (!e.Handled && float.TryParse(edit_d.Text, out value))
            {
                text_status.Text = text_status.Text.Contains("Error: Entry number is not valid") ? "" : text_status.Text;
            }
            else
            {
                text_status.Text = "Error: Entry number is not valid";
            }
        }

        private void btn_pid_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                if (!string.IsNullOrEmpty(edit_p.Text) && !string.IsNullOrEmpty(edit_p.Text) && !string.IsNullOrEmpty(edit_p.Text) && !text_status.Text.Contains("Error"))
                {
                    byte[] frame = new DataFrame().SetPID(float.Parse(edit_p.Text), float.Parse(edit_i.Text), float.Parse(edit_d.Text));
                    this.Invoke(new Action(() => SendFrame(frame)));
                }
                else
                {
                    text_status.Text = "PID parameters is not valid";
                    text_status.ForeColor = Color.Red;
                }
            }
            else
            {
                text_status.Text = "Serial port has not been connected";
                text_status.ForeColor = Color.Red;
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            timerData = 0;
            timerDataEnable = true;
            // When data available in buffer, read those
            int bytesToRead = serialPort.BytesToRead;

            byte[] buffer = new byte[bytesToRead];

            serialPort.Read(buffer, 0, bytesToRead);

            // Store data to a temporary variable until it has 18 elements
            if (tempBytes == null)
            {
                //tempBytes = Encoding.ASCII.GetBytes(dataReceived);
                tempBytes = buffer;
            }
            else
            {
                //tempBytes = tempBytes.Concat(Encoding.ASCII.GetBytes(dataReceived)).ToArray();
                tempBytes = tempBytes.Concat(buffer).ToArray();
            }

            if (tempBytes.Length > 0 && tempBytes[tempBytes.Length - 1] == 0x06) //Is last byte ACK?
            {
                // Convey data from temp variable to official variable and renew temp variable
                bytesReceived = tempBytes;
                tempBytes = new byte[0];

                this.Invoke(new Action(() =>
                {
                DataFrame frame = new DataFrame(bytesReceived);
                if (frame.IsValid)
                {
                        switch (frame.Command)
                        {
                            case (0x01):
                                text_status.Text = $"Set Point success - Value: {frame.FloatConverter(frame.Parameters)}";
                                text_status.ForeColor = Color.Green;
                                break;
                            case (0x02):
                                text_status.Text = $"Set Mode Encoder success - Mode: x{frame.IntConverter(frame.Parameters)}";
                                text_status.ForeColor = Color.Green;
                                break;
                            case (0x03):
                                text_status.Text = $"Set PID parameters success - P: {frame.FloatConverter(frame.Parameters.Take(4).ToArray())}, I: {frame.FloatConverter(frame.Parameters.Skip(4).Take(4).ToArray())}, D: {frame.FloatConverter(frame.Parameters.Skip(8).Take(4).ToArray())}";
                                text_status.ForeColor = Color.Green;
                                break;
                            case (0x04):
                                dataY = frame.FloatConverter(frame.Parameters);
                                text_status.Text = $"Receive current position success - Position: {frame.FloatConverter(frame.Parameters)}";
                                text_status.ForeColor = Color.Green;
                                break;
                        }
                    //this.Invoke(new Action(() => PlotChart(timerX, frame.Parameters)));
                }
                else
                {
                    text_status.Text = $"Error when receiving data from serial port. Command: {frame.Command}";
                    text_status.ForeColor = Color.Red;
                }

                }));
            }
        }

        private void SendFrame(byte[] frame)
        {
            DataFrame dFrame = new DataFrame(frame);
            if (dFrame.Command != 2)
            {
                float value = dFrame.FloatConverter(dFrame.Parameters);
            }
            else
            {
                int value = dFrame.IntConverter(dFrame.Parameters);
            }
            if (serialPort.IsOpen)
            {
                serialPort.Write(frame, 0, frame.Length);
            }
            else
            {
                text_status.Text = "Serial port has not been connected";
            }
        }

        private void PlotChart(double dataX, double dataY)
        {
            chart_fb.Series["Feedback"].Points.AddXY(dataX, dataY);
            chart_fb.Series["SetPoint"].Points.AddXY(dataX, setPoint);
            var chartArea = chart_fb.ChartAreas[0];
            if (dataX > chartArea.AxisX.Maximum)
            {
                chartArea.AxisX.Maximum = dataX;
                if (dataX / chartArea.AxisX.Interval == 10)
                    chartArea.AxisX.Interval = dataX / 5;
            }
            if (dataY > chartArea.AxisY.Maximum || setPoint > chartArea.AxisY.Maximum)
            {
                chartArea.AxisY.Maximum += 20;
            }
        }
    }
}
