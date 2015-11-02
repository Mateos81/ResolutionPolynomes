using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ResolutionPolynomes
{
    /// <summary>
    /// Classe représentant une fenêtre graphique.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lancement du calcul.
        /// </summary>
        /// <param name="sender">Objet.</param>
        /// <param name="e">EventArgs.</param>
        private void btn_calcul_Click(object sender, EventArgs e)
        {
            txtb_res.Text = null;
            txtb_verif.Text = null;
            try
            {
                float param1 = !string.IsNullOrEmpty(txtb_deg3.Text) ? float.Parse(txtb_deg3.Text) : 0.0f;
                float param2 = !string.IsNullOrEmpty(txtb_deg2.Text) ? float.Parse(txtb_deg2.Text) : 0.0f;
                float param3 = !string.IsNullOrEmpty(txtb_deg1.Text) ? float.Parse(txtb_deg1.Text) : 0.0f;
                float param4 = !string.IsNullOrEmpty(txtb_deg0.Text) ? float.Parse(txtb_deg0.Text) : 0.0f;

                if (param1 == 0.0 && param2 == 0.0 && param3 == 0.0)
                {
                    txtb_res.Text = param4 == 0.0 ? "Il y a une infinité de solutions" : "Impossible";
                    return;
                }

                List<System.Numerics.Complex> res = Outils.TroisiemeDegre(param1, param2, param3, param4);
                int i = 0;
                foreach (System.Numerics.Complex c in res)
                {
                    txtb_res.Text += "x" + i + " = " + Outils.ToString(c) + "\r\n\r\n";
                    txtb_verif.Text += Outils.Verif(param1, param2, param3, param4, c) + "\r\n\r\n";
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("Paramètre(s) invalide(s).");
            }
        }
    }
}
