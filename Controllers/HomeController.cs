using DeckCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DeckCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        DeckCardsDAL deckDAL = new DeckCardsDAL();

        public IActionResult Index()
        {
            Deck deck = new Deck();
            deck = deckDAL.GetCards();
            DrawCards d = new DrawCards();
            d = deckDAL.drawCards(deck.deck_id);
            return View(d);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
