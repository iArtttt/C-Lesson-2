using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Less_3
{
    public class Card
    {
        public int Points { get; private set; }
        public int ToSort { get; private set; }
        public string Name { get; }
        public string Suit { get; }
        public Card(string name, string suit)
        {
            Name = name;
            Suit = suit;
            PointsSet(name);
            ValueToSortSet(name);
        }

        private void ValueToSortSet(string name)
        {
            ToSort = name switch
            {
                "Туз" => 1,
                "Король" => 2,
                "Дама" => 3,
                "Валет" => 4,
                "Десять" => 5,
                "Девять" => 6,
                "Восемь" => 7,
                "Семь" => 8,
                "Шесть" => 9,
                _ => 0
            };
        }

        private void PointsSet(string name)
        {
            Points = name switch
            {
                "Туз" => 11,
                "Король" => 4,
                "Дама" => 3,
                "Валет" => 2,
                "Десять" => 10,
                "Девять" => 9,
                "Восемь" => 8,
                "Семь" => 7,
                "Шесть" => 6,
                _ => 0
            };
        }
    }
}
