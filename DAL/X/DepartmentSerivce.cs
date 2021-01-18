using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.X
{
   public class DepartmentSerivce
    {
        //部门信息分页查询所有
        public static PageList fyShow(int pageIndex, int pagesize)
        {
            PageList list = new PageList();
            CKSJKEntities s = new CKSJKEntities();
            var obj = from p in s.department
                      orderby p.BmNum
                      where p.isDel == 1
                      select new
                      {
                          BmNum = p.BmNum,
                          BmName = p.BmName,
                          createTime = p.createTime,
                          title = p.title
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = s.department.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }

        //总条数
        public static int GetRow()
        {
            CKSJKEntities c = new CKSJKEntities();
            return c.department.Count();
        }

        //根据部门编号或部门名称进行查询
        public static PageList ShowBybmName(int pageIndex, int pagesize, string bmName, string bmNum)
        {
            PageList list = new PageList();
            CKSJKEntities ck = new CKSJKEntities();
            var obj = from p in ck.department
                      orderby p.BmNum
                      where p.BmName == bmName || p.BmNum == bmNum && p.isDel == 1
                      select new
                      {
                          BmNum = p.BmNum,
                          BmName = p.BmName,
                          createTime = p.createTime,
                          title = p.title
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = ck.department.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }

        //新增
        public static int Add(department dep)
        {
            CKSJKEntities ck = new CKSJKEntities();
            ck.department.Add(dep);
            return ck.SaveChanges();
        }

        //查询部门名称
        public static IQueryable BybmName()
        {
            CKSJKEntities ck = new CKSJKEntities();
            var obj = from p in ck.department
                      select new
                      {
                        BmNum = p.BmNum,
                        BmName = p.BmName
                      };
            return obj;
        }

        //删除
        public static int Del(string bmNumber)
        {
            CKSJKEntities ck = new CKSJKEntities();
            department obj = ck.department.Find(bmNumber);
            obj.isDel = 0;
            return ck.SaveChanges();
        }

        //根据部门编号进行查询
        public static IQueryable GetById(string BmNum)
        {
            CKSJKEntities ck = new CKSJKEntities();
            var obj = from p in ck.department
                      where p.BmNum == BmNum
                      select new
                      {
                          BmNum = p.BmNum,
                          BmName = p.BmName,
                          createTime = p.createTime,
                          title = p.title
                      };
            return obj;
        }

        //修改
        public static int DepUp(department de)
        {
            CKSJKEntities ck = new CKSJKEntities();
            var obj = (from p in ck.department where p.BmNum == de.BmNum select p).First();
            obj.BmNum = de.BmNum;
            obj.BmName = de.BmName;
            obj.createTime = de.createTime;
            obj.title = de.title;
            return ck.SaveChanges();
        }
    }
}
