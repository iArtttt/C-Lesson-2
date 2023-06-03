using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Less_3
{
    internal class Black_Jack
    {
        private readonly List<string> GameWinnersList = new List<string>();

        
        public Black_Jack() 
        {
            
        }

        public void BlackJackGame()
        {
            Deck cardsDeck = new Deck();

            cardsDeck.CardsShuffle();

            Player playersCards = new();
            Player computersCards = new();
            
            Console.WriteLine("Кто будет ходить первый? ( Вы или ИИ )");
            Console.WriteLine("Вы = 1, ИИ = 2 (В случае неверного символа или пустого поля игру начинает ИИ)");
            char whosTurn = Console.ReadKey().KeyChar;

            playersCards.TakingCard(cardsDeck.Cards);
            playersCards.TakingCard(cardsDeck.Cards);
            computersCards.TakingCard(cardsDeck.Cards);
            computersCards.TakingCard(cardsDeck.Cards);

            if (playersCards.PlayerPoints() >= 21 || computersCards.PlayerPoints() >= 21)
                WhoIsTheWinner(playersCards, computersCards);
            else
            {
                if (whosTurn == '1')
                {
                    PlayersTurn(playersCards, cardsDeck.Cards);
                    ComputersTurn(computersCards, cardsDeck.Cards);
                }
                else
                {
                    ComputersTurn(computersCards, cardsDeck.Cards);
                    PlayersTurn(playersCards, cardsDeck.Cards);
                }
                Console.Write($"У вас {playersCards.PlayerPoints()} очков\t|\tУ ИИ {computersCards.PlayerPoints()}  очков\n");
                WhoIsTheWinner(playersCards, computersCards);
            }
            Winner();

            cardsDeck.AllCardToSort();
        }
        public void GamesResults()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n====[ Статистика всех сыграных игр ]====\n");
            Console.ResetColor();
            
            for (int i = 0; i < GameWinnersList.Count; i++)
            {
                Console.ResetColor();
                Console.Write($" {i + 1} игра: ");
                Console.ForegroundColor = GameWinnersList[i] switch
                {
                    "Вы победили!" => ConsoleColor.Green,
                    "ИИ победил!" => ConsoleColor.Red,
                    "Ничья" => ConsoleColor.White,
                    _ => ConsoleColor.Gray
                };
                Console.Write($"{GameWinnersList[i]}\n");
            }
            Console.ResetColor();

        }
        private void Winner()
        {
            Console.ForegroundColor = GameWinnersList[GameWinnersList.Count - 1] switch
            {
                "Вы победили!" => ConsoleColor.Green,
                "ИИ победил!" => ConsoleColor.Red,
                "Ничья" => ConsoleColor.White,
                _ => ConsoleColor.Gray
            };
            Console.WriteLine(GameWinnersList[GameWinnersList.Count - 1]);
            Console.ResetColor();
        }
        private void WhoIsTheWinner(Player playersCards, Player computersCards)
        {
            int playersPoints = playersCards.PlayerPoints();
            int computersPoints = computersCards.PlayerPoints();

            if (playersPoints == computersPoints)
            {
                GameWinnersList.Add("Ничья");
                return;
            }
            if (playersCards.Arm.All((p) => p.Name == "Туз") && computersCards.Arm.All((p) => p.Name == "Туз"))
            {
                GameWinnersList.Add("Ничья");
                return;
            }
            if (playersCards.Arm.All((p) => p.Name == "Туз") && computersPoints == 21)
            {
                GameWinnersList.Add("Ничья");
                return;
            }
            if (computersCards.Arm.All((p) => p.Name == "Туз") && playersPoints == 21)
            {
                GameWinnersList.Add("Ничья");
                return;
            }
            if (playersCards.Arm.All((p) => p.Name == "Туз") || playersPoints == 21)
            {
                GameWinnersList.Add("Вы победили!");
                return;
            }
            if (computersCards.Arm.All((p) => p.Name == "Туз") || computersPoints == 21)
            {
                GameWinnersList.Add("ИИ победил!");
                return;
            }
            if (playersPoints <= 21 && computersPoints > 21)
            {
                GameWinnersList.Add("Вы победили!");
                return;
            }
            if (computersPoints <= 21 && playersPoints > 21)
            {
                GameWinnersList.Add("ИИ победил!");
                return;
            }
            if (playersPoints < 21 && computersPoints < 21 && playersPoints > computersPoints)
            {
                GameWinnersList.Add("Вы победили!");
                return;
            }
            if (playersPoints < 21 && computersPoints < 21 && playersPoints < computersPoints)
            {
                GameWinnersList.Add("ИИ победил!");
                return;
            }
            if (playersPoints > 21 && computersPoints > 21 && playersPoints < computersPoints)
            {
                GameWinnersList.Add("Вы победили!");
                return;
            }
            if (playersPoints > 21 && computersPoints > 21 && playersPoints > computersPoints)
            {
                GameWinnersList.Add("ИИ победил!");
                return;
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
        private static void ComputersTurn(Player computersCards, List<Card> cards)
        {
            int i = 0;
            Random random = new Random();
            do
            {
                if (computersCards.PlayerPoints() <= 12)
                {
                    Console.WriteLine("ИИ берёт карту");
                    computersCards.TakingCard(cards);
                    if (computersCards.PlayerPoints() >= 20)
                        break;
                }
                if (computersCards.PlayerPoints() < 18 && random.Next(0, 5) < 4)
                {
                    Console.WriteLine("ИИ берёт карту");
                    computersCards.TakingCard(cards);
                    if (computersCards.PlayerPoints() >= 20)
                        break;
                }
                if (computersCards.PlayerPoints() >= 19 && random.Next(0, 9) > 5)
                {
                    Console.WriteLine("ИИ берёт карту");
                    computersCards.TakingCard(cards);
                    if (computersCards.PlayerPoints() >= 20)
                        break;
                }

            } while (i++ != 5);


            Console.WriteLine("ИИ завершил свой ход");
        }

        private static void PlayersTurn(Player playersCards, List<Card> cards)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Ваш ход");
            Console.ResetColor();
            playersCards.ShowAllPlayersCard();
            Console.Write($"Хотите ещё карту?( yes, do, +, ход, да, 1): ");
            string wantCard = Console.ReadLine();

            while (WantOneMoreCard(wantCard))
            {
                playersCards.TakingCard(cards);
                playersCards.ShowAllPlayersCard();

                Console.Write($"Хотите ещё карту?( yes, do, +, ход, да, 1): ");
                wantCard = Console.ReadLine();
            }

        }

        public static void Rules()
        {
            Console.Write($"\nЭто сильно упрощённая версия оригинального ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Блэк-Джека ");
            Console.ResetColor();
            Console.Write($"или как её ещё называют ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"( 21 )\n");
            Console.ResetColor();
            Console.Write($"Суть игры набрать ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"21 ");
            Console.ResetColor();
            Console.Write($"очко. Однако главная цель обыграть диллера\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n\t\tОчки распределяються так:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tТуз ");
            Console.ResetColor();
            Console.Write($"- 11 очков\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tКороль ");
            Console.ResetColor();
            Console.Write($"- 4 очка\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tДама ");
            Console.ResetColor();
            Console.Write($"- 3 очка\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tВалет ");
            Console.ResetColor();
            Console.Write($"- 2 очка\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"\tОстальные карты по наминалу\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\nВ начале вы решаете кто будет ходить первым \n" +
                            $"и доберает по 1 карте по необходимости,\n" +
                            $"затем ход переходит следующему игроку и так далее \n" +
                            $"пока все не скажут хватит\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n\t\tЗатем идёт подсчёт очков:\n");
            Console.ResetColor();
            Console.Write($"\tЕсли у вас 21 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Вы победили!\n");
            Console.ResetColor();
            Console.Write($"\tЕсли у вас и соперника 21 у вас ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Ничья\n");
            Console.ResetColor();
            Console.Write($"\tЕсли у вас больше 21 ( перебор ), а у соперника 21 или маньше ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Вы проиграли!\n");
            Console.ResetColor();
            Console.Write($"\tЕсли ни у вас, ни у соперника очки не привысили 21 побеждает тот у кого очков больше\n");
            Console.Write($"\tЕсли у вас и у соперника очки привысили ( перебор ) 21 побеждает тот у кого очков меньше\n");
            Console.Write($"\nВ этой игре вы будите играть против диллера вместо которого выступает компьютер\n");
            Console.Write($"\nВот собственно и все правила, начнём игру, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Удачи! \n");
            Console.ResetColor();
            
        }
    }
}
