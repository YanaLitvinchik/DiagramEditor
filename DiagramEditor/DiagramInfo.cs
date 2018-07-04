using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor
{
    class DiagramInfo
    {
        public String dataList { get; set; }
        public int point { get; set; }

        public DiagramInfo(string s , int p)
        {
            dataList = s;
            point = p;
        }
    }
}
