

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string nameIn, string foodIn) : base(nameIn, foodIn) { }
        public override string ExplainSelf()=> base.ExplainSelf() + Environment.NewLine + "DJAAF";
        
    }
}
