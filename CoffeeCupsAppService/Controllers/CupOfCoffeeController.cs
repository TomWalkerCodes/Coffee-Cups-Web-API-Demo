using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using CoffeeCupsAppService.DataObjects;
using CoffeeCupsAppService.Models;

namespace CoffeeCupsAppService.Controllers
{
    public class CupOfCoffeeController : TableController<CupOfCoffee>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            CoffeeCupsAppContext context = new CoffeeCupsAppContext();
            DomainManager = new EntityDomainManager<CupOfCoffee>(context, Request);
        }

        // GET tables/CupOfCoffee
        public IQueryable<CupOfCoffee> GetAllCupOfCoffee()
        {
            return Query(); 
        }

        // GET tables/CupOfCoffee/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CupOfCoffee> GetCupOfCoffee(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CupOfCoffee/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CupOfCoffee> PatchCupOfCoffee(string id, Delta<CupOfCoffee> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/CupOfCoffee
        public async Task<IHttpActionResult> PostCupOfCoffee(CupOfCoffee item)
        {
            CupOfCoffee current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CupOfCoffee/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCupOfCoffee(string id)
        {
             return DeleteAsync(id);
        }
    }
}
