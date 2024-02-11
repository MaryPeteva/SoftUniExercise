namespace ShoppingList.Infrastructure.Constants
{
    public static class ValidationConstants
    {
        public static class ProductValidationConstants
        {
            public const int NameMaxLenght = 15;
            public const int NameMinLenght = 3;
        }

        public static class ProductNotesValidationConstants
        {
            public const int ContentMaxLenght = 50;
            public const int ContentMinLenght = 5;
        }
    }
}
