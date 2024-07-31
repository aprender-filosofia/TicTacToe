using System;

namespace TicTacToe
{
    class App
    {
        public static void Main(string[] args)
        {
            App app = new App();
            Table tb = new Table();
            app.GameLoop(tb.IndexTable);
        }

        public void GameLoop(int[] table)
        {
            Player playerX = new Player();
            Player playerY = new Player();

            while (true)
            {
                RenderTable(table);
                Console.Write("Add value for X: ");
                int posX = Convert.ToInt16(Console.ReadLine());
                table = playerX.Add(table, posX, 1);
                if (CheckWon(table, "X"))
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    RenderTable(table);
                    Console.WriteLine("-----------------------------------------------------------");
                    break;
                }

                Console.Write("Add value for Y: ");
                int posY = Convert.ToInt16(Console.ReadLine());
                table = playerX.Add(table, posY, 2);
                if (CheckWon(table, "O"))
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    RenderTable(table);
                    Console.WriteLine("-----------------------------------------------------------");
                    break;
                }
            }
        }

        public void RenderTable(int[] table)
        {
            for (int i = 0; i < table.Length; i++)
            {
                switch (table[i])
                {
                    case 0:
                        Console.Write("|   |");
                        break;
                    case 1:
                        Console.Write("| X |");
                        break;
                    case 2:
                        Console.Write("| O |");
                        break;
                }

                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }

        public bool CheckWon(int[] table, string playerName)
        {
            string player = playerName;

            bool isLot = TableIsLot(table);

            if (isLot)
            {
                Console.WriteLine("Draw");
                return true;
            }

            for (int j = 1; j < 3; j++)
            {
                for (int i = 0; i < table.Length; i++)
                {
                    // Lines
                    if (i == 0 || i == 3 || i == 6)
                    {
                        if (table[i] == j && table[i + 1] == j && table[i + 2] == j)
                        {
                            Console.WriteLine($"Won {player}");
                            return true;
                        }
                    }
                    // Collum
                    if (i == 0 || i == 1 || i == 2)
                    {
                        if (table[i] == j && table[i + 3] == j && table[i + 6] == j)
                        {
                            Console.WriteLine($"Won {player}");
                            return true;
                        }
                    }

                    // Diagonal
                    if (i == 0 || i == 2)
                    {
                        if (i == 0 && table[i] == j && table[i + 4] == j && table[i + 8] == j)
                        {
                            Console.WriteLine($"Won {player}");
                            return true;
                        }

                        if (i == 2 && table[i] == j && table[i + 2] == j && table[i + 4] == j)
                        {
                            Console.WriteLine($"Won {player}");
                            return true;
                        }

                        return false;
                    }
                }
            }
            return false;
        }

        bool TableIsLot(int[] table)
        {
            int cont = 0;
            foreach (int i in table)
            {
                if (i != 0)
                {
                    cont++;
                }
            }

            if (cont >= table.Length)
            {
                return true;
            }
            return false;
        }
        class Table
        {
            public int[] IndexTable = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        class Player
        {
            public int[] Add(int[] table, int pos, int num)
            {
                int[] modTable = table;

                if (table[pos] == 0)
                {
                    modTable[pos] = num;
                }
                else
                {
                    Player player = new Player();
                    Console.Write("Value error, try again: ");
                    pos = Convert.ToInt16(Console.ReadLine());
                    player.Add(table, pos, num);
                }

                return modTable;
            }
        }
    }
}