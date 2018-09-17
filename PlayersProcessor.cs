using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Homma
{
    public class PlayersProcessor
    {
        private IRepository _repos;

        
        public PlayersProcessor(IRepository repos) {
            this._repos = repos;
        }

        public Task<Player> Get(Guid id){
            return _repos.Get(id);
        }
        public Task<Player[]> GetAll(){
            return _repos.GetAll();
        }
        public Task<Player> Create(NewPlayer player){
            Player p = new Player();
            Guid g = Guid.NewGuid();
            p.Id = g;
            p.CreationTime = DateTime.Now;
            p.Score = 0;
            p.Level = player.Level;
            p.IsBanned = false;
            p.Name = player.Name;

            return _repos.Create(p);
        }
        public Task<Player> Modify(Guid id, ModifiedPlayer player){
            return _repos.Modify(id, player);
        }
        public Task<Player> Delete(Guid id){
            return _repos.Delete(id);
        }
    }
}