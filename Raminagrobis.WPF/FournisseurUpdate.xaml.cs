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
    public partial class FournisseurUpdate : Page
    {
        #region FournisseurUpdate
        public FournisseurUpdate(Fournisseur_DTO fournisseur)
        {
            InitializeComponent();
            this.ShowID.Text = fournisseur.ID.ToString();
            this.UpdateSociete.Text = fournisseur.Societe;
            this.UpdateCivilite.Text = fournisseur.Civilite.ToString();
            this.UpdateNom.Text = fournisseur.Nom;
            this.UpdatePrenom.Text = fournisseur.Prenom;
            this.UpdateEmail.Text = fournisseur.Email;
            this.UpdateAdresse.Text = fournisseur.Adresse;
            this.UpdateActif.Text = fournisseur.Actif.ToString();
        }
        #endregion

        #region BtnUpdate 
        public void BtnUpdate(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:44345/", new HttpClient());
            Fournisseur_DTO fournisseur = new Fournisseur_DTO()
            {
                ID = Int32.Parse(this.ShowID.Text),
                Societe = this.UpdateSociete.Text,
                Civilite = Boolean.Parse(this.UpdateCivilite.Text),
                Nom = this.UpdateNom.Text,
                Prenom = this.UpdatePrenom.Text,
                Email = this.UpdateEmail.Text,
                Actif = Boolean.Parse(this.UpdateActif.Text),
            };

            apiclient.FournisseursPutAsync(fournisseur);
            MessageBox.Show("Le fournisseur a été modifié");
        }
        #endregion
    }
}
