using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class Paniers_METIER
    {
        public string Libelle { get; set; }
        public int ID { get; set; }

        public Paniers_METIER(string libelle) => Libelle = libelle;
        public Paniers_METIER(int id, string libelle) => (ID, Libelle) = (id, libelle);
    }
}