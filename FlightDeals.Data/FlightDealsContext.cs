using FlightDeals.Core.Models.AirportProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDeals.Data
{
    public class FlightDealsContext : DbContext
    {

        public FlightDealsContext(DbContextOptions<FlightDealsContext> context) : base(context)
        {
        }     

        public DbSet<Airport> Airport { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().Property(p => p.Id).ValueGeneratedOnAdd();
        }       
     
    }
}