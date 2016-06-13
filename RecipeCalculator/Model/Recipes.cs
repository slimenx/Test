using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator.Model
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Recipes
    {

        private RecipesRecipe[] recipeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Recipe")]
        public RecipesRecipe[] Recipe
        {
            get
            {
                return this.recipeField;
            }
            set
            {
                this.recipeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RecipesRecipe
    {

        private RecipesRecipeIngredient[] ingredientField;

        private byte idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Ingredient")]
        public RecipesRecipeIngredient[] Ingredient
        {
            get
            {
                return this.ingredientField;
            }
            set
            {
                this.ingredientField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RecipesRecipeIngredient
    {

        private byte idField;

        private decimal amountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }
    }


}
