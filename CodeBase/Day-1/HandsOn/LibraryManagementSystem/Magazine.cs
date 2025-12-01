namespace LibraryManagementSystem
{
    
        class Magazine : LibraryItem
        {
            public string Publisher { get; set; }
            public int IssueNumber { get; set; }

            public Magazine(string title, string id, string publisher, int issue)
                : base(title, id)
            {
                Publisher = publisher;
                IssueNumber = issue;
            }

            public override double CalculateLateFee(int daysLate)
            {
                // Magazines: $0.25 per day (lowest fee)
                return daysLate * 0.25;
            }

            public override void DisplayDetails()
            {
                Console.WriteLine($"Magazine: {Title}");
                Console.WriteLine($"  Publisher: {Publisher}");
                Console.WriteLine($"  Issue: #{IssueNumber}");
                Console.WriteLine($"  Available: {IsAvailable}");
            }

            public override string GetCategory()
            {
                return "Periodicals";
            }
        }
    
}
