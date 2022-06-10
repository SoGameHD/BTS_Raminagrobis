using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL.DAL
{
    public class LignesGlobal_DAL
    {
        public int Num_semaine { get; set; }
        public int Annee { get; set; }
        public bool Actif { get; set; }
        public int ID { get; set; }

        public LignesGlobal_DAL(int num_semaine, int annee, bool actif) => (Num_semaine, Annee, Actif) = (num_semaine, annee, actif);

        public LignesGlobal_DAL(int id, int num_semaine, int annee, bool actif) => (ID, Num_semaine, Annee, Actif) = (id, num_semaine, annee, actif);
    }
}
