using DungeonTexetGame;
using System.Text;

namespace DungeonTexetGame
{
    #region User, Item
    // User 클래스
    public class CUser
    {
        public string name;
        public string job;
        public int lv;
        public int power;
        public int defense;
        public int health;
        public int gold;

        // User 생성자
        public CUser(string newName, string newjob, int newLv, int newPower, int newDefense, int newHealth, int newGold)
        {
            this.name = newName;
            this.job = newjob;
            this.lv = newLv;
            this.power = newPower;
            this.defense = newDefense;
            this.health = newHealth;
            this.gold = newGold;
        }
    }

    // Item 클래스
    public class CItem
    {
        public string name;
        public int powerStat;
        public int defenseStat;
        public string manual;
        public int cost;
        public string type;

        // 착용 여부
        public bool isWear;
        // 소유 여부
        public bool isHave;

        // Item 생성자
        public CItem(string itemName, int itemPowerStat, int itemDefenseStat, string itemManual, int itemCost, bool itemIsWear, bool itemIsHave, string itemType)
        {
            this.name = itemName;
            this.powerStat = itemPowerStat;
            this.defenseStat = itemDefenseStat;
            this.manual = itemManual;
            this.cost = itemCost;
            this.isWear = itemIsWear;
            this.isHave = itemIsHave;
            this.type = itemType;  
        }
    }
    #endregion // User, Item

    internal class Program
    {
        #region 선언부
        // user, 유저 아이템 리스트 선언
        static CUser user;
        static List<CItem> userItems = new List<CItem>();
        // 상점 아이템 리스트 선언
        static List<CItem> shopItems = new List<CItem>();
        #endregion // 선언부

        public static void Main(string[] args)
        {
            // 게임 초기화
            SetUser();
            SetShopItem();

            // 메뉴 실행
            PrintMenu();
        }

        #region 초기화
        // 유저 초기화
        static void SetUser()
        {
            user = new CUser("고먐미", "전사", 01, 10, 5, 100, 1500);
        }

        // 상점 아이템 초기화
        static void SetShopItem()
        {
            AddItem(shopItems, "수련자 갑옷", 0, 5, "수련에 도움을 주는 갑옷입니다.", 1000, false, false, "방어력");
            AddItem(shopItems, "무쇠갑옷", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 100, false, false, "방어력");
            AddItem(shopItems, "스파르타의 갑옷", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, false, false, "방어력");
            AddItem(shopItems, "낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.", 600, false, false, "공격력");
            AddItem(shopItems, "청동 도끼", 5, 0, "어디선가 사용됐던거 같은 도끼입니다.", 1500, false, false, "공격력");
            AddItem(shopItems, "스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 100, false, false, "공격력");
            AddItem(shopItems, "모두를 홀리는 고양이", 30, 15, "모두들 고양이를 보면 홀리지!", 5000, false, false, "펫");
            AddItem(shopItems, "너덜너덜한 망토", 0, 20, "너덜너덜해보이지만 사실은 무림고수들이 입던 망토입니다.", 3000, false, false, "방어력");
            AddItem(shopItems, "분노한 자의 고무망치", 15, 0, "층간 소음에 분노한 자의 고무망치입니다.", 2500, false, false, "공격력");
        }
        #endregion // 초기화

        #region 유저 관련
        // 유저 추가 공격력
        static int UserPower()
        {
            int power = 0;
            for (int idx = 0; idx < userItems.Count; idx++)
            {
                if (userItems[idx].isWear)
                {
                    power += userItems[idx].powerStat;
                }
            }
            return power;
        }

        // 유저 추가 방어력
        static int UserDefense()
        {
            int defense = 0;
            for (int idx = 0; idx < userItems.Count; idx++)
            {
                if (userItems[idx].isWear)
                {
                    defense += userItems[idx].defenseStat;
                }
            }
            return defense;
        }
        #endregion // 유저 관련

        #region 아이템 관련
        // 아이템 추가
        static void AddItem(List<CItem> listName, string itemName, int itemPowerStat, int itemDefenseStat, string itemManual, int itemCost, bool itemIsWear, bool itemIsHave, string itemType)
        {
            CItem item = new CItem(itemName, itemPowerStat, itemDefenseStat, itemManual, itemCost, itemIsWear, itemIsHave, itemType);
            listName.Add(item);
        }

        // 아이템 삭제
        static void DeleteItem(List<CItem> listName, string itemName)
        {
            int idx = SearchItem(listName, itemName);

            // 아이템이 존재할 경우
            if (idx >= 0)
            {
                listName.RemoveAt(idx);
            }
        }

        // 아이템 탐색
        static int SearchItem(List<CItem> listName, string itemName)
        {
            for (int idx = 0; idx < listName.Count; idx++)
            {
                // 해당하는 아이템이 존재할 경우
                if (listName[idx].name == itemName)
                {
                    return idx;
                }
            }

            return -1;
        }
        #endregion // 아이템 관련

        #region 메서드
        #region 기본 메뉴
        // 0. 메뉴 출력
        static void PrintMenu()
        {
            // 화면 초기화
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            // 메뉴 선택 확인
            int selectMenu = CheckNum(1, 3);

            switch (selectMenu)
            {
                // 상태 보기
                case 1:
                    ShowInfo();
                    break;

                // 인벤토리
                case 2:
                    ShowInventory();
                    break;

                // 상점
                case 3:
                    ShowShop();
                    break;
            }
        }

        // 숫자 범위 체크
        static int CheckNum(int min, int max)
        {
            while (true)
            {
                int selectMenu = int.Parse(Console.ReadLine());

                // 메뉴에 있는 입력이면
                if (selectMenu >= min && selectMenu <= max)
                {
                    return selectMenu;
                }

                // 메뉴 이외의 입력이면
                Console.WriteLine("!!!!!잘못된 입력입니다!!!!!");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
            }
        }
        #endregion // 기본 메뉴

        #region 메뉴 - 상태보기
        // 1. [메뉴] 상태 보기
        static void ShowInfo()
        {
            // 화면 초기화
            Console.Clear();

            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"LV.{user.lv}");
            Console.WriteLine($"{user.name} \t( {user.job} )");

            int addPower = UserPower();
            Console.Write($"공격력 \t{user.power + addPower} ");
            if (addPower > 0)
            {
                Console.WriteLine($"(+{addPower})");
            }
            else
            {
                Console.WriteLine();
            }

            int addDefense = UserDefense();
            Console.Write($"방어력 \t{user.defense + addDefense} ");
            if (addDefense > 0)
            {
                Console.WriteLine($"(+{addDefense})");
            }
            else
            {
                Console.WriteLine();
            }

            Console.WriteLine($"체력 \t{user.health}");
            Console.WriteLine($"Gold \t{user.gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            // 메뉴 선택 확인
            int selectMenu = CheckNum(0, 0);

            switch (selectMenu)
            {
                // 메뉴 실행
                case 0:
                    PrintMenu();
                    break;
            }
        }
        #endregion // 메뉴 - 상태보기

        #region 메뉴 - 인벤토리
        // 2. [메뉴] 인벤토리
        static void ShowInventory()
        {
            // 화면 초기화
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            // 유저의 인벤토리가 비어있지 않으면
            if (!(userItems.Count == 0))
            {
                PrintInventory(userItems);
            }

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            // 메뉴 선택 확인
            int selectMenu = CheckNum(0, 1);

            switch (selectMenu)
            {
                // 메뉴 실행
                case 0:
                    PrintMenu();
                    break;

                // 장착 관리
                case 1:
                    SetInventory();
                    break;
            }
        }

        // 인벤토리 목록 출력
        static void PrintInventory(List<CItem> listName)
        {
            for (int idx = 0; idx < listName.Count; idx++)
            {
                Console.Write("- ");

                // 장착한 아이템이면,
                if (listName[idx].isWear)
                {
                    Console.Write("[E]");
                }

                Console.Write($"{listName[idx].name}\t| ");

                // 공격 아이템인지 방어 아이템인지 구분
                if (!(listName[idx].powerStat == 0))
                {
                    Console.Write($"공격력 +{listName[idx].powerStat}\t| ");

                }
                if (!(listName[idx].defenseStat == 0))
                {
                    Console.Write($"방어력 +{listName[idx].defenseStat}\t| ");

                }

                Console.WriteLine($"{listName[idx].manual}");
            }
        }

        // 2-1. 장착 관리 메뉴 활성화
        static void SetInventory()
        {
            // 화면 초기화
            Console.Clear();

            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            PrintInventoryWithNum(userItems);
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            // 메뉴 선택 확인
            int selectMenu = CheckNum(0, userItems.Count);

            if (selectMenu == 0)
            {
                // 메뉴 실행
                PrintMenu();
            }
            else
            {
                // 장착 관리
                MountManagement(selectMenu - 1);
                SetInventory();
            }
        }

        // 인벤토리 목록 출력(with. 숫자)
        static void PrintInventoryWithNum(List<CItem> listName)
        {
            for (int idx = 0; idx < listName.Count; idx++)
            {
                Console.Write($"- {idx + 1} ");

                // 장착한 아이템이면,
                if (listName[idx].isWear)
                {
                    Console.Write("[E]");
                }

                Console.Write($"{listName[idx].name}\t| ");

                // 공격 아이템인지 방어 아이템인지 구분
                if (!(listName[idx].powerStat == 0))
                {
                    Console.Write($"공격력 +{listName[idx].powerStat}\t| ");

                }
                if (!(listName[idx].defenseStat == 0))
                {
                    Console.Write($"방어력 +{listName[idx].defenseStat}\t| ");

                }

                Console.WriteLine($"{listName[idx].manual}");
            }
        }

        // 장착 관리
        static void MountManagement(int inputNum)
        {
            // 장착 중이면 -> 장착 해제
            if (userItems[inputNum].isWear)
            {
                userItems[inputNum].isWear = false;
            }
            // 장착 중이지 않다면 -> 장착
            else
            {
                // 기존 장착 아이템 해제
                int idx = SearchItemIsWear(userItems);
                if (idx >= 0)
                {
                    if (userItems[idx].type == userItems[inputNum].type)
                {
                    userItems[idx].isWear = false;
                }
                }
                
                // 새 아이템 장착
                userItems[inputNum].isWear = true;
            }
        }

        // 장착하고 있는 아이템 탐색
        static int SearchItemIsWear(List<CItem> listName)
        {
            for(int idx = 0; idx<listName.Count; idx++)
            {
                if (listName[idx].isWear)
                {
                    return idx;
                }
            }
            return -1;
        }
        #endregion // 메뉴 - 인벤토리

        #region 메뉴 - 상점 
        // 3. [메뉴] 상점
        static void ShowShop()
        {
            // 화면 초기화
            Console.Clear();

            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{user.gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            PrintShopItem(shopItems);
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            // 메뉴 선택 확인
            int selectMenu = CheckNum(0, 2);

            switch (selectMenu)
            {
                // 메뉴 실행
                case 0:
                    PrintMenu();
                    break;

                // 아이템 구매
                case 1:
                    ReShowShop();
                    break;

                // 아이템 판매
                case 2:
                    ShowMyInventory();
                    break;
            }
        }

        // 상점 아이템 목록 출력
        static void PrintShopItem(List<CItem> listName)
        {
            for (int idx = 0; idx < listName.Count; idx++)
            {
                Console.Write($"- {listName[idx].name}\t| ");

                // 공격 아이템인지 방어 아이템인지 구분
                if (!(listName[idx].powerStat == 0))
                {
                    Console.Write($"공격력 +{listName[idx].powerStat}\t| ");

                }
                if (!(listName[idx].defenseStat == 0))
                {
                    Console.Write($"방어력 +{listName[idx].defenseStat}\t| ");

                }

                Console.Write($"{listName[idx].manual}\t| ");

                string result = (IsHaveItem(userItems, listName[idx].name)) ? "구매완료" : $"{listName[idx].cost} G";
                Console.WriteLine(result);
            }
        }

        // 아이템을 가지고 있는지 확인
        static bool IsHaveItem(List<CItem> listName, string searchName)
        {
            // 유저에게 해당 아이템이 존재하는지 확인
            int searchIdx = SearchItem(listName, searchName);

            // 아이템이 존재하면
            if (searchIdx >= 0)
            {
                return listName[searchIdx].isHave;
            }

            // 존재하지 않으면
            return false;
        }

        // 3-1. 아이템 구매 메뉴 활성화
        static void ReShowShop()
        {
            // 화면 초기화
            Console.Clear();

            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{user.gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            PrintShopItemWithNum(shopItems);
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            // 메뉴 선택 확인
            int selectMenu = CheckNum(0, shopItems.Count);

            if (selectMenu == 0)
            {
                // 메뉴 실행
                PrintMenu();
            }
            else
            {
                // 아이템 구매
                BuyItem(selectMenu - 1);
                BuyError();
            }
        }

        // 상점 아이템 목록 출력(with. 숫자)
        static void PrintShopItemWithNum(List<CItem> listName)
        {
            for (int idx = 0; idx < listName.Count; idx++)
            {
                Console.Write($"- {idx + 1} {listName[idx].name}\t| ");

                // 공격 아이템인지 방어 아이템인지 구분
                if (!(listName[idx].powerStat == 0))
                {
                    Console.Write($"공격력 +{listName[idx].powerStat}\t| ");

                }
                if (!(listName[idx].defenseStat == 0))
                {
                    Console.Write($"방어력 +{listName[idx].defenseStat}\t| ");

                }

                Console.Write($"{listName[idx].manual}\t| ");

                string result = (IsHaveItem(userItems, listName[idx].name)) ? "구매완료" : $"{listName[idx].cost} G";
                Console.WriteLine(result);
            }
        }

        // 아이템 구매
        static void BuyItem(int inputNum)
        {
            // 이미 구매한 아이템일 경우
            if (IsHaveItem(userItems, shopItems[inputNum].name))
            {
                Console.WriteLine("구매한 아이템입니다.");
                BuyError();
            }
            // 구매 가능할 경우
            else
            {
                // 보유 금액이 충분할 경우
                if (user.gold >= shopItems[inputNum].cost)
                {
                    user.gold -= shopItems[inputNum].cost;
                    AddItem(userItems, shopItems[inputNum].name, shopItems[inputNum].powerStat, shopItems[inputNum].defenseStat, shopItems[inputNum].manual, shopItems[inputNum].cost, false, true, shopItems[inputNum].type);

                    Console.WriteLine("구매를 완료했습니다.");
                }
                // 보유 금액이 부족할 경우
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                    BuyError();
                }
            }
        }

        // 아이템 구매 에러 메세지
        static void BuyError()
        {
            // 오류 확인 메세지
            Console.WriteLine();
            Console.WriteLine("되돌아가시려면 0을 누르세요.");
            Console.Write(">> ");
            int checkError = CheckNum(0, 0);
            ReShowShop();
        }

        // 3-2. 아이템 판매 메뉴 활성화
        static void ShowMyInventory()
        {
            // 화면 초기화
            Console.Clear();

            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{user.gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            PrintInventoryShopWithNum(userItems);
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            // 메뉴 선택 확인
            int selectMenu = CheckNum(0, userItems.Count);

            if (selectMenu == 0)
            {
                // 메뉴 실행
                PrintMenu();
            }
            else
            {
                // 아이템 판매
                SaleItem(selectMenu - 1);
                ShowMyInventory();
            }
        }

        // 인벤토리 아이템 목록 출력(with. 숫자)
        static void PrintInventoryShopWithNum(List<CItem> listName)
        {
            for (int idx = 0; idx < listName.Count; idx++)
            {
                Console.Write($"- {idx + 1} {listName[idx].name}\t| ");

                // 공격 아이템인지 방어 아이템인지 구분
                if (!(listName[idx].powerStat == 0))
                {
                    Console.Write($"공격력 +{listName[idx].powerStat}\t| ");

                }
                if (!(listName[idx].defenseStat == 0))
                {
                    Console.Write($"방어력 +{listName[idx].defenseStat}\t| ");

                }

                Console.WriteLine($"{listName[idx].manual}\t| {listName[idx].cost} G");
            }
        }

        // 아이템 판매
        static void SaleItem(int inputNum)
        {
            // 인벤토리에 있는 아이템 착용/소유 여부 초기화
            userItems[inputNum].isHave = false;
            userItems[inputNum].isWear = false;

            // 판매 시 구매 가격의 85% 가격에 판매
            user.gold += (int)(userItems[inputNum].cost * 0.85f);

            // 인벤토리에 있는 아이템 삭제
            DeleteItem(userItems, userItems[inputNum].name);
        }
        #endregion // 메뉴 - 상점
        #endregion // 메서드
    }
}