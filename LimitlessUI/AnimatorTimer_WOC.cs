using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
End-User Licence Agreement (EULA) for WithoutCaps Software 

This version is current as of May 27, 2017. Please consult withoutcapsdev@gmail.com for any new versions of this EULA.

You can only use the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team after you agree to this licence. By using this software, you agree to all of the clauses in the WithoutCaps Software EULA.

PLEASE READ CAREFULLY BEFORE USING THIS PRODUCT: This End-User Licence Agreement(EULA) is a legal agreement between you (either an individual or as a single entity) and the entity that is known as the WithoutCaps Team.

(a) Introduction. This is the End-User Licence Agreement (EULA) for the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team. This EULA outlines the clauses of the licence that the WithoutCaps Team is willing to grant you (either as an individual or as a single entity) to use this software.

(b) Licence. The entity known as the WithoutCaps Team will grant a free of charge, fully-revocable, non-exclusive, non-transferable licence to any person obtaining a copy of the software known as "LimitlessUI" as well as the associated documentation. The aforementioned documentation consists of the End-User Licence Agreement (EULA) for the product known as "LimitlessUI" which is currently maintained by the WithoutCaps Team. This licence permits you to use, modify and re-distribute this software non-commercially so long as you (either an individual or as a single entity) has permission from the WithoutCaps Team to do so. If the user wants to re-distribute software made by the WithoutCaps Team this EULA must be included in the software package.

(c) Ownership. The software known as "LimitlessUI" and produced by the WithoutCaps Team is licenced, not sold, to you (either an individual or as a single entity) and as such the WithoutCaps Software Team reserves any rights not explicitly granted to you (either an individual or as a single entity).

The WithoutCaps Team also reserves the right to revoke any persons (either an individual or as a single entity) licence without previous notification or agreements as long as said the person (either an individual or as a single entity) didn't adhere to the End-User Licence Agreement (EULA) distributed with this software.

Notwithstanding the terms and conditions of this EULA, any part of the software contained within the product known as "LimitlessUI" which is currently maintained by the WithoutCaps Team which constitutes Third Party Software and as such now is licenced to you subject to the terms and conditions of the software licence agreement accompanying such Third Party Software. Whatever the form of the licence, whether it be in the form of a discrete agreement, shrink wrap licence or electronic licence terms are accepted at the time of acceptance of the End-User Licence Agreement for the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team.

(d) Limitation of Liability. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright (c) 2017 WithoutCaps
*/

namespace LimitlessUI
{
    public class AnimatorTimer_WOC
    {

        public delegate void onAnimationTick(int progress);
        public event onAnimationTick onAnimationTimerTick;

        public static float _displayRefreshRate;
        private static bool _isFrequencyChecked = false;
        private bool _isEnabled = false;

        private int _interval;
        private int _neededValue;
        private float _progress;
        private float _speed = 0;


        AutoResetEvent reset = new AutoResetEvent(false);
        private Form _invokeControl;

        public AnimatorTimer_WOC(Form control)
        {
            _invokeControl = control;
            if (!_isFrequencyChecked)
            {
                _isFrequencyChecked = true;
                int frequency = Utils_WOC.getMonitorFrequency();
                _displayRefreshRate = frequency != -1 ? frequency : 60;
            }
            _interval = (int)Math.Round(1000 / _displayRefreshRate);
        }

        public void start()
        {
            Enabled = true;
            
            new Thread(() =>
            {
                while (_isEnabled)
                {
                    reset.Set();
                    Thread.Sleep(_interval);
                }
            }).Start();

            new Thread(() =>
            {
                while (_isEnabled)
                {
                    reset.WaitOne();
                    _invokeControl.Invoke(new MethodInvoker(() =>
                    {
                        _progress += _speed;

                        if (_speed < 0 ? _progress <= _neededValue : _progress >= _neededValue)
                        {
                            _progress = _neededValue;
                            Enabled = false;
                        }

                        if (onAnimationTimerTick != null)
                            onAnimationTimerTick.Invoke((int)_progress);
                    }));
                }
            }).Start();
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
                float a = (milis / (1000 / _displayRefreshRate));
                float b = (neededProgress - _progress);
                _speed = (b / a);
            }
            else _speed = -_speed;
            _neededValue = neededProgress;

            if (start) this.start();
        }


        public bool Enabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }
        public int Interval { get { return _interval; } }
    }
}
