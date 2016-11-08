using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EMPAttLogic.EMP
{
    public class Registration : SqlHelper
    {
        public Int64 EMPIDP { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int DesignationIDF { get; set; }
        public bool IsActive { get; set; }

        public MEMBERS.SQLReturnMessageNValue AddUpdate()
        {
            return ExecuteProceduerWithMessage("Employee_Insert_Update", new object[,] { { "EMPIDP", this.EMPIDP }, { "Name", this.Name }, { "Mobile", this.Mobile }, { "EmailID", this.EmailID }, { "Address", this.Address }, { "DesignationIDF", this.DesignationIDF }, { "IsActive", this.IsActive }, { "PASSWORD", this.Password } });
        }

        public DataTable GetEmployee(Int64 EMPIDP)
        {
            object[,] param = { { "EMPIDP", EMPIDP } };
            return ExecuteProcedure("GetEmployee", param);
        }

        public MEMBERS.SQLReturnMessageNValue EMP_AUTH(string UserName, string Password)
        {
            return ExecuteProceduerWithMessage("EMP_AUTH", new object[,] { { "UserName", UserName }, { "Password", Password } });
        }

        public MEMBERS.SQLReturnMessageNValue ClockInOut_Insert_Update(Int64 EMPIDF, string Remarks, Int32 EntryType)
        {
            return ExecuteProceduerWithMessage("ClockInOut_Insert_Update", new object[,] { { "EMPIDF", EMPIDF }, { "Remarks", Remarks }, { "EntryType", EntryType } });
        }

        public MEMBERS.SQLReturnMessageNValue Leave_Insert_Update(Int64 EMPIDF, string Remarks, Int32 LeaveType, string FromDate, string ToDate)
        {
            return ExecuteProceduerWithMessage("Leave_Insert_Update", new object[,] { { "EMPIDF", EMPIDF }, { "Remarks", Remarks }, { "LeaveType", LeaveType }, { "FromDate", FromDate }, { "ToDate", ToDate } });
        }

        public DataTable Attadeance_Report(Int64 EMPIDF, string FROMDATE, string TODATE)
        {
            object[,] param = { { "EMPIDF", EMPIDF }, { "FROMDATE", FROMDATE }, { "TODATE", TODATE } };
            return ExecuteProcedure("Attadeance_Report", param);
        }

        public DataTable Leave_Report(Int64 EMPIDF)
        {
            object[,] param = { { "EMPIDF", EMPIDF } };
            return ExecuteProcedure("Leave_Report", param);
        }
    }
}
