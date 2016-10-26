using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EMPAttLogic.EMP
{
    public class Designation : SqlHelper
    {
        public int DesignationIDP { get; set; }
        public string DesignationName { get; set; }
        public bool IsActive { get; set; }

        public MEMBERS.SQLReturnMessageNValue AddUpdate()
        {
            return ExecuteProceduerWithMessage("Designation_Insert_update", new object[,] { { "DesignationIDP", this.DesignationIDP }, { "DesignationName", this.DesignationName }, { "IsActive", this.IsActive } });
        }

        public DataTable GetDesignation(Int64 DesignationIDP)
        {
            object[,] param = { { "DesignationIDP", DesignationIDP } };
            return ExecuteProcedure("GetDesignation", param);
        }
    }
}
