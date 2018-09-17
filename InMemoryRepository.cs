using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Homma
{
    public interface IRepository
    {
        Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);



        Task<Item> CreateItem(Guid playerId, Item item);
        Task<Item> GetItem(Guid playerId, Guid itemId);
        Task<Item[]> GetAllItems(Guid playerId);
        Task<Item> UpdateItem(Guid playerId, Guid itemId, ModifiedItem item);
        Task<Item> DeleteItem(Guid playerId, Guid itemId);

    }


    public class InMemoryRepository : IRepository
    {

        public List<Player> _pListRepos = new List<Player>();

        public Task<Player> Get(Guid id){
            foreach (Player p in _pListRepos) {
                if (p.Id == id) {
                    return Task.FromResult(p);
                } 
            }
            throw new System.ArgumentException("Unable to find given ID.");
        }
        public Task<Player[]> GetAll(){
            Player[] pArgh = _pListRepos.ToArray();
            return Task.FromResult(pArgh);
        }
        public Task<Player> Create(Player player){
            _pListRepos.Add(player);
            return Task.FromResult(player);
        }
        public Task<Player> Modify(Guid id, ModifiedPlayer player){
            for (int i = 0; i < _pListRepos.Count; i++) {
                if (_pListRepos[i].Id == id) {
                    _pListRepos[i].Score = player.Score;
                    return Task.FromResult(_pListRepos[i]);
                } 
            }
            throw new System.ArgumentException("Unable to find given ID.");
        }
        public Task<Player> Delete(Guid id){
            for (int i = 0; i < _pListRepos.Count; i++) {
                if (_pListRepos[i].Id == id) {
                    _pListRepos.Remove(_pListRepos[i]);
                    return Task.FromResult(_pListRepos[i]);
                } 
            }
            throw new System.ArgumentException("Unable to find given ID.");
        }




        

        public Task<Item> GetItem(Guid playerId, Guid itemId){
            Player _p = Get(playerId).Result;
            foreach (Item i in _p.Items) {
                if (i.Id == itemId) {
                    return Task.FromResult(i);
                } 
            }
            throw new System.ArgumentException("Unable to find given ID.");
        }
        public Task<Item[]> GetAllItems(Guid playerId){
            Player _p = Get(playerId).Result;
            Item[] iArgh = _p.Items.ToArray();
            return Task.FromResult(iArgh);
        }
        public Task<Item> CreateItem(Guid playerId, Item item){
            Player _p = Get(playerId).Result;
            
            _p.Items.Add(item);

            return Task.FromResult(item);
        }
        public Task<Item> UpdateItem(Guid playerId, Guid itemId, ModifiedItem item){
            Player _p = Get(playerId).Result;
            for (int i = 0; i < _p.Items.Count; i++) {
                if (_p.Items[i].Id == itemId) {
                    _p.Items[i].Value = item.Value;
                    return Task.FromResult(_p.Items[i]);
                } 
            }
            throw new System.ArgumentException("Unable to find given ID.");
        }
        public Task<Item> DeleteItem(Guid playerId, Guid itemId){
            Player _p = Get(playerId).Result;
            for (int i = 0; i < _p.Items.Count; i++) {
                if (_p.Items[i].Id == itemId) {
                    _p.Items.Remove(_p.Items[i]);
                    return Task.FromResult(_p.Items[i]);
                } 
            }
            throw new System.ArgumentException("Unable to find given ID.");
        }

    }
}