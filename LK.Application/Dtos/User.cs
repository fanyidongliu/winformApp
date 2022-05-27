using LK.App.LKControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LK.Application.Dtos
{
    public class User : BaseDgvDto
    {
        public string name { get; set; }
        public int age { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
