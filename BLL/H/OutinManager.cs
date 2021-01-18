using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL.H
{
   public class OutinManager
    {
        //分页
        public static PageList Page(int pageIndex, int pagesize)
        {
            return DAL.H.OutinService.Page(pageIndex, pagesize);
        }
        //总条数
        public static int GetRow()
        {
            return DAL.H.OutinService.GetRow();
        }

        //产品入库排行
        public static PageList Put(int pageIndex, int PageSize)
        {
            return DAL.H.OutinService.Put(pageIndex, PageSize);
        }

        //产品出库排行
        public static PageList Out(int pageIndex, int PageSize)
        {
            return DAL.H.OutinService.Out(pageIndex,PageSize);
        }
    }
}
