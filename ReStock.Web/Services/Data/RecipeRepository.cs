using ReStock.DataProvider;
using ReStock.Models;

namespace ReStock.Web.Services.Data
{
    public class RecipeRepository : RepositoryBase<RestockDbContext, Recipe>, IRecipeRepository
    {
        public RecipeRepository(RestockDbContext dbContextCreator) : base(dbContextCreator)
        {
        }
    }
}
