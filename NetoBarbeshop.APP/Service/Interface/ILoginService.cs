using NetoBarbeshop.APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbeshop.APP.Service.Interface
{
    public interface ILoginService
    {
        Task<UserToken> Login(UserLogin userLogin);
    }
}
