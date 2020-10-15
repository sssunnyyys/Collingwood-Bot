using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace DrVonZeloncaBot
{
    class Program
    {
        private DiscordSocketClient _client;

        static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.MessageReceived += CommandHandler;
    
            _client.Log += Log;

            //  You can assign your bot token to a string, and pass that in to connect.
            //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
            var token = File.ReadAllText("token.txt");

            // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

       

        

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandHandler(SocketMessage message)
        {
            //variables
            string command = "";
            int lengthOfCommand = -1;
            var random = new Random();
            var list = new List<string> { "fuck", "shit", "piss off", "dick head", "asshole", "son of a bitch", "bastard", "bitch", "frik", "cock", "anal cavity"};
            int index = random.Next(list.Count);
            string name = Console.ReadLine();
            //filtering messages begin here
            if (!message.Content.StartsWith('!')) //This is your prefix
                return Task.CompletedTask;


            if (message.Content.Contains(' '))
                lengthOfCommand = message.Content.IndexOf(' ');
            else
                lengthOfCommand = message.Content.Length;

            command = message.Content.Substring(1, lengthOfCommand - 1).ToLower();

            //Commands begin here
            if (command.Equals("hello"))
            {
                message.Channel.SendMessageAsync($@"Hello {message.Author.Mention} u r geh");
            }
            else if (command.Equals("gay"))
            {
                message.Channel.SendMessageAsync($@"{message.Author.Mention} y r u gey https://www.youtube.com/watch?v=4Q4O5ztz92o");
            }
            //embarass
            else if (command.Equals("embarrassamirit"))
            {
                message.Channel.SendMessageAsync("Amirit deleted his entire phone so his mom won’t see a few messages");
            }
            else if (command.Equals("embarrasssoefae"))
            {
                message.Channel.SendMessageAsync("Soefae is proculsexual");
            }
            else if (command.Equals("embarrasskelvin"))
            {
                message.Channel.SendMessageAsync("Kelvin once said he is bisexual");
            }
            else if (command.Equals("embarrasssunny"))
            {
                message.Channel.SendMessageAsync();
            }
            else if (command.Equals("embarrasshudson"))
            {
                message.Channel.SendMessageAsync("Hudson is a pathological liar");
            }
            else if (command.Equals("embarrassmaggie"))
            {
                message.Channel.SendMessageAsync("Maggie twerks on the field");
            }
            //end
            else if (command.Equals("swear")) 
            {
                message.Channel.SendMessageAsync(list[index]);
                message.Channel.SendMessageAsync($@"{message.Author.Mention}");
                
            }

            
            else if (command.Equals($@"pp {name}"))
            {
                message.Channel.SendMessageAsync($@"{name} is 99%");
                
            }


            return Task.CompletedTask;
        }

        



    }


}
