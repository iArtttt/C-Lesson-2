namespace C__Less_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card[] cards = CardCreate();
            CardsShuffle(cards);
            SearchOfAces(cards);
            AllSpadesToBegin(cards);

            SearchOfSpadesPosition(cards);

            ShowAllCardPosition(cards);

            AllCardToSort(ref cards);
            ShowAllCardPosition(cards);

        }

        private static void AllCardToSort(ref Card[] cards)
        {
            cards = cards.OrderBy((c) => c.suit == "Пик")
                        .ThenBy((c) => c.suit == "Креста")
                        .ThenBy((c) => c.suit == "Бубна")
                        .ThenBy(c=>c.toSort).ToArray();
            
        }


        private static ConsoleColor SetCardSuitColor(Card card)
        {
            return card.name switch
            {
                "Туз" => Console.ForegroundColor = ConsoleColor.Yellow,
                "Король" => Console.ForegroundColor = ConsoleColor.Yellow,
                "Дама" => Console.ForegroundColor = ConsoleColor.Yellow,
                "Валет" => Console.ForegroundColor = ConsoleColor.Yellow,
                _ => Console.ForegroundColor = ConsoleColor.DarkYellow,
            };
        }
        private static ConsoleColor SetCardNameColor(Card card)
        {
            return card.suit switch
            {
                "Чирва" => Console.ForegroundColor = ConsoleColor.DarkRed,
                "Бубна" => Console.ForegroundColor = ConsoleColor.Red,
                "Креста" => Console.ForegroundColor = ConsoleColor.Blue,
                "Пик" => Console.ForegroundColor = ConsoleColor.DarkBlue,
                _ => Console.ForegroundColor = ConsoleColor.Gray,
            };
        }
        private static void CardPrint(Card card)
        {
            Console.ForegroundColor = SetCardSuitColor(card);
            Console.Write($"{card.name} ");
            Console.ForegroundColor = SetCardNameColor(card);
            Console.Write($"\t{card.suit} ");
            Console.ResetColor();
            Console.Write($"\tна позиции ");
        }
        private static void ShowAllCardPosition(Card[] cards)
        {
            Console.WriteLine();
            for (int i = 0; i < cards.Length; i++)
            {
                CardPrint(cards[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" \t[ {i} ]\n");
                Console.ResetColor();
            }
        }

        private static void SearchOfSpadesPosition(Card[] cards)
        {
            Console.WriteLine();
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].suit == "Пик")
                    Console.WriteLine($"{cards[i].name} {cards[i].suit} на позиции \t[ {i} ]");
            }
        }

        private static void AllSpadesToBegin(Card[] cards)
        {
            int insertToPosition = 0;
            Card temp;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].suit == "Пик")
                {
                    temp = cards[i];
                    cards[i] = cards[insertToPosition];
                    cards[insertToPosition] = temp;
                    insertToPosition++;
                }
            }

        }

        private static void SearchOfAces(Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].name == "Туз")
                    Console.WriteLine($"{cards[i].name} {cards[i].suit} on position \t[ {i} ]");
                
            }
        }

        private static void CardsShuffle(Card[] cards)
        {
            Card temp;
            Random random = new Random();
            
            int numberFromRandom;
            int amountOfMixing = 0;
            int totalAmountOfMixing = random.Next(2, 6);
            
            do
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    numberFromRandom = random.Next(0, cards.Length);
                    temp = cards[numberFromRandom];
                    cards[numberFromRandom] = cards[i];
                    cards[i] = temp;
                }
            }while (amountOfMixing++ < totalAmountOfMixing);
        }

        private static Card[] CardCreate()
        {
            Card[] cards = new Card[]
            {
                new Card("Туз",     "Чирва"),
                new Card("Король",  "Чирва"),
                new Card("Дама",    "Чирва"),
                new Card("Валет",   "Чирва"),
                new Card("Десять",  "Чирва"),
                new Card("Девять",  "Чирва"),
                new Card("Восемь",  "Чирва"),
                new Card("Семь",    "Чирва"),
                new Card("Шесть",   "Чирва"),
                new Card("Туз",     "Бубна"),
                new Card("Король",  "Бубна"),
                new Card("Дама",    "Бубна"),
                new Card("Валет",   "Бубна"),
                new Card("Десять",  "Бубна"),
                new Card("Девять",  "Бубна"),
                new Card("Восемь",  "Бубна"),
                new Card("Семь",    "Бубна"),
                new Card("Шесть",   "Бубна"),
                new Card("Туз",     "Креста"),
                new Card("Король",  "Креста"),
                new Card("Дама",    "Креста"),
                new Card("Валет",   "Креста"),
                new Card("Десять",  "Креста"),
                new Card("Девять",  "Креста"),
                new Card("Восемь",  "Креста"),
                new Card("Семь",    "Креста"),
                new Card("Шесть",   "Креста"),
                new Card("Туз",     "Пик"),
                new Card("Король",  "Пик"),
                new Card("Дама",    "Пик"),
                new Card("Валет",   "Пик"),
                new Card("Десять",  "Пик"),
                new Card("Девять",  "Пик"),
                new Card("Восемь",  "Пик"),
                new Card("Семь",    "Пик"),
                new Card("Шесть",   "Пик"),
            };
            return cards;
        }
    }
    
}