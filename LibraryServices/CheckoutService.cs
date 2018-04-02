﻿using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryServices
{
    public class CheckoutService : ICheckout
    {
        private LibraryContext _context;
        public CheckoutService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(Checkout newCheckout)
        {
            _context.Add(newCheckout);
            _context.SaveChanges();
        }

        public void CheckInItem(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }

        public void CheckOutItem(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Checkout> GetAll()
        {
            throw new NotImplementedException();
        }

        public Checkout GetById(int checkoutId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int id)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentHoldPatronName(int id)
        {
            throw new NotImplementedException();
        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            throw new NotImplementedException();
        }

        public void MarkFound(int assetId)
        {
            throw new NotImplementedException();
        }

        public void MarkLost(int assetId)
        {
            throw new NotImplementedException();
        }

        public void PlaceHold(int assetId, int libaryCardId)
        {
            throw new NotImplementedException();
        }
    }
}