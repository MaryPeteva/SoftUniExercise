

namespace Animals
{
    public class Kittens:Cat
    {
        private const string KittenGender = "female";
        public Kittens(string name, int age, string gender) : base(name, age, KittenGender) { }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
