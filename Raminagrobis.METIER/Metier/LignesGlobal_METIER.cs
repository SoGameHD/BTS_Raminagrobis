using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class LignesGlobal_METIER
    {
        public int Num_semaine { get; set; }
        public int Annee { get; set; }
        public bool Actif { get; set; }
        public int ID { get; set; }


        public LignesGlobal_METIER(int num_semaine, int annee, bool actif) => (Num_semaine, Annee, Actif) = (num_semaine, annee, actif);
        public LignesGlobal_METIER(int id, int num_semaine, int annee, bool actif) => (ID, Num_semaine, Annee, Actif) = (id, num_semaine, annee, actif);
    }
}