using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL.X
{
   public class DepartmentManager
    {
        //部门信息分页查询所有
        public static PageList fyShow(int pageIndex, int pagesize)
        {
            return DAL.X.DepartmentSerivce.fyShow(pageIndex,pagesize);
        }

        //总条数
        public static int GetRow()
        {
            return DAL.X.DepartmentSerivce.GetRow();
        }

        //根据部门编号或部门名称进行查询
        public static PageList ShowBybmName(int pageIndex, int pagesize, string bmName, string bmNum)
        {
            return DAL.X.DepartmentSerivce.ShowBybmName(pageIndex,pagesize,bmName,bmNum);
        }

        //新增
        public static int Add(department dep)
        {
            return DAL.X.DepartmentSerivce.Add(dep);
        }

        //查询部门名称
        public static IQueryable BybmName()
        {
            return DAL.X.DepartmentSerivce.BybmName();
        }

        //删除
        public static int Del(string bmNumber)
        {
            return DAL.X.DepartmentSerivce.Del(bmNumber);
        }

        //根据部门编号进行查询
        public static IQueryable GetById(string BmNum)
        {
            return DAL.X.DepartmentSerivce.GetById(BmNum);
        }

        //修改
        public static int DepUp(department de)
        {
            return DAL.X.DepartmentSerivce.DepUp(de);
        }
    }
}
