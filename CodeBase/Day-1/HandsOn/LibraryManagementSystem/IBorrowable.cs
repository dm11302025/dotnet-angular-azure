    namespace LibraryManagementSystem
    {
        // INTERFACE - Contract that defines what a class must do
        interface IBorrowable
        {
            int BorrowDurationDays { get; set; }
            DateTime DueDate { get; set; }
            void Borrow(string memberName);
            void Return();
        }
    }
