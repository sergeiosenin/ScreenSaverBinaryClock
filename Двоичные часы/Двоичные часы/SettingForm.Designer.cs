namespace Двоичные_часы
{
    partial class SettingForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox_style = new System.Windows.Forms.PictureBox();
            this.pictureBox_right = new System.Windows.Forms.PictureBox();
            this.pictureBox_left = new System.Windows.Forms.PictureBox();
            this.pictureBox_style_2 = new System.Windows.Forms.PictureBox();
            this.timer_left = new System.Windows.Forms.Timer(this.components);
            this.timer_right = new System.Windows.Forms.Timer(this.components);
            this.timer_up = new System.Windows.Forms.Timer(this.components);
            this.timer_down = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разработчикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_style)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_style_2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите тип символов";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Круг";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Круги",
            "Квадраты",
            "Лампочки"});
            this.comboBox1.Location = new System.Drawing.Point(228, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(134, 27);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "Круг";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(41, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Принять";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(361, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(63, 261);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 157);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подробные настройки стиля";
            this.groupBox1.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(42, 128);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(204, 23);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Матрица на заднем плане";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox5.Location = new System.Drawing.Point(330, 76);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(35, 35);
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pictureBox4.Location = new System.Drawing.Point(265, 76);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 35);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Red;
            this.pictureBox3.Location = new System.Drawing.Point(198, 76);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 35);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(130, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Location = new System.Drawing.Point(62, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.BackColor = System.Drawing.Color.Yellow;
            this.radioButton5.Location = new System.Drawing.Point(310, 86);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(14, 13);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.radioButton4.Location = new System.Drawing.Point(245, 86);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(14, 13);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Red;
            this.radioButton3.Location = new System.Drawing.Point(178, 86);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(14, 13);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Lime;
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.radioButton2.Location = new System.Drawing.Point(110, 86);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Blue;
            this.radioButton1.Location = new System.Drawing.Point(42, 86);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(193, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Скорость пермещения";
            this.label2.Visible = false;
            // 
            // pictureBox_style
            // 
            this.pictureBox_style.Location = new System.Drawing.Point(138, 27);
            this.pictureBox_style.Name = "pictureBox_style";
            this.pictureBox_style.Size = new System.Drawing.Size(288, 180);
            this.pictureBox_style.TabIndex = 5;
            this.pictureBox_style.TabStop = false;
            this.pictureBox_style.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox_style_LoadCompleted);
            // 
            // pictureBox_right
            // 
            this.pictureBox_right.Location = new System.Drawing.Point(432, 78);
            this.pictureBox_right.Name = "pictureBox_right";
            this.pictureBox_right.Size = new System.Drawing.Size(48, 64);
            this.pictureBox_right.TabIndex = 6;
            this.pictureBox_right.TabStop = false;
            this.pictureBox_right.Click += new System.EventHandler(this.pictureBox_right_Click);
            this.pictureBox_right.MouseEnter += new System.EventHandler(this.pictureBox_right_MouseEnter);
            this.pictureBox_right.MouseLeave += new System.EventHandler(this.pictureBox_right_MouseLeave);
            // 
            // pictureBox_left
            // 
            this.pictureBox_left.Location = new System.Drawing.Point(84, 78);
            this.pictureBox_left.Name = "pictureBox_left";
            this.pictureBox_left.Size = new System.Drawing.Size(48, 64);
            this.pictureBox_left.TabIndex = 7;
            this.pictureBox_left.TabStop = false;
            this.pictureBox_left.Click += new System.EventHandler(this.pictureBox_left_Click);
            this.pictureBox_left.MouseEnter += new System.EventHandler(this.pictureBox_left_MouseEnter);
            this.pictureBox_left.MouseLeave += new System.EventHandler(this.pictureBox_left_MouseLeave);
            // 
            // pictureBox_style_2
            // 
            this.pictureBox_style_2.Location = new System.Drawing.Point(138, 27);
            this.pictureBox_style_2.Name = "pictureBox_style_2";
            this.pictureBox_style_2.Size = new System.Drawing.Size(288, 180);
            this.pictureBox_style_2.TabIndex = 8;
            this.pictureBox_style_2.TabStop = false;
            this.pictureBox_style_2.Visible = false;
            // 
            // timer_left
            // 
            this.timer_left.Interval = 1;
            this.timer_left.Tick += new System.EventHandler(this.timer_left_Tick);
            // 
            // timer_right
            // 
            this.timer_right.Interval = 1;
            this.timer_right.Tick += new System.EventHandler(this.timer_right_Tick);
            // 
            // timer_up
            // 
            this.timer_up.Interval = 1;
            this.timer_up.Tick += new System.EventHandler(this.timer_up_Tick);
            // 
            // timer_down
            // 
            this.timer_down.Interval = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(546, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseEnter += new System.EventHandler(this.menuStrip1_MouseEnter);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.разработчикToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "&О программе";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.справкаToolStripMenuItem.Text = "&Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // разработчикToolStripMenuItem
            // 
            this.разработчикToolStripMenuItem.Name = "разработчикToolStripMenuItem";
            this.разработчикToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.разработчикToolStripMenuItem.Text = "&Разработчик";
            this.разработчикToolStripMenuItem.Click += new System.EventHandler(this.разработчикToolStripMenuItem_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(138, 204);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(290, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(438, 231);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(64, 64);
            this.pictureBox6.TabIndex = 12;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 476);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox_style_2);
            this.Controls.Add(this.pictureBox_left);
            this.Controls.Add(this.pictureBox_right);
            this.Controls.Add(this.pictureBox_style);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(562, 514);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(562, 300);
            this.Name = "SettingForm";
            this.Text = "Параметры заставки";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_style)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_style_2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.PictureBox pictureBox_style;
        private System.Windows.Forms.PictureBox pictureBox_right;
        private System.Windows.Forms.PictureBox pictureBox_left;
        private System.Windows.Forms.PictureBox pictureBox_style_2;
        private System.Windows.Forms.Timer timer_right;
        private System.Windows.Forms.Timer timer_left;
        private System.Windows.Forms.Timer timer_up;
        private System.Windows.Forms.Timer timer_down;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разработчикToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}