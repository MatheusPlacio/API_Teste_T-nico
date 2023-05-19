﻿using Data.Mapping;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Convenio> Convenios { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PacienteMapping());
            modelBuilder.ApplyConfiguration(new ConvenioMapping());
        }
    }
}
