using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Homma
{
    public class Player
    {
        public Player () {
            Items = new List<Item>();
        }
        public List<Item> Items { get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        
        [Range(1, 99)]
        public int Level { get; set; }
        public int Score { get; set; }
        public bool IsBanned { get; set; }
        public DateTime CreationTime { get; set; }
    }

    public class NewPlayer
    {
        public string Name { get; set; }

        [Range(1, 99)]
        public int Level { get; set; }
    }
    public class ModifiedPlayer
    {
        public int Score { get; set; }
    }
}