using Microsoft.AspNetCore.SignalR;
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
            string strBookJson = @"{
                '_Id': '6260e73bc363928f414c7765',
                'id': 121,
                'title': 'Finish',
                'releaseDate': '2001-08-14T18:30:00Z',
                'price': 66.66,
                'author': 'Jon Acuff'
              }";
            await NotifyBookRelease(strBookJson);
        }

        //notifier method
        public async static Task NotifyBookRelease(string strNewBook)
        {
            await callers.All.SendAsync($"NewBookNotification", strNewBook);
        }
    }
}
