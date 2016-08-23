using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FinalProject
{

    public struct ItemData
    {
        public string ItemNumber;
        public string Description;
        public double RetailPrice;
        public int QtyOnHand;
        public double WholesalePrice;
        public double InventoryValue;
    }

    class Program
    {
        //Create an array of items to use as the item database
        static List<ItemData> Items = new List<ItemData>();

        static string UserInput;

        static void Main()
        {
            while (UserInput != "5")
            {
                UserInput = CreateMenuOptions();

                //Convert the input string into an integer
                int menuselection = int.Parse(UserInput);

                //Decide which menu option was selected
                switch (menuselection)
                {
                    case 1:
                        ItemData item = AddAnItem();
                        Items.Add(item);
                        break;

                    case 2:
                        ChangeAnItem();
                        break;

                    case 3:
                        DeleteAnItem();
                        break;

                    case 4:
                        CreateDBColumns();
                        break;

                    default:
                        break; 
                }
            }
        }

        private static void DeleteAnItem()
        {
            Write("Enter the item number to delete: ");
            string delete = ReadLine();
            int toDelete = int.Parse(delete);
            Items.RemoveAt(toDelete - 1);
        }

        private static void ChangeAnItem()
        {
            Write("Enter the item number to change: ");
            string change = ReadLine();
            int toChange = int.Parse(change);

            ItemData changedItem = AddAnItem();
            Items.RemoveAt(toChange - 1);
            Items.Add(changedItem);
        }

        private static ItemData AddAnItem()
        {
            ItemData newItem = new ItemData();

            //Ask for user to input the item number and then assign it to the first open slot
            //in the items array (variable 'lastused')
            Console.Write("Enter the item number: ");
            newItem.ItemNumber = ReadLine();

            //Ask for user to input the item description and then assign it to the first open
            //slot in the items array (variable 'lastused')
            Console.Write("Enter the item description: ");
            newItem.Description = ReadLine();

            //Ask for user to input the item retail price and then assign it to the first open
            //slot in the items array (variable 'lastused')
            Console.Write("Enter the item retail price: ");
            string retail = ReadLine();
            newItem.RetailPrice = double.Parse(retail);

            //Ask for user to input the qty on hand of the item and then assign it to the
            //first open slot in the items array (variable 'lastused')
            Console.Write("Enter the quantity on hand: ");
            string onhand = ReadLine();
            newItem.QtyOnHand = int.Parse(onhand);

            //Ask for user to input the wholesale price of the item and then assign it to the
            //first open slot in the items array (variable 'lastused')
            Console.Write("Enter the wholesale price: ");
            string wholesale = ReadLine();
            newItem.WholesalePrice = double.Parse(wholesale);

            //Set the value of the items on hand
            newItem.InventoryValue = newItem.RetailPrice * newItem.QtyOnHand;
            return newItem;
            //Items.Add(newItem);
        }

        private static void CreateDBColumns()
        {
            Clear();
            WriteLine("{0,-11} | {1,-11} | {2,-11} | {3, -11} | {4, -11} | {5, -15}", "Item Number", "Description", "Retail Price", "Qty On Hand", "Wholesale Price", "Inventory Value");

            foreach (var item in Items)
            {
                //WriteLine($"{item.ItemNumber,-11} | {item.Description,-11} | {item.RetailPrice, 11} | {item.QtyOnHand, 11} | {item.WholesalePrice, 11} | {item.InventoryValue, 15}");
                WriteLine("{0,-11} | {1,-11} | {2,-12} | {3, -11} | {4, -15} | {5, -15}", item.ItemNumber, item.Description, item.RetailPrice, item.QtyOnHand, item.WholesalePrice, item.InventoryValue);
            }
            ReadLine();
        }

        private static string CreateMenuOptions()
        {
            string tempstring;

            //Clear the window
            Clear();

            //Display the menu options
            WriteLine("1. Add An Item");
            WriteLine("2. Change An Item");
            WriteLine("3. Delete An Item");
            WriteLine("4. List All Items");
            WriteLine("5. Quit");

            //Wait for the user input, and assign it to a string variable
            tempstring = ReadLine();
            return tempstring;
        }
    }
}
