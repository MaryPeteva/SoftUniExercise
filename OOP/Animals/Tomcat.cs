

namespace Animals
{
    public class Tomcat:Animals
    {
        private const string TomcatGender = "male";
        public Tomcat(string name, int age, string gender) : base(name, age, TomcatGender) { }
        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
