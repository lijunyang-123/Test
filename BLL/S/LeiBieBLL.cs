using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.S;
namespace BLL.S
{
  public  class LeiBieBLL
    {
        LeiBieDAL dal = new LeiBieDAL();
        //查询
        public List<productLeix> productLeixes()
        {
            return dal.productLeixes();
        }
        //新增
        public int Add(productLeix pro)
        {
            return dal.Add(pro);
        }
        //修改
        public int Udpate(productLeix pro)
        {
            return dal.Udpate(pro);
        }
        //删除
        public int delete(string id)
        {
            return dal.delete(id);
        }
    }
}
