using InternalControl.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternalControl.Core.Core
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
        }

        public virtual DbSet<QuestionModel> Questions { get; set; }
        public virtual DbSet<IndicatorsModel> Indicators { get; set; }
        public virtual DbSet<GroupOfIndicatorsModel> GroupOfIndicators { get; set; }
        public virtual DbSet<TypeOfForm> TypeOfForm { get; set; }
           
    }
}
