using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entite = DemoEF_Entite;

namespace DemoEF_DALApplicationDBContext.SQLServer.DTO
{
    public class Adresse
    {
        public int AdresseId { get; set; } = 0;
        public int PersonneId { get; set; } = 0;
        public string NoCivique { get; set; } = "";
        public string Odonyme { get; set; } = "";
        public string Ville { get; set; } = "";

        public Adresse()
        {
            ;
        }

        public Adresse(Entite.Adresse p_adresse)
        {
            this.AdresseId = p_adresse.AdresseId;
            this.NoCivique = p_adresse.NumeroCivique;
            this.Odonyme = p_adresse.Odonyme;
            this.Ville = p_adresse.Ville;
            this.PersonneId = p_adresse.ProprietaireAdresseId;
        }

        public Entite.Adresse VersEntite()
        {
            return new Entite.Adresse(this.AdresseId, this.PersonneId, this.NoCivique, this.Odonyme, this.Ville);
        }
    }
}
