using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.S;
namespace BLL.S
{
   public  class KeHuBLL
    {
        KeHuDAL bll = new KeHuDAL();
        //查询客户表
        public List<customer> Customers()
        {
            return bll.Customers();
        }

        //新增
        public int Add(customer war)
        {
            return bll.Add(war);
        }
        //删除
        public int delete(string id)
        {
            return bll.delete(id);
        }

        //修改
        public int Udpate(customer id)
        {
            return bll.Udpate(id);
        }

        //查询客户地址表
        public List<customerAddressInfo> CustomerAddressInfo()
        {
            return bll.CustomerAddressInfo();
        }

        //新增
        public int AddcustomerAddressInfo(customerAddressInfo war)
        {
            return bll.AddcustomerAddressInfo(war);
        }
        //删除
        public int deletecustomerAddressInfo(string id)
        {
            return bll.deletecustomerAddressInfo(id);
        }

        //修改
        public int UdpatecustomerAddressInfo(customerAddressInfo id)
        {
            return bll.UdpatecustomerAddressInfo(id);
        }
        //修改编号
        public int UdpateBianHao(string id, string bianhao)
        {
            return bll.UdpateBianHao(id,bianhao);
        }
    }
}
