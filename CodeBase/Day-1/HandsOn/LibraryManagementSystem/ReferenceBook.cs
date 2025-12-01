

    namespace LibraryManagementSystem
    {
        // Sealed class - Cannot be inherited
        sealed class ReferenceBook : Book
        {
            public bool IsReferenceOnly { get; set; }

            public ReferenceBook(string title, string id, string author, string isbn, int pages)
                : base(title, id, author, isbn, pages)
            {
                IsReferenceOnly = true;
                BorrowDurationDays = 0; // Cannot be borrowed
            }

            public override void DisplayDetails()
            {
                base.DisplayDetails();
                Console.WriteLine($"  Reference Only: {IsReferenceOnly}");
            }
        }
    }

