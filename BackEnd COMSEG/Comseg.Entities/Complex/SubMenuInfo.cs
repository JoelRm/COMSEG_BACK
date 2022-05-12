using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comseg.Entities.Complex
{
    public class SubMenuInfo
    {
        public int SubMenuId { get; set; }
        public int MenuId { get; set; }
        public string SubMenuName { get; set; }
        public string SubMenuPage { get; set; }
        public bool SubMenuStatus { get; set; }
    }
}
