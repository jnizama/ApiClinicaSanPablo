﻿using DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext
{
    public interface IDoctorRepository
    {
        List<EntiyMedico> GetUsers();
    }
}
