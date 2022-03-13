using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http;
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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region InitializeComponent
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region BtnAdherent
        #region BtnAdherentList
        private void BtnAdherentList(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Adherents == null)
            {
                GestionnaireDeFenetres.Adherents = new Adherents();
            }
            Main.Navigate(GestionnaireDeFenetres.Adherents);
        }
        #endregion

        #region BtnAdherentInsert
        private void BtnAdherentInsert(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.AdherentInsert == null)
            {
                GestionnaireDeFenetres.AdherentInsert = new AdherentInsert();
            }
            Main.Navigate(GestionnaireDeFenetres.AdherentInsert);
        }
        #endregion

        #region BtnAdherentUpdate
        private void BtnAdherentUdpate(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Adherents == null || GestionnaireDeFenetres.Adherents.lvAdherents.SelectedItem == null)
            {
                MessageBox.Show("Veuillez séléctionner un adhérent dans la liste");
            }
            else
            {
                if (GestionnaireDeFenetres.AdherentUpdate == null)
                {
                    GestionnaireDeFenetres.AdherentUpdate = new AdherentUpdate((Adherent_DTO)GestionnaireDeFenetres.Adherents.lvAdherents.SelectedItem);
                }
                Main.Navigate(GestionnaireDeFenetres.AdherentUpdate);
            }
        }
        #endregion

        #region BtnAdherentDelete
        private void BtnAdherentDelete(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Adherents == null || GestionnaireDeFenetres.Adherents.lvAdherents == null)
            {
                MessageBox.Show("Veuillez afficher la liste des adhérents");
            }
            else
            {
                if (GestionnaireDeFenetres.AdherentDelete == null)
                {
                    GestionnaireDeFenetres.AdherentDelete = new AdherentDelete();
                }
                Main.Navigate(GestionnaireDeFenetres.AdherentDelete);
            }
        }
        #endregion
        #endregion

        #region BtnFournisseur
        #region BtnFournisseurList
        private void BtnFournisseurList(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Fournisseur == null)
            {
                GestionnaireDeFenetres.Fournisseur = new Fournisseur();
            }
            Main.Navigate(GestionnaireDeFenetres.Fournisseur);
        }
        #endregion

        #region BtnFournisseurInsert
        private void BtnFournisseurInsert(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.FournisseurInsert == null)
            {
                GestionnaireDeFenetres.FournisseurInsert = new FournisseurInsert();
            }
            Main.Navigate(GestionnaireDeFenetres.FournisseurInsert);
        }
        #endregion

        #region BtnFournisseurUpdate
        private void BtnFournisseurUdpate(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Fournisseur == null || GestionnaireDeFenetres.Fournisseur.lvFournisseurs.SelectedItem == null)
            {
                MessageBox.Show("Veuillez séléctionner un fournisseur dans la liste");
            }
            else
            {
                if (GestionnaireDeFenetres.FournisseurUpdate == null)
                {
                    GestionnaireDeFenetres.FournisseurUpdate = new FournisseurUpdate((Fournisseur_DTO)GestionnaireDeFenetres.Fournisseur.lvFournisseurs.SelectedItem);
                }
                Main.Navigate(GestionnaireDeFenetres.FournisseurUpdate);
            }
        }
        #endregion

        #region BtnFournisseurDelete
        private void BtnFournisseurDelete(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Fournisseur == null || GestionnaireDeFenetres.Fournisseur.lvFournisseurs == null)
            {
                MessageBox.Show("Veuillez afficher la liste des fournisseurs");
            }
            else
            {
                if (GestionnaireDeFenetres.FournisseurDelete == null)
                {
                    GestionnaireDeFenetres.FournisseurDelete = new FournisseurDelete();
                }
                Main.Navigate(GestionnaireDeFenetres.FournisseurDelete);
            }
        }
        #endregion

        #region BtnFournisseurReference
        private void BtnFournisseurReference(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Fournisseur == null || GestionnaireDeFenetres.Fournisseur.lvFournisseurs.SelectedItem == null)
            {
                MessageBox.Show("Veuillez séléctionner un fournisseur dans la liste");
            }
            else
            {
                if (GestionnaireDeFenetres.Catalogue == null)
                {
                    GestionnaireDeFenetres.Catalogue = new Catalogue((Fournisseur_DTO)GestionnaireDeFenetres.Fournisseur.lvFournisseurs.SelectedItem);
                }
                Main.Navigate(GestionnaireDeFenetres.Catalogue);
            }
        }
        #endregion
        #endregion

        #region BtnProduit
        #region BtnProduitList
        private void BtnProduitList(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Produits == null)
            {
                GestionnaireDeFenetres.Produits = new Produits();
            }
            Main.Navigate(GestionnaireDeFenetres.Produits);
        }
        #endregion

        #region BtnProduitInsert
        private void BtnProduitInsert(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.ProduitsInsert == null)
            {
                GestionnaireDeFenetres.ProduitsInsert = new ProduitsInsert();
            }
            Main.Navigate(GestionnaireDeFenetres.ProduitsInsert);
        }
        #endregion

        #region BtnProduitUpdate
        private void BtnProduitUdpate(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Produits == null || GestionnaireDeFenetres.Produits.lvProduits.SelectedItem == null)
            {
                MessageBox.Show("Veuillez séléctionner un produit dans la liste");
            }
            else
            {
                if (GestionnaireDeFenetres.ProduitsUpdate == null)
                {
                    GestionnaireDeFenetres.ProduitsUpdate = new ProduitsUpdate((Produits_DTO)GestionnaireDeFenetres.Produits.lvProduits.SelectedItem);
                }
                Main.Navigate(GestionnaireDeFenetres.ProduitsUpdate);
            }
        }
        #endregion

        #region BtnProduitDelete
        private void BtnProduitDelete(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Produits == null || GestionnaireDeFenetres.Produits.lvProduits == null)
            {
                MessageBox.Show("Veuillez afficher la liste des produits");
            }
            else
            {
                if (GestionnaireDeFenetres.ProduitsDelete == null)
                {
                    GestionnaireDeFenetres.ProduitsDelete = new ProduitsDelete();
                }
                Main.Navigate(GestionnaireDeFenetres.ProduitsDelete);
            }
        }
        #endregion
        #endregion

        #region Panier
        #region BtnPanierList
        private void BtnPanierList(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Panier == null)
            {
                GestionnaireDeFenetres.Panier = new Panier();
            }
            Main.Navigate(GestionnaireDeFenetres.Panier);
        }
        #endregion

        #region BtnPanierDetail
        private void BtnPanierDetail(object sender, RoutedEventArgs e)
        {
            if(GestionnaireDeFenetres.Panier == null || GestionnaireDeFenetres.Panier.lvPanier.SelectedItem == null)
            {
                MessageBox.Show("Veuillez séléctionner un panier de la liste");
            }
            else
            {
                if (GestionnaireDeFenetres.PanierDetail == null)
                {
                    GestionnaireDeFenetres.PanierDetail = new PanierDetail();
                }
                Main.Navigate(GestionnaireDeFenetres.PanierDetail);
            }
        }
        #endregion
        #endregion
    }
}