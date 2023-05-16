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
            Deck deck = new Deck(suits, denominations);
            Player player = new Player();

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
        private Stack<Card> _cards;

        public Deck()
        {
            _cards = new Stack<Card>();
        }

        public Deck(string[] suits, string[] denominations)
        {
            _cards = new Stack<Card>();
            Fill(suits, denominations);
            Shuffle();
        }

        public int CardCount => _cards.Count;

        public void AddCardToDeck(Deck customDeck)
        {
            _cards?.Push(customDeck._cards.Pop());
        }

        public void ShowInfo()
        {
            foreach (Card card in _cards)
            {
                Console.WriteLine(card.Denomination + " " + card.Suit);
            }
        }

        private void Shuffle()
        {
            Random random = new Random();
            int randomIndex;
            Card tempCard;
            Card[] tempCards = new Card[_cards.Count];

            _cards.CopyTo(tempCards, 0);

            for (int i = 0; i < tempCards.Length; i++)
            {
                randomIndex = random.Next(i, tempCards.Length);
                tempCard = tempCards[i];
                tempCards[i] = tempCards[randomIndex];
                tempCards[randomIndex] = tempCard;
            }

            _cards = new Stack<Card>(tempCards);
        }

        private void Fill(string[] suits, string[] denominations)
        {
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < denominations.Length; j++)
                {
                    _cards.Push(new Card(suits[i], denominations[j]));
                }
            }
        }
    }

    class Player
    {
        private Deck _deck;

        public Player()
        {
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
                            _deck.AddCardToDeck(customDeck);
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

            _deck.AddCardToDeck(customDeck);

            while (isDrawing)
            {
                if (customDeck.CardCount > 0)
                {
                    Console.Write($"Еще тянем? {CommandYes}/{CommandNo}: ");
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case CommandYes:
                            _deck.AddCardToDeck(customDeck);
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
            _deck.ShowInfo();
        }
    }
}