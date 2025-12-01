
    namespace LibraryManagementSystem
    {
        class LibraryManager
        {
            private List<LibraryItem> items;

            public LibraryManager()
            {
                items = new List<LibraryItem>();
            }

            public void AddItem(LibraryItem item)
            {
                items.Add(item);
            }

            // Polymorphism: Same method works with different item types
            public void ProcessLateFees()
            {
                Console.WriteLine("\n=== LATE FEE CALCULATION (Polymorphism) ===");
                int[] daysLateScenarios = { 5, 10, 15 };

                foreach (var item in items)
                {
                    Console.WriteLine($"\n{item.Title} ({item.GetType().Name}):");
                    foreach (int days in daysLateScenarios)
                    {
                        double fee = item.CalculateLateFee(days);
                        Console.WriteLine($"  {days} days late: ${fee:F2}");
                    }
                }
            }

            public void DisplayAllItems()
            {
                Console.WriteLine("\n=== LIBRARY CATALOG ===");
                foreach (LibraryItem item in items)
                {
                    item.DisplayDetails();
                    Console.WriteLine($"  Category: {item.GetCategory()}");
                    Console.WriteLine();
                }
            }

            // Method using interface as parameter type
            public void ProcessBorrowing(IBorrowable item, string memberName)
            {
                item.Borrow(memberName);
            }

            // Method demonstrating polymorphism with interface
            public void ShowBorrowableItems()
            {
                Console.WriteLine("\n=== BORROWABLE ITEMS ===");
                foreach (var item in items)
                {
                    if (item is IBorrowable borrowable)
                    {
                        LibraryItem libraryItem = item as LibraryItem;
                        Console.WriteLine($"- {libraryItem.Title} (Borrow period: {borrowable.BorrowDurationDays} days)");
                    }
                }
            }

            // Method demonstrating polymorphism with interface
            public void ShowReservableItems()
            {
                Console.WriteLine("\n=== RESERVABLE ITEMS ===");
                foreach (var item in items)
                {
                    if (item is IReservable)
                    {
                        LibraryItem libraryItem = item as LibraryItem;
                        Console.WriteLine($"- {libraryItem.Title}");
                    }
                }
            }
        }
    }
