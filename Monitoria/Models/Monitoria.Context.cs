﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Monitoria.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MonitoriaEntities4 : DbContext
    {
        public MonitoriaEntities4()
            : base("name=MonitoriaEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<CursoTurmaAluno> CursoTurmaAlunoes { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Semestre> Semestres { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
