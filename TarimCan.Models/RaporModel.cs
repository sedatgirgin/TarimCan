using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarimCan.Models
{
    public class RaporModel
    {
        public int VeriX { get; set; }
        public int VeriY { get; set; }
        public string Label { get; set; }
        public string ColorCode { get; set; }
        public bool IsExploded { get; set; }
    }
}
