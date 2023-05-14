using System.Runtime.CompilerServices;

namespace _04_CardDeck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandDrawOneByOneCards = "1";
            const string CommandDrawSomeCards = "2";

            string[] suits = { "Черви", "Пики", "Буби", "Крести" };
            string[] denominations = { "6", "7", "8", "9", "10", "В", "Д", "К", "Т" };
            bool isProgramWork = true;
            string userInput;
            Deck deck = new Deck();
            Player player = new Player();

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < denominations.Length; j++)
                {
                    deck.AddCard(new Card(suits[i], denominations[j]));
                }
            }

            Console.WriteLine($"{CommandDrawOneByOneCards}. Тянуть по одной карте.");
            Console.WriteLine($"{CommandDrawSomeCards}. Вытянуть сразу несколько карт.");

            while (isProgramWork)
            {
                Console.Write("Что делаем? ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandDrawOneByOneCards:
                        player.DrawOneCard(deck);
                        isProgramWork = false;
                        break;

                    case CommandDrawSomeCards:
                        player.DrawSomeCards(deck);
                        isProgramWork = false;
                        break;

                    default:
                        Console.WriteLine("Команда не корректна.");
                        break;
                }
            }

            player.ShowDeck();
        }
    }

    class Card
    {
        public Card(string suit, string denomination)
        {
            Suit = suit;
            Denomination = denomination;
        }

        public string Suit { get; private set; }
        public string Denomination { get; private set; }
    }

    class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
        }

        public int CardCount => _cards.Count;

        public Card GetCard(int index)
        {
            return _cards[index];
        }

        public void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }
    }

    class Player
    {
        private static Random _random;
        private Deck _deck;

        public Player()
        {
            _random = new Random();
            _deck = new Deck();
        }

        public void DrawSomeCards(Deck customDeck)
        {
            bool isCorrect = false;
            string userInput;

            Console.Write("Сколько карт вытянуть? ");

            while (isCorrect == false)
            {
                userInput = Console.ReadLine();
                bool isInt = int.TryParse(userInput, out int count);

                if (isInt)
                {
                    if (count > 0 && count <= customDeck.CardCount)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            AddRandomCardToDeck(customDeck);
                        }

                        isCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректное количество.");
                    }
                }
                else
                {
                    Console.WriteLine("Введите число.");
                }
            }
        }

        public void DrawOneCard(Deck customDeck)
        {
            const string CommandYes = "y";
            const string CommandNo = "n";

            bool isDrawing = true;
            string userInput;

            AddRandomCardToDeck(customDeck);

            while (isDrawing)
            {
                if (customDeck.CardCount > 0)
                {

                    Console.Write("Еще тянем? y/n: ");
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case CommandYes:
                            AddRandomCardToDeck(customDeck);
                            break;

                        case CommandNo:
                            isDrawing = false;
                            break;

                        default:
                            Console.WriteLine("Команда не корректна.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("В колоде не осталось карт.");
                    isDrawing = false;
                }
            }
        }

        public void ShowDeck()
        {
            Console.WriteLine("Ваша колода:");

            for (int i = 0; i < _deck.CardCount; i++)
            {
                Console.WriteLine(_deck.GetCard(i).Denomination + " " + _deck.GetCard(i).Suit);
            }
        }

        private void AddRandomCardToDeck(Deck deck)
        {
            int index = _random.Next(deck.CardCount);
            Card card = deck.GetCard(index);

            Console.WriteLine($"Вы вытянули: {card.Denomination} {card.Suit}");
            _deck.AddCard(card);
            deck.RemoveCard(card);
        }
    }
}