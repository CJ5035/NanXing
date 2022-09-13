using CRMApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Interface
{
    public interface ILoginService
    {
        public bool DoLogin(string name, string pass, ref List<string> roles);

        public List<string> GetRolePowerNames(User user);


    }
}
