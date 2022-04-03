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
            List<Player> players = new List<Player> { };
            Database database = new Database (players);
            
            Console.WriteLine("Это база данных игронков. Выберите что хотите сделать - ");

            database.Work(players);
            
        }    
    }

    class Database
    {
        private List<Player> _players;

        public Database(List<Player> players)
        {
            _players = players;
        }

        public void Work(List<Player> players)
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Для вывода списка игроков введите 1");
                Console.WriteLine("Для добавления игрока введите 2");
                Console.WriteLine("Для бана игрока введите 3");
                Console.WriteLine("Для разбана игрока введите 4");
                Console.WriteLine("Для удаления игрока введите 5");
                Console.WriteLine("Для выхода введите 6 или exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowInfo(players);
                        break;
                    case "2":
                        AddPlayer(players);
                        break;
                    case "3":
                        Ban();
                        break;
                    case "4":
                        DeBan();
                        break;
                    case "5":
                        Delete();
                        break;
                    case "6":
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
        }

        private void Ban()
        {
            if (_players.Count > 0)
            {
                foreach (var player in _players)
                {
                    player.Ban(_players);
                    break;
                }
            }
            else
            {
                Console.WriteLine("В базе нет игроков!");
            }
        }

        private void DeBan()
        {
            if (_players.Count > 0)
            {
                foreach (var player in _players)
                {
                    player.DeBan(_players);
                    break;
                }
            }
            else
            {
                Console.WriteLine("В базе нет игроков!");
            }
        }

        private void ShowInfo(List<Player> players)
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

        private void Delete()
        {
            bool correctInput = false;
            if (_players.Count > 0)
            {
                Console.WriteLine("Введите уникальный номер игрока для удаления: ");
                while (correctInput == false)
                {
                    if (int.TryParse(Console.ReadLine(), out int userInput) == false)
                    {
                        Console.Write("Ввод не корректный введите снова: ");
                    }
                    else
                    {
                        foreach (var player in _players)
                        {
                            if (player.NumberID == userInput)
                            {
                                correctInput = true;

                                Console.WriteLine("Игрок " + player.NickName + " удален");
                                _players.Remove(player);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("У игрока - " + player.NickName + " другой номер");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("В базе нет игроков!");
            }
        }

        private void AddPlayer(List<Player> players)
        {
            int playerID = 0;
            int playerLevel = 0;
            bool correctInput = false;

            Console.WriteLine("Введите уникальный номер игрока: ");
            while (correctInput == false)
            {
                if (int.TryParse(Console.ReadLine(), out int userInput) == false)
                {
                    Console.Write("Ввод не корректный введите снова: ");
                }
                else
                {
                    playerID = userInput;
                    correctInput = true;

                    foreach (var player in players)
                    {
                        if (player.NumberID == userInput)
                        {
                            Console.WriteLine("Такой игрок уже есть повторите ввод: ");
                            correctInput = false;
                        }
                    }
                }
            }

            Console.WriteLine("Введите имя игрока: ");
            string playerName = Console.ReadLine();

            correctInput = false;

            Console.WriteLine("Введите уровень игрока: ");
            while (correctInput == false)
            {
                if (int.TryParse(Console.ReadLine(), out int userInput) == false)
                {
                    Console.Write("Ввод не корректный введите снова: ");
                }
                else
                {
                    playerLevel = userInput;
                    correctInput = true;
                }
            }
            
            bool isBanned = false;

            players.Add(new Player(playerID, playerName, playerLevel, isBanned));
        }
    }

    class Player
    {
        public int NumberID { get; private set; }

        public string NickName { get; private set; }

        public int Level { get; private set; }

        public bool IsBanned { get; private set; }

        public Player(int numberID, string nickName, int level, bool isBanned)
        {
            NumberID = numberID;
            NickName = nickName;
            Level = level;
            IsBanned = isBanned;
        }

        public void Ban(List<Player> players)
        {
            bool correctInput = false;

            Console.Clear();

            while (correctInput == false)
            {
                Console.WriteLine("Введите уникальный номер игрока для бана - ");

                if (int.TryParse(Console.ReadLine(), out int userInput) == false)
                {
                    Console.Write("Ввод не корректный введите снова: ");
                }
                else
                {
                    correctInput = true;

                    foreach (var player in players)
                    {
                        if (player.NumberID == userInput)
                        {
                            player.IsBanned = true;
                            Console.WriteLine("Игрок - " + player.NickName + " зазбанен");
                        }
                        else
                        {
                            Console.WriteLine("У игрока - " + player.NickName + " другой номер");
                        }
                    }
                }
            }
        }

        public void DeBan(List<Player> players)
        {
            bool correctInput = false;

            Console.Clear();

            while (correctInput == false)
            {
                Console.WriteLine("Введите уникальный номер игрока для бана - ");

                if (int.TryParse(Console.ReadLine(), out int userInput) == false)
                {
                    Console.Write("Ввод не корректный введите снова: ");
                }
                else
                {
                    correctInput = true;

                    foreach (var player in players)
                    {
                        if (player.NumberID == userInput)
                        {
                            player.IsBanned = false;
                            Console.WriteLine("Игрок - " + player.NickName + " разбанен");
                        }
                        else
                        {
                            Console.WriteLine("У игрока - " + player.NickName + " другой номер");
                        }
                    }
                }
            }
        }   
    }   
}