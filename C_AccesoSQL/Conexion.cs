﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_AccesoSQL
{
    public class Conexion
    {
        public static string CN = ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString;
    }
}
