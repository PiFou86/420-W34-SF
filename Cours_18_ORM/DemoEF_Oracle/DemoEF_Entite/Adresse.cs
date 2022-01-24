using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_Entite
{
    public class Adresse
    {
        public Adresse(int p_adresseId, int p_proprietaireAdresseId, string p_numeroCivique, string p_odonyme, string p_ville)
        {
            this.AdresseId = p_adresseId;
            this.ProprietaireAdresseId = p_proprietaireAdresseId;
            this.NumeroCivique = p_numeroCivique;
            this.Odonyme = p_odonyme;
            this.Ville = p_ville;
        }

        public int AdresseId { get; private set; }
        public int ProprietaireAdresseId { get; private set; }
        public string NumeroCivique { get; private set; }
        public string Odonyme { get; private set; }
        public string Ville { get; private set; }

        public override string ToString()
        {
            return $"Adresse({this.AdresseId}, {this.NumeroCivique}, {this.Odonyme}, {this.Ville})";
        }
    }
}
