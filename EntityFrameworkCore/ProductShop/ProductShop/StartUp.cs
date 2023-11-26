using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            // 1. Import users
            //string userJson = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, userJson));

            // 2. Import products
            //string productsJson = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, productsJson));

            // 3. Import categories
            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, categoriesJson));

            // 4. Import product categories
            //string productCategoriesJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, productCategoriesJson));

            // 5. Export products in range
            //Console.WriteLine(GetProductsInRange(context));

            // 6. Export sold products
            //Console.WriteLine(GetSoldProducts(context));

            // 7. Export Categories by Prodyct Count
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            // 8. Export users and products
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson) 
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson) 
        {
            var porducts = JsonConvert.DeserializeObject<Product[]>(inputJson);

            if (porducts is not null)
            {
                context.Products.AddRange(porducts);
                context.SaveChanges();
            }

            return $"Successfully imported {porducts?.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson) 
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);
            var notEmptyCat = categories?.Where(c => c.Name != null).ToArray();
            if (notEmptyCat != null) 
            {
                context.AddRange(notEmptyCat);
                context.SaveChanges();
                return $"Successfully imported {notEmptyCat.Length}";
            }

            return $"Successfully imported 0";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson) 
        {
            var categoryProds = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.AddRange(categoryProds);
            context.SaveChanges();

            return $"Successfully imported {categoryProds.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context) 
        {
            var prods = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                                          .Select(p => new
                                          {
                                              name = p.Name,
                                              price = p.Price,
                                              seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                                          })
                                          .OrderBy(p => p.price)
                                          .ToArray();
            var result = JsonConvert.SerializeObject(prods, Formatting.Indented);
            return result;
        }

        public static string GetSoldProducts(ProductShopContext context) 
        {
            var soldProds = context.Users.Where(u => u.ProductsSold.Any(p=>p.BuyerId != null))
                                           .OrderBy(u => u.LastName)
                                                .ThenBy(u => u.FirstName)
                                           .Select(u => new
                                           {
                                               firstName = u.FirstName,
                                               lastName = u.LastName,
                                               soldProducts = u.ProductsSold.Where(p => p.BuyerId != null)
                                                            .Select(p => new
                                                            {
                                                                name = p.Name,
                                                                price = p.Price,
                                                                buyerFirstName = p.Buyer.FirstName,
                                                                buyerLastName = p.Buyer.LastName
                                                            }).ToArray()
                                           }).ToArray();
            var result = JsonConvert.SerializeObject(soldProds, Formatting.Indented);
            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context) 
        {
            var categories = context.Categories.Select(c => new
            {
                category = c.Name,
                productsCount = c.CategoriesProducts.Count(),
                averagePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("f2"),
                totalRevenue = c.CategoriesProducts.Sum(cp=>cp.Product.Price).ToString("f2")
            })
                .OrderByDescending(c=>c.productsCount)
                .ToArray();
            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context) 
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                        .ToArray()
                })
                .OrderByDescending(u => u.soldProducts.Count())
                .ToArray();

            var output = new
            {
                usersCount = users.Count(),
                users = users.Select(u => new
                {
                    u.firstName,
                    u.lastName,
                    u.age,
                    soldProducts = new
                    {
                        count = u.soldProducts.Count(),
                        products = u.soldProducts
                    }
                })
            };

            string result = JsonConvert.SerializeObject(output, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return result;
        }
    }
}