using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Data.Entity;
namespace DAL.S
{
   public class KeWeiDAL
    {
        
        //查询库位表
        public  List<Location> Location()
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
        //新增
        public int Add(Location war)
        {
            CKSJKEntities ck = new CKSJKEntities();
            ck.Location.Add(war);
            return ck.SaveChanges();
        }

        //修改
        public int Update(Location war)
        {
            CKSJKEntities ck = new CKSJKEntities();
            Location su = ck.Location.Find(war.LocationNum);
            su.LocationNum = war.LocationNum;
            su.LocationName = war.LocationName;
            su.isDefult = war.isDefult;
            su.warehourseNum = war.warehourseNum;
            su.barcode = war.barcode;
            return ck.SaveChanges();
        }

        //删除
        public int delete(string id)
        {
            CKSJKEntities ck = new CKSJKEntities();
            Location su = ck.Location.Find(id);
            su.isDel = 0;
            return ck.SaveChanges();
        }

        //是否禁用
        public int JinYong(string id,int isDisable)
        {
            CKSJKEntities ck = new CKSJKEntities();
            Location su = ck.Location.Find(id);
            su.isDisable = isDisable;
            return ck.SaveChanges();
        }
    }
}
