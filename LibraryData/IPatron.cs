using LibraryData.Models;
using System.Collections.Generic;

namespace LibraryData
{
    public interface IPatron
    {     
        IEnumerable<Checkout> GetCheckouts(int patronId);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId);
        IEnumerable<Hold> GetHolds(int patronId);        
        IEnumerable<Patron> GetAll();

        Patron Get(int Id);

        void Add(Patron newPatron);



    }
}
