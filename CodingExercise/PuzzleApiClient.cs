using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CodingExercise
{
    internal class PuzzleApiClient
    {
        // Upload the answer to Agile Bridge's RESTful API
        // The REST endpoint is hosted here:
        // http://ab-coding-puzzle-api.azurewebsites.net/api/puzzle
        //
        // Documentation can be found here:
        // http://ab-coding-puzzle-api.azurewebsites.net/swagger

        public static void Upload(string puzzleAnswer, string email)
        {
            var data = new MyPuzzleAnswer { Email = email, PuzzleAnswer = puzzleAnswer };
            Uri codePuzzleUri = new Uri("http://ab-coding-puzzle-api.azurewebsites.net/api/puzzle");

            Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));

            POSTResponse(codePuzzleUri, data);

        }

        private static void POSTResponse(Uri codePuzzleUri, MyPuzzleAnswer data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = codePuzzleUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PostAsJsonAsync(codePuzzleUri, data);

                Console.WriteLine(response.Result);
            }
        }
    }

    class MyPuzzleAnswer
    {
        public string Email { get; set; }
        public string PuzzleAnswer { get; set; }

    }
}