using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.X
{
    public class StaffSerivce
    {
        //员工信息分页查询所有
        public static PageList fyShow(int pageIndex, int pagesize)
        {
            PageList list = new PageList();
            CKSJKEntities s = new CKSJKEntities();
            var obj = from p in s.Staff
                      orderby p.ygNumber
                      where p.isDel == 1
                      select new
                      {
                          LoginName = p.LoginName,
                          ygNumber = p.ygNumber,
                          ygName = p.ygName,
                          email = p.email,
                          phone = p.phone,
                          LoginNum = p.LoginNum,
                          dBmName = p.department.BmName,
                          pZwName = p.position.ZwName
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = s.Staff.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }

        //总条数
        public static int GetRow()
        {
            CKSJKEntities c = new CKSJKEntities();
            return c.Staff.Count();
        }

        //根据用户名或工号进行查询
        public static PageList ShowByName(int pageIndex, int pagesize, string userName, string ygNum)
        {
            PageList list = new PageList();
            CKSJKEntities ck = new CKSJKEntities();
            var obj = from p in ck.Staff
                      orderby p.ygNumber
                      where p.LoginName == userName || p.ygNumber == ygNum && p.isDel == 1
                      select new
                      {
                          LoginName = p.LoginName,
                          ygNumber = p.ygNumber,
                          ygName = p.ygName,
                          email = p.email,
                          phone = p.phone,
                          LoginNum = p.LoginNum,
                          dBmName = p.department.BmName,
                          pZwName = p.position.ZwName
                      };
            list.Datalist = obj.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            int row = ck.Staff.Count();
            list.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return list;
        }

        //登录o
        public static int login(string name, string pwd)
        {
            CKSJKEntities s = new CKSJKEntities();
            var count = (from p in s.Staff where p.LoginName == name && p.loginPwd == pwd && p.ZwNum == "NB000" select p).Count();
            return count;
        }

        //新增
        public static int Add(Staff sta)
        {
            CKSJKEntities ck = new CKSJKEntities();
            ck.Staff.Add(sta);
            return ck.SaveChanges();
        }


        //根据用户编号查询
        public static IQueryable GetById(string ygNum)
        {
            CKSJKEntities ck = new CKSJKEntities();
            var obj = from p in ck.Staff
                      where p.ygNumber == ygNum
                      select new
                      {
                          LoginName = p.LoginName,
                          ygNumber = p.ygNumber,
                          loginPwd = p.loginPwd,
                          ygName = p.ygName,
                          email = p.email,
                          phone = p.phone,
                          dBmName = p.department.BmName,
                          pZwName = p.position.ZwName

                      };
            return obj;
        }

        //删除
        public static int Del(string ygNum)
        {
            CKSJKEntities ck = new CKSJKEntities();
            Staff obj = ck.Staff.Find(ygNum);
            obj.isDel = 0;
            return ck.SaveChanges();
        }

        //修改
        public static int StaUp(Staff sta)
        {
            CKSJKEntities ck = new CKSJKEntities();
            var obj = (from p in ck.Staff where p.ygNumber == sta.ygNumber select p).First();
            obj.ygNumber = sta.ygNumber;
            obj.LoginName = sta.LoginName;
            obj.loginPwd = sta.loginPwd;
            obj.ygName = sta.ygName;
            obj.email = sta.email;
            obj.phone = sta.phone;
            obj.BmNum = sta.BmNum;
            obj.ZwNum = sta.ZwNum;
            return ck.SaveChanges();
        }

        public static IQueryable GetByName(string name)
        {
            CKSJKEntities ck = new CKSJKEntities();
            var obj = from p in ck.Staff
                      where p.LoginName == name
                      select new
                      {
                          LoginName = p.LoginName,
                          ygNumber = p.ygNumber,
                          loginPwd = p.loginPwd,
                          ygName = p.ygName,
                          email = p.email,
                          phone = p.phone,
                          dBmName = p.department.BmName,
                          pZwName = p.position.ZwName
                      };
            return obj;
        }
    }
}
