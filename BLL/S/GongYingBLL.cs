using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.S;
namespace BLL.S
{
  public  class GongYingBLL
    {
        /*
        * 查询供应商
        */
        public List<supplier> Suppliers()
        {
            return new GongYing().Suppliers();
        }
    }
}
