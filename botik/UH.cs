using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace botik
{
    class UH : IUpdateHandler
    {
        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var x = update.Message.Chat;
            var m = update.Message.Text;
            await botClient.SendTextMessageAsync(
                chatId: x.Id,
                text: m,
                replyToMessageId: update.Message.MessageId);
        }
    }
}
