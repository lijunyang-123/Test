using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.H
{
   public class LocationService
    {
        /// <summary>
        /// 库存清单
        /// </summary>
        //分页
        public static PageList Page(int pageIndex, int pagesize)
        {
            PageList list = new PageList();
            CKSJKEntities s = new CKSJKEntities();
            var obj = from p in s.product
                      orderby p.productNum
                      select new
                      {
                          //库位
                          warehourseNum = p.Location.warehourse.warehourseNum,
                          //库位类型
                          warehourseName = p.Location.warehourse.warehourseName,
                          //产品编号
                          productNum = p.productNum,
                          //产品条码
                          Probarcode = p.Probarcode,
                          //产品名称
                          productName = p.productName,
                          //类别
                          productLeixNum = p.productLeix.productLeixName,
                          //规格 
                          Specifications = p.Specifications,
                          //预警值下限
                          //预警值上限
                          //库存数
                          productCount = p.productCount,
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            list.PageCount = obj.Count();
            return list;
        }
        //总条数
        public static int GetRow()
        {
            CKSJKEntities c = new CKSJKEntities();
            return c.product.Count();
        }
        //根据条件普通查询
        public static PageList queryid(int pageIndex, int pagesize, string warehourseNum, string productNum, string Probarcode, string productName, string warehourseName)
        {
            PageList list = new PageList();
            CKSJKEntities c = new CKSJKEntities();
            var obj = from p in c.product
                      orderby p.productNum
                      where p.Location.warehourseNum==warehourseNum || p.productNum==productNum || p.Probarcode==Probarcode || p.productName==productName|| p.Location.warehourse.warehourseName==warehourseName
                      select new
                      {
                          //库位
                          warehourseNum = p.Location.warehourse.warehourseNum,
                          //库位类型
                          warehourseName = p.Location.warehourse.warehourseName,
                          //产品编号
                          productNum = p.productNum,
                          //产品条码
                          Probarcode = p.Probarcode,
                          //产品名称
                          productName = p.productName,
                          //类别
                          productLeixNum = p.productLeix.productLeixName,
                          //规格 
                          Specifications = p.Specifications,
                          //预警值下限
                          //预警值上限
                          //库存数
                          productCount = p.productCount,
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = c.product.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }


        //public static IQueryable QueryTest(product book)
        //{
        //    CKSJKEntities entity = new CKSJKEntities();
        //    var obj = from p in entity.product
        //              select new
        //              {
        //                  //库位
        //                  warehourseNum = p.Location.warehourse.warehourseNum,
        //                  //库位类型
        //                  warehourseName = p.Location.warehourse.warehourseName,
        //                  //产品编号
        //                  productNum = p.productNum,
        //                  //产品条码
        //                  Probarcode = p.Probarcode,
        //                  //产品名称
        //                  productName = p.productName,
        //                  //类别
        //                  productLeixNum = p.productLeix.productLeixName,
        //                  //规格 
        //                  Specifications = p.Specifications,
        //                  //预警值下限
        //                  //预警值上限
        //                  //库存数
        //                  productCount = p.productCount
        //              };
        
        //    if (!string.IsNullOrEmpty(book.Location.warehourseNum))
        //    {
        //        obj = obj.Where(p => p.warehourseNum.Contains(book.Location.warehourseNum));
        //    }
        //    if (!string.IsNullOrEmpty(book.productNum))
        //    {
        //        obj = obj.Where(p => p.productNum.Contains(book.productNum));
        //    }
        //    if (!string.IsNullOrEmpty(book.Probarcode))
        //    {
        //        obj = obj.Where(p => p.Probarcode.Contains(book.Probarcode));
        //    }
        //    if (!string.IsNullOrEmpty(book.productName))
        //    {
        //        obj = obj.Where(p => p.productName.Contains(book.productName));
        //    }
        //    if (!string.IsNullOrEmpty(book.Location.warehourse.warehourseName))
        //    {
        //        obj = obj.Where(p => p.warehourseName.Contains(book.Location.warehourse.warehourseName));
        //    }
        //    return obj;
        //}
        //下拉框
        public static IQueryable Show()
        {
            CKSJKEntities c = new CKSJKEntities();
            var obj = from p in c.warehourse 
                      select new {
                    warehourseNum=p.warehourseNum,
                    warehourseName = p.warehourseName
                      };
            return obj;
        }
    }
}
