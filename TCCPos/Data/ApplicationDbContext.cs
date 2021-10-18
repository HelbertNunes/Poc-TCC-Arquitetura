using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TCCPos.Data;
using TCCPos.Models;

namespace TCCPos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TCCPos.Data.Item> Item { get; set; }
        public DbSet<FolhaDePagamento> FolhaDePagamento { get; set; }
        public DbSet<NotaFiscal> NotaFiscal { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
    }
}
