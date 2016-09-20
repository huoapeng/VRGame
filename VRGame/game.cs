using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRGame
{
    public class Game
    {
        public int No { get; private set; }
        public string ImgName { get; private set; }
        public string ExcutePath { get; private set; }

        public Game(string line)
        {
            string[] items = line.Split(',');
            this.No = int.Parse(items[0]);
            this.ImgName = items[1];
            this.ExcutePath = items[2];
        }
    }
}
