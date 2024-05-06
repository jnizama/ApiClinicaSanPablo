﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntity;

namespace DBContext
{
    public interface IProjectRepository
    {
        EntityBaseResponse GetProjects();
        EntityBaseResponse GetProject(int id);
        EntityBaseResponse Insert(EntityProject project);
    }
}
