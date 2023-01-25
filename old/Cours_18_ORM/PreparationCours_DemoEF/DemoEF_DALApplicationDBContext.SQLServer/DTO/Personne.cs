using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entite = DemoEF_Entite;

namespace DemoEF_DALApplicationDBContext.SQLServer.DTO
{
    public class Personne
    {
        public int PersonneId { get; set; } = 0;
        public string Nom { get; set; } = "";
        public string Prenom { get; set; } = "";

        public int? AdresseActuelleId { get; set; }

        [ForeignKey("AdresseActuelleId")]
        public Adresse? AdresseActuelle { get; set; }
        public List<Adresse>? Adresses { get; set; }

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
            return new Entite.Personne(this.PersonneId, this.Nom, this.Prenom, this.AdresseActuelleId, this.AdresseActuelle?.VersEntite(), this.Adresses?.Select(a => a.VersEntite()).ToList());
        }
    }
}