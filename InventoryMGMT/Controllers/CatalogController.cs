﻿using InventoryMGMT.Models.Catalog;
using InventoryMGMT.Models.CheckoutModels;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InventoryMGMT.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAsset _assets;
        private ICheckout _checkouts;
        public CatalogController(ILibraryAsset assets, ICheckout checkouts)
        {

            _assets = assets;
            _checkouts = checkouts;


        }

        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();
            var listingResult = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    AuthorOrDirector = _assets.GetAuthorOrDirector(result.Id),
                    DeweyCallNumber = _assets.GetDeweyIndex(result.Id),
                    Title = result.Title,
                    Type = _assets.GetTitle(result.Id)


                });
            var model = new AssetIndexModel()
            {


                Assets = listingResult
            };

            return View(model);

        }


        public IActionResult Detail(int id)
        {
            var asset = _assets.GetById(id);
            var currentHolds = _checkouts.GetCurrentHolds(id)
                .Select(a => new AssetHoldModel {
                    HoldPlaced = _checkouts.GetCurrentHoldPlaced(a.Id),
                    PatronName = _checkouts.GetCurrentHoldPatronName(id)

                });
            var model = new AssetDetailModel
            {
                AssetId = id,
                Title = asset.Title,
                Type = _assets.GetType(id),
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirector(id),
                CurrentLocation = _assets.GetCurrentLocation(id).Name,
                DeweyCallNumber = _assets.GetIsbn(id),
                CheckoutHistory = _checkouts.GetCheckoutHistory(id),
                ISBN = _assets.GetIsbn(id),
                LatestCheckout = _checkouts.GetLatestCheckout(id),
                PatronName = _checkouts.GetCurrentCheckoutPatron(id),
                CurrentHolds = currentHolds



            };
            return View(model);
        }


        public IActionResult Checkout(int id)
        {
            var asset = _assets.GetById(id);

            var model = new CheckoutModel
            {
                AssetId = id,
                ImageUrl = asset.ImageUrl,
                Title = asset.Title,
                LibraryCardId = "",
                IsCheckedOut = _checkouts.IsCheckedOut(id)


            };

            return View(model);

        }


        public IActionResult Checkin(int assetId)
        {
            _checkouts.CheckInItem(assetId);
            return RedirectToAction("Detail", new { id = assetId });


        }


        public IActionResult MarkLost(int assetId)
        {
            _checkouts.MarkLost(assetId);

            return RedirectToAction("Detail", new { id = assetId });

        }

        public IActionResult Hold(int id)
        {
            var asset = _assets.GetById(id);

            var model = new CheckoutModel
            {
                AssetId = id,
                ImageUrl = asset.ImageUrl,
                Title = asset.Title,
                LibraryCardId = "",
                IsCheckedOut = _checkouts.IsCheckedOut(id),
                holdCount=_checkouts.GetCurrentHolds(id).Count()


            };

            return View(model);
        }

        public IActionResult MarkFound(int assetId)
        {
            _checkouts.MarkFound(assetId);

            return RedirectToAction("Detail", new { id = assetId });

        }

        [HttpPost]
        public IActionResult PlaceCheckout(int assetId, int libraryCardId)
        {
            _checkouts.CheckOutItem(assetId, libraryCardId);
            return RedirectToAction("Detail", new { id=assetId});

        }

        

        [HttpPost]
        public IActionResult PlaceHold(int assetId, int libraryCardId)
        {
            _checkouts.PlaceHold(assetId, libraryCardId);
            return RedirectToAction("Detail", new { id = assetId });

        }


    }
}