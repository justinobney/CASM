using System.Threading.Tasks;
using System.Web.Mvc;
using Jobney.Casm.Web.Helpers;
using Jobney.Casm.Web.Models;
using Jobney.Casm.Web.ViewModels;
using Jobney.Core.Domain.Interfaces;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jobney.Casm.Web.Controllers
{
    public class BaseController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; set; }
        protected IUnitOfWork uow;

        public BaseController()
        {
            UserManager = DependencyResolver.Current.GetService<UserManager<ApplicationUser>>();
            uow = DependencyResolver.Current.GetService<IUnitOfWork>();
        }

        public UserViewModel CurrentUser {
            get
            {
                var user = new UserViewModel();
                if (HttpContext.User == null || HttpContext.User.Identity.Name == string.Empty) return null;

                var appUser = UserManager.FindByName(HttpContext.User.Identity.Name);
                user.Id = appUser.Id;
                user.UserName = appUser.UserName;
                user.Email = appUser.Email;
                user.Name = appUser.Name;
                return user;
            }
        }
        
        protected JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        
        protected internal JsonNetResult JsonResult(object data)
        {
            return new JsonNetResult
            {
                Data = data,
                Formatting = Formatting.Indented,
                SerializerSettings = jsonSettings
            };
        }
    }
}