﻿using System;
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
    /// Logique d'interaction pour AdherentUpdate.xaml
    /// </summary>
    public partial class AdherentUpdate : Page
    {
        #region AdherentUpdate
        public AdherentUpdate(Adherent_DTO adherent)
        {
            InitializeComponent();
            this.ShowID.Text = adherent.ID.ToString();
            this.UpdateSociete.Text = adherent.Societe;
            this.UpdateCivilite.Text = adherent.Civilite.ToString();
            this.UpdateNom.Text = adherent.Nom;
            this.UpdatePrenom.Text = adherent.Prenom;
            this.UpdateEmail.Text = adherent.Email;
            this.UpdateActif.IsChecked = adherent.Actif;
        }
        #endregion

        #region BtnUpdate
        public void BtnUpdate(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:44345/", new HttpClient());
            Adherent_DTO adherent = new Adherent_DTO()
            {
                ID = Int32.Parse(this.ShowID.Text),
                Societe = this.UpdateSociete.Text,
                Civilite = Boolean.Parse(this.UpdateCivilite.Text),
                Nom = this.UpdateNom.Text,
                Prenom = this.UpdatePrenom.Text,
                Email = this.UpdateEmail.Text,
                Actif = this.UpdateActif.IsChecked == null? false: this.UpdateActif.IsChecked.Value,
            };

            apiclient.AdherentsPutAsync(adherent);
            MessageBox.Show("L'adhérent a été modifié");
        }
        #endregion
    }
}
