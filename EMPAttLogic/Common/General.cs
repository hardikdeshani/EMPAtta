using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMPAttLogic.Common
{
    partial class General
    {
        public string GetPassword(string Mobile)
        {
            return Mobile.Substring(Mobile.Length - 3, 3).Trim() + "123";
        }
    }
}
