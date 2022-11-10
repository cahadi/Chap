using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Chap
{
    public class Database
    {
        public List<Item> items = new List<Item>();
        public List<Types> types = new List<Types>();
        private int autoinc = 2;

        public Database()
        {
            Item item1 = new Item
            {
                Id = 1,
                Name = "Имя1",
                TypesID = 1
            };
            Item item2 = new Item
            {
                Id = 2,
                Name = "Имя2",
                TypesID = 1
            };
            items.Add(item1);
            items.Add(item2);



            Types type1 = new Types
            {
                Id = 1,
                Name = "Тип1"
            };
            Types type2 = new Types
            {
                Id = 2,
                Name = "Тип2"
            };
            types.Add(type1);
            types.Add(type2);
        }

        public List<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(int id)
        {
            return items.Find(x => x.Id == id);
        }
        public Task DeleteItem(Item Item)
        {
            items.Remove(Item);
            return Task.CompletedTask;
        }
        public Task AddItem(Item item)
        {
            item.Id = ++autoinc;
            items.Add(item);
            return Task.CompletedTask;
        }

        public int EditItem(Item item)
        {
                Item oldItem = GetItem(item.Id);
                item= oldItem;
                return item.Id;
        }
        
        public List<Types> GetTypes()
        {
            return types;
        }
        public Types GetType(int id)
        {
            return types.Find(x => x.Id == id);
        }

        public Types EditTypes(Types type)
        {
            Types oldType = GetType(type.Id);
            oldType = type;
            return oldType;
        }

        public Task DeleteTypes(Types Type)
        {
            types.Remove(Type);
            return Task.CompletedTask;
        }

        public Task AddType(Types type)
        {
            type.Id = ++autoinc;
            types.Add(type);
            return Task.CompletedTask;
        }
    }
}
