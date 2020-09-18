using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Pizzas.Models;
using TP_Pizzas.Utils;

namespace TP_Pizzas.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            List<Pizza> ListePizzas = PizzaFakeDB.Instance.ListePizzas;
            return View(ListePizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            PizzaVM vm = new PizzaVM();
            vm.Pizza = PizzaFakeDB.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }

        // GET: Pizza/Create
        public ActionResult CreatePizza ()
        {
            PizzaVM vm = new PizzaVM();
            vm.Ingredients = PizzaFakeDB.Instance.ListeIngredients;
            vm.Pates = PizzaFakeDB.Instance.ListePates;
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult CreatePizza (PizzaVM vm)
        {
            try
            {
                vm.Pizza.Pate = PizzaFakeDB.Instance.ListePates.FirstOrDefault(x => x.Id == vm.pateId);

                List<Ingredient> pizzaSelect = vm.Pizza.Ingredients;
                pizzaSelect = PizzaFakeDB.Instance.ListeIngredients.Where(x => vm.IngredientsIds.Contains(x.Id)).ToList();
                
                if (ModelState.IsValid)
                {
                    if (PizzaFakeDB.Instance.ListePizzas.Count == 0)
                    {
                        vm.Pizza.Id = 1;
                    }
                    else
                    {
                        vm.Pizza.Id = PizzaFakeDB.Instance.ListePizzas.Max(x => x.Id) + 1;
                    }
                   
                    PizzaFakeDB.Instance.ListePizzas.Add(vm.Pizza);
                    return RedirectToAction("Index");
                } else
                {
                    vm.Ingredients = PizzaFakeDB.Instance.ListeIngredients;
                    vm.Pates = PizzaFakeDB.Instance.ListePates;
                    return View(vm);
                }
                

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaVM vm = new PizzaVM();

            vm.Ingredients = PizzaFakeDB.Instance.ListeIngredients;
            vm.Pates = PizzaFakeDB.Instance.ListePates;

            vm.Pizza = PizzaFakeDB.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);

            if (vm.Pizza.Pate != null)
            {
                vm.pateId = vm.Pizza.Pate.Id;
            }

            if (vm.Pizza.Ingredients.Any())
            {
                vm.IngredientsIds = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }

            return View(vm);
            
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaVM vm)
        {
            try
            {
                Pizza pizzaToEdit = PizzaFakeDB.Instance.ListePizzas.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizzaToEdit.Nom = vm.Pizza.Nom;
                pizzaToEdit.Ingredients = PizzaFakeDB.Instance.ListeIngredients.Where(x => vm.IngredientsIds.Contains(x.Id)).ToList();
                pizzaToEdit.Pate = PizzaFakeDB.Instance.ListePates.Where(x => x.Id == vm.pateId).FirstOrDefault();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            PizzaVM vm = new PizzaVM();
            vm.Pizza = PizzaFakeDB.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizzaToRemove = PizzaFakeDB.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
                PizzaFakeDB.Instance.ListePizzas.Remove(pizzaToRemove);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(id);
            }
        }
    }
}
