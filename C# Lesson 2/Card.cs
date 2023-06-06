using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Less_3
{
    public class Card
    {
        public CardName_Points Name { get; }
        public CardSuit Suit { get; }
        public Card(CardName_Points name, CardSuit suit)
        {
            Name = name;
            Suit = suit;
        }
    }
}
