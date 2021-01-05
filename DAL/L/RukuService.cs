using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DAL.L
{
   public class RukuService
    {
        //分页
        public static PageList fenye(int pageIndex,int pagesize) {
            PageList list= new PageList();
            CKSJKEntities s = new CKSJKEntities();
            var obj = from p in s.putWarehourse orderby p.receiptNum 
            select new { 
              receiptNum=p.receiptNum,
              receiptTypeNum=p.receiptTypeNum,
              orderNo=p.orderNo,
              ygNumber=p.ygNumber,
              supplierNum=p.supplierNum,
              createTime=p.createTime,
              totalNum=p.totalNum,
              examineState=p.examineState,
              OperationMode=p.OperationMode,
              totalAmount=p.totalAmount,
              contents=p.contents,
              isDel = p.isDel,
              supplierName = p.supplier.supplierName,
              receiptTypeName= p.receiptType.receiptTypeName
            };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = s.putWarehourse.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }
        //总条数
        public static int GetRow(){
            CKSJKEntities c=new CKSJKEntities();
            return c.putWarehourse.Count(); 
        }
        //根据条件普通查
        public static PageList queryid(int pageIndex, int pagesize,string id, DateTime kxtime, DateTime jstime ) {
            PageList list = new PageList();
            CKSJKEntities c = new CKSJKEntities();
            var obj = from p in c.putWarehourse
                      orderby p.receiptNum
                      where p.receiptNum == id && p.createTime >=kxtime&& p.createTime <=jstime
                      select new {
                        receiptNum = p.receiptNum,
                        receiptTypeNum = p.receiptTypeNum,
                        orderNo = p.orderNo,
                        ygNumber = p.ygNumber,
                        supplierNum = p.supplierNum,
                        createTime = p.createTime,
                        totalNum = p.totalNum,
                        examineState = p.examineState,
                        OperationMode = p.OperationMode,
                        totalAmount = p.totalAmount,
                        contents = p.contents,
                        isDel = p.isDel,
                        supplierName = p.supplier.supplierName,
                        receiptTypeName = p.receiptType.receiptTypeName
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = c.putWarehourse.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }
    }
}
