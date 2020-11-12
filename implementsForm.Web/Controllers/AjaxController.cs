using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using implementsForm.Web.Models;


namespace implementsForm.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AjaxController : ControllerBase
    {

        public AddNewItemResponse Post(ItemModel item)
        {
            return new AddNewItemResponse { Description = item.Description,
                Name = item.Name,
                IsVisible = item.IsVisible,
                success = true/**/
            } ;
          
        }
    }
}
