using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IUserRepository
    {
        List<EntityUser> GetUsers();
        EntityBaseResponse ValidUser(String userName, String Contrasena);
    }
}
