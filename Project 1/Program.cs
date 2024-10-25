using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} - ${Price} ({Category})";
        }
    }

    class Cart
    {
        private List<Product> items = new List<Product>();
        private List<Product> _allProducts;
        private decimal discount = 0.10M;
        private decimal salesTaxRate = 0.08M;
        private DateTime _createdAt;
        private TimeSpan _expiryDuration;
        private string input;

        public Cart(List<Product> allProducts, TimeSpan expiryDuration)
        {
            _allProducts = allProducts; 
            _createdAt = DateTime.Now;
            _expiryDuration = expiryDuration;
        }
        private void ShowRecommendations(Product addedProduct)
        {
            var recommendedProducts = _allProducts
                .Where(p => p.Category == addedProduct.Category && p.Name != addedProduct.Name)
                .Take(3)
                .ToList();

            if (recommendedProducts.Any())
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t\t\tYou may also be interested in:");
                foreach (var recommendation in recommendedProducts)
                {
                    Console.WriteLine($"\t\t\t\t\t- {recommendation.Name} (${recommendation.Price})");
                }
                Console.ResetColor();
            }
        }
        private void HandleCartExpiration()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\tYour cart is about to expire.");
            Console.ResetColor();

            Console.WriteLine("\t\t\t\t\t1. Let the cart expire");
            Console.WriteLine("\t\t\t\t\t2. Proceed to checkout");

            int userChoice = GetValidIndex(2, "\t\t\t\t\tPlease enter your choice: ");

            if (userChoice == 1)
            {
                items.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired and has been cleared.");
                Console.ResetColor();
            }
            else if (userChoice == 2)
            {
                Checkout();
            }
        }
        private int GetValidIndex(int maxOption, string prompt)
        {
            int choice;
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
            } while (!int.TryParse(input, out choice) || choice < 1 || choice > maxOption);

            return choice;
        }

        public bool IsExpired()
        {
            return DateTime.Now > _createdAt + _expiryDuration;
        }

       
        public void ResetCartTimer()
        {
            _createdAt = DateTime.Now;
        }

        public TimeSpan GetRemainingTime()
        {
            DateTime expirationTime = _createdAt + _expiryDuration;
            return expirationTime - DateTime.Now;
        }
        public void AddProduct(Product product)
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();  
            }
            else
            {
                items.Add(product);
                ResetCartTimer(); 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\t\t\t\t{product.Name} added to the cart.");
                Console.ResetColor();
            }
        }

        public void RemoveProductByIndex(int index)
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();
                return;
            }

            if (index >= 0 && index < items.Count)
            {
                var product = items[index];
                items.RemoveAt(index);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\t\t\t\t{product.Name} removed from the cart.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tInvalid selection. Please choose a valid item number.");
                Console.ResetColor();
            }
        }
        public void ProductRecommendation()
{
    if (IsExpired())
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
        Console.ResetColor();
        items.Clear();
        return;
    }

    // Fetch recommended products with a price less than or equal to $800
    var recommendedProducts = _allProducts.Where(p => p.Price <= 800M).ToList();

    if (!recommendedProducts.Any())
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\t\t\t\t\tSorry, no products are available for recommendation under $800.");
        Console.ResetColor();
        return;
    }

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\t\t\t\t\tRecommended Products with a special discount:");

    // Display the recommended products with a discount
    foreach (var product in recommendedProducts)
    {
        decimal discountedPrice = product.Price * (1 - discount);
        Console.WriteLine($"\t\t\t\t\t- {product.Name} - Original Price: ${product.Price}, Discounted Price: ${discountedPrice:F2}");
    }

    Console.ResetColor();
}


        public void ViewCartWithIndices()
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();
                return;
            }

            if (items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t\t\tYour cart is empty.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"\t\t\t\t\t{i + 1}. {items[i]}");
                }
                Console.ResetColor();

               
                TimeSpan remainingTime = GetRemainingTime();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\t\t\t\t\tYou have {remainingTime.Minutes} minute(s) and {remainingTime.Seconds} second(s) until your cart expires.");
                Console.ResetColor();
            }
        }

        public int ItemsCount()
        {
            return items.Count;
        }

        public decimal CalculateTotal()
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();
                return 0;
            }

            decimal subtotal = items.Sum(p => p.Price);
            decimal discountAmount = subtotal * discount;
            decimal salesTax = (subtotal - discountAmount) * salesTaxRate;
            decimal total = subtotal - discountAmount + salesTax;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t\t\t\t\tSubtotal: ${subtotal}");
            Console.WriteLine($"\t\t\t\t\tDiscount (10%): -${discountAmount}");
            Console.WriteLine($"\t\t\t\t\tSales Tax (8%): +${salesTax}");
            Console.WriteLine($"\t\t\t\t\tTotal: ${total}");
            Console.ResetColor();

            return total;
        }

        public void Checkout()
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();
                return;
            }

            if (items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart is empty, please add some products before checkout.");
                Console.ResetColor();
                return;
            }

            CalculateTotal();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t\tProceeding to checkout...");
            Console.WriteLine("\t\t\t\t\tThank you for your purchase!");
            Console.ResetColor();
            items.Clear();  // Clear the cart after checkout
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan expiryDuration = TimeSpan.FromMinutes(10);

            DisplayWelcomeTitle();
            Console.Title = "\t\t\t\t\tGroup 14 Shopping Cart Application";

            bool continueShopping = true;
            List<Product> allProducts = new List<Product>()
        {
            new Product(" HP Spectre x360   ", 1300M, "Laptop"),
            new Product(" Mechanical Keyboard", 120M, "Computer Accessories"),
            new Product(" OnePlus 11", 899M, "Mobile Phone"),
            new Product("Apple Watch Series 7", 399M, "Smart Watch")
        };

            Cart cart = new Cart(allProducts, expiryDuration);

            while (continueShopping)
            {
                bool shopping = true;
                while (shopping)
                {
                    Console.Clear();
                    Header();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\t\t\t\t\t1. Add Product\n\t\t\t\t\t2. Remove Product\n\t\t\t\t\t3. View Cart\n\t\t\t\t\t4. Checkout\n\t\t\t\t\t5. Product Recommendation\n\t\t\t\t\t6. Exit");

                    Console.ResetColor();

                    string choice = GetValidInput("\t\t\t\t\tSelect an option: ", new string[] { "1", "2", "3", "4", "5" });

                    switch (choice)
                    {
                        case "1":
                            Header();
                            AddProductToCart(cart);
                            PauseScreen();
                            break;

                        case "2":
                            if (cart.ItemsCount() == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t\t\t\tYour cart is empty. No items to remove.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\t\t\t\t\tChoose an item to remove:");
                                Console.ResetColor();
                                cart.ViewCartWithIndices();
                                int removeIndex = GetValidIndex(cart.ItemsCount(), "\t\t\t\t\tEnter the number of the item to remove: ");
                                cart.RemoveProductByIndex(removeIndex - 1);
                            }
                            PauseScreen(); 
                            break;

                        case "3":
                            Header();
                            cart.ViewCartWithIndices();
                            PauseScreen();
                            break;

                        case "4":
                            Header();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\t\t\t\t\tCheckout process:");
                            Console.WriteLine("\t\t\t\t\tCurrent Date and Time: " + DateTime.Now);
                            Console.ResetColor();
                            cart.Checkout();
                            PauseScreen();
                            shopping = false;
                            break;

                        case "5":
                            Header();
                            cart.ProductRecommendation();
                            PauseScreen();
                            break;

                        case "6":
                            Header();
                            shopping = false;
                            continueShopping = false; 
                                                     
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                            Console.ResetColor();
                            PauseScreen(); 
                            break;

                        default:
                            Header();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\t\tInvalid option. Please try again.");
                            Console.ResetColor();
                            PauseScreen();
                            break;
                    }
                }

                if (continueShopping) 
                {
                    string continueResponse = GetValidInput("\t\t\t\t\tWould you like to continue shopping? (y/n): ", new string[] { "y", "n" });
                    if (continueResponse == "n")
                    {
                        continueShopping = false;
                     
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\t\t\t\t\tThank you for shopping with us. Goodbye!");
                        Console.ResetColor();
                    }
                }
            }
        }


        static void DisplayWelcomeTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"   
                                       __        __   _                                                   
                                       \ \      / /__| | ___ ___  _ __ ___   ___  
                                        \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ 
                                         \ V  V /  __/ | (_| (_) | | | | | |  __/ 
                                          \_/\_/ \___|_|\___\___/|_| |_| |_|\___|                                    
");
            Console.ResetColor();
            Console.WriteLine("\t\t\t\t\tWelcome!");
            Console.Write("\t\t\t\t\tPlease enter your name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\tHello, " + customerName + "! Let's start shopping.");
            PauseScreen();
        }


        static void AddProductToCart(Cart cart)
        {
            Console.Clear();
            Header();
            Console.WriteLine("\t\t\t\t\tSelect a category:\n\t\t\t\t\t1. Mobile Phones\n\t\t\t\t\t2. Mobile Phone Accessories\n\t\t\t\t\t3. Laptops\n\t\t\t\t\t4. Computer Accessories\n\t\t\t\t\t5. Smart Watches\n\t\t\t\t\t6. Back\n\t\t\t\t\t7. Exit");
            string categoryChoice = GetValidInput("\t\t\t\t\tSelect a category: ", new string[] { "1", "2", "3", "4", "5", "6", "7" });

            switch (categoryChoice)
            {
                case "1":
                    ChooseMobilePhone(cart);
                    break;

                case "2":
                    ChooseMobilePhoneAccessory(cart);
                    break;

                case "3":
                    ChooseLaptop(cart);
                    break;

                case "4":
                    ChooseComputerAccessory(cart);
                    break;

                case "5":
                    ChooseSmartWatch(cart);
                    break;

                case "6":
                    return;

                case "7":
                    Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                    Environment.Exit(0); 
                    break;

                default:
                    Console.WriteLine("\t\t\t\t\tInvalid category choice.");
                    break;
            }
        }


        static void ChooseMobilePhone(Cart cart)
        {
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\tChoose a mobile phone brand:\n\t\t\t\t\t1. Samsung\n\t\t\t\t\t2. Apple\n\t\t\t\t\t3. Xiaomi\n\t\t\t\t\t4. Huawei\n\t\t\t\t\t5. OnePlus\n\t\t\t\t\t6. Back\n\t\t\t\t\t7. Exit");
            Console.ResetColor();
            string brandChoice = GetValidInput("\t\t\t\t\tSelect a brand: ", new string[] { "1", "2", "3", "4", "5", "6", "7" });

            if (brandChoice == "6")
                return; 
            if (brandChoice == "7")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                Console.ResetColor();
                Environment.Exit(0); 
            }

            List<Product> mobilePhones = new List<Product>();

            switch (brandChoice)
            {
                case "1": 
                    mobilePhones.AddRange(new List<Product>
                {
                    new Product("Samsung Galaxy S24 Ultra", 1299M, "Mobile Phones"),
                    new Product("Samsung Galaxy S24", 1099M, "Mobile Phones"),
                    new Product("Samsung Galaxy Z Fold 6", 1999M, "Mobile Phones"),
                    new Product("Samsung Galaxy Z Flip 6", 1299M, "Mobile Phones"),
                    new Product("Samsung Galaxy A74", 499M, "Mobile Phones"),
                    new Product("Samsung Galaxy A54", 399M, "Mobile Phones"),
                    new Product("Samsung Galaxy S23", 999M, "Mobile Phones"),
                    new Product("Samsung Galaxy S22", 799M, "Mobile Phones"),
                    new Product("Samsung Galaxy S21", 699M, "Mobile Phones"),
                    new Product("Samsung Galaxy S20", 599M, "Mobile Phones")
                });
                    break;
                
                case "2": 
                    mobilePhones.AddRange(new List<Product>
                {
                    new Product("iPhone 16 Pro Max", 1499M, "Mobile Phones"),
                    new Product("iPhone 16 Pro", 1399M, "Mobile Phones"),
                    new Product("iPhone 16", 1299M, "Mobile Phones"),
                    new Product("iPhone 16 Plus", 1199M, "Mobile Phones"),
                    new Product("iPhone 15 Pro Max", 1299M, "Mobile Phones"),
                    new Product("iPhone 15 Pro", 1199M, "Mobile Phones"),
                    new Product("iPhone 15", 1099M, "Mobile Phones"),
                    new Product("iPhone 15 Plus", 999M, "Mobile Phones"),
                    new Product("iPhone 14 Pro Max", 1199M, "Mobile Phones"),
                    new Product("iPhone 14 Pro", 1099M, "Mobile Phones")
                });
                    break;

                case "3": 
                    mobilePhones.AddRange(new List<Product>
                {
                    new Product("Xiaomi 14 Pro", 999M, "Mobile Phones"),
                    new Product("Xiaomi 14", 899M, "Mobile Phones"),
                    new Product("Xiaomi 13 Pro", 899M, "Mobile Phones"),
                    new Product("Xiaomi 13", 799M, "Mobile Phones"),
                    new Product("Xiaomi 12 Pro", 699M, "Mobile Phones"),
                    new Product("Xiaomi 12", 599M, "Mobile Phones"),
                    new Product("Xiaomi 11 Pro", 499M, "Mobile Phones"),
                    new Product("Xiaomi 11", 399M, "Mobile Phones"),
                    new Product("Xiaomi Mi 10 Pro", 599M, "Mobile Phones"),
                    new Product("Xiaomi Mi 10", 499M, "Mobile Phones")
                });
                    break;

                case "4":
                    mobilePhones.AddRange(new List<Product>
                {
                    new Product("Huawei Mate 60 Pro", 1099M, "Mobile Phones"),
                    new Product("Huawei Mate 60", 999M, "Mobile Phones"),
                    new Product("Huawei P60 Pro", 899M, "Mobile Phones"),
                    new Product("Huawei P60", 799M, "Mobile Phones"),
                    new Product("Huawei P50 Pro", 699M, "Mobile Phones"),
                    new Product("Huawei P50", 599M, "Mobile Phones"),
                    new Product("Huawei Nova 11 Pro", 499M, "Mobile Phones"),
                    new Product("Huawei Nova 11", 399M, "Mobile Phones"),
                    new Product("Huawei Nova 10 Pro", 299M, "Mobile Phones"),
                    new Product("Huawei Nova 10", 199M, "Mobile Phones")
                });
                    break;

                case "5": 
                    mobilePhones.AddRange(new List<Product>
                {
                    new Product("OnePlus 12 Pro", 1099M, "Mobile Phones"),
                    new Product("OnePlus 11", 899M, "Mobile Phones"),
                    new Product("OnePlus 10 Pro", 799M, "Mobile Phones"),
                    new Product("OnePlus 12", 999M, "Mobile Phones"),
                    new Product("OnePlus 10T", 699M, "Mobile Phones"),
                    new Product("OnePlus 9 Pro", 599M, "Mobile Phones"),
                    new Product("OnePlus 9", 499M, "Mobile Phones"),
                    new Product("OnePlus 8 Pro", 399M, "Mobile Phones"),
                    new Product("OnePlus 8T", 349M, "Mobile Phones"),
                    new Product("OnePlus 8", 299M, "Mobile Phones")
                });
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\tInvalid brand choice.");
                    Console.ResetColor();
                    break;
            }

            DisplayAndAddProduct(cart, mobilePhones);
        }

        static void ChooseMobilePhoneAccessory(Cart cart)
        {
            Console.Clear();
            Header();
            Console.WriteLine("\t\t\t\t\tSelect a subcategory for mobile phone accessories:\n\t\t\t\t\t1. Samsung Accessories\n\t\t\t\t\t2. iPhone Accessories\n\t\t\t\t\t3. Xiaomi Accessories\n\t\t\t\t\t4. Huawei Accessories\n\t\t\t\t\t5. OnePlus Accessories\n\t\t\t\t\t6. Charging Cables & Adapters\n\t\t\t\t\t7. Back\n\t\t\t\t\t8. Exit");
            string categoryChoice = GetValidInput("\t\t\t\t\t\t\t\t\t\tSelect a subcategory: ", new string[] { "1", "2", "3", "4", "5", "6", "7", "8" });

            switch (categoryChoice)
            {
                case "1":
                    List<Product> samsungAccessories = new List<Product>
            {
                new Product("Samsung Wireless Charger", 49M, "Samsung Accessories"),
                new Product("Samsung Phone Case", 29M, "Samsung Accessories"),
                new Product("Samsung Screen Protector", 19M, "Samsung Accessories")
            };
                    DisplayAndAddProduct(cart, samsungAccessories);
                    break;

                case "2":
                    List<Product> iphoneAccessories = new List<Product>
            {
                new Product("IPhone MagSafe Charger", 59M, "iPhone Accessories"),
                new Product("IPhone Silicone Case", 39M, "iPhone Accessories"),
                new Product("IPhone Screen Protector", 25M, "iPhone Accessories")
            };
                    DisplayAndAddProduct(cart, iphoneAccessories);
                    break;

                case "3":
                    List<Product> xiaomiAccessories = new List<Product>
            {
                new Product("Xiaomi Wireless Charger", 35M, "Xiaomi Accessories"),
                new Product("Xiaomi Phone Case", 18M, "Xiaomi Accessories"),
                new Product("Xiaomi Screen Protector", 15M, "Xiaomi Accessories")
            };
                    DisplayAndAddProduct(cart, xiaomiAccessories);
                    break;

                case "4":
                    List<Product> huaweiAccessories = new List<Product>
            {
                new Product("Huawei Wireless Charger", 45M, "Huawei Accessories"),
                new Product("Huawei Phone Case", 22M, "Huawei Accessories"),
                new Product("Huawei Screen Protector", 17M, "Huawei Accessories")
            };
                    DisplayAndAddProduct(cart, huaweiAccessories);
                    break;

                case "5":
                    List<Product> oneplusAccessories = new List<Product>
            {
                new Product("OnePlus Wireless Charger", 50M, "OnePlus Accessories"),
                new Product("OnePlus Phone Case", 27M, "OnePlus Accessories"),
                new Product("OnePlus Screen Protector", 20M, "OnePlus Accessories")
            };
                    DisplayAndAddProduct(cart, oneplusAccessories);
                    break;

                case "6":
                    ChooseChargingCablesAndAdapters(cart);
                    break;

                case "7":
                    return;

                case "8":
                    Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                    Environment.Exit(0); 
                    break;

                default:
                    Console.WriteLine("\t\t\t\t\tInvalid subcategory choice.");
                    break;
            }
        }
        static void ChooseChargingCablesAndAdapters(Cart cart)
        {
            Console.Clear();
            Header();
            Console.WriteLine("\t\t\t\t\tSelect a type of charging cable or adapter:\n\t\t\t\t\t1. Type-C Cables\n\t\t\t\t\t2. Micro USB Cables\n\t\t\t\t\t3. Lightning USB Cables\n\t\t\t\t\t4. Mini USB Cables\n\t\t\t\t\t5. Adapters\n\t\t\t\t\t6. Back\n\t\t\t\t\t7. Exit");
            string cableChoice = GetValidInput("\t\t\t\t\tSelect a type: ", new string[] { "1", "2", "3", "4", "5", "6", "7" });

            switch (cableChoice)
            {
                case "1":
                    List<Product> typeCCables = new List<Product>
            {
                new Product("Type-C Fast Charging Cable (USB 3.0)", 15M, "Charging Cables & Adapters"),
                new Product("Type-C Standard Charging Cable (USB 2.0)", 10M, "Charging Cables & Adapters")
            };
                    DisplayAndAddProduct(cart, typeCCables);
                    break;

                case "2":
                    List<Product> microUSBCables = new List<Product>
            {
                new Product("Micro USB Fast Charging Cable (USB 3.0)", 12M, "Charging Cables & Adapters"),
                new Product("Micro USB Standard Charging Cable (USB 2.0)", 8M, "Charging Cables & Adapters")
            };
                    DisplayAndAddProduct(cart, microUSBCables);
                    break;

                case "3":
                    List<Product> lightningCables = new List<Product>
            {
                new Product("Lightning USB Fast Charging Cable (USB 3.0)", 20M, "Charging Cables & Adapters"),
                new Product("Lightning USB Standard Charging Cable (USB 2.0)", 15M, "Charging Cables & Adapters")
            };
                    DisplayAndAddProduct(cart, lightningCables);
                    break;

                case "4":
                    List<Product> miniUSBCables = new List<Product>
            {
                new Product("Mini USB Charging Cable (USB 2.0)", 10M, "Charging Cables & Adapters"),
                new Product("Mini USB Fast Charging Cable (USB 3.0)", 14M, "Charging Cables & Adapters")
            };
                    DisplayAndAddProduct(cart, miniUSBCables);
                    break;

                case "5":
                    List<Product> adapters = new List<Product>
            {
                new Product("Type-C to Micro USB Adapter", 5M, "Charging Cables & Adapters"),
                new Product("Lightning to USB Adapter", 7M, "Charging Cables & Adapters"),
                new Product("USB Hub (USB 3.0)", 25M, "Charging Cables & Adapters")
            };
                    DisplayAndAddProduct(cart, adapters);
                    break;

                case "6":
                    return;

                case "7":
                    Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                    Environment.Exit(0); 
                    break;

                default:
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\tInvalid choice.");
                    break;
            }
        }


        static void ChooseLaptop(Cart cart)
        {
            Console.Clear();
            Header();
            List<Product> laptops = new List<Product>
            {
                new Product("Dell XPS 13", 1500M, "Laptops"),
                new Product("MacBook Pro", 2500M, "Laptops"),
                new Product("HP Spectre x360", 1300M, "Laptops")
            };

            DisplayAndAddProduct(cart, laptops);
        }

        static void ChooseComputerAccessory(Cart cart)
        {
            Console.Clear();
            Header();
            List<Product> accessories = new List<Product>
            {
                new Product("Logitech Mouse", 50M, "Computer Accessories"),
                new Product("Mechanical Keyboard", 108M, "Computer Accessories")
            };

            DisplayAndAddProduct(cart, accessories);
        }

        static void ChooseSmartWatch(Cart cart)
        {
            Console.Clear();
            Header();
            List<Product> smartWatches = new List<Product>
            {
                new Product("Apple Watch Series 7", 359.10M, "Smart Watches"),
                new Product("Samsung Galaxy Watch 4", 249M, "Smart Watches")
            };

            DisplayAndAddProduct(cart, smartWatches);
        }

        static void DisplayAndAddProduct(Cart cart, List<Product> products)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\tSelect a product to add to your cart:");
            Console.ResetColor();

            // Display all products
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"\t\t\t\t\t{i + 1}. {products[i]}");
            }

            // Add options to go back or exit
            Console.WriteLine($"\t\t\t\t\t{products.Count + 1}. Back");
            Console.WriteLine($"\t\t\t\t\t{products.Count + 2}. Exit");

            // Get valid index input
            int productChoice = GetValidIndex(products.Count + 2, "\t\t\t\t\tSelect a product: ");

            if (productChoice == products.Count + 1)
            {
                return; // Go back to previous menu
            }
            else if (productChoice == products.Count + 2)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                Console.ResetColor();
                Environment.Exit(0); // Exit program
            }
            else
            {
                // Ask for quantity and add the selected product
                int quantity = GetValidQuantity("\t\t\t\t\tEnter the quantity (1-5): ");

                for (int i = 0; i < quantity; i++)
                {
                    cart.AddProduct(products[productChoice - 1]);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\t\t\t\tSuccessfully added {quantity} unit(s) of {products[productChoice - 1].Name} to your cart.");
                Console.ResetColor();

                // Show remaining time before cart expires
                TimeSpan remainingTime = cart.GetRemainingTime();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\t\t\t\t\tYou have {remainingTime.Minutes} minute(s) and {remainingTime.Seconds} second(s) until your cart expires.");
                Console.ResetColor();
            }
        }

        static int GetValidQuantity(string prompt)
        {
            int quantity;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 1 && quantity <= 5)
                {
                    return quantity;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\tInvalid input. Quantity must be between 1 and 5.");
                    Console.ResetColor();
                }
            }
        }
        static string GetValidInput(string prompt, string[] validOptions)
        {
            int attempts = 3;
            while (attempts > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(prompt);
                Console.ResetColor();
                string input = Console.ReadLine().ToLower();

                if (validOptions.Contains(input))
                {
                    return input;
                }

                attempts--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\t\t\tInvalid input. {attempts} attempts remaining.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\tToo many invalid attempts. Exiting the program.");
            Console.ResetColor();
            Environment.Exit(0);
            return null;
        }

        static int GetValidIndex(int maxIndex, string prompt)
        {
            int attempts = 3;
            while (attempts > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(prompt);
                Console.ResetColor();
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= maxIndex)
                {
                    return index;
                }

                attempts--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\t\t\tInvalid selection. {attempts} attempts remaining.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\tToo many invalid attempts. Exiting the program.");
            Console.ResetColor();
            Environment.Exit(0);
            return -1;
        }


        static void PauseScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\tPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        static void Header()
        {
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t\t\t\t   ***************************************************");
            Console.WriteLine("\t\t\t\t\t   ***************************************************");
            Console.WriteLine("\t\t\t\t\t   ************  SHOPPING  CART  SYSTEM  *************");
            Console.WriteLine("\t\t\t\t\t   ***************************************************");
            Console.WriteLine("\t\t\t\t\t   ***************************************************");
            Console.ResetColor();
        }
    }
}
