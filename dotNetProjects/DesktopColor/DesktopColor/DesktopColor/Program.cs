using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;

namespace DesktopColor
{
    class Program
    {
        [DllImport("user32.dll", SetLastError=true)]
        static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaRgbValues);
        public const int COLOR_DESKTOP = 1;
        private static int _lastR;
        private static int _lastG;
        private static int _lastB;

        static void Main(string[] args)
        {

            //example color
            //System.Drawing.Color sampleColor = System.Drawing.Color.Black;
            _lastR = 100;
            _lastG = 100;
            _lastB = 100;

            Thread thread = new Thread(new ThreadStart(DesktopColor));
            thread.Start();
        }

        private static void DesktopColor()
        {
            while(true)
            {
                Color sampleColor = Color.FromArgb(_lastR, _lastG, _lastB);
                ChangeDesktopColor(sampleColor);
                Thread.Sleep(200);
                CreateRandomColor(_lastR, _lastG, _lastB, out _lastR, out _lastG, out _lastB);
            }
        }
        
        private static void CreateRandomColor(int R, int G, int B, out int Rout, out int Gout, out int Bout)
        {
            int randomValue;
            Random r = new Random();
            randomValue = r.Next(0, 3);

            Rout = R;
            Gout = G;
            Bout = B;

            if (randomValue == 0)
            {   
                randomValue = r.Next(0, 21) - 10;
                Rout = R + randomValue;
            }
            else if (randomValue == 1)
            {
                randomValue = r.Next(0, 21) - 10;
                Gout = G + randomValue;
            }
            else if (randomValue == 2)
            {
                randomValue = r.Next(0, 21) - 10;
                Bout = B + randomValue;
            }

            if (Rout < 0)
            {
                Rout = 255;
            }
            if (Gout < 0)
            {
                Gout = 255;
            }
            if (Bout < 0)
            {
                Bout = 255;
            }

            if (Rout > 255)
            {
                Rout = 0;
            }
            if (Gout > 255)
            {
                Gout = 0;
            }
            if (Bout > 255)
            {
                Bout = 0;
            }
        }

        private static void ChangeDesktopColor(Color newColor)
        {

            //array of elements to change
            int[] elements = { COLOR_DESKTOP };

            //array of corresponding colors
            int[] colors = { System.Drawing.ColorTranslator.ToWin32(newColor) };

            //set the desktop color using p/invoke
            SetSysColors(elements.Length, elements, colors);

            //save value in registry so that it will persist
            //Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\Colors", true);
            //key.SetValue(@"Background", string.Format("{0} {1} {2}", sampleColor.R, sampleColor.G, sampleColor.B));
        }
    }
}
