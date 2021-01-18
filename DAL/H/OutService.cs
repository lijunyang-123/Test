using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.H
{
    public class OutService
    {
        public static PageList Page(int pageIndex, int pagesize)
        {
            PageList list = new PageList();
            CKSJKEntities s = new CKSJKEntities();
            var obj = from p in s.outWarehourse
                      orderby p.OutboundNum
                      select new
                      {
                          //出库单号
                          OutboundNum = p.OutboundNum,
                          //日期
                          Probarcode = p.IssuanceDate,
                          //供应商名称
                          //supplierName = p.supplier.supplierName,  
                          //关联订单号
                          orderNo = p.orderNo,
                          //总数 
                          totalNum = p.totalNum,
                          //总价
                          totalAmount = p.totalAmount
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = s.outWarehourse.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }
        //总条数
        public static int GetRow()
        {
            CKSJKEntities c = new CKSJKEntities();
            return c.outWarehourse.Count();
        }

        //出库报表
        public static PageList Put(int pageIndex, int PageSize)
        {
            CKSJKEntities c = new CKSJKEntities();
            //实例化分页类
            PageList list = new PageList();
            var obj = from p in c.outWareDetail
                      orderby p.OutboundNum
                      select new
                      {
                          OutboundNum = p.OutboundNum,
                          CreateTime = p.Location.CreateTime,
                          productCount = p.productCount,
                          totalMoney = p.totalMoney
                      };
            //设置分页数据
            list.Datalist = obj.Skip((pageIndex - 1) * PageSize).Take(PageSize);
            int rows = c.outWareDetail.Count();
            //设置总页数
            list.PageCount = rows % PageSize == 0 ? rows / PageSize : rows / PageSize + 1;
            return list;
        }


        //根据入库单号查询
        public static IQueryable GetById(string OutboundNum)
        {
            CKSJKEntities ck = new CKSJKEntities();
            var obj = from p in ck.outWarehourse
                      where p.OutboundNum == OutboundNum
                      select new
                      {
                          //出库单号
                          OutboundNum = p.OutboundNum,
                          //类型
                          OutboundTypeName = p.OutboundType.OutboundTypeName,
                          //状态
                          examineState = p.examineState,
                          //地址编号
                          AddressNum = p.customerAddressInfo.AddressNum,
                          //具体地址
                          AddressXinxi = p.customerAddressInfo.AddressXinxi,
                          //联系人
                          contacts = p.customerAddressInfo.contacts,
                          //关联订单号
                          orderNo = p.orderNo,
                          //创建人
                          ygNumber = p.Staff.ygName,
                          //创建时间
                          createTime = p.customer.createTime,
                          //电话
                          phone = p.customer.phone,
                          //备注
                          contents = p.customer.contents,
                          //审核备注
                          OperationMode = p.OperationMode,
                      };
            return obj;
        }





        public static PageList Hu(int pageIndex, int PageSize)
        {
            CKSJKEntities c = new CKSJKEntities();
            //实例化分页类
            PageList list = new PageList();
            var obj = from p in c.product
                      orderby p.productNum
                      select new
                      {
                          //产品名称 
                          productName = p.productName,
                          //产品条码  
                          Probarcode = p.Probarcode,
                          //规格 
                          Specifications = p.Specifications,
                          //批次
                          productNum = p.productNum,
                          //单价
                          price = p.price,
                          //入库数
                          productCount = p.productCount,
                          //总价 
                          num = (p.price * p.productCount),
                          //库位
                          LocationName = p.Location.LocationName
                      };
            //设置分页数据
            list.Datalist = obj.Skip((pageIndex - 1) * PageSize).Take(PageSize);
            int rows = c.product.Count();
            //设置总页数
            list.PageCount = rows % PageSize == 0 ? rows / PageSize : rows / PageSize + 1;
            return list;
        }
        
    }
}
