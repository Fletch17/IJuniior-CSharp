namespace _04_CardDeck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Croupier().Play();
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
            Fill();
            Shuffle();
        }

        public int CardCount => _cards.Count;
        public bool IsEmpy => _cards.Count == 0;

        public Card TakeCard()
        {
            return _cards.Pop();
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

        private void Fill()
        {
            string[] suits = { "Черви", "Пики", "Буби", "Крести" };
            string[] denominations = { "6", "7", "8", "9", "10", "В", "Д", "К", "Т" };

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
        private List<Card> _hand;

        public Player()
        {
            _hand = new List<Card>();
        }

        public void GetCard(Card card)
        {
            _hand.Add(card);
        }

        public void ShowHand()
        {
            Console.WriteLine("Ваша колода:");

            foreach (Card card in _hand)
            {
                Console.WriteLine(card.Denomination + " " + card.Suit);
            }
        }
    }

    class Croupier
    {
        private Deck _deck;
        private Player _player;

        public Croupier()
        {
            _deck = new Deck();
            _player = new Player();
        }

        public void Play()
        {
            const string CommandTransferOneCard = "1";
            const string CommandTransferSomeCards = "2";

            bool isProgramWork = true;
            string userInput;

            Console.WriteLine($"{CommandTransferOneCard}. Вытянуть одну карту.");
            Console.WriteLine($"{CommandTransferSomeCards}. Вытянуть сразу несколько карт.");

            while (isProgramWork)
            {
                Console.Write("Что делаем? ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandTransferOneCard:
                        TransferOneCard();
                        isProgramWork = false;
                        break;

                    case CommandTransferSomeCards:
                        TransferSomeCards();
                        isProgramWork = false;
                        break;

                    default:
                        Console.WriteLine("Команда не корректна.");
                        break;
                }
            }

            _player.ShowHand();
        }

        private void TransferSomeCards()
        {
            bool isCorrect = false;
            string userInput;

            if (_deck.IsEmpy)
            {
                Console.WriteLine("Колода пуста.");
                return;
            }

            Console.Write("Сколько карт вытянуть? ");

            while (isCorrect == false)
            {
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int count))
                {
                    if (count > 0 && count <= _deck.CardCount)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            _player.GetCard(_deck.TakeCard());
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

        private void TransferOneCard()
        {
            if (_deck.IsEmpy)
            {
                Console.WriteLine("Колода пуста.");
                return;
            }

            _player.GetCard(_deck.TakeCard());              
        }
    }
}