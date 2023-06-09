﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace botik
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient("1669922565:AAGHG0JYNmGXiq-vb09kD9m1FymEl3x0vJk");
            var cts = new CancellationTokenSource();
            botClient.StartReceiving<UpdateHandler>(new ReceiverOptions
            {
                AllowedUpdates = new Telegram.Bot.Types.Enums.UpdateType[]
            {
                Telegram.Bot.Types.Enums.UpdateType.CallbackQuery,
                 Telegram.Bot.Types.Enums.UpdateType.Message
            }
            }, cancellationToken: cts.Token);

            Console.ReadLine();

            cts.Cancel();

            await Task.Delay(500);

            /*int offset = 0;
            while (true)
            {
                var update = await botClient.GetUpdatesAsync(offset);
                ProcessUpdates(update, botClient);
                await Task.Delay(1000);
                offset += update.Length;
            }*/
        }

        public static async void ProcessUpdates(Update[] updates, TelegramBotClient botClient)
        {
            if (updates is not { Length: > 0 })
            {
                return;
            }

            try
            {
                foreach (var update in updates)
                {
                    ///
                    var x = update.Message.Chat;
                    var m = update.Message.Text;
                    await botClient.SendTextMessageAsync(
                        chatId: x.Id,
                        text: m,
                        replyToMessageId: update.Message.MessageId);
                    await Task.Delay(100);
                }
            }
            catch (Exception e)
            {
                //
            }
        }

    }
}
