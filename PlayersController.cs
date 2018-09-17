using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Homma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController
    {
        private PlayersProcessor _process;

        public PlayersController(PlayersProcessor process) {
            this._process = process;
        }


        [HttpGet("{id}", Name = "GetPlayer")]
        public Task<Player> Get(Guid id){
            return _process.Get(id);
        }

        [HttpGet]
        public Task<Player[]> GetAll(){
            return _process.GetAll();
        }

        [HttpPost]
        public Task<Player> Create(NewPlayer player){
            return _process.Create(player);
        }

        [HttpPut("{id}", Name = "ModPlayer")]
        public Task<Player> Modify(Guid id, ModifiedPlayer player){
            return _process.Modify(id, player);
        }

        [HttpDelete("{id}", Name = "DelPlayer")]
        public Task<Player> Delete(Guid id){
            return _process.Delete(id);
        }
    }
}