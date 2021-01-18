using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL.H
{
   public class OutManager
    {
        public static PageList Page(int pageIndex, int pagesize)
        {
            return DAL.H.OutService.Page(pageIndex, pagesize);
        }
        //总条数
        public static int GetRow()
        {
            return DAL.H.OutService.GetRow();
        }

        //入库报表
        public static PageList Put(int pageIndex, int PageSize)
        {
            return DAL.H.OutService.Put(pageIndex, PageSize);

        }

        //根据入库单号查询
        public static IQueryable GetById(string OutboundNum)
        {
            return DAL.H.OutService.GetById(OutboundNum);
        }
    }
}
