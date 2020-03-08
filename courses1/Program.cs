using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace courses1
{

    class Program
    {
        delegate void result();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This application is crated to do the predictions for basketball match.");
            Console.WriteLine("Enter the date of the match(dd(d)/mm(m)/yyyy(yy)):");
            string date = Console.ReadLine();
            string pattern = @"\b(?<day>\d{1,2})/(?<month>\d{1,2})/(?<year>\d{2,4})\b";
            while (true) {
                if (!Regex.IsMatch(date, pattern))
                {
                    Console.WriteLine("Incorrect format of date!");
                    date = Console.ReadLine();
                }
                else {
                    break;
                }
            }
            Console.WriteLine("Enter The name of every team(the game consist of two teams only):");
            string name_team1 = Console.ReadLine();
            string name_team2 = Console.ReadLine();
            Console.Clear();
            basketball_match m = new basketball_match(date, name_team1, name_team2)
            {
                SetDate = date,
                SetTeam1 = name_team1,
                SetTeam2 = name_team2
            };

            ////INFORMATION ABOUT FIRST TEAM////
            Console.WriteLine("ENTER INFORMATION ABOUT TEAM {0}",name_team1);
            Cherasteristic_of_team team1 = new Cherasteristic_of_team();
            int[,] arr1 = new int[5, 2]; 
            double res_pl_t1=team1.SetPlayersCheracteristic(arr1);
            Console.WriteLine("Enter amount of games and age of your coach(from 0 to 100):");
            int am1 = int.Parse(Console.ReadLine());
            int age1 = int.Parse(Console.ReadLine());
            Coach c1 = new Coach(am1,age1);
            double mn1=c1.Mnozh(am1, age1);
            c1.SetAge = age1;
            c1.SetGames = am1;
            Console.Clear();

            ////INFORMATION ABOUT SECOND TEAM////
            Console.WriteLine("ENTER INFORMATION ABOUT TEAM {0}", name_team2);
            Cherasteristic_of_team team2 = new Cherasteristic_of_team();
            int[,] arr2 = new int[5, 2];
            double res_pl_t2 = team2.SetPlayersCheracteristic(arr2);
            Console.WriteLine("Enter amount of games and age of your coach:");
            int am2 = int.Parse(Console.ReadLine());
            int age2 = int.Parse(Console.ReadLine());
            Coach c2 = new Coach(am2, age2);
            double mn2= c2.Mnozh(am2, age2);
            c2.SetAge = age2;
            c2.SetGames = am2;
            Console.Clear();

            Draw d1 = new Draw();
            d1.DrawTable(m, arr1, arr2, c1, c2);
            
            result r;
            if (res_pl_t1 * mn1 > res_pl_t2 * mn2)   //победа второй
            {
                
                r = Win1;
                r();
            }
            else {
                if (res_pl_t1 * mn1 < res_pl_t2 * mn2)
                {
                    r = Win2;
                    r();
                }
                else {
                    Console.WriteLine("DRAW! Congratulations to every team!");
                    Console.ReadLine();
                }
            }
            void Win1() {
                Console.WriteLine("Team {0} wins! Congratulations!", m.GetTeam1());
                d1.DrawTable(m,c1, arr1);

            }
            void Win2() {
                Console.WriteLine("Team {0} wins! Congratulations!", m.GetTeam2());
                d1.DrawTable(m, c2, arr2);

            }
        }
        
        //Console.WriteLine(String.Format("|{0,25}|{1,50}|","Date" , basketball_match));        
        
        
        

    }

    class Draw
    {

        public void DrawTable(basketball_match m, Coach c1,int[,]arr1)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(string.Format("|{0,15}|{1,31}|", "Teams", m.GetTeam1()));
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(string.Format("|{0,15}|{1,15}|{2,15}|", "     ", "Games", "Age"));
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(string.Format("|{0,15}|{1,15}|{2,15}|", "Coach", c1.GetGames(), c1.GetAge()));
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(string.Format("|{0,15}|{1,15}|{2,15}|", "     ", "Skill", "Lucky"));
            Console.WriteLine("-------------------------------------------------");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(string.Format("|{0,15}|{1,15}|{2,15}|", "Player", arr1[i, 0], arr1[i, 1]));
                Console.WriteLine("-------------------------------------------------");
            }
            Console.WriteLine("Enter something to exit the program...");
            Console.ReadLine();
        }
        public void DrawTable(basketball_match m, int[,] arr1, int[,] arr2, Coach c1, Coach c2)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("|{0,15}|{1,64}|", "Date", m.GetDate()));
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("|{0,15}|{1,31}||{2,31}|", "Teams", m.GetTeam1(), m.GetTeam2()));
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("|{0,15}|{1,15}|{2,15}||{3,15}|{4,15}|", "     ", "Games", "Age", "Games", "Age"));
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("|{0,15}|{1,15}|{2,15}||{3,15}|{4,15}|", "Coach", c1.GetGames(), c1.GetAge(), c2.GetGames(), c2.GetAge()));
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("|{0,15}|{1,15}|{2,15}||{3,15}|{4,15}|", "     ", "Skill", "Lucky", "Skill", "Lucky"));
            Console.WriteLine("----------------------------------------------------------------------------------");

            for (int p = 0; p < 5; p++)
            {
                Console.WriteLine(string.Format("|{0,15}|{1,15}|{2,15}||{3,15}|{4,15}|", "Player", arr1[p, 0], arr1[p, 1], arr2[p, 0], arr2[p, 1]));
                Console.WriteLine("----------------------------------------------------------------------------------");
            }
            Console.WriteLine("Enter something to see the result...");
            Console.ReadLine();
            Console.Clear();
        }
    }
    class Coach
    {
        int amount_of_games, age;
        public int SetGames
        {
            get
            {
                return amount_of_games;
            }
            set
            {
                amount_of_games = value;
            }
        }
        public int SetAge
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public Coach(int amount_of_games, int age)
        {
            amount_of_games = this.amount_of_games;
            age = this.age;
        }
        public double Mnozh(int amount_of_games, int age)
        {
            return age * amount_of_games;
        }
        ////чем больше множ тем хуже
        public int GetGames()
        {
            return amount_of_games;
        }
        public int GetAge()
        {
            return age;
        }
    }
    class basketball_match
    {
        string date, name_of_team1, name_of_team2;
        public string SetDate
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public string SetTeam1
        {
            get
            {
                return name_of_team1;
            }
            set
            {
                name_of_team1 = value;
            }
        }
        public string SetTeam2
        {
            get
            {
                return name_of_team2;
            }
            set
            {
                name_of_team2 = value;
            }
        }
        public basketball_match(string date, string name_of_team1, string name_of_team2)
        {
            date = this.date;
            name_of_team1 = this.name_of_team1;
            name_of_team2 = this.name_of_team2;
        }
        public string GetDate()
        {
            return date;
        }
        public string GetTeam1()
        {
            return name_of_team1;
        }
        public string GetTeam2()
        {
            return name_of_team2;
        }
    }
    class Cherasteristic_of_team
    {

        public double SetPlayersCheracteristic(int[,] arr)
        {
            List<double> cherasteristic_of_player = new List<double>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter skill and lucky of {0} player(must be from 0 to 100):", i + 1);
                int skill = int.Parse(Console.ReadLine());
                arr[i, 0] = skill;
                int lucky = int.Parse(Console.ReadLine());
                arr[i, 1] = lucky;
                double a = (skill + lucky) / 2;
                cherasteristic_of_player.Add(a);
            }

            double sum = 0;
            foreach (double i in cherasteristic_of_player)
            {
                sum += i;
            }
            return sum;
        }


    }
}
