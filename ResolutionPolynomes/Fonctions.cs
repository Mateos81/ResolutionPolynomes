using System;
using System.Collections.Generic;
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
        private static float PremierDegre(float a, float b)
        {
            return a == .0 ? b : -b / a;
        }

        /// <summary>
        /// Résolution d'un polynôme du second degré.
        /// </summary>
        /// <param name="a">Facteur de degré 2.</param>
        /// <param name="b">Facteur de degré 1.</param>
        /// <param name="c">Constante.</param>
        /// <returns>Les racines sous forme de liste de Complex.</returns>
        private static List<Complex> SecondDegre(float a, float b, float c)
        {
            List<Complex> racines = new List<Complex>();

            float delta = b * b - 4 * a * c;
            
            if (a == 0.0)
            {
                // Premier degré
                racines.Add(new Complex(PremierDegre(b, c), 0));
            }
            else if (delta == 0.0)
            {
                // Une racine réelle double
                racines.Add(new Complex(-b / (2 * a), 0));
            }
            else if (delta > 0.0)
            {
                // Deux racines réelles simples
                racines.Add(new Complex((-b + Math.Sqrt(delta)) / (2.0 * a), 0));
                racines.Add(new Complex((-b - Math.Sqrt(delta)) / (2.0 * a), 0));
            }
            else
            {
                // Deux racines complexes conjuguées
                racines.Add(new Complex(-b / (2 * a), Math.Sqrt(-delta) / (2.0 * a)));
                racines.Add(new Complex(-b / (2 * a), -Math.Sqrt(-delta) / (2.0 * a)));
            }

            return racines;
        }

        /// <summary>
        /// Résolution d'un polynôme du troisième degré.
        /// </summary>
        /// <param name="a">Facteur de degré 3.</param>
        /// <param name="b">Facteur de degré 2.</param>
        /// <param name="c">Facteur de degré 1.</param>
        /// <param name="d">Constante.</param>
        /// <returns>Les racines sous forme de liste de Complex.</returns>
        public static List<Complex> TroisiemeDegre(float a, float b, float c, float d)
        {
            // Cas du second degré
            if (a == 0)
            {
                return SecondDegre(b, c, d);
            }

            float delta, p, q;
            p = c / a - b * b / (3 * a * a);
            q = d / a - b * c / (3 * a * a) + 2 * (float)Math.Pow(b, 3) / (27 * (float)Math.Pow(a, 3));
            delta = q * q + 4 * (float)Math.Pow(p, 3) / 27;

            List<Complex> racines = new List<Complex>();

            // Si delta égal à 0, 2 racines réelles
            if (delta == 0)
            {
                racines.Add(new Complex(3 * q / p - b / (3 * a), 0));
                racines.Add(new Complex(-3 * q / (2 * p) - b / (3 * a), 0));
                
                return racines;
            }

            // j constante complexe pour Cardan
            // Sachant que j = exp(2*i*pi() / 3)
            Complex j = new Complex(-1.0 / 2.0, Math.Sqrt(3) / 2);
            Complex jCarre = Complex.Pow(j, new Complex(2, 0));

            // Si delta positif, 3 racines complexes en fonction de j
            if (delta > 0)
            {
                float membre1, membre2, membre3;

                membre1 = (float)Math.Pow(-q + Math.Sqrt(delta) / 2, 1 / 3);
                membre2 = (float)Math.Pow(-q - Math.Sqrt(delta) / 2, 1 / 3);
                membre3 = (-b / (3 * a));

                racines.Add(new Complex(membre1 - membre2 + membre3, 0));
                
                racines.Add(
                    new Complex(
                        membre3 - ((Complex)(jCarre * membre2)).Real,
                        ((Complex)(j * membre1 - jCarre * membre2)).Imaginary));

                racines.Add(
                    new Complex(
                        membre3 + ((Complex)(jCarre * membre1)).Real,
                        ((Complex)(-j * membre2 + jCarre * membre1)).Imaginary));

                return racines;
            }

            // Si delta négatif
            if (delta < 0)
            {
                Complex membreDeltaPositif = new Complex(-q / 2, Math.Sqrt(-delta) / 2);
                Complex membreDeltaNegatif = new Complex(-q / 2, -Math.Sqrt(-delta) / 2);

                Complex racineTroisiemePositive = new Complex();
                Complex racineTroisiemeNegative = new Complex();

                racineTroisiemePositive = Complex.Pow(membreDeltaPositif, 1 / 3);
                racineTroisiemeNegative = Complex.Pow(membreDeltaNegatif, 1 / 3);

                Complex membre1, membre2, membre3;
                membre1 =
                    racineTroisiemePositive - racineTroisiemeNegative - b / (3*a);

                membre2 =
                    j * racineTroisiemePositive - j * j * racineTroisiemeNegative - b / (3 * a);

                membre3 = 
                    j*j * racineTroisiemePositive - j * racineTroisiemeNegative - b / (3 * a);

                return racines;
            }

            return racines;
        }

        /// <summary>
        /// Description textuelle d'un objet Complex.
        /// </summary>
        /// <param name="complex">Objet à décrire.</param>
        /// <returns>La description du Complex.</returns>
        public static string ToString(Complex complex)
        {
            // Les deux parties sont nulles
            if (complex.Real == 0 && complex.Imaginary == 0)
            {
                return "0";
            }

            // Une des deux est nulle
            if (complex.Real == 0)
            {
                return complex.Imaginary + "i";
            }
            
            if (complex.Imaginary == 0)
            {
                return complex.Real.ToString();
            }
            
            // Les deux parties sont non-nulles
            return complex.Real + " + (" + complex.Imaginary + ")i";
        }

        /// <summary>
        /// Conversion d'une string descriptive en objet Complex.
        /// </summary>
        /// <param name="complex">String descriptive à convertir.</param>
        /// <returns>Un objet Complex suivant la description donnée.</returns>
        public static Complex ToComplex(string complex)
        {
            double reel = 0.0;
            double imaginaire = 0.0;
            
            // Cas où il n'y a pas de partie imaginaire
            if (!complex.Contains("i"))
            {
                reel = double.Parse(complex);
            }
            else
            {
                // Cas où il n'y a pas de partie réelle : i mais sans paranthèses
                if (!complex.Contains("("))
                    imaginaire = double.Parse(complex.Substring(0, complex.Length - 1));
                else
                {
                    reel = double.Parse(complex.Split('+')[0]);
                    imaginaire = double.Parse(complex.Split('(', ')')[1]);
                }

            }            

            return new Complex(reel, imaginaire);
        }

        /// <summary>
        /// Vérification de calcul.
        /// </summary>
        /// <param name="toTest">Objet Complex à tester.</param>
        /// <returns>Une string représentant une égalité.</returns>
        public static string Verif(double a, double b, double c, double d, Complex toTest)
        {
            return (toTest * a).ToString();
        }
    }
}