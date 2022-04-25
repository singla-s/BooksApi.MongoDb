using BooksApi.MongoDb.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace BooksApi.MongoDb.Hubs
{
    public class BooksNotificationHub : Hub
    {
        private static IHubCallerClients callers = null;

        //Client register via subscription
        public async void subscribeToNewBookRelease(string user, string message)
        {
            callers = Clients;
            string strBookJson = "{_Id': '6260e73bc363928f414c7765','id': " + "121" + ",'title': 'DotNet Design Pattersn', 'releaseDate': " + DateTime.Now + ",'price': 66.66,'author': 'Tim Tuckey'}";

            //await NotifyBookRelease(strBookJson);
        }

        //notifier method
        //notifier method
        public async static Task NotifyBookRelease(string strNewBook)
        {
            await callers.All.SendAsync("NewBookNotification", strNewBook);
        }
    }
}
