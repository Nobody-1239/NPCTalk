using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TalkNPC.connection
{
    public class Story
    {
        private string StoryForModel()
        {
            return "You are an AI assistant helping solve a fictional murder mystery.\r\n\r\nHere is the case:\r\n\r\nDaniel Carter, a wealthy tech entrepreneur, was found dead in his study last night — killed by a single blow to the head.\r\n\r\nOnly three people were in the house at the time:\r\n- Emily: his wife\r\n- Thomas: the housekeeper\r\n- Claire: an old friend invited for dinner\r\n\r\nYour role is to simulate conversations with each of these characters: Emily, Thomas, and Claire. \r\nEach character should respond in the first person and remain in character. \r\nOnly answer as one character at a time, based on the user's question. \r\nDo not break character unless explicitly asked to.\r\n\r\nWait for a question to begin the interrogation.\r\n";
        }
        public async Task Start()
        {
            ConnectToModel connectToModel = new ConnectToModel();
            await connectToModel.Connection(StoryForModel());
            Console.WriteLine("game started");
        }
    }
}
