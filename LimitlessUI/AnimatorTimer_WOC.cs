using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessUI
{
    public class AnimatorTimer_WOC : Timer
    {

        public delegate void onAnimationTick(int progress);
        public event onAnimationTick onAnimationTimerTick;

        public static float _displayRefreshRate = 60;
        private static bool run = true;

        private int _neededValue;
        private float _progress;
        private float _speed = 0;

        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(
               string deviceName, int modeNum, ref DEVMODE devMode);
        const int ENUM_CURRENT_SETTINGS = -1;

        const int ENUM_REGISTRY_SETTINGS = -2;

        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {

            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;


        }

        private Stopwatch s = new Stopwatch();
        public AnimatorTimer_WOC()
        {
            if (run)
            {
                run = false;
                DEVMODE vDevMode = new DEVMODE();

                while (EnumDisplaySettings(Screen.PrimaryScreen.DeviceName, ENUM_CURRENT_SETTINGS, ref vDevMode))
                {
                    _displayRefreshRate = vDevMode.dmDisplayFrequency;
                    break;
                }
                Debug.WriteLine("HZ: " + _displayRefreshRate);
            }

            int count = 0;
            Interval = (int)Math.Round(1000 / _displayRefreshRate);
            Debug.WriteLine("SingleFrame: " + (int)Math.Round(1000 / _displayRefreshRate));
            Stopwatch stop = new Stopwatch();
        
            Tick += (object sender, EventArgs e) =>
            {
                if (!s.IsRunning)
                    s.Start();
                Debug.WriteLine("Elapsed: " + s.ElapsedMilliseconds);
                s.Restart();
                count++;

                _progress += _speed;
                Debug.WriteLine(count + " | " + _progress);

                if (_speed < 0 ? _progress <= _neededValue : _progress >= _neededValue)
                {
                    _progress = _neededValue;
                    Stop();
                    Debug.WriteLine("Elapsed: " + s.ElapsedMilliseconds);
                }

                if (onAnimationTimerTick != null)
                    onAnimationTimerTick.Invoke((int)_progress);

            };
        }

        public void setValueRange(int neededProgress, Int32 progress, int milis, bool start)
        {
            if (!Enabled)
            {
                _speed = (neededProgress - _progress) / (milis / (1000 / _displayRefreshRate));
                _progress = progress;
            }

            setValueRange(neededProgress, milis, start);
        }

        public void setValueRange(int neededProgress, int milis, bool start)
        {
            if (!Enabled)
            {
                Debug.WriteLine("Interval: " + (neededProgress - _progress));
                float a = (milis / (1000 / _displayRefreshRate));
                float b = (neededProgress - _progress);
                _speed = (b / a);
            }
            else _speed = -_speed;
            _neededValue = neededProgress;

            if (!Enabled && start)
                Start();
        }

        public void stopIfRunning()
        {
            if (Enabled)
                Stop();
        }
    }
}
