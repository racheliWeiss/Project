using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Manager
{
    public class Manager
    {
        public static int Login(User model)
        {
            return UserRepository.Instance.Login(model);
        }
    }
}
