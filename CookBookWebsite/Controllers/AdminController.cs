using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookBookWebsite.Controllers
{

    public class AdminController : Controller
    {
        CookBookContext db = new CookBookContext();

        [Authorize(Users = "robertjohnhelms@gmail.com")]
        public ActionResult Index()
        {
            return View(db.Recipes.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Recipe newRecipe)
        {
            if(ModelState.IsValid)
            {
                db.Recipes.Add(newRecipe);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(newRecipe);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Recipe recipe = new Recipe();

            if(ModelState.IsValid)
            {
                foreach(Recipe item in db.Recipes)
                {
                    if(item.Id == id)
                    {
                        recipe.Id = item.Id;
                        recipe.Name = item.Name;
                        recipe.ImageUrl = item.ImageUrl;
                        recipe.CookingTime = item.CookingTime;
                        recipe.Ingredients = item.Ingredients;
                        recipe.Directions = item.Directions;
                    }
                }
            }

            return View(recipe);
        }
        [HttpPost]
        public ActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                foreach (Recipe item in db.Recipes)
                {
                    if (item.Id == recipe.Id)
                    {
                        item.Name = recipe.Name;
                        item.ImageUrl = recipe.ImageUrl;
                        item.CookingTime = recipe.CookingTime;
                        item.Ingredients = recipe.Ingredients;
                        item.Directions = recipe.Directions;
                    }
                }

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if(ModelState.IsValid)
            {
                foreach(Recipe item in db.Recipes)
                {
                    if(item.Id == id)
                    {
                        db.Recipes.Remove(item);
                    }
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}