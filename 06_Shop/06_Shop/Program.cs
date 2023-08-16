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
        private Trader _trader;
        private Player _player;

        public Shop()
        {
            _trader = new Trader(1000);
            _player = new Player(300);
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
                        Trade();
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

        private void Trade()
        {
            bool isTrading = true;
            string userInput;

            if (_trader.StackCount == 0)
            {
                Console.WriteLine("Покупать нечего.");
                return;
            }

            while (isTrading)
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
                    if (index >= _trader.StackCount || index < 0)
                    {
                        Console.WriteLine("Индекс не корректен.");
                    }
                    else
                    {
                        Item item = _trader.GetStack(index).Item;

                        if (_player.CanBuy(item.Price))
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

                        isTrading = false;
                    }
                }
            }
        }
    }

    public class Player : Character
    {
        public Player(int gold) : base(gold)
        {
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

        public void DecreaseGold(int gold)
        {
            Gold -= gold;
        }

        public bool CanBuy(int price)
        {
            return Gold - price >= 0 ? true : false;
        }
    }

    public class Trader : Character
    {
        public Trader(int gold) : base(gold)
        {
            Inventory = new List<Stack>();
            Inventory.Add(new Stack(new Item("Зелье силы", 50), 5));
            Inventory.Add(new Stack(new Item("Зелье ловкости", 75), 10));
            Inventory.Add(new Stack(new Item("Зелье интелекта", 100), 10));
            Inventory.Add(new Stack(new Item("Зелье выносливости", 50), 15));
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
                    }
                    else if (stack.Count == 1)
                    {
                        Inventory.Remove(stack);
                        break;
                    }
                }
            }
        }

        public void IncreaseGold(int gold)
        {
            Gold += gold;
        }
    }

    public class Character
    {
        protected List<Stack> Inventory;

        public Character(int gold)
        {
            Inventory = new List<Stack>();
            Gold = gold;
        }

        public int StackCount => Inventory.Count;
        public Stack GetStack(int index) => Inventory[index];

        public int Gold { get; protected set; }
        
        public void ShowInventory()
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            if (Inventory.Count == 0)
            {
                Console.WriteLine("Инвентарь пуст.");
            }
            else
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Console.Write($"{i} ");
                    Inventory[i].ShowInfo();
                }
            }

            Console.WriteLine("Монет: " + Gold);
            Console.ForegroundColor = defaultColor;
        }
    }

    public class Stack
    {
        public Stack(Item item, int count)
        {
            Item = item;
            Count = count;
        }

        public Item Item { get; private set; }
        public int Count { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Item.Name} - {Count} шт., цена - {Item.Price} монет.");
        }

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