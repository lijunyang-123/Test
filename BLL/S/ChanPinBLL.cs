using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.S;
namespace BLL.S
{
  public  class ChanPinBLL
    {
        ChanPinDAL bll = new ChanPinDAL();
        //查询所有产品
        public List<product> Product()
        {
            return bll.Product();
        }
        //新增
        public int Add(product pro)
        {
            return bll.Add(pro);
        }

        //修改
        public int Udpate(product pro)
        {
            return bll.Udpate(pro);
        }

        //删除
        public int delete(string id)
        {
            return bll.delete(id);
        }

        //查询产品类别
        public List<productLeix> ProductLeixes()
        {
            return bll.ProductLeixes();
        }

        //查询计量单位
        public List<Company> Company()
        {
            return bll.Company();
        }

        //查询客户
        public List<customer> Customers()
        {
            return bll.Customers();
        }

        //仓库查询
        public List<warehourse> Warehourses()
        {
            return bll.Warehourses();
        }

        //查询库位
        public List<Location> Location()
        {
            return bll.Location();
        }
    }
}
