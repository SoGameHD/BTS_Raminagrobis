using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.WPF
{
    static class GestionnaireDeFenetres
    {
        static public MainWindow? MainWindow;
        static public Adherents? Adherents;
        static public AdherentInsert? AdherentInsert;
        static public AdherentUpdate? AdherentUpdate;
        static public AdherentDelete? AdherentDelete;
        static public Fournisseur? Fournisseur;
        static public FournisseurInsert? FournisseurInsert;
        static public FournisseurUpdate? FournisseurUpdate;
        static public FournisseurDelete? FournisseurDelete;
        static public Catalogue? Catalogue;
        static public Produits? Produits;
        static public ProduitsInsert? ProduitsInsert;
        static public ProduitsUpdate? ProduitsUpdate;
        static public ProduitsDelete? ProduitsDelete;
    }
}