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
    ///库存清单
    /// </summary>
    public class LocationManager
    {
        //分页
        public static PageList Page(int pageIndex, int pagesize)
        {
            return DAL.H.LocationService.Page(pageIndex, pagesize);
        }
        //总条数
        public static int GetRow()
        {
            return DAL.H.LocationService.GetRow();
        }
        //根据条件普通查
        public static PageList queryid(int pageIndex, int pagesize, string warehourseNum, string productNum, string Probarcode, string productName, string warehourseName)
        {
            return DAL.H.LocationService.queryid(pageIndex,pagesize,warehourseNum,productNum,Probarcode,productName,warehourseName);
        }


        //public static IQueryable QueryTest(product book)
        //{
        //    return DAL.H.LocationService.QueryTest(book);
        //}

        //下拉框
        public static IQueryable Show()
        {
            return DAL.H.LocationService.Show();
        }
    }
}
