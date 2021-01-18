using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DAL.S
{
   public class LeiBieDAL
    {
        CKSJKEntities ck = new CKSJKEntities();
        //查询
        public List<productLeix> productLeixes()
        {
            return ck.productLeix.ToList();
        }
        //新增
        public int Add(productLeix pro)
        {
            ck.productLeix.Add(pro);
            return ck.SaveChanges();
        }
        //修改
        public int Udpate(productLeix pro)
        {
            productLeix ppp = ck.productLeix.Find(pro.productLeixNum);
            ppp.productLeixName = pro.productLeixName;ppp.contents = pro.contents;
            return ck.SaveChanges();
        }
        //删除
        public int delete(string id)
        {
            productLeix ppp = ck.productLeix.Find(id);
            ppp.isDel = 0;
            return ck.SaveChanges();
        }
    }
}
