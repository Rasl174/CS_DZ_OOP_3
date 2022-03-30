using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DZ_OOP_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            List<Player> players = new List<Player> { };

            bool isWork = true;

            Console.WriteLine("Это база данных игронков. Выберите что хотите сделать - ");

            while (isWork)
            {
                database.Menu(ref players ,ref isWork);
            }
        }    
    }

    class Database
    {
        public void Menu(ref List<Player> players, ref bool isWork)
        {
            isWork = true;

            Console.WriteLine("Для вывода списка игроков введите 1");
            Console.WriteLine("Для добавления игрока введите 2");
            Console.WriteLine("Для бана игрока введите 3");
            Console.WriteLine("Для разбана игрока введите 4");
            Console.WriteLine("Для выхода введите 5 или exit");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ShowInfo(players);
                    break;
                case "2":
                    AddPlayer(ref players);
                    break;
                case "3":
                    Ban(players);
                    break;
                case "4":
                    DeBan(players);
                    break;
                case "5":
                case "exit":
                    isWork = false;
                    break;
                default:
                    Console.WriteLine("Ошибка! Введены не верные данные.");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void ShowInfo(List<Player> players)
        {
            Console.Clear();

            if (players.Count > 0)
            {
                foreach (var player in players)
                {
                    Console.WriteLine("Уникальный номер игрока - " + player.NumberID + " его имя - " + player.NickName + " его уровень - " + player.Level + " бан - " + player.IsBanned);
                }
            }
            else
            {
                Console.WriteLine("В базе еще нет игроков!");
            }
        }

        static void Ban(List<Player> players)
        {
            if(players.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Введите уникальный номер игрока для бана - ");
                int userInput = Convert.ToInt32(Console.ReadLine());
                foreach (var player in players)
                {
                    if (player.NumberID == userInput)
                    {
                        player.IsBanned = true;
                    }
                    else
                    {
                        Console.WriteLine("Игрока с таким номером нет!");
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("В базе еще нет игроков!");
            }
        }

        static void DeBan(List<Player> players)
        {
            if (players.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Введите уникальный номер игрока для бана - ");
                int userInput = Convert.ToInt32(Console.ReadLine());
                foreach (var player in players)
                {
                    if (player.NumberID == userInput)
                    {
                        player.IsBanned = false;
                    }
                    else
                    {
                        Console.WriteLine("Игрока с таким номером нет!");
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("В базе еще нет игроков!");
            }
        }

        static void AddPlayer(ref List<Player> players)
        {
            int playerID;
            int playerLevel;

            Console.WriteLine("Введите уникальный номер игрока: ");
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out int userInput) == false)
                {
                    Console.Write("Ввод не корректный введите снова: ");
                }
                else
                {
                    playerID = userInput;
                    break;
                }
            }
            

            Console.WriteLine("Введите имя игрока: ");
            string playerName = Console.ReadLine();

            Console.WriteLine("Введите уникальный номер игрока: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int userInput) == false)
                {
                    Console.Write("Ввод не корректный введите снова: ");
                }
                else
                {
                    playerLevel = userInput;
                    break;
                }
            }
            
            bool isBanned = false;

            List<Player> player = new List<Player> { new Player(playerID, playerName, playerLevel, isBanned) };

            players = player.Union(players).ToList();
        }
    }

    class Player
    {
        public int NumberID { get; private set; }

        public string NickName { get; private set; }

        public int Level { get; private set; }

        public bool IsBanned;

        public Player(int numberID, string nickName, int level, bool isBanned)
        {
            NumberID = numberID;
            NickName = nickName;
            Level = level;
            IsBanned = isBanned;
        }
    }
}