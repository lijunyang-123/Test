using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.S;
using Models;

namespace BLL.S
{
   
   public class KeWeiBLL
    {
        public  List<Location> Location()
        {
            return new KeWeiDAL().Location();
        }

        //查询仓库表
        public   List<warehourse> Warehourses()
        {
            return new DAL.S.KeWeiDAL().Warehourses();
        }




        //修改
        public int Update(Location war)
        {

            return new KeWeiDAL().Update(war);
        }

        //删除
        public int delete(string id)
        {

            return new KeWeiDAL().delete(id);
        }

        //是否禁用
        public int JinYong(string id, int isDisable)
        {

            return new KeWeiDAL().JinYong(id,isDisable);
        }
        //新增
        public int Add(Location war)
        {
            return new KeWeiDAL().Add(war);
        }
    }
}
