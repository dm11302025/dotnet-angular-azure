
    namespace LibraryManagementSystem
    {
        // ABSTRACT CLASS - Cannot be instantiated, serves as a blueprint
        abstract class LibraryItem
        {
            public string Title { get; set; }
            public string UniqueID { get; set; }
            public bool IsAvailable { get; set; }

            public LibraryItem(string title, string id)
            {
                Title = title;
                UniqueID = id;
                IsAvailable = true;
            }

            // Abstract method - must be implemented by derived classes
            public abstract double CalculateLateFee(int daysLate);

            // Abstract method
            public abstract void DisplayDetails();

            // Virtual method - can be overridden (optional)
            public virtual string GetCategory()
            {
                return "General";
            }

            // Regular method - inherited as-is
            public void CheckOut()
            {
                IsAvailable = false;
                Console.WriteLine($"'{Title}' checked out successfully.");
            }

            public void CheckIn()
            {
                IsAvailable = true;
                Console.WriteLine($"'{Title}' returned successfully.");
            }
        }
    }

