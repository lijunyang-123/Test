using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DAL.S
{
   public class DanWeiDAL
    {
        CKSJKEntities ck = new CKSJKEntities();
        //查询
        public List<Company> Company()
        {
            return ck.Company.ToList();
        }
        public int Add(Company co)
        {
            ck.Company.Add(co);
            return ck.SaveChanges();
        }
        public int Udapte(Company co)
        {
            Company jj = ck.Company.Find(co.CompanyNum);
            jj.CompanyName = co.CompanyName;
            return ck.SaveChanges();
        }

        public int Delete(string id)
        {
            Company jj = ck.Company.Find(id);
            jj.isDel = 0;
            return ck.SaveChanges();
        }
    }
}
