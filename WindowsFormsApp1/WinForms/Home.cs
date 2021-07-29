using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1.WinForms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void GetData(object sender, EventArgs e)
        {
            BloodDonatorsGridView.DataSource = BaseService<Doctor>.GetAll("SELECT * FROM Doctors");
        }

        private void Home_Load(object sender, EventArgs e)
        {
            var bloodGroups = BloodDonationService.GetBloodGroups();
            foreach (var bg in bloodGroups)
            {
                BloodGroupCombobox.Items.Add(bg.BloodGroupName);
            }

            BloodDonatorsGridView.DataSource = BaseService<Doctor>.Get("SELECT * FROM Doctors WHERE Id=7");
        }

        private void BloodGroupChange(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            List<BloodDonator> bloodDonators = new List<BloodDonator>();
            foreach (var bdr in BloodDonationService.GetBloodDonators())
            {
                if (bdr.BloodGroupName == comboBox.Text)
                {
                    bloodDonators.Add(bdr);
                }
            }
            BloodDonatorsGridView.DataSource = bloodDonators;

        }

        private void OnBloodDonationKeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            var text = textBox.Text.ToUpper();
            var bdrs = BaseService<BloodDonator>.GetAll("SELECT * FROM BloodDonators");
            List<BloodDonator> bloodDonators
                    = bdrs.Where(bdr => bdr.BloodGroupName.ToUpper() == text
                        || bdr.Address.ToUpper() == text
                        || bdr.ContactNo.ToUpper() == text).ToList();
            if (bloodDonators.Count > 0)
            {
                BloodDonatorsGridView.DataSource = bloodDonators;
            }
            else
            {
                BloodDonatorsGridView.DataSource = null;
            }
        }

        private void OnSearchButton(object sender, EventArgs e)
        {
            BloodDonatorsGridView.DataSource = null;
            string query = "SELECT * FROM Doctors WHERE Id=7";
            BloodDonatorsGridView.DataSource = BaseService<Doctor>.Get(query);
        }
    }
}
