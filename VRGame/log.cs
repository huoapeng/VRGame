using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRGame
{
    public class Log
    {
        public int GameId { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime FinishTime { get; private set; }
        public TimeSpan Span { get; private set; }

        public Log(int id, DateTime time)
        {
            this.GameId = id;
            this.StartTime = time;
        }

        public void finish(DateTime time)
        {
            this.FinishTime = time;
            this.Span = this.FinishTime - this.StartTime;
        }

        public string serialize()
        {
            return String.Format("{0},{1},{2},{3}",
                this.GameId,
                this.StartTime.ToString("hh:mm:ss"),
                this.FinishTime.ToString("hh:mm:ss"),
                this.Span.ToString(@"hh\:mm\:ss"));
        }

        public static string titleSerialize()
        {
            return String.Format("{0},{1},{2},{3}", "游戏ID", "开始时间","结束时间","游戏时长");
        }

    }
}
