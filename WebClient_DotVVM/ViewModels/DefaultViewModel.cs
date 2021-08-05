using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using WebClient_DotVVM.Model;

namespace WebClient_DotVVM.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
		private readonly UserService userService;
        public DefaultViewModel(UserService userService)
        {
            this.userService = userService;
        }
        [Bind(Direction.ServerToClient)]
        public List<UserListModel> Users { get; set; }

        public override async Task PreRender()
        {
            Users = userService.GetAllUsers();
            await base.PreRender();
        }
    }
}
