using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL.X
{
   public class PositionManager
    {
        //角色信息分页查询所有
        public static PageList fyShow(int pageIndex, int pagesize)
        {
            return DAL.X.PositionSerivce.fyShow(pageIndex,pagesize);
        }

        //总条数
        public static int GetRow()
        {
            return DAL.X.PositionSerivce.GetRow();
        }

        //根据角色编号或角色名称进行查询
        public static PageList ShowByjsName(int pageIndex, int pagesize, string jsName, string jsNum)
        {
            return DAL.X.PositionSerivce.ShowByjsName(pageIndex,pagesize,jsName,jsNum);
        }

        //新增
        public static int Add(position po)
        {
            return DAL.X.PositionSerivce.Add(po);
        }

        //查询角色名称
        public static IQueryable ByjsName()
        {
            return DAL.X.PositionSerivce.ByjsName();
        }

        //删除
        public static int Del(string zwNumber)
        {
            return DAL.X.PositionSerivce.Del(zwNumber);
        }

        //根据角色编号进行查询
        public static IQueryable GetById(string ZwNumber)
        {
            return DAL.X.PositionSerivce.GetById(ZwNumber);
        }

        //角色表修改
        public static int PosiUp(position po)
        {
            return DAL.X.PositionSerivce.PosiUp(po);
        }
    }
}
