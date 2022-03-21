using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Raminagrobis.API.Client;
using Raminagrobis.DTO.DTO;

namespace Raminagrobis.WPF
{
    /// <summary>
    /// Logique d'interaction pour FournisseurDelete.xaml
    /// </summary>
    public partial class ProduitsUpdate : Page
    {
        #region ProduitsUpdate
        public ProduitsUpdate(Produits_DTO produits)
        {
            InitializeComponent();
            this.ShowID.Text = produits.ID.ToString();
            this.UpdateReference.Text = produits.Reference;
            this.UpdateLibelle.Text = produits.Libelle;
            this.UpdateMarque.Text = produits.Marque;
            this.UpdateActif.IsChecked = produits.Actif;
        }
        #endregion

        #region BtnUpdate 
        public void BtnUpdate(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:44345/", new HttpClient());
            Produits_DTO produits = new Produits_DTO()
            {
                ID = Int32.Parse(this.ShowID.Text),
                Reference = this.UpdateReference.Text,
                Libelle = this.UpdateLibelle.Text,
                Marque = this.UpdateMarque.Text,
                Actif = this.UpdateActif.IsChecked == null ? false : this.UpdateActif.IsChecked.Value,
            };

            apiclient.ProduitsPutAsync(produits);
            MessageBox.Show("Le produit a été modifié");
        }
        #endregion
    }
}
