using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entite = DemoEF_Entite;

namespace DemoEF_DALApplicationDBContext.Oracle.DTO
{
    [Table("ORM_PERSONNE")]
    public class Personne
    {
        [Key]
        [Column("PERSONNEID")]
        public int PersonneId { get; set; } = 0;
        [Column("NOM")]
        public string Nom { get; set; } = "";
        [Column("PRENOM")]
        public string Prenom { get; set; } = "";

        [Column("ADRESSEACTUELLEID")]
        public int? AdresseActuelleId { get; set; }

        [ForeignKey("AdresseActuelleId")]
        public virtual Adresse? AdresseActuelle { get; set; }

        public Personne()
        {
            ;
        }

        public Personne(Entite.Personne p_entity)
        {
            if (p_entity is null)
            {
                throw new ArgumentNullException(nameof(p_entity));
            }
            this.PersonneId = p_entity.PersonneId;
            this.Nom = p_entity.Nom;
            this.Prenom = p_entity.Prenom;
            this.AdresseActuelleId = p_entity.AdresseActuelleId;
            this.AdresseActuelle = p_entity.AdresseActuelle is not null ? new Adresse(p_entity.AdresseActuelle) : null;
        }

        public Entite.Personne VersEntite()
        {
            return new Entite.Personne(this.PersonneId, this.Nom, this.Prenom, this.AdresseActuelleId, this.AdresseActuelle?.VersEntite(), new List<Entite.Adresse>());
        }
    }
}