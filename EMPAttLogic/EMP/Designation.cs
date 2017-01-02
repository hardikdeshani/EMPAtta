using System;
using System.Data;

namespace EMPAttLogic
{
    public class Designation : SqlHelper
    {
        public Int32 DesignationIDP { get; set; }
        public string DesignationName { get; set; }
        public bool IsActive { get; set; }

        public MEMBERS.SQLReturnMessageNValue Designation_Insert_update()
        {
            return ExecuteProceduerWithMessage("Designation_Insert_update", new object[,] { { "DesignationIDP", this.DesignationIDP }, { "DesignationName", this.DesignationName }, { "IsActive", this.IsActive } });
        }

        public DataTable GetDesignation(Int32 DesignationIDP)
        {
            object[,] param = { { "DesignationIDP", DesignationIDP } };
            return ExecuteProcedure("GetDesignation", param);
        }
    }
}
