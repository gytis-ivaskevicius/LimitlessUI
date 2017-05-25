using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessUI
{
    public class AnimatorTimer_WOC : Timer
    {
        public delegate void onAnimationStart();
        public delegate void onAnimationEnd();
        public delegate void onAnimationTick(int progress);

        public event onAnimationStart onAnimationStarted;
        public event onAnimationEnd onAnimationEnded;
        public event onAnimationTick onAnimationTimerTick;

        public static readonly int REFRESH_RATE = 60;

        private int _maxVal;
        private int _minVal;
        private int _progress;
        private int _speed;

        private bool _isIncreasing;

        public AnimatorTimer_WOC()
        {
            Interval = 17;
            Tick += (object sender, EventArgs e) =>
            {
                if (onAnimationStarted != null)
                    onAnimationStarted.Invoke();

                _progress += _speed;

                if (_progress > _maxVal) { Debug.WriteLine("max"); _progress = _maxVal; Stop(); }
                else if (_progress < _minVal) { Debug.WriteLine("min"); _progress = _minVal; Stop(); }
                Debug.WriteLine(_progress + " : " + _maxVal + " : " + _minVal);

                if (onAnimationTimerTick != null)
                    onAnimationTimerTick.Invoke(_progress);

                if (onAnimationEnded != null)
                    onAnimationEnded.Invoke();
            };
        }

        public void setValueRange(int neededProgress, int progress, int milis, bool isIncreasing)
        {
            _isIncreasing = isIncreasing;
            _progress = progress;
            _speed = (neededProgress - progress) / (milis / 17);

            if (isIncreasing)
            {
                _maxVal = neededProgress;
                _minVal = progress;
            }
            else
            {
                _maxVal = progress;
                _minVal = neededProgress;
            }

            if (!Enabled)
                Start();
        }

        public void stopIfRunning()
        {
            if (Enabled)
                Stop();
        }
    }
}
