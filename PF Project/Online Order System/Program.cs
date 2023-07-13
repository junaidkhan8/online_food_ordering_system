using System;
using System.IO;

internal class Program
{
    static void Main(string[] args)
    {
        string[] restaurant = { "PizzaHut", "PizzaPoint" };
        string[] pizzaFlavour = { "Tikka", "Fajita", "Cheese", "Veggie" };
        string[] pizzaSize = { "Small", "Medium", "Large" };
        string[] pizzaTopping = { "Mushroom", "Extra Cheese" };
        double[] pizzaSizePrice = { 300, 600, 1200 };
        double[] pizzaToppingPrice = { 100, 200 };
        Console.WriteLine("Welcome to our pizza delivery system");

        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "order.txt");
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            bool exitProgram = false;
            do
            {
                int chosenRestaurant = 0;
                bool showError = false;
                while (chosenRestaurant <= 0 || chosenRestaurant > restaurant.Length)
                {
                    if (showError)
                        Console.WriteLine("Invalid Selection.");
                    Console.WriteLine("Select your restaurant, press ");
                    for (int i = 0; i < restaurant.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} for {restaurant[i]} ");
                    }
                    int.TryParse(Console.ReadLine(), out chosenRestaurant);
                    showError = true;
                }

                showError = false;
                int chosenFlavour = 0;
                while (chosenFlavour <= 0 || chosenFlavour > pizzaFlavour.Length)
                {
                    if (showError)
                        Console.WriteLine("Invalid Selection.");
                    Console.WriteLine("Select your flavour, press ");
                    for (int i = 0; i < pizzaFlavour.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} for {pizzaFlavour[i]} ");
                    }
                    int.TryParse(Console.ReadLine(), out chosenFlavour);
                    showError = true;
                }

                showError = false;
                int chosenSize = 0;
                while (chosenSize <= 0 || chosenSize > pizzaSize.Length)
                {
                    if (showError)
                        Console.WriteLine("Invalid Selection.");
                    Console.WriteLine("Select your size, press ");
                    for (int i = 0; i < pizzaSize.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} for {pizzaSize[i]} ");
                    }
                    int.TryParse(Console.ReadLine(), out chosenSize);
                    showError = true;
                }

                showError = false;
                int chosenTopping = 0;
                while (chosenTopping <= 0 || chosenTopping > pizzaTopping.Length)
                {
                    if (showError)
                        Console.WriteLine("Invalid Selection.");
                    Console.WriteLine("Select your topping, press ");
                    for (int i = 0; i < pizzaTopping.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} for {pizzaTopping[i]} ");
                    }
                    int.TryParse(Console.ReadLine(), out chosenTopping);
                    showError = true;
                }

                double total = pizzaSizePrice[chosenSize - 1] + pizzaToppingPrice[chosenTopping - 1];
                string customerName = "", address = "", phoneNumber = "";
                while (string.IsNullOrEmpty(customerName))
                {
                    Console.Write("Write your name: ");
                    customerName = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(address))
                {
                    Console.Write("Write your address: ");
                    address = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(phoneNumber))
                {
                    Console.Write("Write your phone no.: ");
                    phoneNumber = Console.ReadLine();
                }

                writer.WriteLine($"------------------------------------");
                writer.WriteLine($"Restaurant: {restaurant[chosenRestaurant - 1]}");
                writer.WriteLine($"Flavour: {pizzaFlavour[chosenFlavour - 1]}");
                writer.WriteLine($"Size: {pizzaSize[chosenSize - 1]}");
                writer.WriteLine($"Topping: {pizzaTopping[chosenTopping - 1]}");
                writer.WriteLine($"Customer Name: {customerName}");
                writer.WriteLine($"Address: {address}");
                writer.WriteLine($"Phone Number: {phoneNumber}");
                writer.WriteLine($"Order Total: Rs. {total}");
                writer.WriteLine($"Estimated Delivery Time: {DateTime.Now.AddMinutes(30)}");

                Console.WriteLine("\n\n\n");
                Console.WriteLine($"Thank you {customerName} for ordering with {restaurant[chosenRestaurant - 1]}. \n" +
                                    $"Your estimated order delivery time is {DateTime.Now.AddMinutes(30)} \n" +
                                    $"Your order total is Rs.{total} \n" +
                                    $"Kindly pay Rs.{total} as cash on delivery.");

                Console.WriteLine("\nDo you want to place another order? (Y/N)");
                string choice = Console.ReadLine();
                exitProgram = (choice.ToLower() != "y");
            } while (!exitProgram);
        }

        Console.WriteLine("Thank you for using our pizza delivery system. Press Enter to exit.");
        Console.ReadLine();
    }
}
