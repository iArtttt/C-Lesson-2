namespace C__Less_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Black_Jack black_Jack = new();

            Console.WriteLine("Это карточная игра Блэк-Джек или же как её называют 21");
            char ch;
            Console.WriteLine("Это сообщение будет лишь раз: \nНе желаете прочитать правила?\n( ( + ) -> Да, ( остальные символы ) -> Нет )");
            ch = Console.ReadKey().KeyChar;
            if (ch == '+')
                Black_Jack.Rules();

            do
            {
                Console.ResetColor();
                black_Jack.BlackJackGame();


                Console.Write("Если вы хотите закончить нажмите ( Q ) ");
                ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (ch != 'q');

            black_Jack.GamesResults();
        }

    }
    
}