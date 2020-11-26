using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using implementsForm.Web.Models;
using implementsForm.Web.Database;
using implementsForm.Web.Entities;

namespace implementsForm.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AjaxController : ControllerBase
    {
        private readonly ExchangesDbContext _dbContext;

        public AjaxController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<ItemEntity> Post(ItemModel item)
        {
            var entity = new ItemEntity {
                Name = item.Name,
                Description = item.Description,
                IsVisible = item.IsVisible
            } ;

            _dbContext.Items.Add(entity);
            _dbContext.SaveChanges();


            return _dbContext.Set<ItemEntity>();
          
        }
    }
}
