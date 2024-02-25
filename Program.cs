using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace MultipleObjects
{
    class Products
    {
        //variables
        protected int _Id;
        protected bool _Available;
        protected int _Quantity;

        //default Products constructor
        public Products()
        {
            _Id = 0;
            _Available = false;
            _Quantity = 0;
        }
        //parameterized Products constructor
        public Products(int id, bool available, int quantity)
        {
            _Id = id;
            _Available = available;
            _Quantity = quantity;
        }
        //Get and Set Methods
        /*public int getId() { return _Id; }
        public void setId(int id) { _Id = id; }
        public bool getAvailable() { return _Available; }
        public void setAvailable(bool available) { _Available = available; }
        public int getQuantity() { return _Quantity; }
        public void setQuantity(int quantity) { _Quantity = quantity; }*/

        //display method
        public virtual void changeMe()
        {
            Console.Write("Id = ");
            _Id = int.Parse(Console.ReadLine());
            Console.Write("Available for purchase (true/false)= ");
            _Available = bool.Parse(Console.ReadLine());
            Console.Write("Quantity available = ");
            _Quantity = int.Parse(Console.ReadLine());
        }

        //print method
        public virtual void print()
        {

            Console.WriteLine();
            Console.WriteLine($"Id: {_Id}");
            Console.WriteLine($"Available: {_Available}");
            Console.WriteLine($"Quantity: {_Quantity}");
        }

    } //end products class

    //derived class
    class Books : Products
    {
        //variables
        protected string _Title;
        protected string _Author;
        protected string _Format;

        //default Books constructor
        public Books() : base()
        {
            _Title = string.Empty;
            _Author = string.Empty;
            _Format = string.Empty;
        }
        //parameterized Books constructor
        public Books(int id, bool available, int quantity, string title, string author, string format) : base(id, available, quantity)
        {
            _Title = title;
            _Author = author;
            _Format = format;
        }
        //Get and Set Methods
        /*public string getTitle() { return _Title; }
        public void setTitle(string title) { _Title = title; }
        public string getAuthor() { return _Author; }
        public void setAuthor(string author) { _Author = author; }
        public string getFormat() { return _Format; }
        public void setFormat(string format) { _Format = format; }*/

        // add/change and display method that override the base class method
        public override void changeMe()
        {
            base.changeMe();
            Console.Write("Title: ");
            _Title = Console.ReadLine();
            Console.Write("Author: ");
            _Author = Console.ReadLine();
            Console.Write("Format: ");
            _Format = Console.ReadLine();
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($"Title: {_Title}");
            Console.WriteLine($"Author: {_Author}");
            Console.WriteLine($"Format: {_Format}");
        }
    } // end books class

    class Program
    {
        static void Main(string[] args)
        {
            // create an array of base class objects and an array of derived class objects
            Console.WriteLine("How many products do you want to enter?");
            int prodNum;
            while (!int.TryParse(Console.ReadLine(), out prodNum))
                Console.WriteLine("Please enter an integer (whole number!): ");
            //product object array
            Products[] prod = new Products[prodNum];

            Console.WriteLine("How many books do you want to enter?");
            int bookNum;
            while (!int.TryParse(Console.ReadLine(), out bookNum))
                Console.WriteLine("Please enter an integer (whole number!): ");
            //book object array
            Books[] book = new Books[bookNum];

            int menuChoice, selection, idNum;
            int prodCount = 0, bookCount = 0;
            menuChoice = Menu();
            while (menuChoice != 4)
            {
                Console.WriteLine("Enter 1 for Books or 2 for Products: ");
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("Enter 1 for Books or 2 for Products: ");
                try
                {
                    switch (menuChoice)
                    {
                        case 1: //Add choice
                            if (selection == 1) // for books
                            {
                                if (bookCount <= bookNum) //if books entered hasn't met set limit
                                {
                                    book[bookCount] = new Books();
                                    book[bookCount].changeMe();
                                    bookCount++;
                                }
                                else
                                    Console.WriteLine("The maximum number of books has been added.");
                            }
                            else // chose product instead
                            {
                                if (prodCount <= prodNum)
                                {
                                    prod[prodCount] = new Products();
                                    prod[prodCount].changeMe();
                                    prodCount++;
                                }
                                else
                                    Console.WriteLine("The maximum number of products has been added.");
                            }

                            break; //end case 1

                        case 2: //Change choice
                            Console.WriteLine("Enter the id number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out idNum))
                                Console.WriteLine("Enter the id number you want to change: ");
                            idNum--;
                            if (selection == 1) //books 
                            {
                                while (idNum > bookCount - 1 || idNum < 0)
                                {
                                    Console.WriteLine("The number you entered was not in range. Try again.");
                                    while (!int.TryParse(Console.ReadLine(), out idNum))
                                        Console.WriteLine("Enter the id number you want to change: ");
                                    idNum--;
                                }
                                book[idNum].changeMe();
                            }
                            else //product change
                            {
                                while (idNum > prodCount - 1 || idNum < 0)
                                {
                                    Console.WriteLine("The number you entered was not in range. Try again.");
                                    while (!int.TryParse(Console.ReadLine(), out idNum))
                                        Console.WriteLine("Enter the id number you want to change: ");
                                    idNum--;
                                }
                                prod[idNum].changeMe();
                            }
                            break; //end case 2

                        case 3: //print all
                            if (selection == 1) //books{
                                for (int i = 0; i < bookCount; i++)
                                {
                                    book[i].print();
                                }
                            else
                            {
                                for (int i = 0; i < prodCount; i++)
                                {
                                    prod[i].print();
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    } //end switch
                } //end try
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                menuChoice = Menu();
            } //end menuchoice while loop

        }//end main

        private static int Menu()
        {
            Console.WriteLine("Please selection an option from the menu: ");
            Console.WriteLine("1 - Add, 2 - Change, 3 - Print, 4 - Quit");
            int menuChoice = 0;
            while (menuChoice < 1 || menuChoice > 4)
            {
                while (!int.TryParse(Console.ReadLine(), out menuChoice))
                {
                    Console.WriteLine("1 - Add, 2 - Change, 3 - Print, 4 - Quit");
                }
            }
            return menuChoice;
        }//end menu class
    } //end program class

} //end namespace
