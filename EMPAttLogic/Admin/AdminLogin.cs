using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMPAttLogic.Admin
{
    public class AdminLogin : SqlHelper
    {
        public MEMBERS.SQLReturnMessageNValue ADMIN_AUTH(string UserName, string Password)
        {
            return ExecuteProceduerWithMessage("ADMIN_AUTH", new object[,] { { "UserName", UserName }, { "Password", Password } });
        }
    }
}
