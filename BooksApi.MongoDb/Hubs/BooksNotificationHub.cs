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
            Book newBook = new Book();
            newBook._Id = "6260e73bc363928f414c7769";
            newBook.Id = 121;
            newBook.Title = "Finish";
            newBook.ReleaseDate = DateTime.Now;
            newBook.Price = 66.66;
            newBook.Author = "Jon Acuff";

            await NotifyBookRelease(newBook);
        }

        //notifier method
        public async static Task NotifyBookRelease(Book newBook)
        {
            await callers.All.SendAsync("NewBookNotification", newBook);
        }
    }
}
