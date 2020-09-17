using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Pizzas.Utils
{
    public class PizzaFakeDB
    {
        private static readonly Lazy<PizzaFakeDB> lazy =
           new Lazy<PizzaFakeDB>(() => new PizzaFakeDB());

        /// <summary>
        /// PizzaFakeDB singleton access.
        /// </summary>
        public static PizzaFakeDB Instance { get { return lazy.Value; } }
        private Random rand = new Random();
        private PizzaFakeDB()
        {
            this.ListePates = this.GetPates();
            this.ListeIngredients = this.GetIngredients();
            this.ListePizzas = this.GetPizzas();
        }

        public List<Pizza> ListePizzas { get; private set; }
        public List<Pate> ListePates { get; private set; }
        public List<Ingredient> ListeIngredients { get; private set; }

        private List<Pizza> GetPizzas()
        {
            List<Pizza> pizzas = new List<Pizza>();

            for (int i = 1; i < 10; i++)
            {
                Pizza randPizza = new Pizza
                {
                    Id = i,
                    Nom = String.Format("Pizza n°{0}", i),
                    Pate = ListePates.FirstOrDefault(x => x.Id == this.GetRandPate())
                };

                randPizza.Ingredients = new List<Ingredient>();
                Ingredient ingredientAdded = new Ingredient();
                for (int j = 0; j < rand.Next(0, 10); j++)
                {
                    Ingredient ingredientRandom = ListeIngredients.FirstOrDefault(x => x.Id == this.GetRandIngredient());
                    if (ingredientRandom != ingredientAdded)
                    {
                        randPizza.Ingredients.Add(ingredientRandom);
                        ingredientAdded = ingredientRandom;
                    }
                }
                pizzas.Add(randPizza);
            }
            return pizzas;
        }

        private List<Pate> GetPates()
        {
            return new List<Pate>
        {
            new Pate{ Id=1,Nom="Pate fine, base crême"},
            new Pate{ Id=2,Nom="Pate fine, base tomate"},
            new Pate{ Id=3,Nom="Pate épaisse, base crême"},
            new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
            };
        }

            private List<Ingredient> GetIngredients()
        {
            return new List<Ingredient>
            {
                new Ingredient { Id = 1, Nom = "Mozzarella" },
                new Ingredient { Id = 2, Nom = "Jambon" },
                new Ingredient { Id = 3, Nom = "Tomate" },
                new Ingredient { Id = 4, Nom = "Oignon" },
                new Ingredient { Id = 5, Nom = "Cheddar" },
                new Ingredient { Id = 6, Nom = "Saumon" },
                new Ingredient { Id = 7, Nom = "Champignon" },
                new Ingredient { Id = 8, Nom = "Poulet" }
            };
        }

        private int GetRandIngredient()
        {
            return rand.Next(0, this.ListeIngredients.Count()+1);
        }

        private int GetRandPate()
        {
            return rand.Next(0, this.ListePates.Count()+1);
        }
    }

}