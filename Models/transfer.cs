//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class transfer
    {
        public string transferNum { get; set; }
        public string transferTypeNum { get; set; }
        public string orderNo { get; set; }
        public long totalNum { get; set; }
        public string ygNumber { get; set; }
        public System.DateTime createTime { get; set; }
        public string OperationMode { get; set; }
        public string examineState { get; set; }
        public string contents { get; set; }
        public int isDel { get; set; }
    
        public virtual Staff Staff { get; set; }
        public virtual transferType transferType { get; set; }
    }
}