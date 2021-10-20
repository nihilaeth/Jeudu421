using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace JeuDu421
{
    class Program
    {
        public readonly int NbManches = 5;
        public readonly int NbDes = 5;
        private List<De> Des = new List<De>();
        
        static void Main(string[] args)
        {
            // Boucle pour recommencer le jeu
            while (true)
            {
                //Initialisation d'un nouveau jeu
                var Game = new Program();
                int mancheNumber = Game.NbManches;
                Typing("Bienvenue ! Nous allons jouer au jeu du 421.\n");
            
                Typing($"Nous allons jouer avec {Game.NbDes} Dés sur {Game.NbManches} manches.\n");
            
                //Premier lancer des dés
                DrawDice(Game.NbDes, Game.Des);
                
                //Boucle d'une manche
                bool repeatManche = true;
                while (repeatManche == true)
                {
                    Typing($"Manche {mancheNumber}\n");
                    
                    ShowDice(Game.Des);
                
                    Console.WriteLine($"Votre score est de {Score(Game.Des)} points.");
                
                    mancheNumber = Run(mancheNumber, Game.Des);
                
                    if (mancheNumber <= 0)
                    {
                        repeatManche = false;
                    }
                }
            
                Typing($"Bravo ! Vous avez fait un score de {Score(Game.Des)} points !\n\n");
                Thread.Sleep(300);
                Typing("Voulez-vous recommencer ? (O ou N)\n");
                string answer = Console.ReadLine();
                if (answer.ToUpper() == "N")
                {
                    Typing("Bye !");
                    Thread.Sleep(100);
                    break;
                }
            }
        }

        //Fonction qui calcul le score du joueur
        static int Score(List<De> Des)
        {
            int score = 0;
            foreach (De des in Des)
            {
                score += des.Face;
            }

            return score;
        }
        
        //Fonction qui appelle la fonction relancer et gère la saisie utilisateur.
        //Permet également de finir la partie si l'utilisateur décide de ne plus relancer ses dés.
        static int Run(int mancheNumber, List<De> Des)
        {
            bool repeat = false;
            Console.WriteLine("Quel sont les dés que vous souhaitez relancer? (Entre 1 à 5 pour relancer les Dés, sinon taper \'n\')");
            while(repeat == false)
            {
                //Vérification de la saisie utilisateur
                try
                {
                    string lectureRelance = Console.ReadLine();
                    if (lectureRelance.Contains("1") || lectureRelance.Contains("2") || lectureRelance.Contains("3") || lectureRelance.Contains("4") || lectureRelance.Contains("5"))
                    {
                        Relancer(lectureRelance, Des);

                        mancheNumber -= 1;
                        repeat = true;
                    } else if (lectureRelance.ToUpper() == "N") //Si l'utilisateur ne veut plus relancer ses dés
                    {
                        mancheNumber = 0;
                        repeat = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Veuillez entrer les chiffres correspondant sapristis !");
                }
            }

            return mancheNumber;

        }

        //Fonction qui relance les dés choisis
        static void Relancer(string lectureRelance, List<De> Des)
        {
            for (int i = 1; i <= Des.Count; i++)
            {
                if (lectureRelance.Contains(i.ToString()))
                {
                    Des[i - 1].Lancer();
                }
            }
        }

        //Fonction qui initialise la liste de dés
        static void DrawDice(int nbDes, List<De> Des)
        {
            for (int i = 0; i < nbDes; i++)
            {
                De lance = new De(6, 0);
                lance.Lancer();
                Des.Add(lance);
            }
        }

        //Fonction qui affiche les dés
        static void ShowDice(List<De> Des)
        {
            Console.WriteLine(String.Concat(Enumerable.Repeat("+---+ ", 5)));
            foreach (De des in Des)
            {
                Console.Write(des);
            }
            Console.Write("\n");
            Console.WriteLine(String.Concat(Enumerable.Repeat("+---+ ", 5)));
        }
        
        //Fonction qui affiche le texte char par char
        static void Typing(string text, int delay = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        

    }
}

