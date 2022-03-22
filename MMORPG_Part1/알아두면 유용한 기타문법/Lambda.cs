using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C��.MMORPG_�������.MMORPG_Part1.�˾Ƶθ�_������_��Ÿ_����
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
            // Lambda : ��ȸ�� �Լ��� ����µ� ����ϴ� �Լ�

            Item ITem = FindItem( (Item item) => { return item.ItemType == ItemType.Weapon; });

            // Anonymous Fuction : ���� �Լ�  / �͸� �Լ�
            Item Item = FindItem(delegate (Item item){return item.ItemType == ItemType.Weapon;});

            // delegate�� ���� �������� �ʾƵ� , �̹� ������� �ֵ��� �����Ѵ�.
            // �̰� func �� �����������
            // -> ��ȯ Ÿ���� ���� ��� Func
            // -> ��ȯ Ÿ���� ������ Action
            Func<Item, bool> selector = (Item item) => { return item.ItemType == ItemType.Weapon; };


            }
    }
}
