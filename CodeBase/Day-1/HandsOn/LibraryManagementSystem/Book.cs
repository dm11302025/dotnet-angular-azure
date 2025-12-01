namespace LibraryManagementSystem
    {
        // Book class - Inherits abstract class and implements interfaces
        class Book : LibraryItem, IBorrowable, IReservable
        {
            public string Author { get; set; }
            public string ISBN { get; set; }
            public int PageCount { get; set; }

            // IBorrowable properties
            public int BorrowDurationDays { get; set; }
            public DateTime DueDate { get; set; }

            // IReservable properties
            public Queue<string> ReservationQueue { get; set; }

            public Book(string title, string id, string author, string isbn, int pages)
                : base(title, id)
            {
                Author = author;
                ISBN = isbn;
                PageCount = pages;
                BorrowDurationDays = 14; // 2 weeks
                ReservationQueue = new Queue<string>();
            }

            // Must implement abstract methods
            public override double CalculateLateFee(int daysLate)
            {
                // Books: $0.50 per day
                return daysLate * 0.50;
            }

            public override void DisplayDetails()
            {
                Console.WriteLine($"Book: {Title}");
                Console.WriteLine($"  Author: {Author}");
                Console.WriteLine($"  ISBN: {ISBN}");
                Console.WriteLine($"  Pages: {PageCount}");
                Console.WriteLine($"  Available: {IsAvailable}");
            }

            // Override virtual method
            public override string GetCategory()
            {
                return "Books";
            }

            // Implement IBorrowable
            public void Borrow(string memberName)
            {
                DueDate = DateTime.Now.AddDays(BorrowDurationDays);
                Console.WriteLine($"{memberName} borrowed '{Title}'");
                Console.WriteLine($"Due date: {DueDate.ToShortDateString()}");
            }

            public void Return()
            {
                Console.WriteLine($"'{Title}' returned.");
                CheckIn();
            }

            // Implement IReservable
            public void Reserve(string memberName)
            {
                ReservationQueue.Enqueue(memberName);
                Console.WriteLine($"{memberName} reserved '{Title}' (Position: {ReservationQueue.Count})");
            }

            public void CancelReservation(string memberName)
            {
                Console.WriteLine($"Reservation cancelled for {memberName}");
            }
        }
    }

