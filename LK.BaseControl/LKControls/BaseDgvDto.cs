using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LK.App.LKControls
{
    public class BaseDgvDto
    {
        //隐藏主键
        public string Id { get; set; }

        //行索引
        [DisplayName("用于表示行索引")] public int rowIndex { get; set; }
    }
}
