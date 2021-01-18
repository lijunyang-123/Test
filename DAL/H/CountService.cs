using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DAL.H
{
    /// <summary>
    /// 货品统计 
    /// </summary>
    public class CountService
    {
        //分页
        public static PageList Page(int pageIndex, int pagesize)
        {
            PageList list = new PageList();
            CKSJKEntities s = new CKSJKEntities();
            var obj = from p in s.product
                      orderby p.productNum
                      select new
                      {
                          //产品编号
                          productNum = p.productNum,
                          //产品条码
                          Probarcode = p.Probarcode,
                          //产品名称
                          productName = p.productName,
                          //类别
                          productLeixNum = p.productLeix.productLeixName,
                          //预警值下限
                          //规格 
                          Specifications = p.Specifications,
                          //库存数
                          productCount = p.productCount,
                          //进货总数
                          JhCount = from pp in p.putWareDetail where pp.productNum == p.productNum select pp.productCount,
                          //出货总数
                          ChCount = from pp in p.outWareDetail where pp.productNum == p.productNum select pp.productCount,
                          //报损总数
                          BsCount = from pp in p.LossReportDetails where pp.productNum == p.productNum select pp.productCount
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

        //根据条件普通查询
        public static PageList queryid(int pageIndex, int pagesize, string productNum, string Probarcode, string productName)
        {
            PageList list = new PageList();
            CKSJKEntities c = new CKSJKEntities();
            var obj = from p in c.product
                      orderby p.productNum
                      where p.productNum.Contains(productNum) || p.Probarcode.Contains(Probarcode) || p.productName.Contains(productName)    
                      select new
                      {
                          //产品编号
                          productNum = p.productNum,
                          //产品条码
                          Probarcode = p.Probarcode,
                          //产品名称
                          productName = p.productName,
                          //类别
                          productLeixNum = p.productLeix.productLeixName,
                          //预警值下限
                          //规格 
                          Specifications = p.Specifications,
                          //库存数
                          productCount = p.productCount,
                          //进货总数
                          JhCount = from pp in p.putWareDetail where pp.productNum == p.productNum select pp.productCount,
                          //出货总数
                          ChCount = from pp in p.outWareDetail where pp.productNum == p.productNum select pp.productCount,
                          //报损总数
                          BsCount = from pp in p.LossReportDetails where pp.productNum == p.productNum select pp.productCount
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = c.product.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }
    }
}
