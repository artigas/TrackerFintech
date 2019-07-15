using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerFintech.Models;

namespace TrackerFintech.DataContexts
{
    public class TrackerDataContext : DbContext
    {
        public DbSet<Tracker> Trackers { get; set; }

        public TrackerDataContext(DbContextOptions<TrackerDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
