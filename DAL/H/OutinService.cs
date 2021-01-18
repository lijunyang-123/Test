using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.H
{
    /// <summary>
    /// 出入库报表
    /// </summary>
   public class OutinService
    {
        public static PageList Page(int pageIndex, int pagesize)
        {
            PageList list = new PageList();
            CKSJKEntities s = new CKSJKEntities();
            var obj = from p in s.product
                      orderby p.productNum
                      select new
                      {  
                          //产品名称
                          productName = p.productName,                     
                          //产品条码
                          Probarcode = p.Probarcode,
                          //产品编号
                          productNum = p.productNum,
                          //规格 
                          Specifications = p.Specifications,
                          //入库总数
                          JhCount = from pp in p.putWareDetail where pp.productNum == p.productNum select pp.productCount,
                          //出库总数
                          ChCount = from pp in p.outWareDetail where pp.productNum == p.productNum select pp.productCount,
                          //入库所占比例
                          //出库所占比例
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = s.product.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }
        //总条数
        public static int GetRow()
        {
            CKSJKEntities c = new CKSJKEntities();
            return c.product.Count();
        }

        //产品入库排行
        public static PageList Put(int pageIndex, int PageSize)
        {
            CKSJKEntities c = new CKSJKEntities();
            //实例化分页类
            PageList list = new PageList();
            var obj = from p in c.putWareDetail
                      orderby p.receiptNum
                      select new
                      {
                          receiptNum = p.receiptNum,
                          productNum = p.productNum,
                          productCount = p.productCount,
                          totalMoney = p.totalMoney,
                          LocationNum = p.LocationNum
                      };
            //设置分页数据
            list.Datalist = obj.Skip((pageIndex - 1) * PageSize).Take(PageSize);
            int rows = c.putWareDetail.Count();
            //设置总页数
            list.PageCount = rows % PageSize == 0 ? rows / PageSize : rows / PageSize + 1;
            return list;
        }

        //产品出库排行
         public static PageList Out(int pageIndex, int PageSize)
        {
            CKSJKEntities c = new CKSJKEntities();
            PageList list = new PageList();
            var obj = from p in c.outWareDetail
                      orderby p.OutboundNum
                      select new
                      {
                          OutboundNum = p.OutboundNum,
                          productNum = p.productNum,
                          productCount = p.productCount,
                          totalMoney = p.totalMoney,
                          LocationNum = p.LocationNum
                      };
            //设置分页数据
            list.Datalist = obj.Skip((pageIndex - 1) * PageSize).Take(PageSize);
            int rows = c.outWareDetail.Count();
            //设置总页数
            list.PageCount = rows % PageSize == 0 ? rows / PageSize : rows / PageSize + 1;
            return list;
        }
    }
}
