using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace 仓储后台管理系统.Controllers
{
    public class XMLController : Controller
    {
        // GET: XML
        /// <summary>
        /// 员工管理视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        //员工信息分页显示所有
        public ActionResult fyShow(int pageIndex,int pagesize)
        {
            return Json(BLL.X.StaffManager.fyShow(pageIndex,pagesize),JsonRequestBehavior.AllowGet);
        }

        //员工信息总条数
        public ActionResult getRow()
        {
            return Json(BLL.X.StaffManager.GetRow(),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 角色管理视图
        /// </summary>
        /// <returns></returns>
        public ActionResult juese()
        {
            return View();
        }


        /// <summary>
        /// 角色信息分页显示所有
        /// </summary>
        public ActionResult jsAll(int pageIndex,int pagesize)
        {
            return Json(BLL.X.PositionManager.fyShow(pageIndex,pagesize),JsonRequestBehavior.AllowGet);
        }

        //角色信息总条数
        public ActionResult jsRow()
        {
            return Json(BLL.X.PositionManager.GetRow(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 部门管理视图
        /// </summary>
        /// <returns></returns>
        public ActionResult bumen()
        {
            return View();
        }

        /// <summary>
        /// 部门信息分页显示所有
        /// </summary>
        public ActionResult bmAll(int pageIndex, int pagesize)
        {
            return Json(BLL.X.DepartmentManager.fyShow(pageIndex, pagesize), JsonRequestBehavior.AllowGet);
        }

        //部门信息总条数
        public ActionResult bmRow()
        {
            return Json(BLL.X.DepartmentManager.GetRow(), JsonRequestBehavior.AllowGet);
        }

        //根据用户名或工号查询
        public ActionResult ShowByName(int pageIndex, int pagesize, string userName, string ygNum)
        {
            return Json(BLL.X.StaffManager.ShowByName(pageIndex, pagesize, userName, ygNum), JsonRequestBehavior.AllowGet);
        }

        //根据角色编号或角色名称进行查询
        public ActionResult queryByjsName(int pageIndex, int pagesize, string jsName, string jsNum)
        {
            return Json(BLL.X.PositionManager.ShowByjsName(pageIndex,pagesize,jsName,jsNum),JsonRequestBehavior.AllowGet) ;
        }

        //根据部门名称或部门编号进行查询
        public ActionResult queryBybmName(int pageIndex,int pagesize,string bmName,string bmNum)
        {
            return Json(BLL.X.DepartmentManager.ShowBybmName(pageIndex,pagesize,bmName,bmNum),JsonRequestBehavior.AllowGet);
        }

        //登录
        public ActionResult login(string name, string pwd)
        {
            if (BLL.X.StaffManager.login(name, pwd)>0)
            {
                Session["name"] = name;
            }
            return Json(BLL.X.StaffManager.login(name, pwd), JsonRequestBehavior.AllowGet);
        }

        //部门新增
        public ActionResult bmAdd(department dep)
        {
            return Json(BLL.X.DepartmentManager.Add(dep),JsonRequestBehavior.AllowGet) ;
        }

        //用户新增
        public ActionResult ygAdd(Staff sta)
        {
            return Json(BLL.X.StaffManager.Add(sta),JsonRequestBehavior.AllowGet);
        }

        //角色新增
        public ActionResult jsAdd(position po)
        {
            return Json(BLL.X.PositionManager.Add(po), JsonRequestBehavior.AllowGet);
        }


        //查询部门名称
        public ActionResult BybmName()
        {
            return Json(BLL.X.DepartmentManager.BybmName(),JsonRequestBehavior.AllowGet);
        }

        //查询角色名称
        public ActionResult ByjsName()
        {
            return Json(BLL.X.PositionManager.ByjsName(),JsonRequestBehavior.AllowGet);
        }

        //员工表删除
        public ActionResult ygDel(string ygNum)
        {
            return Json(BLL.X.StaffManager.Del(ygNum),JsonRequestBehavior.AllowGet);
        }

        //角色表删除
        public ActionResult jsDel(string zwNumber)
        {
            return Json(BLL.X.PositionManager.Del(zwNumber),JsonRequestBehavior.AllowGet);
        }

        //部门表删除
        public ActionResult bmDel(string bmNumber)
        {
            return Json(BLL.X.DepartmentManager.Del(bmNumber),JsonRequestBehavior.AllowGet);
        }

        //根据用户编号进行查询
        public ActionResult GetById(string ygNum)
        {
            return Json(BLL.X.StaffManager.GetById(ygNum),JsonRequestBehavior.AllowGet);
        }

        //员工表修改
        public ActionResult StaUp(Staff sta)
        {
            return Json(BLL.X.StaffManager.StaUp(sta),JsonRequestBehavior.AllowGet);
        }

        //根据角色编号进行查询
        public ActionResult GetByjsId(string ZwNumber)
        {
            return Json(BLL.X.PositionManager.GetById(ZwNumber),JsonRequestBehavior.AllowGet);
        }

        //角色表修改
        public ActionResult PosiUp(position po)
        {
            return Json(BLL.X.PositionManager.PosiUp(po),JsonRequestBehavior.AllowGet);
        }

        //根据部门编号进行查询
        public ActionResult GetBybmId(string BmNum)
        {
            return Json(BLL.X.DepartmentManager.GetById(BmNum), JsonRequestBehavior.AllowGet);
        }

        //部门表修改
        public ActionResult DepUp(department de)
        {
            return Json(BLL.X.DepartmentManager.DepUp(de),JsonRequestBehavior.AllowGet);
        }
    }
}