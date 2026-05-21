using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    internal class QuestionReponseCourte : Question
    {


        string Enonce { get; set; }

        Categorie Categorie { get; set; }
        int Points { get; }
        int BonneReponse { get; set; }
        bool ValiderReponse(string reponse);
        double CorrigerReponse(string reponse);


    }

}




