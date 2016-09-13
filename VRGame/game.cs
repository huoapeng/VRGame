using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Game
    {
        public int No { get; private set; }
        public string imgName { get; private set; }
        public string excutePath { get; private set; }

        public Game(string line)
        {
            string[] items = line.Split(',');
            this.No = int.Parse(items[0]);
            this.imgName = items[1];
            this.excutePath = items[2];
        }
    }
}
