

namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }

        protected Animal(string nameIn, string foodIn) 
        {
            Name = nameIn;
            FavouriteFood = foodIn;
        }

        public virtual string ExplainSelf() => $"{this.Name} and my favourite food is {this.FavouriteFood}";
       
    }
}
