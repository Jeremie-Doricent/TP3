using System;
using System.Collections.Generic;
using Models.Interfaces;

namespace Models
{
    public class BanqueQuestions
    {
        #region Propriétés

        public IReadOnlyList<IQuestion> Questions { get; protected set; }

        #endregion

        #region Constructeur

        public BanqueQuestions()
        {
            Questions = new List<IQuestion>()
            {
                new QuestionVraiFaux(
                    "Le langage C# est un langage orienté objet.",
                    Categorie.Programmation, 1, true),

                new QuestionVraiFaux(
                    "La terre est plus grande que le soleil.",
                    Categorie.CultureGenerale, 1, false),

                new QuestionNumerique(
                    "Quelle est la valeur approximative de PI (2 décimales)?",
                    Categorie.Mathematiques, 2, 3.14),

                new QuestionNumerique(
                    "Combien de bits contient un octet?",
                    Categorie.Programmation, 2, 8),

                 new QuestionReponseCourte(
                 "Quelle est la capitale du Canada?",
                    Categorie.CultureGenerale, 2, "Ottawa", "C'est une ville en Ontario", 0.5),

                new QuestionReponseCourte(
                "Quel mot-clé permet de créer un objet en C#?",
                    Categorie.Programmation, 2, "new", "C'est un mot réservé du langage", 0.5),
                new QuestionReponseUnique(
                    "Quelle est la capitale de la France?",
                    Categorie.CultureGenerale, 3, "Paris",
                    new List<string> { "Paris", "Rome", "Madrid", "Berlin" }),

                new QuestionReponseUnique(
                    "Quel symbole est utilisé pour les commentaires sur une ligne en C#?",
                    Categorie.Programmation, 3, "//",
                    new List<string> { "//", "/*", "#", "--" }),

                new QuestionReponseMultiples(
                    "Quels sont des types de données en C#?",
                    Categorie.Programmation, 4,
                    new List<string> { "int", "string", "bool" },
                    new List<string> { "int", "string", "bool", "excel", "word" }),

                new QuestionReponseMultiples(
                    "Quels pays sont en Europe?",
                    Categorie.CultureGenerale, 4,
                    new List<string> { "France", "Italie" },
                    new List<string> { "France", "Italie", "Mexique", "Japon" }),
            };
        }

        #endregion

        #region Génération de quiz

        public Quiz GenererQuiz(string nom, int nombreQuestions)
        {
            if (nombreQuestions <= 0)
                throw new ArgumentOutOfRangeException(nameof(nombreQuestions));

            if (Questions == null || nombreQuestions > Questions.Count)
                throw new InvalidOperationException("Il n'y a pas assez de questions dans la banque.");

            List<IQuestion> questionsCopiees = new List<IQuestion>(Questions);
            OutilsQuiz.MelangerQuestions(questionsCopiees);

            List<IQuestion> questionsSelectionnees = new List<IQuestion>();
            for (int i = 0; i < nombreQuestions; i++)
            {
                questionsSelectionnees.Add(questionsCopiees[i]);
            }

            return new Quiz(nom, questionsSelectionnees);
        }

        #endregion
    }
}