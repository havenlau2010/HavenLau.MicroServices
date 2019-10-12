using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBase.Data
{
    public class MenuService
    {
        private List<MenuItem> GetMenuItems()
        {
            List<MenuItem> menus = new List<MenuItem>()
            {
                new MenuItem{ MenuText="Home", MatchTagret="NavLinkMatch.All", MenuHref="", MenuIcon="oi oi-home",OrderNumber=1 },
                new MenuItem{ MenuText="Counter", MatchTagret="", MenuHref="counter", MenuIcon="oi oi-plus",OrderNumber=2 },
                new MenuItem{ MenuText="Fetch data", MatchTagret="", MenuHref="fetchdata", MenuIcon="oi oi-list-rich",OrderNumber=3 },
                new MenuItem{ MenuText="ToDo List", MatchTagret="", MenuHref="todolist", MenuIcon="oi oi-list-rich",OrderNumber=4 },
            };
            return menus;
        }

        public Task<List<MenuItem>> GetMenusAsync()
        {
            return Task.FromResult(this.GetMenuItems().OrderBy(x => x.OrderNumber).ToList());
        }
    }
}
