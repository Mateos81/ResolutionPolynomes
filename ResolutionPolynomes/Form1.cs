using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

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

            // Tests fonctions
            float a = 1.0f, b = 2.0f, c = 1.0f, d = 4.0f;

            string res = Outils.TroisiemeDegre(a, b, c, d);

            //txtb_res.Text = res;
        }

        private static bool verifParams()
        {
            string regex =  "[0-9]*[\\.[0-9]+]?";
            Regex reg = new Regex(regex);
            //MatchCollection matches = reg.Matches();

            return true;
        }
    }
}
