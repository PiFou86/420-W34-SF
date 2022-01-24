using DemoEF_DALApplicationDBContext.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_DALApplicationDBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            ;
        }

        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Adresse> Adresses { get; set; }

        public List<Adresse> ObtenirAdressesPourVilleContenant(string p_partieNomVille)
        {
            return this.Adresses.FromSqlRaw("SELECT * FROM TABLE(OBTENIR_ADRESSE_VILLE({0}));", p_partieNomVille).ToList();
        }
    }
}
