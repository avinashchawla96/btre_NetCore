﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using btre.Models;

namespace btre.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IListingRepository _listingRepository;

        public HomeController(ILogger<HomeController> logger, IListingRepository listingRepository)
        {
            _logger = logger;
            _listingRepository = listingRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Current = "Index";
            var listings = await _listingRepository.GetTop3Listing();
            return View(listings);
        }

        public IActionResult About()
        {
            ViewBag.Current = "About";
            return View();
        }

        public async Task<IActionResult> Listings()
        {
            ViewBag.Current = "Listings";
            var listings = await _listingRepository.GetListings();
            return View(listings);
        }

        public async Task<IActionResult> Listing(int id)
        {
            var listing = await _listingRepository.GetListing(id);
            return View(listing);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
