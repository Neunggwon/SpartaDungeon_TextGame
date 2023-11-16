using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace SpartaDungeon_TextGame
{
    //test_1
    //test_3
    internal class Program
    {
        private static Program program;
        public static ItemShop itemShop;
        private static Character player;
        public static List<Item> Inventory = new List<Item>();
        public static List<Item> Weapon = new List<Item>();
        public static List<Item> Armor = new List<Item>();
        public static List<Item> SecondaryWeapon = new List<Item>();
        //test2

        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameTitle()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine(" $$$$$$\\  $$$$$$$\\   $$$$$$\\  $$$$$$$\\ $$$$$$$$\\  $$$$$$\\             \r\n$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\\\__$$  __|$$  __$$\\            \r\n$$ /  \\__|$$ |  $$ |$$ /  $$ |$$ |  $$ |  $$ |   $$ /  $$ |           \r\n\\$$$$$$\\  $$$$$$$  |$$$$$$$$ |$$$$$$$  |  $$ |   $$$$$$$$ |           \r\n \\____$$\\ $$  ____/ $$  __$$ |$$  __$$<   $$ |   $$  __$$ |           \r\n$$\\   $$ |$$ |      $$ |  $$ |$$ |  $$ |  $$ |   $$ |  $$ |           \r\n\\$$$$$$  |$$ |      $$ |  $$ |$$ |  $$ |  $$ |   $$ |  $$ |           \r\n \\______/ \\__|      \\__|  \\__|\\__|  \\__|  \\__|   \\__|  \\__|\r\n$$$$$$$\\  $$\\   $$\\ $$\\   $$\\  $$$$$$\\  $$$$$$$$\\  $$$$$$\\  $$\\   $$\\ \r\n$$  __$$\\ $$ |  $$ |$$$\\  $$ |$$  __$$\\ $$  _____|$$  __$$\\ $$$\\  $$ |\r\n$$ |  $$ |$$ |  $$ |$$$$\\ $$ |$$ /  \\__|$$ |      $$ /  $$ |$$$$\\ $$ |\r\n$$ |  $$ |$$ |  $$ |$$ $$\\$$ |$$ |$$$$\\ $$$$$\\    $$ |  $$ |$$ $$\\$$ |\r\n$$ |  $$ |$$ |  $$ |$$ \\$$$$ |$$ |\\_$$ |$$  __|   $$ |  $$ |$$ \\$$$$ |\r\n$$ |  $$ |$$ |  $$ |$$ |\\$$$ |$$ |  $$ |$$ |      $$ |  $$ |$$ |\\$$$ |\r\n$$$$$$$  |\\$$$$$$  |$$ | \\$$ |\\$$$$$$  |$$$$$$$$\\  $$$$$$  |$$ | \\$$ |\r\n\\_______/  \\______/ \\__|  \\__| \\______/ \\________| \\______/ \\__|  \\__|");
            Console.WriteLine("=======================================================================");
        }
        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅 - 이름, 타입, 능력, 공격력, 방어력, 골드, 설명, 입은 상태
            Item ironArmor = new Item("무쇠갑옷", "방어구", "방어력 +5", 0, 5, 500, "무쇠로 만들어져 튼튼한 갑옷입니다.", "");
            Inventory.Add(ironArmor);
            Item oldSword = new Item("낡은 검", "무기", "공격력 +5", 5, 0, 500, "쉽게 볼 수 있는 낡은 검입니다.", "");
            Inventory.Add(oldSword);
            Item oldShield = new Item("낡은 방패", "보조무기", "방어력 +3", 0, 3, 300, "쉽게 볼 수 있는 낡은 방패입니다.", "");
            Inventory.Add(oldShield);
            //Item potion = new Item("물약", "방어력", 0, 50, 0, "마시기만 해도 상처를 치료합니다.", "");

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
        public static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
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
        public static void DisplayInventoryInfo(List<Item> Inventory)
        {
            Console.Clear();
            //Console.WriteLine("======================================================================");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t인벤토리");
            Console.ForegroundColor = ConsoleColor.White;
            var table = new ConsoleTable("이름", "능력치", "설명");
            for (int i = 0; i < Inventory.Count; i++)
            {
                table.AddRow($"{Inventory[i].Equip} {Inventory[i].Name} ", $"{Inventory[i].Ability}", $"{Inventory[i].Explanation}");
            }
            table.Write();
            Console.WriteLine();
            //Console.ReadKey();
            
        }

        //인벤토리
        public static void DisplayInventory(List<Item> Inventory)
        {
            DisplayInventoryInfo(Inventory);
            
            Console.WriteLine($"1. 아이템 장착/ 해제");
            Console.WriteLine($"2. 아이템 정렬");
            Console.WriteLine("0. 나가기");
            Console.Write(": ");
            int input = CheckValidInput(0, Inventory.Count);
            switch (input)
            {
                case 0:
                    //나가기
                    DisplayGameIntro();
                    break;
                case 1:
                    //장착
                    DisplayInvemtoryEquip(Inventory, Weapon, Armor, SecondaryWeapon);
                    break;
                case 2:
                    //정렬
                    DisplayInventorySort(Inventory);
                    break;
            }
            //장착
            static void DisplayInvemtoryEquip(List<Item> Inventory, List<Item> Weapon, List<Item> Armor, List<Item> SecondaryWeapon)
            {
                DisplayInventoryInfo(Inventory);

                for (int i = 0; i < Inventory.Count; i++)
                    Console.WriteLine($"{i + 1}. {Inventory[i].Name} 장착/해제");
                Console.WriteLine("0. 나가기");
                Console.Write(": ");
                int input = CheckValidInput(0, Inventory.Count);
                if (input == 0)
                {
                    DisplayInventory(Inventory);
                }
                else
                {
                    if (!Inventory[input - 1].Equip.Contains("[E]"))
                    {
                        Console.WriteLine($"장착중..");
                        Inventory[input - 1].Equip += "[E]";
                        
                        //Weapon.RemoveAt(0); //제거
                        if (Inventory[input - 1].Type == "무기")
                            Weapon.Add(Inventory[input - 1]); //추가
                        else if (Inventory[input - 1].Type == "방어구")
                            Armor.Add(Inventory[input - 1]);
                        else if (Inventory[input - 1].Type == "보조무기")
                            SecondaryWeapon.Add(Inventory[input - 1]);

                        player.Atk += Inventory[input - 1].Atk;
                        player.Def += Inventory[input - 1].Def;

                        //player.Atk = player.Atk + Weapon[0].Atk + Armor[0].Atk + SecondaryWeapon[0].Atk;
                        //player.Def = player.Def + Weapon[0].Def + Armor[0].Def + SecondaryWeapon[0].Def;
                    }
                    else
                    {
                        Console.WriteLine($"해제중..");
                        //if (Weapon[0].Type == "무기")
                        //    Weapon.RemoveAt(0);
                        //else if (Armor[0].Type == "방어구")
                        //    Armor.RemoveAt(0);
                        //else if (SecondaryWeapon[0].Type == "보조무기")
                        //    SecondaryWeapon.RemoveAt(0);

                        Inventory[input - 1].Equip = "";
                        player.Atk -= Inventory[input - 1].Atk;
                        player.Def -= Inventory[input - 1].Def;

                        //player.Atk = player.Atk - Weapon[0].Atk - Armor[0].Atk - SecondaryWeapon[0].Atk;
                        //player.Def = player.Def - Weapon[0].Def - Armor[0].Def - SecondaryWeapon[0].Def;

                        //if (Inventory[input - 1].Type.Contains("공격력"))
                        //{
                        //}
                        //else if (Inventory[input - 1].Type.Contains("방어력"))
                        //{
                        //}
                    }
                }
                Thread.Sleep(1000);
                DisplayInvemtoryEquip(Inventory, Weapon, Armor, SecondaryWeapon);
            }

            //정렬
            static void DisplayInventorySort(List<Item> Inventory)
            {
                DisplayInventoryInfo(Inventory);

                Console.WriteLine($"1. 공격력 정렬");
                Console.WriteLine($"2. 방어력 정렬");
                Console.WriteLine("0. 나가기");
                Console.Write(": ");
                int input = CheckValidInput(0, Inventory.Count);
                switch (input)
                {
                    case 0:
                        //나가기
                        DisplayInventory(Inventory);
                        break;
                    case 1:
                        //공격력 높은 순
                        List<Item> atkSortList = Inventory.OrderBy(x => x.Atk).Reverse().ToList();
                        DisplayInventorySort(atkSortList);
                        break;
                    case 2:
                        //방어력 높은 순
                        List<Item> defSortList = Inventory.OrderBy(x => x.Def).Reverse().ToList();
                        DisplayInventorySort(defSortList);
                        break;
                }
            }
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
        //private static Program program;
        private static List<Item> ItemShopList = new List<Item>();

        static ItemShop()
        {
            Item steelArmor = new Item("강철갑옷", "방어구", "방어력 +10", 0, 10, 700, "단단한 강철로 만든 갑옷입니다.", "");
            ItemShopList.Add(steelArmor);
            Item steelSword = new Item("강철 검", "무기", "공격력 +10", 10, 0, 1000, "단단한 강철로 만든 검입니다.", "");
            ItemShopList.Add(steelSword);
            Item steelShield = new Item("강철 방패", "보조무기", "방어력 +5", 0, 5, 500, "단단한 강철로 만든 방패입니다.", "");
            ItemShopList.Add(steelShield);
            Item legendArmor = new Item("전설의 갑옷", "방어구", "방어력 +50", 0, 10, 30000, "전설의 갑옷이다.", "");
            ItemShopList.Add(legendArmor);
            Item legendSword = new Item("전설의 검", "무기", "공격력 +50", 10, 0, 30000, "전설의 검이다", "");
            ItemShopList.Add(legendSword);
            Item legendShield = new Item("전설의 방패", "보조무기", "방어력 +30", 0, 5, 15000, "전설의 방패이다.", "");
            ItemShopList.Add(legendShield);
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
                table.AddRow($"{ItemShopList[i].Name} ", $"{ItemShopList[i].Ability}", $"{ItemShopList[i].Explanation}", $"{ItemShopList[i].Gold}G");
            }
            table.Write();
            Console.WriteLine();
            //Console.ReadKey();
            //Console.WriteLine($"소지 금액 : {player.Gold}G");
            Console.WriteLine();
            Console.WriteLine("1. 구매하기");
            Console.WriteLine("2. 판매하기");
            Console.WriteLine("0. 나가기");
            Console.Write(": ");
            int input = Program.CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    Program.DisplayGameIntro();
                    break;
                case 1:
                    IsBuy();
                    break;
                case 2:
                    IsSell();
                    break;
            }
        }

        //아이템 구매
        static void IsBuy()
        {
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            int listCount = ItemShopList.Count;
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
            //Console.WriteLine($"소지중인 골드 : {player.Gold}G");
            Console.WriteLine();
            //Console.ReadKey();
            for (int i = 0; i < ItemShopList.Count; i++)
                Console.WriteLine($"{i + 1}. {ItemShopList[i].Name} 구매하기");

            Console.WriteLine("0. 나가기");
            Console.Write(": ");
            int input = Program.CheckValidInput(0, ItemShopList.Count);
            

            if (input == 0)
            {
                DisplayShop();
            }
            else
            {

                //player.Gold >= ItemShopList[input - 1].Gold
                if (player.Gold >= ItemShopList[input - 1].Gold)    //골드가 충분할 때    //오류
                {
                    Console.WriteLine($"구매중..");
                    player.Gold -= ItemShopList[input - 1].Gold;  //오류
                    Program.Inventory.Add(ItemShopList[input - 1]);
                    Thread.Sleep(1000);
                }
                else   //골드가 부족할때
                {
                    Console.WriteLine($"골드가 부족합니다..");
                    Thread.Sleep(1000);
                }
                IsBuy();
            }
        }

        //인벤토리 아이템 판패
        static void IsSell()
        {
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            Console.Clear();
            //Console.WriteLine("======================================================================");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t인벤토리/판매물픔");
            Console.ForegroundColor = ConsoleColor.White;
            var table = new ConsoleTable("이름", "능력치", "설명", "판매금액");
            for (int i = 0; i < Program.Inventory.Count; i++)
            {
                table.AddRow($"{Program.Inventory[i].Equip} {Program.Inventory[i].Name} ", $"{Program.Inventory[i].Type}", $"{Program.Inventory[i].Explanation}", $"{Program.Inventory[i].Gold / 2}G");
            }
            table.Write();
            Console.WriteLine();
            //Console.ReadKey();
            for (int i = 0; i < Program.Inventory.Count; i++)
                Console.WriteLine($"{i + 1}. {Program.Inventory[i].Name} 판매하기");
            Console.WriteLine("0. 나가기");
            Console.Write(": ");
            int input = Program.CheckValidInput(0, Program.Inventory.Count);
            
            if (input == 0)
            {
                DisplayShop();
            }
            else
            {
                if (!Program.Inventory[input - 1].Equip.Contains("[E]"))
                {
                    // 바로 판매
                    Program.Inventory.Remove(Program.Inventory[input - 1]);
                    player.Gold += (Program.Inventory[input - 1].Gold * 85 / 100);
                }
                else
                {
                    //장착 해제하고
                    Console.WriteLine($"해제중..");
                    Program.Inventory[input - 1].Equip = "";
                    if (Program.Inventory[input - 1].Type.Contains("공격력"))
                    {
                        player.Atk -= Program.Inventory[input - 1].Atk;
                    }
                    else if (Program.Inventory[input - 1].Type.Contains("방어력"))
                    {
                        player.Def -= Program.Inventory[input - 1].Def;
                    }
                    //판매
                    Program.Inventory.Remove(Program.Inventory[input - 1]);
                    player.Gold += (Program.Inventory[input - 1].Gold * 85 / 100);

                    Thread.Sleep(500);
                }
                IsSell();
            }
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
        public string Ability { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Heel { get; }
        public int Gold { get; set; }
        //설명
        public string Explanation { get; }
        public string Equip { get; set; }

        //이름, 타입, 공격력, 방어력, 금액 , 설명, 장착
        public Item(string name, string type, string ability, int atk, int def, int gold, string explanation, string equip)
        {
            Name = name;
            Type = type;
            Ability = ability;
            Atk = atk;
            Def = def;
            Gold = gold;
            Explanation = explanation;
            Equip = equip;
        }
    }
}