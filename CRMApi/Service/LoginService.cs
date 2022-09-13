using CRMApi.Entity;
using CRMApi.Interface;
using CRMApi.Models.ModelUtils;
using CRMApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Service
{
    public class LoginService:BaseService,ILoginService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public LoginService(IDbContextFactory contextFactory):base (contextFactory)
        {
            base._ContextFactory = contextFactory;
        }

        public bool DoLogin(string name,string pass,ref List<string> roles)
        {
            User user = GetList<User>(u => u.Name == name).FirstOrDefault();
            if (user != null && PasswordUtil.ComparePasswords(user.Password, pass))
            {
                roles = GetRolePowerNames(user);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取当前登录用户拥有的全部权限列表
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<string> GetRolePowerNames(User user)
        {
            List<string> rolePowerNames = new List<string>();
            foreach (RoleUser temp in user.RoleUsers)
            {
                foreach (RolePower temp2 in temp.Role.RolePowers)
                {
                    if (!rolePowerNames.Contains(temp2.Power.Name))
                    {
                        rolePowerNames.Add(temp2.Power.Name);
                    }
                }
            }
            return rolePowerNames;
        }

       

    }
}
