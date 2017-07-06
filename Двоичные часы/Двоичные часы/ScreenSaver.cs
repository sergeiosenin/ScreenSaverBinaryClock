using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Win32;
using System.Security.Permissions;


namespace Двоичные_часы
{
    public class ScreenSaver : Microsoft.Xna.Framework.Game
    {
        #region variable
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RegistryKey key;
        MouseState state1 = Mouse.GetState();
        DateTime nowTime;
        bool play_sound = true;
        int STYLE ;
            //Style 1- Matrix   
        SpriteFont spriteFont_3;        //Style 3
       
        //Style 1
        SpriteFont spriteFont;           //Style 1 - Text
        SpriteFont spriteFont_matrix;
        Texture2D lamps_0;
        Texture2D lamps_1;
        Texture2D Frames;
        char[,] matrix;
        int[] Number_line;
        Random rand;
        bool matrix_draw=true;

        //Style 2
        Texture2D Arrow_Hour;
        Texture2D Arrow_Minute;
        Texture2D Arrow_Second;
        Texture2D numeric_0;
        Texture2D numeric_1;
        Texture2D numeric_2;
        Texture2D numeric_3;
        int interval_width;
        int interval_height;        
        Rectangle ArrowRectangle_hour;
        Rectangle ArrowRectangle_minute;
        Rectangle ArrowRectangle_second;
        Vector2 ArrowPosition;
        Vector2 ArrowOrigin_Hour;
        Vector2 ArrowOrigin_Minute;
        Vector2 ArrowOrigin_Second;
        float rotation_second;
        float rotation_minute;
        float rotation_hour;
        SoundEffect sound_tick;

        //Style 3
        Vector2 position;
        Vector2 speed;
        SoundEffect sound_stuk;
        Texture2D lines;
        Random rand_color;
        Color color;
        int r = 0, g = 0, b = 0;
        
        
        private const int GWL_STYLE = -16;
        private const int WS_CHILD = 1073741824;
        
        private struct RECT
        {
            public int left,
                            top,
                            right,
                            bottom;
        }
        #region Win32 API functions
        [DllImport("user32.dll")]
        private static extern void SetWindowLong(IntPtr hWnd, int nIndex, int nNewIndex);

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT rect);

        [DllImport("user32.dll")]
        public static extern void MoveWindow(IntPtr hwnd, int x, int y, int width, int height, bool repaint);

        [DllImport("user32.dll")]
        public static extern void SetParent(IntPtr childHwnd, IntPtr parentHwnd);

        [DllImport("user32.DLL", EntryPoint = "IsWindowVisible")]
        private static extern bool IsWindowVisible(IntPtr hWnd);
        #endregion
        
        public IntPtr _parentHwnd = new IntPtr(0);
        public bool _previewMode = false;
        #endregion

        public ScreenSaver()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           
        }
        public ScreenSaver(IntPtr parentHwnd)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this._previewMode = true;
            this._parentHwnd = parentHwnd;
        }
        protected override void Initialize()
        {
            if (this._previewMode == false)
            {
                this.graphics.PreferredBackBufferFormat = this.graphics.GraphicsDevice.DisplayMode.Format;
                this.graphics.PreferredBackBufferWidth = this.graphics.GraphicsDevice.DisplayMode.Width;
                this.graphics.PreferredBackBufferHeight = this.graphics.GraphicsDevice.DisplayMode.Height;
                this.graphics.IsFullScreen = true;
                this.IsMouseVisible = false;
                this.graphics.ApplyChanges();
                try
                {
                     key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Demo_ScreenSaver_Bin");
                     if (key == null)  STYLE = 1;
                     else if (key.GetValue("Style").ToString() == "1") STYLE = 1;
                     else if (key.GetValue("Style").ToString() == "2") STYLE = 2;
                     else if (key.GetValue("Style").ToString() == "3") STYLE = 3;
                }
                catch { };
                Number_line = new int[this.graphics.GraphicsDevice.DisplayMode.Height / 15];
                for (int i = 0; i < Number_line.Length; i++)
                    Number_line[i] = i - 1;

                interval_width = (int)this.graphics.GraphicsDevice.DisplayMode.Width / 10;
                interval_height = (int)this.graphics.GraphicsDevice.DisplayMode.Height / 7;
            }
            else
            {
                this.graphics.IsFullScreen = false;
                this.IsMouseVisible = true;
                
                this.graphics.ApplyChanges();

                if (IsWindowVisible(this._parentHwnd) == true)
                {
                    RECT wndRect = new RECT();
                    GetClientRect(this._parentHwnd, ref wndRect);
                    SetParent(this.Window.Handle, this._parentHwnd);
                    SetWindowLong(this.Window.Handle, GWL_STYLE, WS_CHILD);
                    MoveWindow(this.Window.Handle, wndRect.left, wndRect.top, wndRect.right, wndRect.bottom, false);
                }
            }
                base.Initialize();
        }
        protected override void LoadContent()
        {
            switch (STYLE)
            {
                case 1:
                    {
                        spriteFont = Content.Load<SpriteFont>("SpriteFont1");
                        spriteFont_matrix = Content.Load<SpriteFont>("SpriteFont_matrix");
                        try
                        {
                            key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Demo_ScreenSaver_Bin");
                            if (key == null)
                            {
                                lamps_0 = Content.Load<Texture2D>("Lamps/circle");
                                lamps_1 = Content.Load<Texture2D>("Lamps/circle_blue");
                                matrix_draw = true;
                            }
                            else
                            {
                                lamps_0 = Content.Load<Texture2D>("Lamps/" + (string)key.GetValue("Type"));
                                lamps_1 = Content.Load<Texture2D>("Lamps/" + (string)key.GetValue("Type") + 
                                    "_" + (string)key.GetValue("Color"));
                                if ((int)key.GetValue("Matrix")==1) matrix_draw = true;
                                else matrix_draw = false;
                            }
                        }
                        catch { };
                        Frames = Content.Load<Texture2D>("Frames/4");
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Demo_ScreenSaver_Bin");
                            if (key == null)
                            {
                                play_sound = true;
                            }
                            else if ((int)key.GetValue("Sound") == 0) play_sound = false;
                            else play_sound = true;
                        }
                        catch { };
                        Arrow_Hour = Content.Load<Texture2D>("Arrow/1");
                        Arrow_Minute = Content.Load<Texture2D>("Arrow/Minute");
                        Arrow_Second = Content.Load<Texture2D>("Arrow/Second_Big");
                        ArrowPosition = new Vector2(this.graphics.GraphicsDevice.DisplayMode.Width / 2,
                            this.graphics.GraphicsDevice.DisplayMode.Height / 2);
                        sound_tick = Content.Load<SoundEffect>("Sound/tick");
                        break;
                    }
                case 3:
                    try
                    {
                        key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Demo_ScreenSaver_Bin");
                        if (key == null)
                        {
                            play_sound = true;
                            speed = new Vector2(1, 1);
                        }
                        else
                        {
                            speed = new Vector2((int)key.GetValue("Speed"), (int)key.GetValue("Speed"));
                            if ((int)key.GetValue("Sound") == 0) play_sound = false;
                            else play_sound = true;
                        }
                    }
                    catch {};
                    sound_stuk = Content.Load<SoundEffect>("Sound/stuk");
                    spriteFont_3 = Content.Load<SpriteFont>("SpriteFont_3");
                    if (this.GraphicsDevice.DisplayMode.Width<spriteFont_3.MeasureString("00000:000000:000000").X)
                        spriteFont_3 = Content.Load<SpriteFont>("SpriteFont_3_mini");
                    else
                        spriteFont_3 = Content.Load<SpriteFont>("SpriteFont_3");
                    position = new Vector2(this.GraphicsDevice.DisplayMode.Width / 2 - spriteFont_3.MeasureString("00000:000000:000000").X/2,
                        this.GraphicsDevice.DisplayMode.Height / 2 -spriteFont_3.MeasureString("00000:000000:000000").Y/2);
                    lines = new Texture2D(GraphicsDevice, 1, 1);
                    lines.SetData(new Color[] { Color.White });
                    break;
            }
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void UnloadContent()
        {
            Content.Unload();
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {

            if (this._previewMode == true)
            {
                if (IsWindowVisible(this._parentHwnd) == false)
                    this.Exit();
            }
            MouseState Mousestate = Mouse.GetState();
            KeyboardState KeyBoardState = Keyboard.GetState();
            if ((Math.Abs(state1.X - Mousestate.X)>10) || (Math.Abs(state1.Y - Mousestate.Y)>10)
                || (Mousestate.LeftButton==ButtonState.Pressed)
                || (Mousestate.RightButton==ButtonState.Pressed)
                || (KeyBoardState.IsKeyDown(Keys.Escape)))
            this.Exit();
           
            nowTime = DateTime.Now;
            switch (STYLE)
            {
                case 1:
                    {
                        Next_Line(Number_line);
                        break;
                    }
                case 2:
                    {
                        Update_2_Style();
                        break;
                    }
                case 3:
                    {
                        string hour = STR(dec_bin(nowTime.Hour,5));
                        string minute = STR(dec_bin(nowTime.Minute,6));
                        string second = STR(dec_bin(nowTime.Second,6));
                        if (position.Y <= -5)
                        {
                            Update_3_Style(new Vector2(1, -1));
                        }
                        if ((position.X + spriteFont_3.MeasureString(hour + ":" + minute + ":" + second).X) >= this.GraphicsDevice.DisplayMode.Width-15)
                        {
                            Update_3_Style(new Vector2(-1, 1));
                        }
                        if ((position.Y + spriteFont_3.MeasureString(hour + ":" + minute + ":" + second).Y) >= this.GraphicsDevice.DisplayMode.Height + 25)
                        {
                            Update_3_Style(new Vector2(1, -1));
                        }
                        if (position.X <= 16)
                        {
                            Update_3_Style(new Vector2(-1,1));
                        }
                        position += speed;
                        break;
                    }
            }
            MouseState ms = Mouse.GetState();
            base.Update(gameTime);
        }
        protected void Update_2_Style()
        {
            ArrowRectangle_hour = new Rectangle((int)ArrowPosition.X, (int)ArrowPosition.Y, Arrow_Hour.Width, Arrow_Hour.Height);
            ArrowRectangle_second = new Rectangle((int)ArrowPosition.X, (int)ArrowPosition.Y, Arrow_Second.Width, Arrow_Second.Height);
            ArrowRectangle_minute = new Rectangle((int)ArrowPosition.X, (int)ArrowPosition.Y, Arrow_Minute.Width, Arrow_Minute.Height);
            float rotation_second_0 = rotation_second;
            ArrowOrigin_Hour = new Vector2(ArrowRectangle_hour.Width / 2, ArrowRectangle_hour.Height / 2);
            ArrowOrigin_Minute = new Vector2(ArrowRectangle_minute.Width / 2, ArrowRectangle_minute.Height / 2);
            ArrowOrigin_Second = new Vector2(ArrowRectangle_second.Width / 2, ArrowRectangle_second.Height / 2);
            rotation_second = nowTime.Second * (float)Math.PI / 30 /*+ nowTime.Millisecond * (float)Math.PI / 500 / 1000*/;
            rotation_minute = nowTime.Minute * (float)Math.PI / 30 + nowTime.Second * (float)Math.PI / 30 / 60;
            rotation_hour = nowTime.Hour * (float)Math.PI / 6 + nowTime.Minute * (float)Math.PI / 30 / 60;
            if ((rotation_second != rotation_second_0) && (play_sound)) sound_tick.Play();
        }
        protected void Update_3_Style(Vector2 vect)
        {   
            
            rand_color = new Random();
            {
                r=rand_color.Next(255);
                g=rand_color.Next(255);
                b=rand_color.Next(255);
            }
            color = new Color(r, g, b);
            if (play_sound) sound_stuk.Play();
            speed *= vect;
        }
        protected void Next_Line(int[] mas)//переход матрицы на новую строку
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > this.graphics.GraphicsDevice.DisplayMode.Height / 15)
                {
                    mas[i] = -1;
                }
                else mas[i] = mas[i]++;
            }
        }
        protected void Draw_Matrix()
        {
            rand = new Random();
            matrix = new char[this.graphics.GraphicsDevice.DisplayMode.Width / 10,this.graphics.GraphicsDevice.DisplayMode.Height / 15];
            for (int i = 0; i < this.graphics.GraphicsDevice.DisplayMode.Width / 10; i++)
            {
                for (int j = 0; j < this.graphics.GraphicsDevice.DisplayMode.Height / 15; j++)
                {
                    int n = rand.Next(5);
                    if ((n == 2)|| (n==3) ||(n==4)) matrix[i, j] = ' ';
                    else if (n == 1) matrix[i, j] = '1';
                    else matrix[i, j] = '0';
                }
                for (int j = 0; j < this.graphics.GraphicsDevice.DisplayMode.Height / 15; j++)
                {

                    spriteBatch.DrawString(spriteFont_matrix, matrix[i, j].ToString(), new Vector2(i * 10, Number_line[j]*15), Color.DarkGreen);
                }
            }
           
        }
        protected void Draw_Time(int n,int time,  Texture2D t1, Texture2D t0,int lx, int ly)
        {
            
            for (int i = 0; i < n; i++)
            {

                if (dec_bin(time, n)[i] == 1)
                    spriteBatch.Draw(t1, new Rectangle(interval_width+i*lx,ly,interval_height,interval_height), Color.White);
                else spriteBatch.Draw(t0, new Rectangle(interval_width + i * lx, ly, interval_height, interval_height), Color.White);
            }
            if (this.graphics.GraphicsDevice.DisplayMode.Height <= 850)
            {
                for (int i = 0; i < 4; i++)
                {
                    spriteBatch.DrawString(spriteFont, Draw_Text(time), new Vector2(interval_width + lx * 6.3f + i, ly - 50 + i), Color.Yellow);
                }
                spriteBatch.DrawString(spriteFont, Draw_Text(time), new Vector2(interval_width + lx * 6.3f + 4, ly - 50 + 4), Color.Red);
            }
            else if (this.graphics.GraphicsDevice.DisplayMode.Height <= 800)
            {
                for (int i = 0; i < 4; i++)
                {
                    spriteBatch.DrawString(spriteFont, Draw_Text(time), new Vector2(interval_width + lx * 6.2f + i, ly - 50 + i), Color.Yellow);
                }
                spriteBatch.DrawString(spriteFont, Draw_Text(time), new Vector2(interval_width + lx * 6.2f + 4, ly - 50 + 4), Color.Red);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    spriteBatch.DrawString(spriteFont, Draw_Text(time), new Vector2(interval_width + lx * 7 + i, ly - 35 + i), Color.Yellow);
                }
                spriteBatch.DrawString(spriteFont, Draw_Text(time), new Vector2(interval_width + lx * 7 + 4, ly - 35 + 4), Color.Red);

            }

        }
        protected string Draw_Text(int time)
        {
            if (time < 10) return ("0" + time.ToString());
            return time.ToString();
        }
        protected Rectangle Numeric_Size( Texture2D t)
        {
            int n = 0; ;
            if (t == numeric_0) n=1;//3
             else if (t == numeric_1) n=2;//6
             else if (t == numeric_2) n=3;//9
             else if (t == numeric_3) n=4;//12
            Rectangle size = new Rectangle(0, 0, 0, 0);
            switch (n)
            {
                case 1://3
                    {
                        if (this.graphics.GraphicsDevice.DisplayMode.Height > 870)
                        {
                            size = new Rectangle(
                                this.graphics.GraphicsDevice.DisplayMode.Width / 2 + Arrow_Second.Width / 2 - 20,
                                this.graphics.GraphicsDevice.DisplayMode.Height / 2 - numeric_0.Height / 2,
                                t.Width, t.Height);
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 870)
                        {
                            size = new Rectangle(
                                this.graphics.GraphicsDevice.DisplayMode.Width / 2 + Arrow_Second.Width / 2 -30,
                                this.graphics.GraphicsDevice.DisplayMode.Height / 2 - (int)(numeric_0.Height / 2.4f),
                                (int)(t.Width/1.2f), (int)(t.Height/1.2f));
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 770)
                        {
                            size = new Rectangle(
                                this.graphics.GraphicsDevice.DisplayMode.Width / 2 + Arrow_Second.Width / 2 - 20,
                                this.graphics.GraphicsDevice.DisplayMode.Height / 2 - numeric_0.Height / 4,
                                (int)(t.Width/2), (int)(t.Height/2));
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 650)
                        {
                           size = new Rectangle(0,0,0,0);
                        }
                        break;
                    }
                case 2://6
                    {
                        if (this.graphics.GraphicsDevice.DisplayMode.Height > 870)
                        {
                            size = new Rectangle(
                                this.graphics.GraphicsDevice.DisplayMode.Width / 2 - t.Width / 2,
                                this.graphics.GraphicsDevice.DisplayMode.Height / 2 + Arrow_Second.Height / 2-35,
                                (int)(t.Width), (int)(t.Height));
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 870)
                        {
                            size = new Rectangle(
                                this.graphics.GraphicsDevice.DisplayMode.Width / 2 - (int)(t.Width / 2.4f),
                                this.graphics.GraphicsDevice.DisplayMode.Height / 2 + Arrow_Second.Height / 2-35,
                                (int)(t.Width/1.2f), (int)(t.Height/1.2f));
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 770)
                        {
                            size = new Rectangle(
                                this.graphics.GraphicsDevice.DisplayMode.Width / 2 - t.Width / 4,
                                this.graphics.GraphicsDevice.DisplayMode.Height / 2 + Arrow_Second.Height / 2 - 35,
                                (int)(t.Width/2), (int)(t.Height/2));
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 650)
                        {
                            size = new Rectangle(0, 0, 0, 0);
                        }
                        break;
                    }
                case 3://9
                    {
                        if (this.graphics.GraphicsDevice.DisplayMode.Height > 870)
                        {
                            size = new Rectangle(
                                this.graphics.GraphicsDevice.DisplayMode.Width / 2 - Arrow_Second.Width / 2 - t.Width + 20,
                                this.graphics.GraphicsDevice.DisplayMode.Height / 2 - t.Height / 2 + 10,
                                t.Width, t.Height);
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 870)
                        {
                            size = new Rectangle(
                               this.graphics.GraphicsDevice.DisplayMode.Width / 2 - Arrow_Second.Width / 2 - t.Width + 80,
                               this.graphics.GraphicsDevice.DisplayMode.Height / 2 - (int)(t.Height / 2.4f),
                               (int)(t.Width / 1.2f), (int)(t.Height / 1.2f));
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 770)
                        {
                            size = new Rectangle(
                               this.graphics.GraphicsDevice.DisplayMode.Width / 2 - Arrow_Second.Width / 2 - t.Width + 180,
                               this.graphics.GraphicsDevice.DisplayMode.Height / 2 - (int)(t.Height / 4),
                               (int)(t.Width / 2f), (int)(t.Height / 2));
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 650)
                        {
                            size = new Rectangle(0, 0, 0, 0);
                        }
                        break;
                    }
                case 4://12
                    {
                        if (this.graphics.GraphicsDevice.DisplayMode.Height > 870)
                        {
                            size = new Rectangle(
                                this.graphics.GraphicsDevice.DisplayMode.Width / 2 - t.Width / 2 - 15,
                                this.graphics.GraphicsDevice.DisplayMode.Height / 2 - Arrow_Second.Height / 2- t.Height/2-15 ,
                                (int)(t.Width), (int)(t.Height));
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 870)
                        {
                            size = new Rectangle(
                               this.graphics.GraphicsDevice.DisplayMode.Width / 2 - (int)(t.Width / 2.4f) - 15,
                               this.graphics.GraphicsDevice.DisplayMode.Height / 2 - Arrow_Second.Height / 2-(int)(t.Height/2.4f),
                                (int)(t.Width/1.2f), (int)(t.Height/1.2f));
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 770)
                        {
                            size = new Rectangle(
                                 this.graphics.GraphicsDevice.DisplayMode.Width / 2 - (int)(t.Width / 4) - 15,
                                 this.graphics.GraphicsDevice.DisplayMode.Height / 2 - Arrow_Second.Height / 2 - (int)(t.Height / 4),
                                (int)(t.Width / 2), (int)(t.Height / 2));
                        }
                        if (this.graphics.GraphicsDevice.DisplayMode.Height <= 650)
                        {
                            size = new Rectangle(0, 0, 0, 0);
                        }
                        
                        break;
                    }
            }
            return size;
        }//Метод, определяющий позицию и размер выводимых чисел 3,6,9,12
        protected void Draw_Number()
        {
            //рисование цифры 0011=3
            if ((nowTime.Second >= 14) && (nowTime.Second <= 16)) numeric_0 = Content.Load<Texture2D>("Numeric_neon/0011_3");
            else numeric_0 = Content.Load<Texture2D>("Numeric_neon/0011_0");
            spriteBatch.Draw(numeric_0, Numeric_Size(numeric_0), Color.White);

            //рисование цифры 0110 = 6
            if ((nowTime.Second >= 26) && (nowTime.Second <= 33)) numeric_1 = Content.Load<Texture2D>("Numeric_neon/0110_3");
            else numeric_1 = Content.Load<Texture2D>("Numeric_neon/0110_0");
            spriteBatch.Draw(numeric_1, Numeric_Size(numeric_1) , Color.White);

            //рисование цифры 1001=9
            if ((nowTime.Second >= 44) &&  (nowTime.Second<=46)) numeric_2 = Content.Load<Texture2D>("Numeric_neon/1001_3");
            else numeric_2 = Content.Load<Texture2D>("Numeric_neon/1001_0");
            spriteBatch.Draw(numeric_2, Numeric_Size(numeric_2) , Color.White);

            //рисование цивры 1100 = 12
            if ((nowTime.Second >= 56) || (nowTime.Second <= 3)) numeric_3 = Content.Load<Texture2D>("Numeric_neon/1100_3");
            else numeric_3 = Content.Load<Texture2D>("Numeric_neon/1100_0");
            spriteBatch.Draw(numeric_3, Numeric_Size(numeric_3) , Color.White);
        }
        protected void Draw_String_Time()
        {
            string hour = STR(dec_bin(nowTime.Hour,5));
            string minute = STR(dec_bin(nowTime.Minute, 6));
            string second = STR(dec_bin(nowTime.Second, 6));
            for (int i=0; i<5; i++)
                spriteBatch.DrawString(spriteFont_3, hour + ":" + minute + ":" + second, 
                    position-new Vector2 (i,i) ,Color.Black);
            spriteBatch.DrawString(spriteFont_3, hour + ":" + minute + ":" + second, 
                position-new Vector2(5,5), color);
        }
        protected void Drow_Lines()
        {
            spriteBatch.Draw(lines, new Rectangle(0, 0, this.GraphicsDevice.DisplayMode.Width, 10), Color.LightGray);
            spriteBatch.Draw(lines, new Rectangle(this.GraphicsDevice.DisplayMode.Width - 10, 0, 10,
                this.GraphicsDevice.DisplayMode.Height), Color.LightGray);
            spriteBatch.Draw(lines, new Rectangle(0, this.GraphicsDevice.DisplayMode.Height - 10,
                this.GraphicsDevice.DisplayMode.Width, 10), Color.LightGray);
            spriteBatch.Draw(lines, new Rectangle(0, 0, 10, this.GraphicsDevice.DisplayMode.Height), Color.LightGray);

        }
        protected override void Draw(GameTime gameTime)
        {
            switch (STYLE)
            {
                case 1:
                    {
                        graphics.GraphicsDevice.Clear(Color.Black);
                        spriteBatch.Begin();
                        if (matrix_draw) Draw_Matrix();
                        spriteBatch.Draw(Frames, new Rectangle(interval_width - interval_width / 2 ,
                            interval_height - interval_height / 2 , 9 * interval_width, 6 * interval_height), Color.White);
                        // выводим часы
                        Draw_Time(5, nowTime.Hour, lamps_1, lamps_0, interval_width, interval_height);
                        // выводим МИНУТЫ
                        Draw_Time(6, nowTime.Minute, lamps_1, lamps_0, interval_width, interval_height * 3);
                        // выводим СЕКУНДЫ
                        Draw_Time(6, nowTime.Second, lamps_1, lamps_0, interval_width, interval_height * 5);
                        break;
                    }
                case 2:
                    {
                        graphics.GraphicsDevice.Clear(Color.Black);
                        spriteBatch.Begin();
                        //circle clock
                        Draw_Number();
                        spriteBatch.Draw(Arrow_Hour, ArrowPosition, null, Color.White,
                            rotation_hour, ArrowOrigin_Hour, 1f, SpriteEffects.FlipHorizontally, 0);
                        spriteBatch.Draw(Arrow_Second, ArrowPosition, null, Color.Violet,
                            rotation_second, ArrowOrigin_Second, 1f, SpriteEffects.FlipHorizontally, 0);
                        spriteBatch.Draw(Arrow_Minute, ArrowPosition, null, Color.White,
                            rotation_minute, ArrowOrigin_Minute, 1f, SpriteEffects.FlipHorizontally, 0);
                        break;
                    }
                case 3:
                    {
                        graphics.GraphicsDevice.Clear(Color.LightGray);
                        spriteBatch.Begin();
                        Draw_String_Time();
                        Drow_Lines();
                        break;
                    }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public int[] dec_bin(int h, int len)
        {
            int[] h_bin = new int[len];
            int l = len - 1;
            while (Convert.ToInt32(h) > 0)
            {

                h_bin[l] = h % 2;
                h = h / 2;
                l--;
            }
            return h_bin;
        }
        public string STR(int[] h_bin)
        {
            string s = "";
            for (int i = 0; i < h_bin.Length; i++)
                s += h_bin[i];
            return s;
        }
    }
}
