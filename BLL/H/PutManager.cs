using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
namespace BLL.H
{
   public class PutManager
    {
        //分页
        public static PageList Page(int pageIndex, int pagesize)
        {
            return DAL.H.PutService.Page(pageIndex, pagesize);
        }
        //总条数
        public static int GetRow()
        {
            return DAL.H.PutService.GetRow();
        }

        //入库报表
        public static PageList Put(int pageIndex, int PageSize)
        {
            return DAL.H.PutService.Put(pageIndex, PageSize);
        }

        //根据入库单号查询
        public static IQueryable GetById(string receiptNum)
        {
            return DAL.H.PutService.GetById(receiptNum);
        }
        public static PageList Hu(int pageIndex, int PageSize)
        {
            return DAL.H.PutService.Hu(pageIndex, PageSize);
        }
    }
    }
