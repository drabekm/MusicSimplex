using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Simplex
{
    class MyEventArg : EventArgs
    {
        public MyEventArg(string content) : base()
        {
            this.Content = content;
        }

        public string Content { get; private set; }
    }
}
