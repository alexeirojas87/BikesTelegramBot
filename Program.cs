using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace BotBikeReputationTelegram
{
    class Program
    {
        private static readonly TelegramBotClient bot = new TelegramBotClient("1083112357:AAGjNk4XfLkPX-DPKU47cNc6KSDSsjGm9X8");
        static void Main(string[] args)
        {
            var me = bot.GetMeAsync().Result;
            Console.Title = "Conectado a bot de Telegram " + me.Username;
            bot.OnMessage += BikeReputationbotmessage;

            bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"Escuchando mensajes de @{me.Username}");

            //Si se pulsa INTRO en la consola se detiene la escucha de mensajes
            Console.ReadLine();
            bot.StopReceiving();
        }

        private static void BikeReputationbotmessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Text)
                PrepareQuestionnaires(e);
        }
        public static void PrepareQuestionnaires(MessageEventArgs e)
        {
            bot.SendTextMessageAsync(e.Message.Chat.Id, "hello "+e.Message.Chat.Username + Environment.NewLine + 
                "Bienvenido al boot de reputacion de vendedores de bicicletas." + Environment.NewLine + 
                "Delfina estas apretando con los precios ?");
        }
    }

}
