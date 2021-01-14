using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
namespace DAL.S
{
  public  class KeHuDAL
    {
        CKSJKEntities ck = new CKSJKEntities();
        //查询客户表
        public List<customer> Customers()
        {
            return ck.customer.ToList();
        }

        //新增
        public int Add(customer war)
        {
            ck.customer.Add(war);
            return ck.SaveChanges();
        }
        //删除
        public int delete(string id)
        {
            customer su = ck.customer.Find(id);
            su.isDel = 0;
            return ck.SaveChanges();
        }

        //修改
        public int Udpate(customer id)
        {
            customer su = ck.customer.Find(id.customerNum);
            su.customerName = id.customerName;su.chuanzhen = id.chuanzhen;
            su.contents = id.contents;su.phone = id.phone;su.email = id.email;
            return ck.SaveChanges();
        }

        //查询客户地址表
        public List<customerAddressInfo> CustomerAddressInfo()
        {
            return ck.customerAddressInfo.ToList();
        }

        //新增
        public int AddcustomerAddressInfo(customerAddressInfo war)
        {
            ck.customerAddressInfo.Add(war);
            return ck.SaveChanges();
        }
        //删除
        public int deletecustomerAddressInfo(string id)
        {
            customerAddressInfo su = ck.customerAddressInfo.Find(id);
            su.isDel = 0;
            return ck.SaveChanges();
        }

        //修改
        public int UdpatecustomerAddressInfo(customerAddressInfo id)
        {
            customerAddressInfo su = ck.customerAddressInfo.Find(id.AddressNum);
            su.AddressXinxi = su.AddressXinxi;
            su.phone = id.phone;su.contacts = id.contacts;
            return ck.SaveChanges();
        }
        //修改编号
        public int UdpateBianHao(string id,string bianhao)
        {
            customerAddressInfo su = ck.customerAddressInfo.Find(id);
            su.customerNum = bianhao;
            return ck.SaveChanges();
        }
    }
}
