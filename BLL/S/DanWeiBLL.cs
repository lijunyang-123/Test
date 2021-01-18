using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.S;
using Models;
namespace BLL.S
{
  public  class DanWeiBLL
    {
        DanWeiDAL dal = new DanWeiDAL();
        //查询
        public List<Company> Company()
        {
            return dal.Company();
        }
        public int Add(Company co)
        {
            return dal.Add(co);
        }
        public int Udapte(Company co)
        {
            return dal.Udapte(co);
        }

        public int Delete(string id)
        {
            return dal.Delete(id);
        }
    }
}
