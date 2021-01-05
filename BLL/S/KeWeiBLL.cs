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
        public static List<Location> Location()
        {
            return KeWeiDAL.Location();
        }

        //查询仓库表
        public   List<warehourse> Warehourses()
        {
            return new DAL.S.KeWeiDAL().Warehourses();
        }

        }
}
