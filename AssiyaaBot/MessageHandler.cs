using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace AssiyaaBot
{
    public class MessageHandler
    {
        private readonly ITelegramBotClient _botClient;
        //private readonly ApplicationDbContext _dbContext;

        public MessageHandler(ITelegramBotClient botClient)
        {
            _botClient = botClient;
           
        }

        private ReplyKeyboardMarkup GetStartActionDisplayKeyboard()
        {
            var keyboardButtonsRow1 = new KeyboardButton[]
            {
                new KeyboardButton("Фотографии"),
                new KeyboardButton("Аудио"),
            };

            var keyboardButtonsRow2 = new KeyboardButton[]
            {
                new KeyboardButton("Милашества от меня \u2764"),
                new KeyboardButton("История этого бота!")
            };

            var rkhm = new ReplyKeyboardMarkup();

            rkhm.Keyboard = new KeyboardButton[][]
            {
                keyboardButtonsRow1,
                keyboardButtonsRow2
            };

            return rkhm;
        }

        private ReplyKeyboardMarkup GetPrettiesKeyboardDisplay()
        {
            var keyboardButtonsRow1 = new KeyboardButton[]
            {
                new KeyboardButton("Текст любви"),
                new KeyboardButton("Милая история"),
            };

            var keyboardButtonsRow2 = new KeyboardButton[]
            {
                new KeyboardButton("Если поругались!")                
            };

            var keyboardButtonsRow3 = new KeyboardButton[]
            {
                new KeyboardButton("У меня фантазия \nзакончилась(")
            };
            var keyboardButtonsRow4 = new KeyboardButton[]
           {
                new KeyboardButton("Назад")
           };

            var rkhm = new ReplyKeyboardMarkup();

            rkhm.Keyboard = new KeyboardButton[][]
            {
                keyboardButtonsRow1,
                keyboardButtonsRow2,
                keyboardButtonsRow3,
                keyboardButtonsRow4
            };

            return rkhm;
        }


        private ReplyKeyboardMarkup GetPhotosKeyboardDisplay()
        {
            var keyboardButtonsRow1 = new KeyboardButton[]
            {
                new KeyboardButton("Фотка моей \nбезграничной любви")
            };

            var keyboardButtonsRow2 = new KeyboardButton[]
            {
                new KeyboardButton("Фотка ч*ена, \nчто бы не забывала!")
            };

            var keyboardButtonsRow3 = new KeyboardButton[]
            {
                new KeyboardButton("То, куда мы \nдолжны стремиться")
            };

            var keyboardButtonsRow4 = new KeyboardButton[]
            {
                new KeyboardButton("Фотка угар")
            };

            var keyboardButtonsRow5 = new KeyboardButton[]
            {
                new KeyboardButton("Назад")
            };

            var rkhm = new ReplyKeyboardMarkup();

            rkhm.Keyboard = new KeyboardButton[][]
            {
                keyboardButtonsRow1,
                keyboardButtonsRow2,
                keyboardButtonsRow3,
                keyboardButtonsRow4,
                keyboardButtonsRow5
            };

            return rkhm;
        }

        private ReplyKeyboardMarkup GetAudiosKeyboardDisplay()
        {
            var keyboardButtonsRow1 = new KeyboardButton[]
            {
                new KeyboardButton("Аудио адын"),
                new KeyboardButton("Аудио два"),
            };

            var keyboardButtonsRow2 = new KeyboardButton[]
            {
                new KeyboardButton("Аудио тли"),
                new KeyboardButton("Назад")
            };

            var rkhm = new ReplyKeyboardMarkup();

            rkhm.Keyboard = new KeyboardButton[][]
            {
                keyboardButtonsRow1,
                keyboardButtonsRow2
            };

            return rkhm;
        }





        public async Task ProcesStartMessage(MessageEventArgs e)
        {
            string topResponseMessage = "Выбери действие";
            var replyKeyboardMarkup = GetStartActionDisplayKeyboard();

            await _botClient.SendTextMessageAsync(e.Message.Chat.Id, topResponseMessage, replyMarkup: replyKeyboardMarkup);
        }

        public async Task PrettiesMessagesStart(MessageEventArgs e)
        {
            string topResponseMessage = "Выбери милашество bitch";
            var replyKeyBoardMarkup = GetPrettiesKeyboardDisplay();

            await _botClient.SendTextMessageAsync(e.Message.Chat.Id, topResponseMessage, replyMarkup: replyKeyBoardMarkup);
        }

        public async Task PhotosMessagesStart(MessageEventArgs e)
        {
            string topResponseMessage = "Выбери фотку любовь";
            var replyKeyBoardMarkup = GetPhotosKeyboardDisplay();

            await _botClient.SendTextMessageAsync(e.Message.Chat.Id, topResponseMessage, replyMarkup: replyKeyBoardMarkup);
        }

        public async Task AudioMessagesStart(MessageEventArgs e)
        {
            string topResponseMessage = "Выбери что ни-будь жаным";
            var replyKeyBoardMarkup = GetAudiosKeyboardDisplay();

            await _botClient.SendTextMessageAsync(e.Message.Chat.Id, topResponseMessage, replyMarkup: replyKeyBoardMarkup);
        }

        public async Task HistoryMessage(MessageEventArgs e)
        {
            Message message = await _botClient.SendTextMessageAsync(
                chatId: e.Message.Chat.Id,
                text: "Этот бот я уже начал задумывать очень давно! Когда ты начала пилить мне мозги про подарок на день рождение :/ \nВ принципе мне понравилось его писать, тем более это все опыт. В дальнейшем если что его можно дорабатывать.\nСамое сложное в разработке бота, было то что как его запустить на сервере. Не буду вдаваться в подробности, но это было не легко. \nНо как всегда, потом все стало просто и ясно. \nЭтот простенький бот как и всего себя я посвящаю тебе, любимая жена!",
                parseMode: ParseMode.Html);
        }

        public async Task SendPrettyFotoMessage(MessageEventArgs e)
        {
            Message message = await _botClient.SendPhotoAsync(
            chatId: e.Message.Chat,
            photo: "https://s206iva.storage.yandex.net/rdisk/9be475edcfa2fe35b038c2e1c5ea8976a4d5b45cab1df327ceba57bf2b257183/5e750e18/yQXUW-T4bM2L-nrKhsj_PC05ltIlQbbnk1uz6cpPzLHiS969bOfGzlNA95ubE0BFyEJrR41Au57bbroS84bQEQ==?uid=83539494&filename=For+bot+image.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&tknv=v2&owner_uid=83539494&fsize=109995&etag=3204b7ee2c2b0da220336808f200e06a&hid=273a6591cc75fa411f0d4051f338b2f3&media_type=image&rtoken=XCVReOBAXQd4&force_default=yes&ycrid=na-8395a9f295f1110a2dd898145747a8b4-downloader22h&ts=5a14d9e4db600&s=fa109ecee78a19e8cd1d5340bd435b2a593e3140c9570062f592b6c52f38d5ca&pb=U2FsdGVkX1_zwD8qsJLpOl8I7tPcMuRHROlhPB7wI8v3_krGp4c6gbCK-S3_3-kufbqiO0hI4oqY16X9VzS9qpIvQB6zZW_lde6VIiohCd4");
        }

        public async Task SendDickFotoMessage(MessageEventArgs e)
        {
            Message message = await _botClient.SendPhotoAsync(
            chatId: e.Message.Chat,
            photo: "https://s91myt.storage.yandex.net/rdisk/a193e1d66d89b55b7c9ebc17321a2d67ecb5871461ff3c271147873301689928/5e750d91/yQXUW-T4bM2L-nrKhsj_PNmmv_bUdEo_J02NBVy6QWjZ4NCJQGCdWacSD0LxrkTCwgpEKoxF6-kRlxlfyDbWMQ==?uid=83539494&filename=For+Bot+image2.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&tknv=v2&owner_uid=83539494&etag=1aa01a99cfc33e63e6facf58f133ae18&media_type=image&fsize=117673&hid=b527ef3af75d005fab3485430536a421&rtoken=SGstj8MmQIpK&force_default=yes&ycrid=na-f8cfbd43461d6881336612b7669b9194-downloader20f&ts=5a14d9641c640&s=8c00237e9f51c4790c7e60d90772511d1220d1d2068ed3b700954177d1ec8403&pb=U2FsdGVkX1892EPtWBMO2W7EDWLQbsm0hkw6zHvDvn-eeeOHRuZX1BmTcdOuuSH_yDd_8ANwDVDXsUGHhofkXsfT4WJd7vqCcFyF7st7lfI");
        }

        public async Task SendFunFotoMessage(MessageEventArgs e)
        {
            Message message = await _botClient.SendPhotoAsync(
            chatId: e.Message.Chat,
            photo: "https://s238vla.storage.yandex.net/rdisk/001cdd4bce2ebe9d70e6eb5cfd593e0c0ac17d62e346c512dfc5fecd2eaefb67/5e750f11/yQXUW-T4bM2L-nrKhsj_PPbOHyrElOBp0msknJ7Lc90Ycmh-fuzPmBQhFM1FwBZLPM9AafNaarW3FjPaNvMjBg==?uid=83539494&filename=For+bot+image3.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&tknv=v2&owner_uid=83539494&etag=84c809169fd32fabba590109673c5bdf&fsize=101317&hid=8bed070e62d2c1ab0a5b45ae06a50b15&media_type=image&rtoken=bNMVUCvRS44f&force_default=yes&ycrid=na-f1df5a5b5a0e0a0f7ebb7583d4c4d6bc-downloader11h&ts=5a14dad252640&s=fc0591e2a7aba232f695b372f14d8ab73d58a08393833b9a7a785357575eec87&pb=U2FsdGVkX1-cEJtsftTXtYCbP7xzMJrj0g5O0Q9T0HrNckFbZAMdrttReIMeIvvPB_WwZG7ssNnmIfueZQ9PHuzrXIs_TaXeSXlQi9nWCNQ");
        }
        public async Task SendDreamFotoMessage(MessageEventArgs e)
        {
            Message message = await _botClient.SendPhotoAsync(
            chatId: e.Message.Chat,
            photo: "https://s287iva.storage.yandex.net/rdisk/35fb95e2f9f25e84333e8572656b6472bfea74c709e839f9ffe3b8794845c146/5e75119f/yQXUW-T4bM2L-nrKhsj_POp7-hEGv_wT1hyk1ZXneBNG3R63i7zdcR3ccGwvdxX3-8FlFwH9hsG1Fnwafg5OPQ==?uid=83539494&filename=new+york+panoram3.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&tknv=v2&owner_uid=83539494&fsize=528012&etag=c225abef7885ba7c1a947510f8b90e85&media_type=image&hid=d3509cfcf57a946b5e97f6539ad9177e&rtoken=Ez3zqc3K8MFG&force_default=yes&ycrid=na-da5b684f5ef3320eceaefee01c59eeea-downloader8e&ts=5a14dd42065c0&s=c52cd71d69c4ff4b21108db9deed8fe4cf19b6dfde7ff06ce4d169e139504fc0&pb=U2FsdGVkX1_XkC855sZ3SPXECD2PQ6DBPQI1CAsVw0A6Ey763A_dTNfZ5w7N4AyLV61A7QyMqHFrpO2k5-kDOKFJV6X_gCvxIr7llos2l5Y");
        }


        public async Task PassPasswordMessage(MessageEventArgs e)
        {
            await _botClient.SendTextMessageAsync(
                e.Message.Chat.Id,
                "Введи пароль! \nПодсказка: мне нравится когда ты мне так говоришь...",
                ParseMode.Html);
        }

        public async Task SendUtiPutiAudioMessageWithId(MessageEventArgs e)
        {
            string audioId = "CQACAgIAAxkBAAIBpF549HtiosQMES-Yz-i76lpIcm_oAAJgBgACBrvJSw3hgnD01_VhGAQ";
            Message message = await _botClient.SendAudioAsync(e.Message.Chat.Id,
                audioId);
        }

        public async Task SendHappyMomentsAudioMessageWithId(MessageEventArgs e)
        {
            string audioId = "CQACAgIAAxkBAAIBoV548_idMM14XarOyz8c7-HjiQLTAAI4BQACF1rJS8dBJryKiUaKGAQ";
            Message message = await _botClient.SendAudioAsync(e.Message.Chat.Id,
                audioId);
        }

        public async Task SendWhenSadAudioMessageWithId(MessageEventArgs e)
        {
            string audioId = "CQACAgIAAxkBAAIBpl549KX6zPjTxsEj5WGbpQQ42bsCAAI5BQACF1rJS6z1PZp77MFMGAQ";
            Message message = await _botClient.SendAudioAsync(e.Message.Chat.Id,
                audioId);
        }

        public async Task SendTextLoveMessage(MessageEventArgs e)
        {
            await _botClient.SendTextMessageAsync(
                e.Message.Chat.Id,
                "Любимая любовь! Так, много уже у нас тобой общего и так \nмного разного, но одно точно общее, это любовь к друг другу! \nГлубинное чувство привязанности, страх потерять, мечты о \nгрядущем, принятие неизбежности и милый зоркий смех твой \nвсе это я к тебе чувствую, получаю и люблю. Разыскивал \nнеустанно я очи твои и очаровательные шалости. Никто из \nживущих не мог заполнить чашу так мне необходимого \nженского начала. Ведь кто если не ты моя Асия скажет мне под \nхолодным покрывалом черной и не приглядной ночи \"Жаным \nя спать\" и ярким светом словно лучи солнца осветит этот мрак!",
                ParseMode.Html);
        }
        public async Task SendTextPrettyMessage(MessageEventArgs e)
        {
            await _botClient.SendTextMessageAsync(
                e.Message.Chat.Id,
                "Все мои милые истории про тебя связаны с тем как как ты мне \nчто то рассказываешь или показываешь))) Как сегодня я утром \nтипа спал а ты хотела перелезть через меня и я схватил твою \nногу))) Или как ты на тренажере сегодня во дворе пыталась что \nто сделать, это все для меня дико мило и все это можешь \nделать только ты. Все эти моменты и истории я буду \nколлекционировать в своей памяти.",
                ParseMode.Html);
        }
        public async Task SendTextFantasyMessage(MessageEventArgs e)
        {
            await _botClient.SendTextMessageAsync(
                e.Message.Chat.Id,
                "Фантазия реально закончилась, все это я пишу наблюдая твой \nтоксикоз и твои мучения, я веру что ты сильная и все это \nпреодолеешь моя ути пути любовь.",
                ParseMode.Html);
        }
        public async Task SendTextIfArgueMessage(MessageEventArgs e)
        {
            await _botClient.SendTextMessageAsync(
                e.Message.Chat.Id,
                "Жаным, как бы мы сильно не поругались или друг друга не \nпонимаем, знай я тебя люблю и прошу прощения. Можешь это \nписьмо каждый раз перечитывать и считать что я извинился и \nподходить ко мне обниматься)",
                ParseMode.Html);
        }



        public async void ProcessMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message.Text;
            
            if (message == "/start")
            {
                var passPassword = PassPasswordMessage(e);
                await passPassword;
            }
            else if (message == "Назад" || message.ToLower() == "бопешечка")
            {
                var processStartMessage = ProcesStartMessage(e);
                await processStartMessage;
            }
            else if (message != null && message.StartsWith("Милашества"))
            {
                var prettiesMessage = PrettiesMessagesStart(e);
                await prettiesMessage;
            }
            else if (message != null && message.StartsWith("Фотографии"))
            {
                var photosMessages = PhotosMessagesStart(e);
                await photosMessages;
            }
            else if(message != null && message == "Аудио")
            {
                var audioMEssages = AudioMessagesStart(e);
                await audioMEssages;
            }
            else if(message != null && message.StartsWith("История"))
            {
                var historyMessage = HistoryMessage(e);
                await historyMessage;
            }
            else if(message != null && message == "Фотка моей \nбезграничной любви")
            {
                var photoMessage = SendPrettyFotoMessage(e);
                await photoMessage;
            }
            else if (message != null && message.EndsWith("забывала!"))
            {
                var photoMessage = SendDickFotoMessage(e);
                await photoMessage;
            }
            else if (message != null && message.StartsWith("То,"))
            {
                var photoMessage = SendDreamFotoMessage(e);
                await photoMessage;
            }
            else if (message != null && message.EndsWith("угар"))
            {
                var photoMessage = SendFunFotoMessage(e);
                await photoMessage;
            }
            else if(message != null && message == "Аудио тли")
            {
                var audioMessage = SendUtiPutiAudioMessageWithId(e);
                await audioMessage;
            }
            else if(message != null && message == "Аудио адын")
            {
                var audioMessage = SendHappyMomentsAudioMessageWithId(e);
                await audioMessage;
            }
            else if (message != null && message == "Аудио два")
            {
                var audioMessage = SendWhenSadAudioMessageWithId(e);
                await audioMessage;
            }
            else if (message != null && message == "Текст любви")
            {
                var textMessage = SendTextLoveMessage(e);
                await textMessage;
            }
            else if (message != null && message == "Милая история")
            {
                var textMessage = SendTextPrettyMessage(e);
                await textMessage;
            }
            else if (message != null && message == "Если поругались!")
            {
                var textMessage = SendTextIfArgueMessage(e);
                await textMessage;
            }
            else if (message != null && message.StartsWith("У меня фантазия"))
            {
                var textMessage = SendTextFantasyMessage(e);
                await textMessage;
            }
        }
    }
}
