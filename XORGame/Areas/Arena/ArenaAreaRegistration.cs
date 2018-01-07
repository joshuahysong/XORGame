using System.Web.Mvc;

namespace XORGame.Areas.Arena
{
    public class ArenaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Arena";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Arena_default",
                "Arena/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "XORGame.Areas.Arena.Controllers" }
            );
        }
    }
}