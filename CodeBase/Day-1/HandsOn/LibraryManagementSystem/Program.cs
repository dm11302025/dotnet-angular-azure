namespace LibraryManagementSystem
{
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("*** LIBRARY MANAGEMENT SYSTEM ***");
                Console.WriteLine("*** POLYMORPHISM DEMONSTRATION ***\n");

                LibraryManager manager = new LibraryManager();

                // Create various library items
                Book book1 = new Book("C# Programming", "BK001", "John Smith", "978-1234567890", 450);
                Book book2 = new Book("Data Structures", "BK002", "Alice Johnson", "978-9876543210", 380);
                DVD dvd1 = new DVD("The Matrix", "DV001", "Wachowski Brothers", 136);
                DVD dvd2 = new DVD("Inception", "DV002", "Christopher Nolan", 148);
                Magazine mag1 = new Magazine("Tech Today", "MG001", "Tech Publications", 156);
                ReferenceBook ref1 = new ReferenceBook("Encyclopedia", "RF001", "Various", "978-1111111111", 1200);

                // Add to manager
                manager.AddItem(book1);
                manager.AddItem(book2);
                manager.AddItem(dvd1);
                manager.AddItem(dvd2);
                manager.AddItem(mag1);
                manager.AddItem(ref1);

                // Display all items (polymorphism - each displays differently)
                manager.DisplayAllItems();

                // Calculate late fees (polymorphism - each calculates differently)
                manager.ProcessLateFees();

                // Demonstrate interface polymorphism
                manager.ShowBorrowableItems();
                manager.ShowReservableItems();

                // Borrowing demonstration
                Console.WriteLine("\n=== BORROWING DEMONSTRATION ===");
                manager.ProcessBorrowing(book1, "John Doe");
                manager.ProcessBorrowing(dvd1, "Jane Smith");

                // Reservation demonstration
                Console.WriteLine("\n=== RESERVATION DEMONSTRATION ===");
                book1.Reserve("Alice Brown");
                book1.Reserve("Bob Wilson");
                book1.Reserve("Carol Davis");

                // Demonstrate runtime polymorphism
                Console.WriteLine("\n=== RUNTIME POLYMORPHISM ===");
                LibraryItem item;

                item = book2;
                Console.WriteLine($"Item type at runtime: {item.GetType().Name}");
                item.DisplayDetails();

                item = dvd2;
                Console.WriteLine($"\nItem type at runtime: {item.GetType().Name}");
                item.DisplayDetails();

                // Type checking and casting
                Console.WriteLine("\n=== TYPE CHECKING ===");
                List<LibraryItem> mixedItems = new List<LibraryItem> { book1, dvd1, mag1 };

                foreach (var obj in mixedItems)
                {
                    Console.WriteLine($"\nProcessing: {obj.Title}");

                    if (obj is Book)
                    {
                        Book b = obj as Book;
                        Console.WriteLine($"  This is a book by {b.Author}");
                    }
                    else if (obj is DVD)
                    {
                        DVD d = obj as DVD;
                        Console.WriteLine($"  This is a DVD directed by {d.Director}");
                    }
                    else if (obj is Magazine)
                    {
                        Magazine m = obj as Magazine;
                        Console.WriteLine($"  This is magazine issue #{m.IssueNumber}");
                    }
                }

                

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
