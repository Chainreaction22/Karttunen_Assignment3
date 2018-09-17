using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Homma
{
    
    [Route("api/players/{playerId}/[controller]")]
    [ApiController]
    public class ItemsController
    {
        private ItemsProcessor _process;
        public ItemsController(ItemsProcessor process) {
            this._process = process;
        }
        
        [HttpGet("{itemId}")]
        public Task<Item> Get(Guid playerId, Guid itemId){
            return _process.Get(playerId, itemId);
        }
        
        [HttpGet]
        public Task<Item[]> GetAll(Guid playerId){
            return _process.GetAll(playerId);
        }
        
        [HttpPost]
        public Task<Item> Create(Guid playerId, NewItem item){
            return _process.Create(playerId, item);
        }
        
        [HttpPut("{itemId}")]
        public Task<Item> Modify(Guid playerId, Guid itemId, ModifiedItem item){
            return _process.Modify(playerId, itemId, item);
        }

        [HttpDelete("{itemId}")]
        public Task<Item> Delete(Guid playerId, Guid itemId){
            return _process.Delete(playerId, itemId);
        }
    }
    
}