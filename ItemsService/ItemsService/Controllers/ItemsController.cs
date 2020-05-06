using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUYERDBENTITY.Entity;
using ItemsService.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemManager _itemManager;
        public ItemsController(IItemManager itemManager)
        {
            _itemManager = itemManager;
        }
        [HttpGet]
        [Route("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            List<Items> items=await _itemManager.GetItems();
            if (items != null)
            {
                return Ok(items);
            }
            else
                return Ok("No Items Found");
        }

    }
}