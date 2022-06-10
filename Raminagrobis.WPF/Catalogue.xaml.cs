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
using System.IO;
using Raminagrobis.API.Client;
using Raminagrobis.DTO.DTO;
using Microsoft.Win32;

namespace Raminagrobis.WPF
{
    /// <summary>
    /// Logique d'interaction pour Catalogue.xaml
    /// </summary>
    public partial class Catalogue : Page
    {
        #region InitializeComponent
        Fournisseur_DTO fournisseur;
        public Catalogue(Fournisseur_DTO fournisseur_DTO)
        {
            InitializeComponent();
            fournisseur = fournisseur_DTO;
        }
        #endregion

        #region LoadPage
        private async void LoadPage(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:44345/", new HttpClient());
            var catalogue = await apiclient.ProduitsGetAsync(); // TODO : Remplacer par la liste des produits en lien avec le fournisseur

            lvCatalogue.ItemsSource = catalogue;
        }
        #endregion

        #region BtnSelectFiles
        private void BtnSelectFiles(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            opfd.ShowDialog();
            var liste = File.ReadAllText(opfd.FileName);

            var file = File.ReadLines(opfd.FileName);
            List<string> csv_file = file.Skip(1).Take(file.Count() - 1).ToList();

            for (int i = 1; i < file.Count(); i++)
            {
                csv_file.ToList().Add(file.ElementAt(i));
            }
            var apiclient = new Client("https://localhost:44345/", new HttpClient());
            apiclient.FournisseursCatalogueAsync(fournisseur.ID, csv_file); 
            MessageBox.Show("Le fichier CSV a été enregistré");
        }
        #endregion
    }
}