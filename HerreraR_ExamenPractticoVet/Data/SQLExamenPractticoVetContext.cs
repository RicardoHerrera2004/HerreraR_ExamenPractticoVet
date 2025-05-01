using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HerreraR_ExamenPractticoVet.Models;

    public class SQLExamenPractticoVetContext : DbContext
    {
        public SQLExamenPractticoVetContext (DbContextOptions<SQLExamenPractticoVetContext> options)
            : base(options)
        {
        }

        public DbSet<HerreraR_ExamenPractticoVet.Models.Propietario> Propietario { get; set; } = default!;

public DbSet<HerreraR_ExamenPractticoVet.Models.Mascota> Mascota { get; set; } = default!;

public DbSet<HerreraR_ExamenPractticoVet.Models.Visita> Visita { get; set; } = default!;
    }
