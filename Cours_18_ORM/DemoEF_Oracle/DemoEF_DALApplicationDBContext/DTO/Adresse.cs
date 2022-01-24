using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entite = DemoEF_Entite;

namespace DemoEF_DALApplicationDBContext.DTO
{
    [Table("ORM_ADRESSE")]
    public class Adresse
    {
        [Key]
        [Column("ADRESSEID")]
        public int AdresseId { get; set; }
        [Column("PERSONNEID")]
        public int ProprietaireAdresseId { get; set; }
        [Column("NOCIVIQUE")]
        public string NumeroCivique { get; set; }
        [Column("ODONYME")]
        public string Odonyme { get; set; }
        [Column("VILLE")]
        public string Ville { get; set; }

        public Adresse()
        {
            ;
        }

        public Adresse(Entite.Adresse p_adresse)
        {
            this.AdresseId = p_adresse.AdresseId;
            this.NumeroCivique = p_adresse.NumeroCivique;
            this.Odonyme = p_adresse.Odonyme;
            this.Ville = p_adresse.Ville;
            this.ProprietaireAdresseId = p_adresse.ProprietaireAdresseId;
        }

        public Entite.Adresse VersEntite()
        {
            return new Entite.Adresse(this.AdresseId, this.ProprietaireAdresseId, this.NumeroCivique, this.Odonyme, this.Ville);
        }
    }
}
