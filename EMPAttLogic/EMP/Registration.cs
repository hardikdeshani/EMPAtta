using System;
using System.Data;

namespace EMPAttLogic
{
    public class Registration : SqlHelper
    {
        public Int64 EMPIDP { get; set; }
        public Int64 CustomerID { get; set; }
        public string ProjectsName { get; set; }
        public string WebsiteUrl { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int DesignationIDF { get; set; }
        public bool IsActive { get; set; }
        public Int32 ClientType { get; set; }

        public MEMBERS.SQLReturnMessageNValue Employee_Insert_Update()
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

        public MEMBERS.SQLReturnMessageNValue Customer_AUTH(string UserName, string Password)
        {
            return ExecuteProceduerWithMessage("Customer_AUTH", new object[,] { { "UserName", UserName }, { "Password", Password } });
        }

        public MEMBERS.SQLReturnMessageNValue ClockInOut_Insert_Update(Int64 EMPIDF, string Remarks, Int32 EntryType, string IPAddress)
        {
            return ExecuteProceduerWithMessage("ClockInOut_Insert_Update", new object[,] { { "EMPIDF", EMPIDF }, { "Remarks", Remarks }, { "EntryType", EntryType }, { "IPAddress", IPAddress } });
        }

        public MEMBERS.SQLReturnMessageNValue Leave_Insert_Update(Int64 EMPIDF, string Remarks, Int32 LeaveType, string FromDate, string ToDate)
        {
            return ExecuteProceduerWithMessage("Leave_Insert_Update", new object[,] { { "EMPIDF", EMPIDF }, { "Remarks", Remarks }, { "LeaveType", LeaveType }, { "FromDate", FromDate }, { "ToDate", ToDate } });
        }

        public MEMBERS.SQLReturnMessageNValue TaskMaster_Insert_Update(Int64 TaskIDP, int UserIDF, string TaskTitle, string TaskDesc, Int32 ProjectIDF, Int32 WorkType)
        {
            return ExecuteProceduerWithMessage("TaskMaster_Insert_Update", new object[,] { { "TaskIDP", TaskIDP }, { "UserIDF", UserIDF }, { "TaskDesc", TaskDesc }, { "TaskTitle", TaskTitle }, { "ProjectIDF", ProjectIDF }, { "WorkType", WorkType } });
        }

        public MEMBERS.SQLReturnMessageNValue CustomerTaskMaster_Insert_Update(Int64 TaskIDP, string TicketNo, Int64 CustomerID, Int32 TaskTitle, string TaskDesc, int CustomerType, int EMPIDF)
        {
            return ExecuteProceduerWithMessage("CustomerTaskMaster_Insert_Update", new object[,] { { "TaskIDP", TaskIDP }, { "CustomerID", CustomerID }, { "TicketNo", TicketNo }, { "TaskDesc", TaskDesc }, { "TaskTitle", TaskTitle }, { "CustomerType", CustomerType }, { "EMPIDF", EMPIDF } });
        }

        public DataTable GetTask(Int64 TaskIDP, int UserIDF, string FROMDATE, string TODATE)
        {
            object[,] param = { { "TaskIDP", TaskIDP }, { "UserIDF", UserIDF }, { "FROMDATE", FROMDATE }, { "TODATE", TODATE } };
            return ExecuteProcedure("GetTask", param);
        }

        public DataTable GetCustomerTask(Int64 TaskIDP, Int64 CustomerID)
        {
            object[,] param = { { "CustomerID", CustomerID } };
            return ExecuteProcedure("GetCustomerTask", param);
        }

        public DataTable Attadeance_Report(Int64 EMPIDF, string FROMDATE, string TODATE, int Status)
        {
            object[,] param = { { "EMPIDF", EMPIDF }, { "FROMDATE", FROMDATE }, { "TODATE", TODATE }, { "Status", Status } };
            return ExecuteProcedure("Attadeance_Report", param);
        }

        public DataSet GetTimeDuration(Int64 EMPIDF, string FROMDATE, string TODATE)
        {
            object[,] param = { { "UserIDF", EMPIDF }, { "FROMDATE", FROMDATE }, { "TODATE", TODATE } };
            return ExecuteProcedureDS("GetTimeDuration", param);
        }

        public DataTable Leave_Report(Int64 EMPIDF)
        {
            object[,] param = { { "EMPIDF", EMPIDF } };
            return ExecuteProcedure("Leave_Report", param);
        }

        public MEMBERS.SQLReturnMessageNValue EmployeeCurrentTime(Int64 EMPIDF)
        {
            object[,] param = { { "EMPIDF", EMPIDF } };
            return ExecuteProceduerWithMessage("EmployeeCurrentTime", param);
        }

        public MEMBERS.SQLReturnMessageNValue Customer_Insert_Update()
        {
            return ExecuteProceduerWithMessage("Customer_Insert_Update", new object[,] { { "CustomerID", this.CustomerID }, { "Name", this.Name }, { "Mobile", this.Mobile }, { "EmailID", this.EmailID }, { "Address", this.Address }, { "ProjectsName", this.ProjectsName }, { "WebsiteUrl", this.WebsiteUrl }, { "IsActive", this.IsActive == true ? 1 : 0 }, { "PASSWORD", this.Password }, { "ClientType", this.ClientType } });
        }

        public DataTable GetCustomers(Int64 CustomerID)
        {
            return ExecuteProcedure("GetCustomers", new object[,] { { "CustomerID", CustomerID } });
        }
    }
}
