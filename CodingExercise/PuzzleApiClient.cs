using System;
using RestSharp;
using System.Configuration;

namespace CodingExercise
{
    class PuzzleApiClient
    {
        // Upload the answer to Agile Bridge's RESTful API
        // The REST endpoint is hosted here:
        // http://ab-coding-puzzle-api.azurewebsites.net/api/puzzle
        //
        // Documentation can be found here:
        // http://ab-coding-puzzle-api.azurewebsites.net/swagger

        //Gets the url of the web service
        private static string PuzzleApiUrl
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["PuzzleApiUrl"]);
            }
        }

        //Name of the endpoint to upload the puzzle answer to
        private const string resource = @"api/puzzle";
         
        //To upload the puzzel result we wil use RestSharp. It's a rest client that I have worked with previously

        /// <summary>
        /// Uploads the puzzel answer to the Agile Bridge Puzzel endpoint
        /// </summary>
        /// <param name="puzzleAnswer">Your Puzzel answer</param>
        /// <param name="email">Your email address</param>
        public static void Upload(string puzzleAnswer, string email)
        {
            Console.WriteLine("Upload the puzzle answer [{0}] from [{1}]", puzzleAnswer, email);

            RestClient client = GetRestClient();

            RestRequest postRequest = new RestRequest(resource, Method.POST);
            postRequest.RequestFormat = DataFormat.Json;
            postRequest.AddParameter("Email",email);
            postRequest.AddParameter("PuzzleAnswer",puzzleAnswer);

            var postResult = client.Execute<PuzzelPostResult>(postRequest);

            if (postResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(postResult.Data.Message);
            }
            else
            {
                Console.WriteLine("Something Went wrong:");
                Console.WriteLine(postResult.ErrorMessage);
            }
        }



        //Creates a new rest client for us to use. Can add custom logic in here to configure the client
        private static RestClient GetRestClient()
        { 
            RestClient client = new RestClient(PuzzleApiUrl);
            
            return client;
        }
    }

    //Helper class for RestSharp response reserialization
    public class PuzzelPostResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}