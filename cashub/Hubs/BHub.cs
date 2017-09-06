using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Subjects;

namespace cashub.Hubs
{

    public class BHub : Hub
    {

        public BHub(): base()
        {
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).InvokeAsync("Welcome", "Welcome to the b Hub!");
            report("Client with id " + Context.ConnectionId + " has connected at " + DateTime.Now.ToString());
            await base.OnConnectedAsync();
        }

        public async void report(string onWhat)
        {
            await Clients.All.InvokeAsync("Report", onWhat);
        }

    }

}
