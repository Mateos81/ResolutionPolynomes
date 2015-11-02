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
            delta = -q * q * 27 - 4 * (float)Math.Pow(p, 3);

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
                Complex membreU = new Complex(-q / 2.0, Math.Sqrt(delta / 27.0) / 2.0);

                Complex racineTroisiemeU = racineTroisieme(membreU);

                Complex membre1, membre2, membre3;
                
                membre1 = racineTroisiemeU + Complex.Conjugate(racineTroisiemeU);
                membre2 = j * racineTroisiemeU + Complex.Conjugate(j * racineTroisiemeU);
                membre3 = j * j * racineTroisiemeU + Complex.Conjugate(j * j * racineTroisiemeU);

                racines.Add(membre1 - b / (3 * a));
                racines.Add(membre2 - b / (3 * a));
                racines.Add(membre3 - b / (3 * a));

                return racines;
            }

            // Si delta négatif
            if (delta < 0)
            {
                Complex membreDeltaPositif = new Complex((-q + Math.Sqrt(-delta / 27.0)) / 2.0, 0.0);
                Complex membreDeltaNegatif = new Complex((-q - Math.Sqrt(-delta / 27.0)) / 2.0, 0.0);

                Complex racineTroisiemePositive = racineTroisieme(membreDeltaPositif);
                Complex racineTroisiemeNegative = racineTroisieme(membreDeltaNegatif);

                Complex membre1, membre2, membre3;
                membre1 =
                    racineTroisiemePositive + racineTroisiemeNegative - b / (3.0 * a);

                membre2 =
                    j * racineTroisiemePositive + Complex.Conjugate(j) * racineTroisiemeNegative - b / (3.0 * a);

                membre3 = 
                    j * j * racineTroisiemePositive + Complex.Conjugate(j * j) * racineTroisiemeNegative - b / (3.0 * a);

                racines.Add(membre1);
                racines.Add(membre2);
                racines.Add(membre3);

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
            if (complex.Real == 0)
            {
                if (complex.Imaginary == 0)
                    return complex.Real.ToString("0.0000");
                else
                    return complex.Imaginary.ToString("0.0000") + "i";
            }
            else
            {
            if (complex.Imaginary == 0)
                    return complex.Real.ToString("0.0000");
                else
                    return complex.Real.ToString("0.0000") + " + (" + complex.Imaginary.ToString("0.0000") + ")i";
            }
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
        /// <param name="a">Nombre facteur de degré 3.</param>
        /// <param name="b">Nombre facteur de degré 2.</param>
        /// <param name="c">Nombre facteur de degré 1.</param>
        /// <param name="d">Constante.</param>
        /// <param name="toTest">Objet Complex à tester.</param>
        /// <returns>Une string représentant le calcul résultat.</returns>
        public static string Verif(double a, double b, double c, double d, Complex toTest)
        {
            Complex result = Complex.Pow(toTest, 3) * a + Complex.Pow(toTest, 2) * b + toTest * c + d;
            if (result.Real < Math.Pow(10, -5) && result.Imaginary < Math.Pow(10, -5))
            {
                result = 0.0;
            }

            return a + "* (" + ToString(toTest) + ")³ + " + b + "* (" + ToString(toTest) + ")² + " + c + "* (" + ToString(toTest) + ") + " + d + " = " + ToString(result);
        }

        /// <summary>
        /// Racine troisième d'un nombre complexe.
        /// </summary>
        /// <param name="complex">Nombre complexe.</param>
        /// <returns>La racine troisième du complexe passé en paramètre.</returns>
        private static Complex racineTroisieme(Complex complex)
        {
            return complex.Real >= 0 ? Complex.Pow(complex, 1 / 3.0) : -Complex.Pow(-complex, 1 / 3.0);
        }
    }
}