
namespace EMPAttLogic
{
    public class AdminLogin : SqlHelper
    {
        public MEMBERS.SQLReturnMessageNValue ADMIN_AUTH(string UserName, string Password)
        {
            return ExecuteProceduerWithMessage("ADMIN_AUTH", new object[,] { { "UserName", UserName }, { "Password", Password } });
        }
    }
}
