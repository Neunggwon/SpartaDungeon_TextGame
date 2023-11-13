using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace SpartaDungeon_TextGame
{
    internal class Program
    {
        private static Program program;
        public static ItemShop itemShop;
        private static Character player;
        public static List<Item> Inventory = new List<Item>();
        
        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameTitle()
        {
            //Console.WriteLine("╔═╗╔═╗╔═╗╦═╗╔╦╗╔═╗ ");
            //Console.WriteLine("╚═╗╠═╝╠═╣╠╦╝ ║ ╠═╣ ");
            //Console.WriteLine("╚═╝╩  ╩ ╩╩╚═ ╩ ╩ ╩ ");
            //Console.WriteLine("╔╦╗╦ ╦╔╗╔╔═╗╔═╗╔═╗╔╗╔");
            //Console.WriteLine(" ║║║ ║║║║║ ╦║╣ ║ ║║║║");
            //Console.WriteLine("═╩╝╚═╝╝╚╝╚═╝╚═╝╚═╝╝╚╝");
            Console.WriteLine("");

        }
        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅 - 이름, 타입, 공격력, 방어력, 골드, 설명, 입은 상태
            
            Item ironArmor = new Item("무쇠갑옷", "방어력 +5", 0,  5, 500, "무쇠로 만들어져 튼튼한 갑옷입니다.", "");
            Inventory.Add(ironArmor);
            Item oldSword = new Item("낡은 검", "공격력 +5", 5, 0, 500, "쉽게 볼 수 있는 낡은 검입니다.", "");
            Inventory.Add(oldSword);
            Item oldShield = new Item("낡은 방패", "방어력 +5", 0, 3, 300, "쉽게 볼 수 있는 낡은 방패입니다.", "");
            Inventory.Add(oldShield);
            Item potion = new Item("물약", "방어력", 0, 50, 0, "마시기만 해도 상처를 치료합니다.", "");
            Inventory.Add(potion);
        }
        //마을?
        public static void DisplayGameIntro()
        {

            Console.Clear();
            GameTitle();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전입장");
            Console.WriteLine("5. 휴식");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요 : ");

            int input = CheckValidInput(1, 5);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    // 작업해보기
                    DisplayInventory(Inventory);
                    break;
                case 3:
                    ItemShop.DisplayShop();
                    Console.WriteLine("공사중..");
                    break;
                case 4:
                    Console.WriteLine("공사중..");
                    break;
                case 5:
                    Console.WriteLine("공사중..");
                    break;
            }
        }

        //플레이어 정보
        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보르 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);
            switch (input) //나가기
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        //인벤토리
        public static void DisplayInventory(List<Item> Inventory)
        {
            Console.Clear();
            //Console.WriteLine("======================================================================");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t인벤토리");
            Console.ForegroundColor = ConsoleColor.White;
            var table = new ConsoleTable("이름", "능력치", "설명");
            for (int i = 0; i < Inventory.Count; i++)
            {
                table.AddRow($"{Inventory[i].Equip} {Inventory[i].Name} ", $"{Inventory[i].Type}", $"{Inventory[i].Explanation}");
            }
            table.Write();
            Console.WriteLine();
            //Console.ReadKey();
            for (int i = 0; i < Inventory.Count; i++)
                Console.WriteLine($"{i + 1}. {Inventory[i].Name} 장착/해제");
            //Console.WriteLine("1. 착용/해제");
            Console.WriteLine("0. 나가기");
            Console.Write(": ");
            int input = CheckValidInput(0, Inventory.Count);
            
            //switch (input)
            //{
            //    case 0:
            //        DisplayGameIntro();
            //        break;
            //    case 1:
            //        ItemEquip(j - 1);
            //        break;
            //    case 2:
            //        ItemEquip(j - 1);
            //        break;
            //    case 3:
            //        ItemEquip(j - 1);
            //        break;
            //    case 4:
            //        ItemEquip(j - 1);
            //        break;
            //}


            if (input == 0)
            {
                DisplayGameIntro();
            }
            else
            {
                if (!Inventory[input - 1].Equip.Contains("[E]"))
                {
                    Console.WriteLine($"장착중..");
                    Inventory[input - 1].Equip += "[E]";
                    //Inventory[input - 1].Equip.Insert(0, "[E]");
                    //player.Atk += Inventory[1].Atk;
                    if (Inventory[input - 1].Type.Contains("공격력"))
                    {
                        player.Atk += Inventory[input - 1].Atk;
                    }
                    else if (Inventory[input - 1].Type.Contains("방어력"))
                    {
                        player.Def += Inventory[input - 1].Def;
                    }
                }
                else
                {
                    Console.WriteLine($"해제중..");
                    Inventory[input - 1].Equip = "";

                    if (Inventory[input - 1].Type.Contains("공격력"))
                    {
                        player.Atk -= Inventory[input - 1].Atk;
                    }
                    else if (Inventory[input - 1].Type.Contains("방어력"))
                    {
                        player.Def -= Inventory[input - 1].Def;
                    }
                }
            }
            Thread.Sleep(1000);
            DisplayInventory(Inventory);

        }

        // 오류가 있어 일단 주석
        //public static void ItemEquip(int input)
        //{
            
        //    //아이템을 착용하면 이름 앞에[E] 추가하고 플레이어 정보를 조정한다. 
        //    if (!Inventory[input - 1].Equip.Contains("[E]")) //"[E]가 없다면 실행!!"
        //    {
        //        Console.WriteLine($"장착중..");
        //        Inventory[input - 1].Equip += "[E]";
        //        //Inventory[input - 1].Equip.Insert(0, "[E]");
        //        //player.Atk += Inventory[1].Atk;
        //        if (Inventory[input - 1].Type.Contains("공격력"))
        //        {
        //            player.Atk += Inventory[input - 1].Atk;
        //        }
        //        else if (Inventory[input - 1].Type.Contains("방어력"))
        //        {
        //            player.Def += Inventory[input - 1].Def;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine($"해제중..");
        //        Inventory[1].Equip.Remove(0, 2);

        //        if (Inventory[input - 1].Type.Contains("공격력"))
        //        {
        //            player.Atk -= Inventory[input - 1].Atk;
        //        }
        //        else if (Inventory[input - 1].Type.Contains("방어력"))
        //        {
        //            player.Def -= Inventory[input - 1].Def;
        //        }
        //    }
        //    Thread.Sleep(1000);
        //    DisplayInventory(Inventory);
        //}

        //입력값 확인
        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }

    public class ItemShop
    {
        private static Character player;
        private static Program program;
        private static List<Item> ItemShopList = new List<Item>();

        static ItemShop()
        {
            Item steelArmor = new Item("강철갑옷", "방어력 +10", 0, 10, 700, "단단한 강철로 만든 갑옷입니다.", "");
            ItemShopList.Add(steelArmor);
            Item steelSword = new Item("강철 검", "공격력 +10", 10, 0, 1000, "단단한 강철로 만든 검입니다.", "");
            ItemShopList.Add(steelSword);
            Item steelShield = new Item("강철 방패", "방어력 +5", 0, 5, 500, "단단한 강철로 만든 방패입니다.", "");
            ItemShopList.Add(steelShield);
        }

        //상점 기본화면
        public static void DisplayShop()
        {
            Console.Clear();
            //Console.WriteLine("======================================================================");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t상점");
            Console.ForegroundColor = ConsoleColor.White;
            var table = new ConsoleTable("이름", "능력치", "설명", "가격");
            for (int i = 0; i < ItemShopList.Count; i++)
            {
                table.AddRow($"{ItemShopList[i].Name} ", $"{ItemShopList[i].Type}", $"{ItemShopList[i].Explanation}", $"{ItemShopList[i].Gold}G");
            }
            table.Write();
            Console.WriteLine();
            //Console.ReadKey();
            Console.WriteLine($"소지 금액 : {player.Gold}G");
            Console.WriteLine();
            Console.WriteLine("1. 구매하기");
            Console.WriteLine("2. 판매하기");
            Console.WriteLine("0. 나가기");
            Console.Write(": ");
            int input = Program.CheckValidInput(0, 4);
            switch (input)
            {
                case 0:
                    Program.DisplayInventory(Program.Inventory);
                    break;
                case 1:
                    IsBuy();
                    break;
                case 2:
                    IsSell();
                    break;
                case 3:
                    Console.WriteLine("강철 방패");
                    break;
            }
        }

        //아이템 구매
        static void IsBuy()
        {
            int listCount = ItemShopList.Count;
            Console.Clear();
            //Console.WriteLine("======================================================================");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t상점");
            Console.ForegroundColor = ConsoleColor.White;
            var table = new ConsoleTable("이름", "능력치", "설명", "가격");
            for (int i = 0; i < listCount; i++)
            {
                table.AddRow($"{ItemShopList[i].Name} ", $"{ItemShopList[i].Type}", $"{ItemShopList[i].Explanation}", $"{ItemShopList[i].Gold}G");
            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine($"소지중인 골드 : {player.Gold}G");
            //Console.ReadKey();
            for (int i = 0; i < listCount; i++)
                Console.WriteLine($"{i + 1}. {ItemShopList[i].Name}");

            Console.WriteLine("0. 나가기");
            Console.Write(": ");
            int input = Program.CheckValidInput(0, listCount);
            switch (input)
            {
                case 0:
                    DisplayShop();
                    break;
                case 1:
                    //Inventory[1].Name.Insert(0, "[E]");
                    //DisplayInventory();
                    Thread.Sleep(1000);
                    Console.WriteLine($"{ItemShopList[input - 1].Name} 구매하기");
                    break;
                case 2:
                    Console.WriteLine($"{ItemShopList[input - 1].Name} 구매하기");
                    break;
                case 3:
                    Console.WriteLine($"{ItemShopList[input - 1].Name} 구매하기");
                    break;
                case 4:
                    Console.WriteLine("물약");
                    break;
            }

            //if (ItemShopList[1].Equip.Contains(" ")) //"[E]가 없다면 실행!!"
            //{
            //    Console.WriteLine($"구매중..");
            //    ItemShopList[1].Equip.Insert(0, "품절");
            //    //player.Atk += Inventory[1].Atk;
            //}
            //else
            //{
            //    Console.WriteLine($"해제중..");
            //    ItemShopList[1].Equip.Insert(0, "품절");
            //}
            //Thread.Sleep(1000);
            //Console.WriteLine($"완료");
            DisplayShop();
        }

        //인벤토리 아이템 판패
        static void IsSell()
        {
            Console.Clear();
            //Console.WriteLine("======================================================================");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t인벤토리/판매물픔");
            Console.ForegroundColor = ConsoleColor.White;
            var table = new ConsoleTable("이름", "능력치", "설명", "판매금액");
            for (int i = 0; i < Program.Inventory.Count; i++)
            {
                //table.AddRow($"{Inventory[i].Equip} {Inventory[i].Name} ", $"{Inventory[i].Type}", $"{Inventory[i].Explanation}");
                if (Program.Inventory[i].Equip.Contains("[E]"))
                {
                    table.AddRow($"{Program.Inventory[i].Equip} {Program.Inventory[i].Name} ", $"{Program.Inventory[i].Type}", $"{Program.Inventory[i].Explanation}", $"{Program.Inventory[i].Gold}G");
                }
                else
                {
                    table.AddRow($"{Program.Inventory[i].Name} ", $"{Program.Inventory[i].Type}", $"{Program.Inventory[i].Explanation}", $"{Program.Inventory[i].Gold}G");
                }
            }
            table.Write();
            Console.WriteLine();
            //Console.ReadKey();
            for (int i = 0; i < ItemShopList.Count; i++)
                Console.WriteLine($"{i + 1}. {Program.Inventory[i].Name} 판매하기");
            Console.WriteLine("0. 나가기");
            Console.Write(": ");
            int input = Program.CheckValidInput(0, Program.Inventory.Count);
            switch (input)
            {
                case 0:
                    DisplayShop();
                    break;
                case 1:
                    Program.Inventory.Remove(Program.Inventory[input - 1]);
                    ItemShopList.Add(Program.Inventory[input - 1]);
                    player.Gold += Program.Inventory[input - 1].Gold * 1/2;
                    IsSell();
                    break;
                case 2:
                    Program.Inventory.Remove(Program.Inventory[input - 1]);
                    ItemShopList.Add(Program.Inventory[input - 1]);
                    IsSell();
                    break;
                case 3:
                    Program.Inventory.Remove(Program.Inventory[input - 1]);
                    ItemShopList.Add(Program.Inventory[input - 1]);
                    IsSell();
                    break;
                case 4:
                    Console.WriteLine("물약");
                    break;
            }
            while(true)
            {
                if (Program.Inventory[input - 1].Equip.Contains("E"))
                {

                }
            }

            Program.DisplayInventory(Program.Inventory);
            if (ItemShopList[1].Equip.Contains(" ")) //"[E]가 없다면 실행!!"
            {
                Console.WriteLine($"구매중..");
                ItemShopList[1].Equip.Insert(0, "품절");
                //player.Atk += Inventory[1].Atk;
            }
            else
            {
                Console.WriteLine($"해제중..");
                ItemShopList[1].Equip.Insert(0, "품절");
            }
            Thread.Sleep(1000);
            Console.WriteLine($"완료");
            DisplayShop();
        }
    }


    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }

    public class Item
    {
        //enum Type
        //{
        //    Clothes,
        //    Weapon,
        //    Potion,
        //}
        //이름
        public string Name { get; set; }
        public string Type { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Heel { get; }
        public int Gold { get; }
        //설명
        public string Explanation { get; }
        public string Equip { get; set; }

        //이름, 타입, 공격력, 방어력, 금액 , 설명, 장착
        public Item(string name, string type, int atk, int def, int gold, string explanation, string equip)
        {
            Name = name;
            Type = type;
            Atk = atk;
            Def = def;
            Gold = gold;
            Explanation = explanation;
            Equip = equip;
        }
    }
}