using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryData
{
    public interface ICheckout
    {
       
        Checkout GetById(int checkoutId);
        Checkout GetLatestCheckout(int assetId);

        DateTime GetCurrentHoldPlaced(int id);

        IEnumerable<Checkout> GetAll();
        IEnumerable<Hold> GetCurrentHolds(int id);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);

        string GetCurrentCheckoutPatron(int assetId);       
        string GetCurrentHoldPatronName(int id);    


        void Add(Checkout newCheckout);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assetId, int libraryCardId);
        void PlaceHold(int assetId, int libaryCardId);
        void MarkLost(int assetId);
        void MarkFound(int assetId);








    }
}
