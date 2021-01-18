using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.S;
namespace BLL.S
{
    public class GongYingBLL
    {
        /*
        * 查询供应商
        */
        public List<supplier> Suppliers()
        {
            return new GongYing().Suppliers();
        }

        //新增
        public int Add(supplier war)
        {

            return new GongYing().Add(war);
        }

        //查询供应商类型
        public List<supplierLeix> SupplierLeixes()
        {
            return new GongYing().SupplierLeixes();
        }

        //删除
        public int delete(string id)
        {
            return new GongYing().delete(id);
        }

        //修改
        public int Udpate(supplier id)
        {
            return new GongYing().Udpate(id);
        }
    }
}
