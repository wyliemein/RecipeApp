namespace XamarinFirebase.Model
{
    public class Recipes
    {
        public string URL { get; set; }
        public string Name { get; set; }
        public string Ingredient { get; set; }
        public string Calcium { get; set; }
        public int Calories { get; set; }
        public string Categroy { get; set; }
        public string Cholesterol { get; set; }
        public string DietaryFiber { get; set; }
        public string Folate { get; set; }
        public string Iron { get; set; }
        public string Magnesium { get; set; }
        public string Niacin { get; set; }
        public string Potassium { get; set; }
        public string Protein { get; set; }
        public string SaturatedFat { get; set; }
        public string Sodium { get; set; }
        public string Sugars { get; set; }
        public string Thiamin { get; set; }
        public string TotalCarbohydrates { get; set; }
        public string TotalFat { get; set; }
        public string VitaminA { get; set; }
        public string VitaminB6 { get; set; }
        public string VitaminC { get; set; }
    }

    public class SavedRecipes
    {
        public string URL { get; set; }
        public string Name { get; set; }
        public string Ingredient { get; set; }
    }
   
}