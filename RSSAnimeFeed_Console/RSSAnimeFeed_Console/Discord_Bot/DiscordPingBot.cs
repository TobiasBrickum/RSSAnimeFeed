using Discord.WebSocket;
using Discord;
using SimpleFeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using RSSAnimeFeed_Console;

namespace RSSAnimeFeed_Console.Discord_Bot
{
    public class DiscordPingBot
    {

        public DiscordPingBot(List<FeedItem> pingAnimes)
        {

        }

        public Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        /// <summary>
        /// todo create ini config file for bot token and file path ect.
        /// todo diferent path seperator outputs o_O
        /// </summary>
        /// <returns></returns>
        private string GetDiscordToken()
        {
            // C:\Users\User\Desktop\Discord_Anime_Ping_Bot_Token.json.txt
            string seperator = new SaveLoadJsonGeneric<string>().Seperator.ToString();
            string discordTokenFile = @"Discord_Anime_Ping_Bot_Token.json";
            string discordTokenFilePath = @"C:\Users\Shiki\Desktop";
            string discordTokenFileFullPath = discordTokenFilePath + seperator + discordTokenFile;
            SaveLoadJsonGeneric<string> svDiscordToken = new SaveLoadJsonGeneric<string>(discordTokenFile, discordTokenFilePath, discordTokenFileFullPath);
            //svDiscordToken.LoadJson("TestValue");
            return svDiscordToken.LoadJson();
        }

        public async void ConnectDiscordBot()
        {
            DiscordSocketClient _client = new DiscordSocketClient();
            _client.Log += Log;

            //  You can assign your bot token to a string, and pass that in to connect.
            //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
            //var token = "token";

            // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

            await _client.LoginAsync(TokenType.Bot, GetDiscordToken());
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }


    }
}
