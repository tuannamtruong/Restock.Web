using ReStock.DataProvider;
using ReStock.Models;
using System.Collections.Generic;

namespace ReStock.Web.Services.Data
{
    public class RecipeRepository : RepositoryBase<RestockDbContext, Recipe>, IRecipeRepository
    {
        public RecipeRepository(RestockDbContext dbContextCreator) : base(dbContextCreator)
        {
        }
    }
}
