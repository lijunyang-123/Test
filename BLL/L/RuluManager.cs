using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
namespace BLL.L
{
   public class RuluManager
    {
        //分页
        public static PageList fenye(int pageIndex, int pagesize)
        {
            return DAL.L.RukuService.fenye(pageIndex,pagesize);
        }
        //总条数
        public static int GetRow()
        {
            return DAL.L.RukuService.GetRow();
        }
        //根据条件普通查
        public static PageList queryid(int pageIndex, int pagesize, string id, DateTime kxtime, DateTime jstime)
        {
            return DAL.L.RukuService.queryid(pageIndex,pagesize,id,kxtime,jstime);
        }

        }
}
