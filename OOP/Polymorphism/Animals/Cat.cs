
namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string nameIn, string foodIn) : base(nameIn, foodIn){}
        public override string ExplainSelf()=> base.ExplainSelf() + Environment.NewLine +  "MEEOW";
        
    }
}
