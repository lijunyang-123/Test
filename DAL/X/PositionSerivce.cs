using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.X
{
    public class PositionSerivce
    {
        //角色信息分页查询所有
        public static PageList fyShow(int pageIndex, int pagesize)
        {
            PageList list = new PageList();
            CKSJKEntities s = new CKSJKEntities();
            var obj = from p in s.position
                      orderby p.ZwNum
                      where p.isDel == 1
                      select new
                      {
                          ZwNum = p.ZwNum,
                          ZwName = p.ZwName,
                          CreateTime = p.CreateTime,
                          title = p.title
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = s.position.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }

        //总条数
        public static int GetRow()
        {
            CKSJKEntities c = new CKSJKEntities();
            return c.position.Count();
        }

        //根据角色编号或角色名称进行查询
        public static PageList ShowByjsName(int pageIndex, int pagesize, string jsName, string jsNum)
        {
            PageList list = new PageList();
            CKSJKEntities ck = new CKSJKEntities();
            var obj = from p in ck.position
                      orderby p.ZwNum
                      where p.ZwName == jsName || p.ZwNum == jsNum && p.isDel == 1
                      select new
                      {
                          ZwNum = p.ZwNum,
                          ZwName = p.ZwName,
                          CreateTime = p.CreateTime,
                          title = p.title
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = ck.position.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }

        //新增
        public static int Add(position po)
        {
            CKSJKEntities ck = new CKSJKEntities();
            ck.position.Add(po);
            return ck.SaveChanges();
        }

        //查询角色名称
        public static IQueryable ByjsName()
        {
            CKSJKEntities ck = new CKSJKEntities();
            var obj = from p in ck.position
                      where p.isDel == 1
                      select new
                      {
                          ZwNum = p.ZwNum,
                          ZwName = p.ZwName
                      };
            return obj;
        }

        //删除
        public static int Del(string zwNumber)
        {
            CKSJKEntities ck = new CKSJKEntities();
            position obj = ck.position.Find(zwNumber);
            obj.isDel = 0;
            return ck.SaveChanges();
        }

        //根据角色编号进行查询
        public static IQueryable GetById(string ZwNumber)
        {
            CKSJKEntities ck = new CKSJKEntities();
            var obj = from p in ck.position
                      where p.ZwNum == ZwNumber
                      select new
                      {
                          ZwNum = p.ZwNum,
                          ZwName = p.ZwName,
                          CreateTime = p.CreateTime,
                          title = p.title
                      };
            return obj;
        }

        //角色表修改
        public static int PosiUp(position po)
        {
            CKSJKEntities ck = new CKSJKEntities();
            var obj = (from p in ck.position where p.ZwNum == po.ZwNum select p).First();
            obj.ZwNum = po.ZwNum;
            obj.ZwName = po.ZwName;
            obj.CreateTime = po.CreateTime;
            obj.title = po.title;
            return ck.SaveChanges();
        }
    }
}
