namespace DemoEF_Entite
{
    public class Personne
    {
        public Personne(int p_personneId, string p_nom, string p_prenom, int? p_adresseActuelleId, Adresse? p_adresseActuelle, List<Adresse>? p_adresses)
        {
            this.PersonneId = p_personneId;
            this.Nom = p_nom;
            this.Prenom = p_prenom;
            this.AdresseActuelleId = p_adresseActuelleId;
            this.AdresseActuelle = p_adresseActuelle;
            this.Adresses = p_adresses ?? new List<Adresse>();
        }

        public int PersonneId { get; set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public List<Adresse> Adresses { get; private set; }
        public int? AdresseActuelleId { get; private set; }
        private Adresse? m_adresseActuelle;
        public Adresse? AdresseActuelle
        {
            get { return m_adresseActuelle; }
            set
            {
                this.m_adresseActuelle = value;
                this.AdresseActuelleId = value?.AdresseId;
            }
        }

        public override string ToString()
        {
            string res = $"Personne({this.PersonneId}, {this.Nom}, {this.Prenom}, {(this.AdresseActuelleId is null?"null":this.AdresseActuelleId)})";
            if (this.AdresseActuelle is not null)
            {
                res += Environment.NewLine + "  ***" + this.AdresseActuelle + "***";
            }
            foreach (Adresse adresse in this.Adresses)
            {
                res += Environment.NewLine + "  " + adresse;
            }

            return res;
        }
    }
}