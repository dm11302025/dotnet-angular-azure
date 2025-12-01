namespace LibraryManagementSystem
{
   
        class DVD : LibraryItem, IBorrowable
        {
            public string Director { get; set; }
            public int DurationMinutes { get; set; }

            public int BorrowDurationDays { get; set; }
            public DateTime DueDate { get; set; }

            public DVD(string title, string id, string director, int duration)
                : base(title, id)
            {
                Director = director;
                DurationMinutes = duration;
                BorrowDurationDays = 7; // 1 week
            }

            public override double CalculateLateFee(int daysLate)
            {
                // DVDs: $1.00 per day (higher fee)
                return daysLate * 1.00;
            }

            public override void DisplayDetails()
            {
                Console.WriteLine($"DVD: {Title}");
                Console.WriteLine($"  Director: {Director}");
                Console.WriteLine($"  Duration: {DurationMinutes} minutes");
                Console.WriteLine($"  Available: {IsAvailable}");
            }

            public override string GetCategory()
            {
                return "Movies";
            }

            public void Borrow(string memberName)
            {
                DueDate = DateTime.Now.AddDays(BorrowDurationDays);
                Console.WriteLine($"{memberName} borrowed DVD '{Title}'");
                Console.WriteLine($"Due date: {DueDate.ToShortDateString()}");
            }

            public void Return()
            {
                Console.WriteLine($"DVD '{Title}' returned.");
                CheckIn();
            }
        }
    }
