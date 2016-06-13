using RecipeCalculator.Helpers;
using RecipeCalculator.Model;
using System;
using System.Linq;

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

                decimal sum = 0;
                decimal discount = 0;
                decimal tax = 0;

                foreach (RecipesRecipeIngredient recipeIngredient in recipe.Ingredient)
                {
                    IngredientsIngredient ingredient = ingredients.First(i => i.id == recipeIngredient.id);
                    decimal total = (ingredient.price * recipeIngredient.amount);

                    //is used for 1/3
                    if (recipeIngredient.amount == 0.33M)
                    {
                        total = ingredient.price / 3;
                    }

                    sum += total;
                    decimal d = 0;

                    if (ingredient.isOrganic)
                    {
                        d = total * WELLNESSDISCOUNT;
                        discount += d;
                    }

                    if (ingredient.type != "Produce")
                    {
                        decimal t = total * SALETAX;
                        tax += t;
                    }
                }

                discount = Math.Ceiling(discount * 100) / 100; //rounding up to the nearest cent
                tax = Math.Ceiling(tax / 0.07M) * 0.07M; //rounding up to the nearest 7th cent

                //fancy output box
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
            }

            //bottom of fancy output box
            Console.WriteLine("----------------------");
            Console.ReadKey();
        }
    }
}
