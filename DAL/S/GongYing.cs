using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
namespace DAL.S
{
    public  class GongYing
    {
        CKSJKEntities ck = new CKSJKEntities();
        /*
         * 查询供应商
         */
        public List<supplier> Suppliers()
        {
            return ck.supplier.ToList();
        }

        //新增
        public int Add(supplier war)
        {
            ck.supplier.Add(war);
            return ck.SaveChanges();
        }

        //查询供应商类型
        public List<supplierLeix> SupplierLeixes()
        {
            return ck.supplierLeix.ToList();
        }

        //删除
        public int delete(string id)
        {
            supplier su = ck.supplier.Find(id);
            su.isDel = 0;
            return ck.SaveChanges();
        }

        //修改
        public int Udpate(supplier id)
        {
            ck.Set<supplier>().Attach(id);
            ck.Entry<supplier>(id).State = EntityState.Modified;
            return ck.SaveChanges();
        }
    }
}
