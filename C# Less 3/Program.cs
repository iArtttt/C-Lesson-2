namespace C__Less_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card[] cards = CardCreate();
            List<string> gameWinnerList = new List<string>();
            Console.WriteLine("Это карточная игра Блэк-Джек или же как её называют 21");
            char ch;
            do
            {
                //Console.ResetColor();
                BlackJackGame(cards, gameWinnerList);


                Console.Write("Если вы хотите закончить нажмите ( Q ) ");
                ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (ch != 'q');

            GamesResults(gameWinnerList);
        }

        private static void BlackJackGame(Card[] cards, List<string> gameWinnerList)
        {
            CardsShuffle(cards);
            
            List<Card> cardsList = cards.ToList();
            List<Card> playersCards = new List<Card>();
            List<Card> computersCards = new List<Card>();

            Console.WriteLine("Кто будет ходить первый? ( Вы или ИИ )");
            Console.WriteLine("Вы = 1, ИИ = 2 (В случае неверного символа или пустого поля игру начинает ИИ)");
            char whosTurn = Console.ReadKey().KeyChar;
            
            TakingCard(playersCards, cardsList);
            TakingCard(playersCards, cardsList);
            TakingCard(computersCards, cardsList);
            TakingCard(computersCards, cardsList);
            if (PlayerPoints(playersCards) >= 21 || PlayerPoints(computersCards) >= 21)
                WhoIsTheWinner(playersCards, computersCards, gameWinnerList);
            else
            {
                if (whosTurn == '1')
                {
                    PlayersTurn(playersCards, cardsList);
                    ComputersTurn(computersCards, cardsList);
                }
                else
                {
                    ComputersTurn(computersCards, cardsList);
                    PlayersTurn(playersCards, cardsList);
                }
                Console.Write($"У вас {PlayerPoints(playersCards)} очков\t|\tУ ИИ {PlayerPoints(computersCards)}  очков\n");
                WhoIsTheWinner(playersCards, computersCards, gameWinnerList);
            }            
            Winner(gameWinnerList);
            
            AllCardToSort(ref cards);
        }
        #region GAME RERULTS, WINNERS AND PLAYER POINTS
        public static int PlayerPoints(List<Card> playersCards)
        {
            int PlayerPoints = 0;

            foreach (Card card in playersCards)
            {
                PlayerPoints += card.points;
            }
            return PlayerPoints;
        }
        public static void GamesResults(List<string> gameWinnerList)
        {
            Console.Write($"====[ Статистика всех сыграных игр ]====\n");
            for (int i = 0; i < gameWinnerList.Count; i++)
            {
                Console.ResetColor();
                Console.Write($" {i+1} игра: ");
                Console.ForegroundColor = gameWinnerList[i] switch
                {
                    "Вы победили!" => ConsoleColor.Green,
                    "ИИ победил!" => ConsoleColor.Red,
                    "Ничья" => ConsoleColor.White,
                    _ => ConsoleColor.Gray
                };
                Console.Write($"{gameWinnerList[i]}\n");
            }
                Console.ResetColor();
            
        }
        public static void Winner(List<string> gameWinnerList)
        {
            Console.ForegroundColor = gameWinnerList[gameWinnerList.Count-1] switch
            {
                "Вы победили!" => ConsoleColor.Green,
                "ИИ победил!" => ConsoleColor.Red,
                "Ничья" => ConsoleColor.White,
                _ => ConsoleColor.Gray
            };
            Console.WriteLine(gameWinnerList[gameWinnerList.Count-1]);
            Console.ResetColor();
        }
        public static void WhoIsTheWinner(List<Card> playersCards, List<Card> computersCards, List<string> gameWinnerList)
        {
            int playersPoints = PlayerPoints(playersCards);
            int computersPoints = PlayerPoints(computersCards);

            if (playersPoints == computersPoints)
            {
                gameWinnerList.Add("Ничья");
                return;
            }
            if (playersCards.All((p) => p.name == "Туз") && computersCards.All((p) => p.name == "Туз"))
            {
                gameWinnerList.Add("Ничья");
                return;
            }
            if (playersCards.All((p) => p.name == "Туз") && computersPoints == 21)
            {
                gameWinnerList.Add("Ничья");
                return;
            }
            if (computersCards.All((p) => p.name == "Туз") && playersPoints == 21)
            {
                gameWinnerList.Add("Ничья");
                return;
            }
            if(playersCards.All((p)=> p.name == "Туз") || playersPoints == 21)
            {
                gameWinnerList.Add("Вы победили!");
                return;
            }
            if(computersCards.All((p) => p.name == "Туз") || computersPoints == 21)
            {
                gameWinnerList.Add("ИИ победил!");
                return;
            }
            if (playersPoints <= 21 &&  computersPoints > 21)
            {
                gameWinnerList.Add("Вы победили!");
                return;
            }
            if (computersPoints <= 21 &&  playersPoints > 21)
            {
                gameWinnerList.Add("ИИ победил!");
                return;
            }
            if(playersPoints < 21 && computersPoints < 21 && playersPoints > computersPoints)
            {
                gameWinnerList.Add("Вы победили!");
                return;
            }
            if(playersPoints < 21 && computersPoints < 21 && playersPoints < computersPoints)
            {
                gameWinnerList.Add("ИИ победил!");
                return;
            }
            if(playersPoints > 21 && computersPoints > 21 && playersPoints < computersPoints)
            {
                gameWinnerList.Add("Вы победили!");
                return;
            }
            if(playersPoints > 21 && computersPoints > 21 && playersPoints > computersPoints)
            {
                gameWinnerList.Add("ИИ победил!");
                return;
            }


        }
        #endregion
        private static void ComputersTurn(List<Card> computersCards, List<Card> cards)
        {
            Random random = new Random();
            do
            {
                if (PlayerPoints(computersCards) <= 12)
                {
                    Console.WriteLine("ИИ берёт карту");
                    TakingCard(computersCards, cards);
                    if (PlayerPoints(computersCards) >= 20)
                        break;
                }
                if (PlayerPoints(computersCards) < 18 && random.Next(0,5) < 4)
                {
                    Console.WriteLine("ИИ берёт карту");
                    TakingCard(computersCards, cards);
                    if (PlayerPoints(computersCards) >= 20)
                        break;
                }
                if (PlayerPoints(computersCards) >= 19 && random.Next(0, 9) > 5)
                {
                    Console.WriteLine("ИИ берёт карту");
                    TakingCard(computersCards, cards);
                    if (PlayerPoints(computersCards) >= 20 )
                        break;
                }

            } while (true);
                

            Console.WriteLine("ИИ завершил свой ход");
        }

        private static void PlayersTurn(List<Card> playersCards, List<Card> cards)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Ваш ход");
            Console.ResetColor();
            ShowAllPlayersCard(playersCards);
            Console.Write($"Хотите ещё карту?( yes, do, +, ход, да, 1): ");
            string wantCard = Console.ReadLine();

            while (WantOneMoreCard(wantCard))
            {
                TakingCard(playersCards, cards);
                ShowAllPlayersCard(playersCards);

                Console.Write($"Хотите ещё карту?( yes, do, +, ход, да, 1): ");
                wantCard = Console.ReadLine();
            } 

        }

        private static bool WantOneMoreCard(string? wantCard)
        {
            return wantCard.ToLower() switch
            {
                "1" => true,
                "да" => true,
                "ход" => true,
                "+" => true,
                "yes" => true,
                "do" => true,
                _ => false,
            };
        }

        private static void TakingCard(List<Card> playersCards, List<Card> cards)
        {
            if (cards.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В колоде больше нет карт!");
                Console.ResetColor();
                return;
            }
            playersCards.Add(cards[0]);
            cards.Remove(cards[0]);
        }


        #region CARDS PRINT
        private static ConsoleColor SetCardSuitColor(Card card)
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
        private static ConsoleColor SetCardNameColor(Card card)
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
        private static void CardPrint(Card card)
        {
            Console.ForegroundColor = SetCardNameColor(card);
            Console.Write($"{card.name} ");
            Console.ForegroundColor = SetCardSuitColor(card);
            Console.Write($"\t{card.suit} ");
            Console.ResetColor();
        }
        
        private static void ShowAllCardPosition(Card[] cards)
        {
            Console.WriteLine();
            for (int i = 0; i < cards.Length; i++)
            {
                CardPrint(cards[i]);
                Console.Write($"\tна позиции ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" \t[ {i} ]\n");
                Console.ResetColor();
            }
        }
        private static void ShowAllPlayersCard(List<Card> cards)
        {
            Console.WriteLine();

            for (int i = 0; i < cards.Count; i++)
            {
                CardPrint(cards[i]);
                Console.Write($"\t{cards[i].points} очков\n");
            }
            Console.WriteLine($"=====[ Всего {PlayerPoints(cards)} очков ]=====");

        }

        #endregion

        #region LESSON TUSKS
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

        #endregion
        
        private static void AllCardToSort(ref Card[] cards)
        {
            cards = cards.OrderBy((c) => c.suit == "Пик")
                        .ThenBy((c) => c.suit == "Креста")
                        .ThenBy((c) => c.suit == "Бубна")
                        .ThenBy(c=>c.toSort).ToArray();
            
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