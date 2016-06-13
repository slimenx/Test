using System.Xml.Serialization;

namespace RecipeCalculator.Model
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Recipes
    {

        private RecipesRecipe[] recipeField;

        /// <remarks/>
        [XmlElementAttribute("Recipe")]
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
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class RecipesRecipe
    {

        private RecipesRecipeIngredient[] ingredientField;

        private byte idField;

        /// <remarks/>
        [XmlElementAttribute("Ingredient")]
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
        [XmlAttributeAttribute()]
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
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class RecipesRecipeIngredient
    {

        private byte idField;

        private decimal amountField;

        /// <remarks/>
        [XmlAttributeAttribute()]
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
        [XmlAttributeAttribute()]
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
