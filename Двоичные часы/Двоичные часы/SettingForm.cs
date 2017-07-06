using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Diagnostics;

namespace Двоичные_часы
{
    public partial class SettingForm : Form
    {
        
        const int _left_rb5 = 300;
        const int _left_pb5 = 320;
        public SettingForm()
        {
            InitializeComponent();
            LoadSettings();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }
        private void SaveSettings()
        {
            // Create or get existing subkey
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Demo_ScreenSaver_Bin");
            if (pictureBox_style.ImageLocation == "Content/settings/style_1.xn") key.SetValue("Style", "1");
            else if (pictureBox_style.ImageLocation == "Content/settings/style_2.xn") key.SetValue("Style", "2");
            else if (pictureBox_style.ImageLocation == "Content/settings/style_3.xn") key.SetValue("Style", "3");

            if (comboBox1.SelectedIndex==0) key.SetValue("Type", "circle");
            else if (comboBox1.SelectedIndex == 1) key.SetValue("Type", "box");
            else if (comboBox1.SelectedIndex == 2) key.SetValue("Type", "bulb");

            String color = "";
            if (radioButton1.Checked) color="blue";
            else if (radioButton2.Checked) color = "green";
            else if (radioButton3.Checked) color = "red";
            else if (radioButton4.Checked) color = "orange";
            else if (radioButton5.Checked) color = "yellow";
            else color = "blue";
                key.SetValue("Color", color);

                key.SetValue("Speed", trackBar1.Value);
                if (pictureBox6.ImageLocation == "Content/settings/no_sound.bmp") key.SetValue("Sound", 0);
                else key.SetValue("Sound", 1);
                if (checkBox1.Checked) key.SetValue("Matrix", 1);
                else key.SetValue("Matrix", 0);
            key.Close();
        }

        private void LoadSettings()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Demo_ScreenSaver_Bin", true);
                if (key == null) 
                {
                    comboBox1.SelectedItem = "Круги";
                    radioButton1.Select();
                    pictureBox_style.Load("Content/settings/style_1.xn");
                    groupBox1.Visible = true;
                    pictureBox6.Load("Content/settings/sound.bmp");
                    pictureBox6.Visible = false;
                    checkBox1.Checked = true;
                }
                else if ((string)key.GetValue("Type") == "circle") comboBox1.SelectedIndex = 0;
                else if ((string)key.GetValue("Type") == "box") comboBox1.SelectedIndex = 1;
                else if ((string)key.GetValue("Type") == "bulb") comboBox1.SelectedIndex = 2;

                if ((key != null) && (key.GetValue("Color").ToString() != "") && (key.GetValue("Type").ToString() != ""))
                {
                    if ((string)key.GetValue("Color") == "blue") radioButton1.Select();
                    else if ((string)key.GetValue("Color") == "green") radioButton2.Select();
                    else if ((string)key.GetValue("Color") == "red") radioButton3.Select();
                    else if ((string)key.GetValue("Color") == "orange") radioButton4.Select();
                    else if ((string)key.GetValue("Color") == "yellow") radioButton5.Select();
                }
                if ((key != null) || (key.GetValue("Style").ToString() != ""))
                {
                    if ((string)key.GetValue("Style") == "1")
                    {
                        pictureBox_style.Load("Content/settings/style_1.xn");
                        groupBox1.Visible = true;
                        pictureBox6.Visible = false;
                    }
                    else if ((string)key.GetValue("Style") == "2")
                    { pictureBox_style.Load("Content/settings/style_2.xn"); pictureBox6.Visible = true; }
                    else if ((string)key.GetValue("Style") == "3")
                    {
                        pictureBox_style.Load("Content/settings/style_3.xn");
                        trackBar1.Visible = true;
                        label2.Visible = true;
                        pictureBox6.Visible = true;
                    }
                }
                if (key != null) trackBar1.Value = (int)key.GetValue("Speed");
                if ((key != null) && (key.GetValue("Sound")!=null))
                {
                    if ((int)key.GetValue("Sound")==0) pictureBox6.Load("Content/settings/no_sound.bmp");
                    else pictureBox6.Load("Content/settings/sound.bmp");
                }
                if ((key != null) && (key.GetValue("Matrix")!=null))
                {
                    if ((int)key.GetValue("Matrix") == 1) checkBox1.Checked = true;
                    else checkBox1.Checked = false;
                    
                }
            }
            catch { };
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2) 
            {
                if (radioButton4.Checked) radioButton1.Select();
                radioButton4.Visible = false; pictureBox4.Visible = false;
                radioButton5.Left = radioButton4.Left;
                pictureBox5.Left = pictureBox4.Left;
            }
            else 
            { 
                radioButton4.Visible = true; pictureBox4.Visible = true;
                radioButton5.Left = _left_rb5;
                pictureBox5.Left = _left_pb5;
            }

        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            pictureBox_left.Load("Content/settings/left.xna");
            pictureBox_right.Load("Content/settings/right.xna");
            pictureBox_style_2.Location = new System.Drawing.Point(pictureBox_style.Location.X - 100, pictureBox_style.Location.Y);
        }

        private void pictureBox_right_Click(object sender, EventArgs e)
        {
            if (pictureBox_style.ImageLocation == "Content/settings/style_1.xn")
            {
                pictureBox_style_2.Visible = true;
                pictureBox_style_2.Location = new System.Drawing.Point(pictureBox_style_2.Location.X+260, pictureBox_style_2.Location.Y);
                pictureBox_style_2.Load("Content/settings/style_2.xn");
                timer_right.Start();
                timer_right_Tick(sender,e);
                pictureBox6.Visible = true;
            }
            else if (pictureBox_style.ImageLocation == "Content/settings/style_2.xn")
            {
                pictureBox_style_2.Visible = true;
                pictureBox_style_2.Location = new System.Drawing.Point(pictureBox_style_2.Location.X + 260, pictureBox_style_2.Location.Y);
                pictureBox_style_2.Load("Content/settings/style_3.xn");
                timer_right.Start();
                timer_right_Tick(sender, e);
                pictureBox6.Visible = true;
            }
            else if (pictureBox_style.ImageLocation == "Content/settings/style_3.xn")
            {
                pictureBox_style_2.Visible = true;
                pictureBox_style_2.Location = new System.Drawing.Point(pictureBox_style_2.Location.X + 260, pictureBox_style_2.Location.Y);
                pictureBox_style_2.Load("Content/settings/style_1.xn");
                pictureBox6.Visible = false;
                timer_right.Start();
                timer_right_Tick(sender, e);
            }
        }

        private void pictureBox_right_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_right.Load("Content/settings/right_80.xna");
        }

        private void pictureBox_right_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_right.Load("Content/settings/right.xna");
        }

        private void pictureBox_left_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_left.Load("Content/settings/left_80.xna");
        }

        private void pictureBox_left_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_left.Load("Content/settings/left.xna");
        }

        private void pictureBox_left_Click(object sender, EventArgs e)
        {
            if (pictureBox_style.ImageLocation == "Content/settings/style_1.xn")
            {
                pictureBox_style_2.Visible = true;
                pictureBox_style_2.Location = new System.Drawing.Point(-140, pictureBox_style_2.Location.Y);
                pictureBox_style_2.Load("Content/settings/style_3.xn");
                timer_left.Start();
                timer_left_Tick(sender, e);
                pictureBox6.Visible = true;
                
            }
            else if (pictureBox_style.ImageLocation == "Content/settings/style_2.xn")
            {
                pictureBox_style_2.Visible = true;
                pictureBox_style_2.Location = new System.Drawing.Point(-140, pictureBox_style_2.Location.Y);
                pictureBox_style_2.Load("Content/settings/style_1.xn");
                pictureBox6.Visible = false;
                timer_left.Start();
                timer_left_Tick(sender, e);
            }
            else if (pictureBox_style.ImageLocation == "Content/settings/style_3.xn")
            {
                pictureBox_style_2.Visible = true;
                pictureBox_style_2.Location = new System.Drawing.Point(-140, pictureBox_style_2.Location.Y);
                pictureBox_style_2.Load("Content/settings/style_2.xn");
                timer_left.Start();
                timer_left_Tick(sender, e);
                pictureBox6.Visible = true;
            }

            
        }

        private void timer_left_Tick(object sender, EventArgs e)
        {
            if (pictureBox_style_2.Location.X <= pictureBox_style.Location.X)
                pictureBox_style_2.Location = new System.Drawing.Point(pictureBox_style_2.Location.X + 20,
                    pictureBox_style_2.Location.Y);
            else
            {
                pictureBox_style_2.Visible = false;
                pictureBox_style.ImageLocation = pictureBox_style_2.ImageLocation;
                timer_left.Stop();
            }
        }

        private void timer_right_Tick(object sender, EventArgs e)
        {
            if (pictureBox_style_2.Location.X >= pictureBox_style.Location.X)
                pictureBox_style_2.Location = new System.Drawing.Point(pictureBox_style_2.Location.X - 20,
                    pictureBox_style_2.Location.Y);
            else
            {
                pictureBox_style_2.Visible = false;
                pictureBox_style.ImageLocation = pictureBox_style_2.ImageLocation;
                timer_right.Stop();

            }
        }

        private void pictureBox_style_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (pictureBox_style.ImageLocation == "Content/settings/style_1.xn")
            {
                groupBox1.Visible = true;
            }
            if (pictureBox_style.ImageLocation != "Content/settings/style_1.xn")
            {
                groupBox1.Visible = false;
                SettingForm f = new SettingForm();
                f.Height = 250;
                timer_up.Start();
                timer_up_Tick(sender, e);
            }
            if (pictureBox_style.ImageLocation == "Content/settings/style_2.xn")
            {
                SettingForm f = new SettingForm();
                 f.Size = new System.Drawing.Size(562, 310);
            }

            if (pictureBox_style.ImageLocation == "Content/settings/style_3.xn")
            {
                trackBar1.Visible = true;
                label2.Visible = true;
            }
            if (pictureBox_style.ImageLocation != "Content/settings/style_3.xn")
            {
                trackBar1.Visible = false;
                label2.Visible = false;
            } 
            
        }

        private void timer_up_Tick(object sender, EventArgs e)
        {
            SettingForm f = new SettingForm();
            if (f.Height > 250) f.Height -= 10;
            else timer_up.Stop();
        }

        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            menuStrip1.Visible = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox6.ImageLocation == "Content/settings/no_sound.bmp") pictureBox6.ImageLocation = "Content/settings/sound.bmp";
            else pictureBox6.ImageLocation = "Content/settings/no_sound.bmp";
        }

        private void разработчикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программу разработал:\t\t\t\nучащийся 4 курса\n группы 369\nБГКЛП\nОсейко Сергей Иванович\n"+
                "_________________________________________________________\n"+
            "Кантактные данные:   \t\t\t\nsergeioseiko@mail.ru",
                "О разработчике...", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            Process SysInfo = new Process();
            SysInfo.StartInfo.ErrorDialog = true;
            SysInfo.StartInfo.FileName = "Content\\settings\\Help.chm";
            SysInfo.Start();
            }
            catch (Exception ex)
            {
            MessageBox.Show (ex.Message);
            }
        }
    }
}
