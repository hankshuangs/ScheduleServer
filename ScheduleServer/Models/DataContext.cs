﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScheduleServer.Models
{
    public class DataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DataContext() : base("name=DataContext")
        {
        }

        public System.Data.Entity.DbSet<ScheduleServer.Models.A1Data> A1Data { get; set; }

        public System.Data.Entity.DbSet<ScheduleServer.Models.A2Data> A2Data { get; set; }

        public System.Data.Entity.DbSet<ScheduleServer.Models.N1Data> N1Data { get; set; }
    }
}
