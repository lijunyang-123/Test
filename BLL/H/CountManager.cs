using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
namespace BLL.H
{
    /// <summary>
    /// 货品统计 
    /// </summary>
    public class CountManager
    {
        //分页
        public static PageList Page(int pageIndex, int pagesize)
        {
            return DAL.H.CountService.Page(pageIndex, pagesize);
        }
        //总条数
        public static int GetRow()
        {
            return DAL.H.CountService.GetRow();
        }
        //按条件查询
        public static PageList queryid(int pageIndex, int pagesize, string productNum, string Probarcode, string productName)
        {
            return DAL.H.CountService.queryid(pageIndex,pagesize,productNum,Probarcode,productName);
        }
        }
}
