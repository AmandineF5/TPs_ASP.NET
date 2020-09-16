using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP3_Chats.Models;

namespace TP3_Chats.Database
{
    public class FakeDB
    {
        private static readonly Lazy<FakeDB> lazy =
            new Lazy<FakeDB>(() => new FakeDB());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDB Instance { get { return lazy.Value; } }

        private FakeDB()
        {
            this.Chats = new List<Chat>();
            Chats = this.GetMeuteDeChats();
        }

        public List<Chat> Chats { get; private set; }

        private List<Chat> GetMeuteDeChats()
        {
            var i = 1;
            return new List<Chat>
            {
                new Chat{Id=i++,Nom = "Felix",Age = 3,Couleur = "Roux"},
                new Chat{Id=i++,Nom = "Minette",Age = 1,Couleur = "Noire"},
                new Chat{Id=i++,Nom = "Miss",Age = 10,Couleur = "Blanche"},
                new Chat{Id=i++,Nom = "Garfield",Age = 6,Couleur = "Gris"},
                new Chat{Id=i++,Nom = "Chatran",Age = 4,Couleur = "Fauve"},
                new Chat{Id=i++,Nom = "Minou",Age = 2,Couleur = "Blanc"},
                new Chat{Id=i,Nom = "Bichette",Age = 12,Couleur = "Rousse"}
            };
        }
    }
}