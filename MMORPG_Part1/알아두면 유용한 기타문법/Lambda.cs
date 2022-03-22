using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식.MMORPG_Part1.알아두면_유용한_기타_문법
{
    enum ItemType
    {
        Weapon,
        Armor,
        Amulet,
        Ring
    }
    enum Rarity
    {
        Normal,
        Uncommon,
        Rare
    }

    class Item
    {
        public ItemType ItemType;
        public Rarity Rarity;
    }

    internal class Lambda
    {
        static List<Item> items = new List<Item>();

        delegate bool MyFunc<T,Return>(T item);
        
        static bool IsWeapon(Item item)
        {
            return item.ItemType == ItemType.Weapon;
        }
        static Item FindItem(MyFunc<Item,bool>  selector)
        {
           foreach(Item item in items)
            {
                if(selector(item))
                {
                   return item;
                }
            }
           return null; 
        }
       
        static void Main_Lambda(string[] args)
        {
            items.Add(new Item() { ItemType = ItemType.Weapon , Rarity = Rarity.Normal });
            items.Add(new Item() { ItemType = ItemType.Armor, Rarity = Rarity.Uncommon });
            items.Add(new Item() { ItemType = ItemType.Ring, Rarity = Rarity.Rare });
            // Lambda : 일회용 함수를 만드는데 사용하는 함수

            Item ITem = FindItem( (Item item) => { return item.ItemType == ItemType.Weapon; });

            // Anonymous Fuction : 무명 함수  / 익명 함수
            Item Item = FindItem(delegate (Item item){return item.ItemType == ItemType.Weapon;});

            // delegate를 직접 선언하지 않아도 , 이미 만들어진 애들이 존재한다.
            // 이게 func 로 만들어져있음
            // -> 반환 타임이 있을 경우 Func
            // -> 반환 타임이 없으면 Action
            Func<Item, bool> selector = (Item item) => { return item.ItemType == ItemType.Weapon; };


            }
    }
}
