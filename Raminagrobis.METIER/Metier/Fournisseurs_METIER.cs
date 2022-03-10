using System;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class Fournisseurs_METIER
    {
        public string Societe { get; set; }
        public bool Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public bool Actif { get; set; }

        public int ID { get; set; }

        public Fournisseurs_METIER(string societe, bool civilite, string nom, string prenom, string email, string adresse, bool actif) => (Societe, Civilite, Nom, Prenom, Email, Adresse, Actif) = (societe, civilite, nom, prenom, email, adresse, actif);
        public Fournisseurs_METIER(int id, string societe, bool civilite, string nom, string prenom, string email, string adresse, bool actif) => (ID, Societe, Civilite, Nom, Prenom, Email, Adresse, Actif) = (id, societe, civilite, nom, prenom, email, adresse, actif);
    }
}