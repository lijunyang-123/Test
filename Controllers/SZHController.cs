using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL.S;
namespace 仓储后台管理系统.Controllers
{
    public class SZHController : Controller
    {
        // GET: SZH
        public ActionResult Index()
        {
            return View();
        }
        //库位页面
        public ActionResult KeWei()
        {
            BLL.S.KeWeiBLL bll = new KeWeiBLL();
            ViewBag.gg = bll.Warehourses(); ;
            return View();
        }
        //供应商页面
        public ActionResult GongYing()
        {
            GongYingBLL bll = new GongYingBLL();
            ViewBag.gg = bll.SupplierLeixes();
            return View();
        }
        //供应商分页
        public ActionResult SelectGongYing(int pageIndex,int pageSize,string Id,string name)
        {
            GongYingBLL bll = new GongYingBLL();
            List<supplier> list = bll.Suppliers();

            var obj = from a in list
                      where a.isDel == 1
                      select new
                      {
                          supplierNum = a.supplierNum,
                          supplierName = a.supplierName,
                          phone = a.phone,
                          chuanzhen = a.chuanzhen,
                          email = a.email,
                          contacts = a.contacts,
                          address = a.address,
                          contents = a.contents,
                          supplierLeix = a.supplierLeix1.supplierLeixName
                      };
            if (!string.IsNullOrEmpty(Id))
            {
                obj = obj.Where(p=> p.supplierNum.Contains(Id));
            }
            if (!string.IsNullOrEmpty(name))
            {
                obj = obj.Where(p => p.supplierName.Contains(name));
            }
            obj = obj.OrderBy(p => p.supplierNum).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return Json(obj,JsonRequestBehavior.AllowGet);
        }

        //供应商表的总条数
        public ActionResult SelectGongYings(string Id, string name)
        {
            GongYingBLL bll = new GongYingBLL();
            List<supplier> list = bll.Suppliers();
            var obj = from a in list where a.isDel == 1 select a;
            if (!string.IsNullOrEmpty(Id))
            {
                obj = obj.Where(p => p.supplierNum.Contains(Id));
            }
            if (!string.IsNullOrEmpty(name))
            {
                obj = obj.Where(p => p.supplierName.Contains(name));
            }
            return Json(obj.Count(), JsonRequestBehavior.AllowGet);
        }
        
        //新增供应商
        public ActionResult AddGongYing(string supplierLeix,string supplierName,string phone,string chuanzhen,string email,string contacts,string address,string contents)
        {
            GongYingBLL bll = new GongYingBLL();
            List<supplier> list = bll.Suppliers();
            int shu = list.Count(); string zhang = shu.ToString();
            string supplierNum = null;
            if (zhang.Length == 1)
            {
                supplierNum = "00000" + (shu + 1);
            }
            else if(zhang.Length ==2)
            {
                supplierNum = "0000" + (shu + 1);
            }
            else if (zhang.Length == 3)
            {
                supplierNum = "000" + (shu + 1);
            }
            supplier a = new supplier();
            a.supplierNum = supplierNum;a.supplierLeix = supplierLeix;a.supplierName = supplierName;a.phone = phone; a.chuanzhen = chuanzhen;
            a.email = email;a.contacts = contacts;a.address = address;a.contents = contents;a.isDel = 1;
            bll.Add(a);
           
                return Json("新增成功！",JsonRequestBehavior.AllowGet);
           
        }

        //删除供应商
        public ActionResult DeleteGongYing(string supplierNum)
        {
            GongYingBLL bll = new GongYingBLL();
            bll.delete(supplierNum);
            return Json("删除成功！",JsonRequestBehavior.AllowGet);
        }
        //全选删除供应商
        public ActionResult DeleteGongYings(string supplierNum)
        {
            GongYingBLL bll = new GongYingBLL();
            return Json(bll.delete(supplierNum), JsonRequestBehavior.AllowGet);
        }
        //修改
        public ActionResult UdpateGongYing(string supplierLeix, string supplierName, string phone, string chuanzhen, string email, string contacts, string address, string contents,string supplierNum)
        {
            GongYingBLL bll = new GongYingBLL();
            List<supplier> list = bll.Suppliers();
            supplier a = new supplier();
            a.supplierNum = supplierNum; a.supplierLeix = supplierLeix; a.supplierName = supplierName; a.phone = phone; a.chuanzhen = chuanzhen;
            a.email = email; a.contacts = contacts; a.address = address; a.contents = contents; a.isDel = 1;
            bll.Udpate(a);

            return Json("修改成功！", JsonRequestBehavior.AllowGet);
        }
        //查询一个供应商
        public ActionResult SelectOneGongYing(string supplierNum) 
        {
            GongYingBLL bll = new GongYingBLL();
            List<supplier> list = bll.Suppliers();
          var  su = from a in list
                 where  a.supplierNum == supplierNum
                 select new
                 {
                     supplierNum = a.supplierNum,
                     supplierName = a.supplierName,
                     phone = a.phone,
                     chuanzhen = a.chuanzhen,
                     email = a.email,
                     contacts = a.contacts,
                     address = a.address,
                     contents = a.contents,
                     supplierLeix = a.supplierLeix
                 };
            return Json(su, JsonRequestBehavior.AllowGet);

        }
    }
}