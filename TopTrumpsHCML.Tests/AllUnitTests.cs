using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopTrumpsHCML.Controllers;
using TopTrumpsHCML.Models;

namespace TopTrumpsHCML.Tests
{
    [TestClass]
    public class AllUnitTests
    {
        [TestMethod]
        public void TestIndexPage()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestShuffle()
        {
            //arrange
            CardViewModel card1 = new CardViewModel
            {
                Credits = "100",
                Films = "2",
                Crew = "1",
                Manufacturer = "BMW",
                Model = "1 Series",
                Pilot = "1",
                Ratings = "34",
                Speed = "1000"
            };

            CardViewModel card2 = new CardViewModel
            {
                Credits = "100",
                Films = "2",
                Crew = "1",
                Manufacturer = "BMW",
                Model = "1 Series",
                Pilot = "1",
                Ratings = "34",
                Speed = "1000"
            };


            CardViewModel card3 = new CardViewModel
            {
                Credits = "100",
                Films = "2",
                Crew = "1",
                Manufacturer = "BMW",
                Model = "1 Series",
                Pilot = "1",
                Ratings = "34",
                Speed = "1000"
            };


            CardViewModel card4 = new CardViewModel
            {
                Credits = "100",
                Films = "2",
                Crew = "1",
                Manufacturer = "BMW",
                Model = "1 Series",
                Pilot = "1",
                Ratings = "34",
                Speed = "1000"
            };

            CardViewModel card5 = new CardViewModel
            {
                Credits = "100",
                Films = "2",
                Crew = "1",
                Manufacturer = "BMW",
                Model = "1 Series",
                Pilot = "1",
                Ratings = "34",
                Speed = "1000"
            };

            var cardDeck = new List<CardViewModel>();

            cardDeck.Add(card1);
            cardDeck.Add(card2);
            cardDeck.Add(card3);
            cardDeck.Add(card4);
            cardDeck.Add(card5);

            //act
            var newSufffledCard = ShuffleCards(cardDeck);

            //assert
            CollectionAssert.AreNotEqual(newSufffledCard.ToList(), cardDeck);
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
