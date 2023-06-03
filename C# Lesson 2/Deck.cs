using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Less_3
{
    internal class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck() => CardCreate();

        private void CardCreate()
        {
            Cards = new List<Card>()
            {
               { new Card("Туз",    "Чирва")  },
               { new Card("Король", "Чирва")  },
               { new Card("Дама",   "Чирва")  },
               { new Card("Валет",  "Чирва")  },
               { new Card("Десять", "Чирва")  },
               { new Card("Девять", "Чирва")  },
               { new Card("Восемь", "Чирва")  },
               { new Card("Семь",   "Чирва")  },
               { new Card("Шесть",  "Чирва")  },
               { new Card("Туз",    "Бубна")  },
               { new Card("Король", "Бубна")  },
               { new Card("Дама",   "Бубна")  },
               { new Card("Валет",  "Бубна")  },
               { new Card("Десять", "Бубна")  },
               { new Card("Девять", "Бубна")  },
               { new Card("Восемь", "Бубна")  },
               { new Card("Семь",   "Бубна")  },
               { new Card("Шесть",  "Бубна")  },
               { new Card("Туз",    "Креста") },
               { new Card("Король", "Креста") },
               { new Card("Дама",   "Креста") },
               { new Card("Валет",  "Креста") },
               { new Card("Десять", "Креста") },
               { new Card("Девять", "Креста") },
               { new Card("Восемь", "Креста") },
               { new Card("Семь",   "Креста") },
               { new Card("Шесть",  "Креста") },
               { new Card("Туз",    "Пик")    },
               { new Card("Король", "Пик")    },
               { new Card("Дама",   "Пик")    },
               { new Card("Валет",  "Пик")    },
               { new Card("Десять", "Пик")    },
               { new Card("Девять", "Пик")    },
               { new Card("Восемь", "Пик")    },
               { new Card("Семь",   "Пик")    },
               { new Card("Шесть",  "Пик")    }
            };                                                                                                                                        { new Card("Шесть",   "Пик")   ;
            }
        }
        public void SearchOfSpadesPosition()
        {
            Console.WriteLine();
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Suit == "Пик")
                    Console.WriteLine($"{Cards[i].Name} {Cards[i].Suit} на позиции \t[ {i} ]");
            }
        }

        public void AllSpadesToBegin()
        {
            int insertToPosition = 0;
            Card temp;
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Suit == "Пик")
                {
                    temp = Cards[i];
                    Cards[i] = Cards[insertToPosition];
                    Cards[insertToPosition] = temp;
                    insertToPosition++;
                }
            }

        }

        public void SearchOfAces()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Name == "Туз")
                    Console.WriteLine($"{Cards[i].Name} {Cards[i].Suit} on position \t[ {i} ]");

            }
        }

        public void AllCardToSort()
        {
            Cards = Cards.OrderBy((c) => c.Suit == "Пик")
                        .ThenBy((c) => c.Suit == "Креста")
                        .ThenBy((c) => c.Suit == "Бубна")
                        .ThenBy(c => c.ToSort).ToList();

        }
        public void CardsShuffle()
        {
            Card temp;
            Random random = new Random();

            int numberFromRandom;
            int amountOfMixing = 0;
            int totalAmountOfMixing = random.Next(2, 6);

            do
            {
                for (int i = 0; i < Cards.Count; i++)
                {
                    numberFromRandom = random.Next(0, Cards.Count);
                    temp = Cards[numberFromRandom];
                    Cards[numberFromRandom] = Cards[i];
                    Cards[i] = temp;
                }
            } while (amountOfMixing++ < totalAmountOfMixing);
        }

        public void ShowAllCards()
        {
            foreach (var card in Cards)
            {
                CardPrint(card);
            }
        }
        public void ShowAllCardPosition()
        {
            Console.WriteLine();
            for (int i = 0; i < Cards.Count; i++)
            {
                CardPrint(Cards[i]);
                Console.Write($"\tна позиции ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" \t[ {i} ]\n");
                Console.ResetColor();
            }
        }
        private static ConsoleColor SetCardSuitColor(Card card)
        {
            return card.Suit switch
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
            return card.Name switch
            {
                "Туз" => Console.ForegroundColor = ConsoleColor.Yellow,
                "Король" => Console.ForegroundColor = ConsoleColor.Yellow,
                "Дама" => Console.ForegroundColor = ConsoleColor.Yellow,
                "Валет" => Console.ForegroundColor = ConsoleColor.Yellow,
                _ => Console.ForegroundColor = ConsoleColor.DarkYellow,
            };
        }
        public static void CardPrint(Card card)
        {
            Console.ForegroundColor = SetCardNameColor(card);
            Console.Write($"{card.Name} ");
            Console.ForegroundColor = SetCardSuitColor(card);
            Console.Write($"\t{card.Suit} ");
            Console.ResetColor();
        }
    }
}