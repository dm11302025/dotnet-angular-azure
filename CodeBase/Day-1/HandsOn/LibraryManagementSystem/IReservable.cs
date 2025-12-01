namespace LibraryManagementSystem
{
   
        interface IReservable
        {
            Queue<string> ReservationQueue { get; set; }
            void Reserve(string memberName);
            void CancelReservation(string memberName);
        }
    
}
