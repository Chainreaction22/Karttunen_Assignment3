using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Homma
{
    public enum ItemType {
        Pants,
        Pantaloons,
        Shorts
    }


    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }


        [Range(1, 99)]
        public int Level { get; set; }

        public ItemType itemType { get; set; }

        [ValidDateAttribute]
        public DateTime CreationDate { get; set;}
    }
    //"Name": "Derptastic"
    //"Name": "Plop", "Level": 1, "itemType": "Pants", "CreationDate": "02-02-2000 22:22:22"
    //"Name": "Plop", "Level": 1, "itemType": "Pantsers", "CreationDate": "02-02-2000 22:22:22"
    public class NewItem
    {
        public string Name { get; set; }

        [Range(1, 99)]
        public int Level { get; set; }

        public ItemType itemType { get; set; }

        [ValidDateAttribute]
        public DateTime CreationDate { get; set;}
    }
    public class ModifiedItem
    {
        public int Value { get; set; }
    }

    public class ItemsProcessor
    {

        IRepository _repos;

        public ItemsProcessor (IRepository repos) {
            this._repos = repos;
        }

        public Task<Item> Get(Guid playerId, Guid itemId){
            return _repos.GetItem(playerId, itemId);
        }
        
        public Task<Item[]> GetAll(Guid playerId){
            return _repos.GetAllItems(playerId);
        }
        
        public Task<Item> Create(Guid playerId, NewItem item){
            Player player = _repos.Get(playerId).Result;

            if (item.itemType == 0 && player.Level < 3) {
                //throw new System.ArgumentException("NANI THE FUCK?!");
                throw new TooLowLevel("NANI THE FUCK?!?");
            }

            Item i = new Item();
            Guid g = Guid.NewGuid();
            i.Id = g;
            i.Name = item.Name;
            i.Level = item.Level;
            i.itemType = item.itemType;
            i.CreationDate = item.CreationDate;
            return _repos.CreateItem(playerId, i);
        }
        public Task<Item> Modify(Guid playerId, Guid itemId, ModifiedItem item){
            return _repos.UpdateItem(playerId, itemId, item);
        }
        public Task<Item> Delete(Guid playerId, Guid itemId){
            return _repos.DeleteItem(playerId, itemId);
        }
        
    }
}