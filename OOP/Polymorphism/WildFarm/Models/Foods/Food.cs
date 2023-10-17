

namespace WildFarm.Models.Foods
{
    public abstract class Food
    {
        private int amount;

        protected Food(int amountIn)
        {
            amount = amountIn;
        }

        public int Amount { get => amount; private set => amount = value; }
    }
}
