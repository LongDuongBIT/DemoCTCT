using DemoCTCT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace DemoCTCT.Controllers
{
    [Route("activity")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public ActivityController(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        [HttpGet]
        public Task<OkObjectResult> GetActivity(string mssv)
        {
            Task.Run(async () =>
            {
                using var scope = serviceScopeFactory.CreateScope();
                var scopeActiviyService = scope.ServiceProvider.GetRequiredService<IActivityServices>();
                await scopeActiviyService.GetActivity(mssv);
            });

            return Task.FromResult(Ok(new JsonResult("Ahihi")));
        }
    }
}