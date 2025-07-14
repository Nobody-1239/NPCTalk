using TalkNPC.connection;
using TalkNPC.Prompet;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("---------write <start> to start---------------------------");
        Console.WriteLine("---------interrogation of [name]------------------------");
        Console.WriteLine("---------write <list> to show persons----------------------");
        Console.WriteLine("---------write the name of the murderer to exit---------");
        Console.WriteLine("---------write <bye> to finish conversation--------------");

        Story connection = new Story();

        while (true)
        {
            string answer = Console.ReadLine().ToLower();

            switch (answer)
            {
                case "start":
                    Console.WriteLine("\nDaniel Carter, a wealthy tech entrepreneur, was found dead in his study last night—killed by a single blow to the head.\n" +
                       "Only three people were in the house at the time:\n" +
                       "Emily: his wife\nThomas: the housekeeper\nClaire: an old friend invited for dinner\n" +
                       "Find the murderer.");
                    await connection.Start();
                    break;

                case "murderer":
                    Console.WriteLine("congratulations you found murderer");
                    break;

                case "list":
                    Console.WriteLine("wife");
                    Console.WriteLine("housekeeper");
                    Console.WriteLine("friend");
                    break;

                case "wife":
                    Console.WriteLine("ask your question from Emily");
                    Wife wife = null;
                    while (true)
                    {
                        var WifeQuestion = Console.ReadLine();
                        if (WifeQuestion.ToLower() == "bye") break;
                        wife = new Wife(WifeQuestion);
                        wife.Promp();
                    }
                    break;

                case "housekeeper":
                    Console.WriteLine("ask your question from Thomas");
                    Servant servant = null;
                    while (true)
                    {
                        var ServantQuestion = Console.ReadLine();
                        if (ServantQuestion.ToLower() == "bye") break;
                        servant = new Servant(ServantQuestion);

                    }
                    break;

                case "friend":
                    Console.WriteLine("ask your question from Claire");
                    Friend friend = null;
                    while (true)
                    {
                        var FriendQuestion = Console.ReadLine();
                        if (FriendQuestion.ToLower() == "bye") break;
                        friend = new Friend(FriendQuestion);
                        friend.Promp();
                    }
                    break;

                case "bye":
                    Console.WriteLine("Conversation ended.");
                    return;

                default:
                    Console.WriteLine("Unknown command. Try again.");
                    break;
            }
        }
    }
}
