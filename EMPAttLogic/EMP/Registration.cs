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
            return ExecuteProceduerWithMessage("Employee_Insert_Update", new object[,] { { "EMPIDP", this.EMPIDP }, { "Name", this.Name }, { "Mobile", this.Mobile }, { "EmailID", this.EmailID }, { "Address", this.Address }, { "DesignationIDF", this.DesignationIDF }, { "IsActive", this.IsActive } });
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
    }
}
