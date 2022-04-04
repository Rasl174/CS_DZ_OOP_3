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

            database.Work();
        }    
    }

    class Database
    {
        private List<Player> _players;

        public Database(List<Player> players)
        {
            _players = players;
        }

        public void Work()
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
                        ShowInfo();
                        break;
                    case "2":
                        AddPlayer();
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

        private bool TryGetPlayer(out Player player)
        {
            player = null;

            if (_players.Count > 0)
            {
                bool correctInput = false;

                Console.Clear();

                while (correctInput == false)
                {
                    Console.WriteLine("Введите уникальный номер игрока - ");

                    if (int.TryParse(Console.ReadLine(), out int userInput) == false)
                    {
                        Console.Write("Ввод не корректный введите снова: ");
                    }
                    else
                    {
                        correctInput = true;

                        foreach (var getPlayer in _players)
                        {
                            if (getPlayer.NumberID == userInput)
                            {
                                player = getPlayer;
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("В базе нет игроков!");
                return false;
            }
        }

        private void Ban()
        {
            if(TryGetPlayer(out Player player) == true)
            {
                player.Ban();
                Console.WriteLine("Игрок - " + player.NickName + " забанен.");
            }
        }

        private void DeBan()
        {
            if(TryGetPlayer(out Player player) == true)
            {
                player.DeBan();
                Console.WriteLine("Игрок - " + player.NickName + " разбанен.");
            }
        }

        private void ShowInfo()
        {
            Console.Clear();

            if (_players.Count > 0)
            {
                foreach (var player in _players)
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
            if(TryGetPlayer(out Player player) == true)
            {
               _players.Remove(player);
                Console.WriteLine("Игрок - " + player.NickName + " удален.");
            }
        }

        private void AddPlayer()
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

                    foreach (var player in _players)
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

            Console.WriteLine("Введите уровень игрока не больше 90го : ");
            while (correctInput == false)
            {
                if (int.TryParse(Console.ReadLine(), out int userInput) == false || userInput < 0 || userInput > 90)
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

            _players.Add(new Player(playerID, playerName, playerLevel, isBanned));
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

        public void Ban()
        {
            IsBanned = true;
        }

        public void DeBan()
        {
            IsBanned = true;
        }   
    }   
}