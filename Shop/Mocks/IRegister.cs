using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace Shop.Mocks
{
    public interface  IRegister
    {
        bool IsEmail(string email);
    }
}