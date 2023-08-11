﻿namespace _06_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Shop().Play();
        }
    }

    public class Shop
    {
        private Character _trader;
        private Character _player;

        public Shop()
        {
            FillTraderInventory();
            _player = new Character(300);
        }

        public void Play()
        {
            const string CommandBuy = "1";
            const string CommandShowPlayerInventory = "2";
            const string CommandShowTraderInventory = "3";
            const string CommandExit = "4";
            bool isPlaying = true;
            string userInput;

            while (isPlaying)
            {
                Console.WriteLine($"{CommandBuy}. Купить предмет.");
                Console.WriteLine($"{CommandShowPlayerInventory}. Показать инвентарь игрока.");
                Console.WriteLine($"{CommandShowTraderInventory}. Показать инвентарь продавца.");
                Console.WriteLine($"{CommandExit}. Выйти.");
                Console.Write("Ваш выбор: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandBuy:
                        BuyItem();
                        break;
                    case CommandShowPlayerInventory:
                        _player.ShowInventory();
                        break;
                    case CommandShowTraderInventory:
                        _trader.ShowInventory();
                        break;
                    case CommandExit:
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Нет такой команды.");
                        break;
                }
            }
        }

        private void BuyItem()
        {
            bool isBuying = true;
            string userInput;

            if (_trader.Inventory.Count == 0)
            {
                Console.WriteLine("Покупать нечего.");
                return;
            }

            while (isBuying)
            {
                Console.Write("Введите индекс предмета: ");

                userInput = Console.ReadLine();
                bool isInt = int.TryParse(userInput, out int index);

                if (isInt == false)
                {
                    Console.WriteLine("Введите цифру.");
                }
                else
                {
                    if (index >= _trader.Inventory.Count)
                    {
                        Console.WriteLine("Индекс не корректен.");
                    }
                    else
                    {
                        Item item = _trader.Inventory[index].Item;

                        if (_player.Gold >= item.Price)
                        {
                            _player.DecreaseGold(item.Price);
                            _trader.IncreaseGold(item.Price);
                            _player.AddItem(item);
                            _trader.RemoveItem(item);

                            Console.WriteLine("Вы купили: " + item.Name);
                        }
                        else
                        {
                            Console.WriteLine("Не хватает монет.");
                        }

                        isBuying = false;
                    }
                }
            }
        }

        private void FillTraderInventory()
        {
            List<Stack> inventory = new List<Stack>();
            inventory.Add(new Stack(new Item("Зелье силы", 50), 5));
            inventory.Add(new Stack(new Item("Зелье ловкости", 75), 10));
            inventory.Add(new Stack(new Item("Зелье интелекта", 100), 10));
            inventory.Add(new Stack(new Item("Зелье выносливости", 50), 15));
            _trader = new Character(inventory, 1000);
        }
    }

    public class Character
    {
        public Character(int gold)
        {
            Inventory = new List<Stack>();
            Gold = gold;
        }

        public Character(List<Stack> inventory, int gold)
        {
            Inventory = inventory;
            Gold = gold;
        }

        public List<Stack> Inventory { get; private set; }
        public int Gold { get; private set; }

        public void IncreaseGold(int gold)
        {
            Gold += gold;
        }

        public void DecreaseGold(int gold)
        {
            Gold -= gold;
        }

        public void AddItem(Item item)
        {
            bool isContains = false;

            foreach (var stack in Inventory)
            {
                if (stack.Item.Name == item.Name)
                {
                    stack.IncreaseCount();
                    isContains = true;
                    break;
                }
            }

            if (isContains == false)
            {
                Inventory.Add(new Stack(item, 1));
            }
        }

        public void RemoveItem(Item item)
        {
            foreach (var stack in Inventory)
            {
                if (stack.Item.Name == item.Name)
                {
                    if (stack.Count > 1)
                    {
                        stack.DecreaseCount();
                        break;
                    }
                    else if (stack.Count == 1)
                    {
                        Inventory.Remove(stack);
                        break;
                    }
                }
            }
        }

        public void ShowInventory()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Инвентарь пуст.");
            }
            else
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    string name = Inventory[i].Item.Name;
                    int count = Inventory[i].Count;
                    int price = Inventory[i].Item.Price;

                    Console.WriteLine($"{i}. {name} - {count} шт., цена - {price}");
                }
            }

            Console.WriteLine("Монет: " + Gold);
        }
    }

    public class Stack
    {
        public Stack(string name, int price, int count)
        {
            Item = new Item(name, price);
            Count = count;
        }

        public Stack(Item item, int count)
        {
            Item = item;
            Count = count;
        }

        public Item Item { get; private set; }
        public int Count { get; private set; }

        public void IncreaseCount()
        {
            Count++;
        }

        public void DecreaseCount()
        {
            Count--;
        }
    }

    public class Item
    {
        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
    }
}