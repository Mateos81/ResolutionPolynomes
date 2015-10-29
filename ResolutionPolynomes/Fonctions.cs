using System;
using System.Numerics;

namespace ResolutionPolynomes
{
    /// <summary>
    /// Classe regroupant les fonctions de résolution de polynômes.
    /// </summary>
    internal class Outils
    {
        /// <summary>
        /// Résolution d'un polynôme du premier degré.
        /// </summary>
        /// <param name="a">Facteur de degré 1.</param>
        /// <param name="b">Constante.</param>
        /// <returns>La racine du polynôme.</returns>
        private static string PremierDegre(float a, float b)
        {
            return a == .0 ? b.ToString() : (-b / a).ToString();
        }

        /// <summary>
        /// Résolution d'un polynôme du second degré.
        /// </summary>
        /// <param name="a">Facteur de degré 2.</param>
        /// <param name="b">Facteur de degré 1.</param>
        /// <param name="c">Constante.</param>
        /// <returns>Les racines sous forme de String.</returns>
        private static string SecondDegre(float a, float b, float c)
        {
            // Premier degré (a = 0)
            if (a == 0.0)
            {
                return PremierDegre(b, c);
            }

            float delta = b * b - 4 * a * c;

            // Une racine réelle simple
            if (delta == 0.0)
            {
                return (-b / (2 * a)).ToString();
            }

            // Une racine réelle double
            if (delta > 0.0)
            {
                return (-b + Math.Sqrt(delta)) / (2.0 * a)
                    + " ; " +
                    (-b - Math.Sqrt(delta)) / (2.0 * a);
            }

            // Deux racines complexes conjuguées
            Complex racine1 = new Complex(-b / (2 * a), Math.Sqrt(-delta) / (2.0 * a));
            Complex racine2 = new Complex(-b / (2 * a), -Math.Sqrt(-delta) / (2.0 * a));

            return "x1 = " + ToString(racine1) + "\r\nx2 = " + ToString(racine2);
        }

        /// <summary>
        /// Résolution d'un polynôme du troisième degré.
        /// </summary>
        /// <param name="a">Facteur de degré 3.</param>
        /// <param name="b">Facteur de degré 2.</param>
        /// <param name="c">Facteur de degré 1.</param>
        /// <param name="d">Constante.</param>
        /// <returns>Les racines sous forme de String.</returns>
        public static string TroisiemeDegre(float a, float b, float c, float d)
        {
            // Cas du second degré
            if (a == 0)
            {
                return SecondDegre(b, c, d);
            }

            Complex j = new Complex(-1 / 2, Math.Sqrt(3)/2);
            float delta, p, q;
            p = c / a - b * b / (3 * a * a);
            q = d / a - b * c / (3 * a * a) + 2 * (float)Math.Pow(b, 3) / (27 * (float)Math.Pow(a, 3));
            delta = q * q + 4 * (float)Math.Pow(p, 3) / 27;

            // Si delta égal à 0, 2 racines réelles
            if (delta == 0)
            {
                return (3 * q / p - b / (3 * a)) + " ; " + (-3 * q / (2 * p) - b / (3 * a));
            }

            // Si delta positif, 3 racines complexes en fonction de j, sachant que j=exp(2*i*pi()/3)
            if (delta > 0)
            {
                float Membre1, Membre2, Membre3;

                Membre1 = (float)Math.Pow(-q + Math.Sqrt(delta) / 2, 1 / 3);
                Membre2 = (float)Math.Pow(-q - Math.Sqrt(delta) / 2, 1 / 3);
                Membre3 = (-b / (3 * a));

                return Membre1 + Membre2 + Membre3 + "\r\n"
                    + j * Membre1 + j * j + Membre2 + Membre3 + "\r\n "
                    + j*j * Membre1 + j * Membre2 + Membre3;
            }

            // Si delta négatif
            if (delta < 0)
            {
                string RacineTroisiemePositive, RacineTroisiemeNegative;

                RacineTroisiemePositive =
                    "PUISSANCE((" + -q + " + i*RACINE(ABS(" + delta + ")))/2, 1/3)";

                RacineTroisiemeNegative =
                    "PUISSANCE((" + -q + " - i*RACINE(ABS(" + delta + ")))/2, 1/3)";

                string Membre1, Membre2, Membre3;
                Membre1 =
                    RacineTroisiemePositive +
                    " - " +
                    RacineTroisiemeNegative +
                    -b/(3*a);

                Membre2 =
                    "j * " + RacineTroisiemeNegative + " - " +
                    "j² * " + RacineTroisiemeNegative +
                    -b / (3 * a);

                Membre3 = 
                    "j² * " + RacineTroisiemePositive + " - " +
                    "j * " + RacineTroisiemeNegative +
                    -b / (3 * a);
                
                return Membre1 + " ; " + Membre2 + " ; " + Membre3;
            }

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="complex"></param>
        /// <returns></returns>
        private static string ToString(Complex complex)
        {
            return complex.Real + (complex.Imaginary < 0 ? " " : " + ") + complex.Imaginary + "i";    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="complex"></param>
        /// <returns></returns>
        private static Complex ToComplex(string complex)
        {
            string reel = complex.Split('+')[0];

            return new Complex();
        }
    }
}