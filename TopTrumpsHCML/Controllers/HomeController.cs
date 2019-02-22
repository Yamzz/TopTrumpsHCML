using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TopTrumpsHCML.Entities;
using TopTrumpsHCML.Mappings;
using TopTrumpsHCML.Models;
using TopTrumpsHCML.Utilities;

namespace TopTrumpsHCML.Controllers
{
    public class HomeController : Controller
    {
        private CardMapper mCardMapper;

        public HomeController()
        {
            mCardMapper = new CardMapper(); 
        }

        public ActionResult Index() => View("Index");

        [HttpGet]
        public JsonResult StartGame(string firstPlayer)
        {
            IEnumerable<CardViewModel> cards = new List<CardViewModel>(); 
            try
            {
                using (var startWarsApi = new StarWarsApiCore())
                {
                    var starShips = startWarsApi.GetAllStarships();
                    cards = ShuffleCards(GetGameCards(starShips));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Json(cards, JsonRequestBehavior.AllowGet);
        }


        private IEnumerable<CardViewModel> GetGameCards(SharpEntityResults<Starship> sharpEntityResults)
        {
            var allStarShips = sharpEntityResults.results
                                   .Select(cdvm => cdvm);
            var allCardViewModels = mCardMapper.MapEntityToViewModel_List(allStarShips);
            return allCardViewModels; 
        }

        private IEnumerable<CardViewModel> ShuffleCards(IEnumerable<CardViewModel> cardDeck)
        {
            var randomNumber = new Random();
            var shuffledCardDeck = cardDeck.ToArray();
            for (int firstCard = 0; firstCard < cardDeck.Count(); firstCard++)
            {
                int second = randomNumber.Next(cardDeck.Count());
                CardViewModel temp = shuffledCardDeck[firstCard];
                shuffledCardDeck[firstCard] = shuffledCardDeck[second];
                shuffledCardDeck[second] = temp;
            }
            return shuffledCardDeck;
        }



    }
}