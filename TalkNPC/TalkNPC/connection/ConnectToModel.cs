using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TalkNPC.connection
{
    public class ConnectToModel
    {
        public string responseString { get; set; }
        public async Task Connection(string Prompt)
        {
            var url = "http://localhost:11434/api/generate";

            var requestData = new
            {
                model = "gemma:2b",
                prompt = Prompt,
                stream = false
            };

            var jsonContent = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    responseString = await response.Content.ReadAsStringAsync();
                   //Console.WriteLine(responseString);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("error:");
                    Console.WriteLine(ex.Message);
                }

                
            }
            
        }
        public async Task ShowResponse()
        {
            Console.WriteLine(responseString);
        }
    }
}