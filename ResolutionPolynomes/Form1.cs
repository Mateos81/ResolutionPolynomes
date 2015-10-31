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

            List<System.Numerics.Complex> res = Outils.TroisiemeDegre(a, b, c, d);

            txtb_res.Text = Outils.ToString(res.ToArray()[0]);

            System.Numerics.Complex temp =
                Outils.ToComplex(
                    Outils.ToString(
                        new System.Numerics.Complex(0, -1)));
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
