using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Двоичные_часы
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static string firstArgument;
        static string secondArgument;
        public static int lockCounter = 0;
        private static int threadCountOrig;
        public static bool stopScreenSavers = false;
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (ScreenSaver game = new ScreenSaver())
            {
                if (args.Length > 0)
                {
                    firstArgument = args[0].ToLower().Trim();
                    secondArgument = null;

                    // Обработка случаев, когда аргумент разделяются ":"
                    // Пример: /c:1234567 or /P:1234567
                    if (firstArgument.Length > 2)
                    {
                        secondArgument = firstArgument.Substring(3).Trim();
                        firstArgument = firstArgument.Substring(0, 2);
                    }
                    else if (args.Length > 1)
                        secondArgument = args[1];

                    if (firstArgument == "/c")           // Configuration mode
                    {
                        Application.Run(new Двоичные_часы.SettingForm());
                        /*SettingForm f = new SettingForm();
                        f.ShowDialog();*/
                    }
                    else if (firstArgument == "/p")      // Preview mode
                    {
                        if (secondArgument == null)
                        {
                            MessageBox.Show("Sorry, but the expected window handle was not provided.",
                                "ScreenSaver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        SetupScreenSavers(false, true);
                        //IntPtr previewWndHandle = new IntPtr(long.Parse(secondArgument));
                        //game.Run();
                    }
                    else if (firstArgument == "/s")      // Full-screen mode
                    {
                        //SetupScreenSavers(true, false);
                        game.Run();
                    }
                    else    // Undefined argument
                    {
                        MessageBox.Show("Sorry, but the command line argument \"" + firstArgument +
                            "\" is not valid.", "ScreenSaver",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else    // No arguments - treat like /c
                {
                    Application.Run(new Двоичные_часы.SettingForm());
                    /*SettingForm f = new SettingForm();
                    f.ShowDialog();*/
                }          
                
            }
        }

        static public void RunScreenSaver(Object previewWndHandle)
        {
            ScreenSaver screenSaver = new ScreenSaver();
            if (previewWndHandle != null)
            {
                screenSaver._previewMode = true;
                screenSaver._parentHwnd = (IntPtr)previewWndHandle;
            }
            screenSaver.Run();

        }
        static private void SetupScreenSavers(bool normalMode, bool previewMode)
        {

           
            ArrayList threads = new ArrayList();
            int counter = 0;
            if (normalMode)
            {

                foreach (Screen screen in Screen.AllScreens)
                {
                    threads.Add(new Thread(RunScreenSaver));
                    ((Thread)(threads[counter])).Name = "ScreenSaver " + counter;
                    ((Thread)(threads[counter])).Start(null);
                    counter++;
                }
            }
            else if (previewMode)
            {
                IntPtr previewWndHandle = new IntPtr(long.Parse(secondArgument));
                threads.Add(new Thread(RunScreenSaver));
                ((Thread)(threads[counter])).Name = "Preview Thread";
                ((Thread)(threads[counter])).Start(previewWndHandle);
            }
            else
            {

                threads.Add(new Thread(RunScreenSaver));
                ((Thread)(threads[counter])).Name = "ScreenSaver";
                ((Thread)(threads[counter])).Start(null);

            }

            threadCountOrig = threads.Count;

            if (previewMode == false)
            {
                do
                {
                    System.Threading.Thread.Sleep(100);
                } while (stopScreenSavers == false);

                //Wait for the childern to stop before leaving
                bool screensaversNotStopped = false;
                do
                {
                    screensaversNotStopped = false;
                    counter = 0;
                    foreach (Screen screen in Screen.AllScreens)
                    {
                        if (((Thread)(threads[counter])).IsAlive)
                        {
                            screensaversNotStopped = true;
                        }
                        counter++;
                    }
                    System.Threading.Thread.Sleep(10);
                } while (screensaversNotStopped);
            }
            else
            {
                //Wait for the childern to stop before leaving
                bool screensaverNotStopped = false;
                do
                {
                    screensaverNotStopped = false;

                    if (((Thread)(threads[0])).IsAlive)
                    {
                        screensaverNotStopped = true;
                    }
                    System.Threading.Thread.Sleep(10);
                } while (screensaverNotStopped);
            }
        }
    }
#endif
}

