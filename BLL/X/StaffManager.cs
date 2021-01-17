using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL.X
{
   public class StaffManager
    {
        //分页查询所有
        public static PageList fyShow(int pageIndex, int pagesize)
        {
            return DAL.X.StaffSerivce.fyShow(pageIndex,pagesize);
        }

        //总条数
        public static int GetRow()
        {
            return DAL.X.StaffSerivce.GetRow();
        }

        //根据用户名或工号查询
        public static PageList ShowByName(int pageIndex, int pagesize, string userName, string ygNum)
        {
            return DAL.X.StaffSerivce.ShowByName(pageIndex, pagesize, userName, ygNum);
        }

        //登录
        public static int login(string name, string pwd)
        {
            return DAL.X.StaffSerivce.login(name,pwd);
        }

        //新增
        public static int Add(Staff sta)
        {
            return DAL.X.StaffSerivce.Add(sta);
        }

        //根据用户编号查询
        public static IQueryable GetById(string ygNum)
        {
            return DAL.X.StaffSerivce.GetById(ygNum);
        }

        //删除
        public static int Del(string ygNum)
        {
            return DAL.X.StaffSerivce.Del(ygNum);
        }


        //修改
        public static int StaUp(Staff sta)
        {
            return DAL.X.StaffSerivce.StaUp(sta);
        }
    }
}
