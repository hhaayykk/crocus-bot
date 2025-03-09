using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient("TOKEN");

using var cts = new CancellationTokenSource();

var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { }
};

botClient.StartReceiving(
    HandleUpdatesAsync,
    HandleErrorAsync,
    receiverOptions,
    cancellationToken: cts.Token);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Conected @{me.Username}");
Console.ReadLine();

cts.Cancel();

async Task HandleUpdatesAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Type == UpdateType.Message && update?.Message?.Text != null)
    {
        await HandleMessage(botClient, update.Message);
        return;
    }

    if (update.Type == UpdateType.CallbackQuery)
    {
        await HandleCallbackQuery(botClient, update.CallbackQuery);
        return;
    }
}

async Task HandleMessage(ITelegramBotClient botClient, Message message)
{

    if (message.Text == "/start")
    {
        ReplyKeyboardMarkup keyboard = new(new[]
        {
            new KeyboardButton[] { "📝 FAQ", "🔍 Other", },

        })
        {
            ResizeKeyboard = true
        };
        await botClient.SendPhotoAsync(message.Chat.Id, photo: "https://drive.google.com/file/d/1tNm1j35OfuBuMKCongz7ojsbEAWwwLAZ/view?usp=sharing",
            caption: "Hello, I'm a bot of Crocus Ltd. Check out the commands - /help ", replyMarkup: keyboard);
        return;
    }

    if (message.Text == "🔍 Other")
    {

        ReplyKeyboardMarkup keyboard = new(new[]
{
            new KeyboardButton[] { "🗞 NEWS", "⚙️ ABOUT", },
            new KeyboardButton[] { "👥 SUPPORT", "🖌 BRANDING", },
            new KeyboardButton[] { "📲 CROCUS APP", "🖥 COLLABORATION", },
            new KeyboardButton[] { "❌ cancel", }

        })
        {
            ResizeKeyboard = true
        };
        await botClient.SendPhotoAsync(message.Chat.Id, photo: "https://drive.google.com/file/d/1tNm1j35OfuBuMKCongz7ojsbEAWwwLAZ/view?usp=sharing",
            caption: "Hello, I'm a bot of Crocus Ltd. Check out the commands - /help ", replyMarkup: keyboard);
        return;
    }

    if (message.Text == "📝 FAQ")
    {

            ReplyKeyboardMarkup keyboard = new(new[]
            {

            new KeyboardButton[] { "💻Registration", "💸Investment", },
            new KeyboardButton[] { "👥Partners Program", },
            new KeyboardButton[] { "💳Withdrawal", "🌐Client support", },
            new KeyboardButton[] { "❌ cancel", },

        })
            {
                ResizeKeyboard = true
            };
            await botClient.SendPhotoAsync(message.Chat.Id, photo: "https://drive.google.com/file/d/11BgiSY_blA1udmiDFpnYIw6mH8L28_OO/view?usp=sharing", replyMarkup: keyboard);
            return;
        
    }

    //հարցեր https://drive.google.com/file/d/1J_Vp4nkMbp_eHxY7CE-FciGilNFc4ZqQ/view?usp=sharing
    if (message.Text == "💻Registration")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "/1th Can I start working with CROCUS as an investor ?\n/2nd Is it possible to join CROCUS if I am under 18 years old?\n" +
            "/3rd Is it possible to create more than one account from one computer for all members of my family?\n" +
            "/4th Do I need to enter any personal information in my account on your site?");
        return;
    }
    if (message.Text == "💸Investment")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "/5th How much income can I get with CROCUS?\n/6th How do I earn on CROCUS investment plans?\n" +
            "/7th What payment systems can I use to fund my CROCUS account?\n" +
            "/8th How often will I receive interest on my CROCUS deposits?\n" +
            "/9th Are there any limits on the investment amount in CROCUS?");
        return;
    }
    if (message.Text == "👥Partners Program")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "/10th How do I earn money with CROCUS?\n" +
            "/11th Can I earn in CROCUS without my own deposit?");
        return;
    }
    if (message.Text == "💳Withdrawal")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "/12th How long does it take to withdraw the profit to my wallet?\n" +
            "/13th How do I withdraw funds from my personal wallet?\n/14th What payment system can I use to withdraw my profit? Can I choose one?\n" +
            "/15th What is the minimum withdrawal amount? Are there any limits on number of withdrawals or sums per day?");
        return;
    }
    if (message.Text == "🌐Client support")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "/16th I can’t log in to CROCUS, what should I do?\n" +
            "/17th I can’t remember my password. How do I recover it?\n/18th I did not find an answer to my question here. What should I do?");
        return;
    }
    if (message.Text == "/1th")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "Can I start working with CROCUS as an investor?\n\nBefore you begin working with us, " +
            "please read the Agreement of the Parties and if you accept it, you must register on our website and create an account in the CROCUS system.");
        return;
    }
    if (message.Text == "/2nd")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "Is it possible to join CROCUS if I am under 18 years old?\n\nYou can earn money in CROCUS " +
            "if you are over the age of majority in your country of residence.");
        return;
    }
    if (message.Text == "/3rd")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "Is it possible to create more than one account from one computer for all members of my family?\n\n" +
            "You can create only 1 account from one computer. If you create more than one account, CROCUS has the right to block them with further penalties.");
        return;
    }
    if (message.Text == "/4th")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "Do I need to enter any personal information in my account on your site?\n\n" +
            "You don’t need to enter any personal data. All you need to do is to enter the number of the wallet, where your funds will be withdrawn from your balance in your personal CROCUS account.");
        return;
    }
    if (message.Text == "/5th")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "How much income can I get with CROCUS?\n\nOur investment plans are presented on the Investors page of the CROCUS website. Your income depends " +
            "only on the amount you have invested and the number of affiliate partners you have attracted.");
        return;
    }
    if (message.Text == "/6th")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "How do I earn on CROCUS investment plans?\n\n" +
            "The CROCUS Company has a floating earning system with a guaranteed annual return.\nYou can read more on our Investors page.Please note that you can create any number of investment plans at the same time.");
        return;
    }
    if (message.Text == "/7th")
    {

        await botClient.SendTextMessageAsync(message.Chat.Id, "What payment systems can I use to fund my CROCUS account?\n\n" +
            "Now you can fund your account using various payment systems such as Bitcoin, Etherium, Litecoin, Tether ERC20, " +
            "TetherTRC20, etc. You can find more information about all payment systems in your personal account.");
        return;
    }
    if (message.Text == "/8th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "How often will I receive interest on my CROCUS deposits?\n\n" +
            "Interest is paid according to the conditions of the investment offer. But not earlier than 24 hours after opening a deposit in the system.");
        return;
    }
    if (message.Text == "/9th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "Are there any limits on the investment amount in CROCUS?\n\n" +
            "The minimum amount of investment in our company is 100 USD.\nThe maximum amount of investment in our company is 9999 USD.");
        return;
    }
    if (message.Text == "/10th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "How do I earn money with CROCUS?\n\n" +
            "There are several ways for users to earn: by opening a deposit on a chosen investment plan, by " +
            "receiving affiliate commissions from attracting new partners, and by participating in one or more programs." +
            "\nIn this case we have a multi - level affiliate program.You can also find programs such as: “Office Program”, “Bount Program” and others.");
        return;
    }
    if (message.Text == "/11th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "Can I earn in CROCUS without my own deposit?\n\n" +
            "Yes, there is no need to have your own deposit to start referring new affiliates.");
        return;
    }
    if (message.Text == "/12th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "How long does it take to withdraw the profit to my wallet?\n\n" +
            "It takes 3-5 business days from the time of ordering the payment.");
        return;
    }
    if (message.Text == "/13th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "How do I withdraw funds from my personal wallet?\n\n" +
            "At first carefully check your account wallet, which you want to withdraw money from, it must be registered in" +
            " your account. If you do not register a wallet you have to do it in the section “Payment details” in your account. " +
            "After that, you can order a payment through an automated payment system CROCUS.");
        return;
    }
    if (message.Text == "/14th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "What payment system can I use to withdraw my profit? Can I choose one?\n\n" +
            "You can use only that payment system which you used for making a deposit.");
        return;
    }
    if (message.Text == "/15th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "What is the minimum withdrawal amount? Are there any limits on number of withdrawals or sums per day?\n\n" +
            "The minimum withdrawal amount is $1. There are no limits on the maximum withdrawal amount, as well as on the number of withdrawal operations per day.");
        return;
    }
    if (message.Text == "/16th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "I can’t log in to CROCUS, what should I do?\n\n" +
            "Make sure your information is correct. If everything is OK but registration is still not successful, please contact CROCUS online support.");
        return;
    }
    if (message.Text == "/17th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "I can’t remember my password. How do I recover it?\n\n" +
            "Simply use the “Forgotten your password?” link on the log in page.");
        return;
    }
    if (message.Text == "/18th")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "I did not find an answer to my question here. What should I do?\n\n" +
            "You can contact us through CROCUS online support. Please find the best channel for your message.");
        return;
    }
    /*            new KeyboardButton[] { "🗞 NEWS", "⚙️ ABOUT", },
    new KeyboardButton[] { "👥 SUPPORT", "🖌 BRANDING", },
            new KeyboardButton[] { "📲 CROCUS APP", "🖥 COLLABORATION", },*/

    if (message.Text == "🖥 COLLABORATION")
    {
        InlineKeyboardMarkup keyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Tamyr plan"),
                InlineKeyboardButton.WithCallbackData("🔴 Youtube"),
            },

        });
        await botClient.SendTextMessageAsync(message.Chat.Id, "Creative Association \"Tamyr\" is a promising and incredibly creative animation studio that already " +
            "has a series of well-known collections, such as \"Erkeler\", \"Soz kazynasy\" and others. But for the further development" +
            " of the studio, a strategic investor was needed, which became Crocus. We have already developed a long-term development " +
            "strategy and relying on our technological capabilities and resources, we will realize the huge export potential of Tamyr's products.", replyMarkup: keyboard);
        return;
    }

    if (message.Text == "📲 CROCUS APP")
    {

        await botClient.SendPhotoAsync(message.Chat.Id, photo: "https://drive.google.com/file/d/1cuWh85P2llbbjJ9QYARhu62bkylajpwr/view?usp=sharing",
            caption: "https://play.google.com/store/apps/details?id=com.crocusapp");
        return;
    }

    if (message.Text == "🗞 NEWS")
    {
        InlineKeyboardMarkup keyboard = new(new[]
{
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Subscribe"),
            },

        });
        await botClient.SendTextMessageAsync(message.Chat.Id, "Subscribe to our channel for news", replyMarkup: keyboard);
        return;
    }

    if (message.Text == "⚙️ ABOUT")
    {
        await botClient.SendPhotoAsync(message.Chat.Id, photo: "https://drive.google.com/file/d/1dtnJI_1Mxetiog_yyrrwUyjS_e2TXMzj/view?usp=sharing",
    caption: "CHECK COMPANY REGISTRATION DATA Revolutionary changes are now taking place in all areas, the concept of geographical boundaries is constantly blurred. A well - thought -out strategic vision helps set long - term directions and clearly define intentions in any business area.\n" +
            "The main direction of CROCUS is the development, as well as increasing the volume and number of existing mining farms that are operating at full capacity.");
        return;
    }
    if (message.Text == "👥 SUPPORT")
    {
        await botClient.SendTextMessageAsync(message.Chat.Id, "Support service - support@crocus.cc\n\n" +
            "General issues - info@crocus.cc\n\nAffiliate questions - partner@crocus.cc");
        return;
    }

    if (message.Text == "🖌 BRANDING")
    {
        await botClient.SendPhotoAsync(message.Chat.Id, photo: "https://drive.google.com/file/d/1J_Vp4nkMbp_eHxY7CE-FciGilNFc4ZqQ/view?usp=sharing", 
            caption: "To identify the brand and corporate identity of the company, as well as the implementation of Crocus ground promotion, we have developed " +
            "a competent, information and marketing strategy with an extensive range of advertising tools.\n\n" +
            "https://crocus.cc/branding");
        return;
    }

    if (message.Text == "❌ cancel")
    {
        ReplyKeyboardMarkup keyboard = new(new[]
        {
            new KeyboardButton[] { "📝 FAQ", "🔍 Other", },

        })
        {
            ResizeKeyboard = true
        };
        await botClient.SendPhotoAsync(message.Chat.Id, photo: "https://drive.google.com/file/d/11BgiSY_blA1udmiDFpnYIw6mH8L28_OO/view?usp=sharing", replyMarkup: keyboard);
        return;
    }

    //await botClient.SendTextMessageAsync(message.Chat.Id, $"Not founded:\n{message.Text}");
}

//ստեղ են բոլոր մինի կնոպկեքը
async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
{

    if (callbackQuery.Data.StartsWith("Tamyr plan"))
    {
        await botClient.SendTextMessageAsync(
            callbackQuery.Message.Chat.Id,
            $"NEW!!!\n\nStartup-plan \"TAMYR\"\n11.66 %\nMonthly, for 180 days\n\n" +
            $"https://crocus.cc/collaboration"
        );
        return;
    }


    if (callbackQuery.Data.StartsWith("🔴 Youtube"))
    {
        await botClient.SendTextMessageAsync(
            callbackQuery.Message.Chat.Id,
            $"https://www.youtube.com/watch?v=P2m8XU1w7Xc"
        );
        return;
    }

    if (callbackQuery.Data.StartsWith("Subscribe"))
    {
        await botClient.SendTextMessageAsync(
            callbackQuery.Message.Chat.Id,
            $"https://t.me/crocusinfo"
        );
        return;
    }

    await botClient.SendTextMessageAsync(
    callbackQuery.Message.Chat.Id,
    $"You choose with data: {callbackQuery.Data}"
    );
    return;
}

Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"error\n{apiRequestException.ErrorCode}\n{apiRequestException.Message}",
        _ => exception.ToString()
    };
    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}
