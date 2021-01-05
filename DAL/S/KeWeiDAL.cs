using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
namespace DAL.S
{
   public class KeWeiDAL
    {
        
        //查询库位表
        public static List<Location> Location()
        {
            CKSJKEntities ck = new CKSJKEntities();
            return ck.Location.ToList();
        }
        //查询仓库表
        public  List<warehourse> Warehourses()
        {
            CKSJKEntities ck = new CKSJKEntities();
            var list = from p in ck.warehourse select p;
            return  list.ToList();
        }
    }
}
