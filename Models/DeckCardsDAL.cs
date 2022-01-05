using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeckCardsAPI.Models
{
    public class DeckCardsDAL
    {
        public Deck GetCards()
        {
            string url = "https://deckofcardsapi.com/api/deck/new/shuffle";

            //2 We need to create our request 
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //3 If your API needs any kind of login or key, that may go here
            //SWAPI doesn't need anything sp we're good

            //Now we're ready to send off our request and grab the server's response
            //Inside our response, the resulting data lives 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Pull the result into a stream reader which will then give us a string
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //Grab our response string - read to end starts at the top of our file and returns each line
            //until it hits the end. 
            string result = rd.ReadToEnd();

            //Converts JSON string into a person object automatically
            Deck p = JsonConvert.DeserializeObject<Deck>(result);

            //Later we'll convert our string into a model which makes it much easier to use for .net
            return p;
        }

        public DrawCards drawCards(string id)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{id}/draw/?count=5";

            //2 We need to create our request 
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //3 If your API needs any kind of login or key, that may go here
            //SWAPI doesn't need anything sp we're good

            //Now we're ready to send off our request and grab the server's response
            //Inside our response, the resulting data lives 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Pull the result into a stream reader which will then give us a string
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //Grab our response string - read to end starts at the top of our file and returns each line
            //until it hits the end. 
            string result = rd.ReadToEnd();

            //Converts JSON string into a person object automatically
            DrawCards p = JsonConvert.DeserializeObject<DrawCards>(result);

            //Later we'll convert our string into a model which makes it much easier to use for .net
            return p;
        }


    }
}
