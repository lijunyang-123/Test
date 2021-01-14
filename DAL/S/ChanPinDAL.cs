using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
namespace DAL.S
{
   public  class ChanPinDAL
    {
        CKSJKEntities ck = new CKSJKEntities();
        //查询所有产品
        public List<product> Product()
        {
            return ck.product.ToList();
        }
        //新增
        public int Add(product pro)
        {
            ck.product.Add(pro);
            return ck.SaveChanges();
        }

        //修改
        public int Udpate(product pro)
        {
            ck.Set<product>().Attach(pro);
            ck.Entry<product>(pro).State = EntityState.Modified;
            return ck.SaveChanges();
        }

        //删除
        public int delete(string id)
        {
            product pro = ck.product.Find(id);
            pro.isDel = 0;
            return ck.SaveChanges();
        }
        //查询产品类别
        public List<productLeix> ProductLeixes()
        {
            return ck.productLeix.ToList();
        }

        //查询计量单位
        public List<Company> Company()
        {
            return ck.Company.ToList();
        }

        //查询客户
        public List<customer> Customers()
        {
            return ck.customer.ToList();
        }

        //仓库查询
        public List<warehourse> Warehourses ()
        {
            return ck.warehourse.ToList();
        }

        //查询库位
        public List<Location> Location()
        {
            return ck.Location.ToList();
        }
    }
}
