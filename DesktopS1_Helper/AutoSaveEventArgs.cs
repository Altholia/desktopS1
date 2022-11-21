using System;
using System.Threading;

namespace DesktopS1_Helper
{
    public class AutoSave
    {
        public event AutoSaveEventHandler AutoSaveEvent;

        private readonly int _interval;

        public AutoSave(int interval)
        {
            _interval = interval;
        }

        protected virtual void OnAutoSave(AutoSaveEventArgs e)
        {
            if (e != null)
                AutoSaveEvent(this, e);
        }

        /// <summary>
        /// 事件的监听
        /// </summary>
        public void MonitorAutoSave()
        {
            while (true)
            {
                Thread.Sleep(_interval*60*1000);//等待多少毫秒再执行下面的语句

                AutoSaveEventArgs args = new AutoSaveEventArgs(_interval);
                OnAutoSave(args);
            }
        }
    }
    public class AutoSaveEventArgs:EventArgs
    {
        public int Interval { get; set; }
        public AutoSaveEventArgs(int interval)
        {
            Interval=interval;
        }
    }
}