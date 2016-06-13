using RecipeCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

using RecipeCalculator.Helpers;

namespace RecipeCalculator
{
    class Program
    {
        static decimal SALETAX = 0.086M;
        static decimal WELLNESSDISCOUNT = 0.05M;

        static void Main(string[] args)
        {
            IngredientsIngredient[] ingredients = null;
            RecipesRecipe[] recipes = null;
            try
            {
                ingredients = SimpleDeserializer.Deserialize<Ingredients>("Data/Ingredients.xml").Ingredient;
                recipes = SimpleDeserializer.Deserialize<Recipes>("Data/Recipes.xml").Recipe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue");
                return;
            }


            foreach (RecipesRecipe recipe in recipes)
            {
                //Console.WriteLine($"Recipe {recipe.id}:");
                decimal sum = 0;
                decimal discount = 0;
                decimal tax = 0;

                bool isWell = false;
                foreach (RecipesRecipeIngredient recipeIngredient in recipe.Ingredient)
                {
                    IngredientsIngredient ingredient = ingredients.First(i => i.id == recipeIngredient.id);

                    //FancyConsole.Write($"{ingredient.name}", 0);
                    //FancyConsole.Write($"{ingredient.price}", 20);
                    //FancyConsole.Write($"{recipeIngredient.amount}", 30);

                    decimal total = (ingredient.price * recipeIngredient.amount);

                    if (recipeIngredient.amount == 0.33M)
                    {
                        total = ingredient.price / 3;
                    }
                    
                    sum += total;

                    //FancyConsole.Write(total.ToString(), 70);

                    decimal d = 0;

                    if (ingredient.isOrganic)
                    {
                        d = total * WELLNESSDISCOUNT;

                        //FancyConsole.Write(d.ToString(), 40);
                        discount += d;
                    }
                    if (ingredient.type != "Produce")
                    {
                        decimal t = total * SALETAX;
                        //FancyConsole.Write(t.ToString(), 50);
                        tax += t;
                    }
                    //Console.WriteLine();
                }

                discount = Math.Ceiling(discount * 100) / 100;
                tax = Math.Ceiling(tax / 0.07M) * 0.07M;


                int leftWall = 21;

                Console.WriteLine($"-------Recipe {recipe.id}-------");
                Console.Write($"Sum:\t\t{sum.ToString("0.00")}");
                FancyConsole.Write("|", leftWall, true);
                Console.Write($"Tax:\t\t{tax.ToString("0.00")}");
                FancyConsole.Write("|", leftWall, true);
                Console.Write($"Discount:\t{discount.ToString()}");
                FancyConsole.Write("|", leftWall, true);
                Console.Write($"Total:\t\t{(sum + tax - discount).ToString("0.00")}");
                FancyConsole.Write("|", leftWall, true);
                //Console.WriteLine("-----------------------------------------");
            }
            Console.WriteLine("----------------------");


            Console.ReadKey();
        }
    }
}
