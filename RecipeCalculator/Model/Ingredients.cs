using System.Xml.Serialization;

namespace RecipeCalculator.Model
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class Ingredients
    {

        private IngredientsIngredient[] ingredientField;

        /// <remarks/>
        [XmlElement("Ingredient")]
        public IngredientsIngredient[] Ingredient
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
    }

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class IngredientsIngredient
    {

        private byte idField;

        private string nameField;

        private decimal priceField;

        private bool isOrganicField;

        private string typeField;

        /// <remarks/>
        [XmlAttribute()]
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
        [XmlAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public decimal price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public bool isOrganic
        {
            get
            {
                return this.isOrganicField;
            }
            set
            {
                this.isOrganicField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
}
