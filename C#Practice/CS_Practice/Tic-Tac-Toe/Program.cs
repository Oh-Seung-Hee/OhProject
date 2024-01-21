namespace Tic_Tac_Toe
{
    internal class Program
    {
        static char[] num = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int turn = 1;        // 어떤 플레이어의 턴인지 확인하기 위한 변수
        static int isGameOver = -1; // 게임이 끝났는지 확인하기 위한 변수
        static int cnt = 0;         // 몇번째 턴인지 확인하기 위한 변수
        static int inputNum = 0;    // 다음 입력을 받기 위한 변수

        static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            // 몇번째 턴인지 확인
            cnt++;
            // 보드 출력
            PrintBoard();
            // 자리 입력
            Play();
            // 게임 룰 확인
            isGameOver = GameRule();
            // 다음 행동
            NextTurn();
        }

        // 보드 출력
        private static void PrintBoard()
        {
            // 화면 초기화
            Console.Clear();

            Console.WriteLine("플레이어 1 : X 와 플레이어 2 : O");
            if (turn % 2 == 1)
            {
                turn = 1;
            }
            else
            {
                turn = 2;
            }
            Console.WriteLine($"플레이어 {turn}의 차례\n\n\n");

            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {num[0]}  |  {num[1]}  |  {num[2]}  ");
            Console.WriteLine("-----|-----|-----");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {num[3]}  |  {num[4]}  |  {num[5]}  ");
            Console.WriteLine("-----|-----|-----");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {num[6]}  |  {num[7]}  |  {num[8]}  ");
            Console.WriteLine("     |     |     ");
        }

        // 자리 입력
        private static void Play()
        {
            Console.WriteLine("숫자를 입력하세요.");
            Console.Write(">> ");

            // 입력이 범위 내 숫자인지 확인
            CheckNum(1, 9);

            // 입력에 있는 자리에 놓을 수 있는지 확인
            if (!(num[inputNum - 1] == 'O') && !(num[inputNum - 1] == 'X'))
            {
                num[inputNum - 1] = turn == 1 ? 'X' : 'O';
            }
            else
            {
                Console.WriteLine("놓을 수 없는 자리입니다.");
                Play();
            }
        }

        // 입력이 숫자인지 확인
        private static void CheckNum(int min, int max)
        {
            while (IsNum(min, max) == false)
            {
                Console.WriteLine("보드에 있는 숫자를 입력해주세요.");
                Console.Write(">> ");
            }
        }
        private static bool IsNum(int min, int max)
        {
            if (int.TryParse(Console.ReadLine(), out inputNum) == false)
            {
                return false;
            }

            if (inputNum > max || inputNum < min)
            {
                return false;
            }

            return true;
        }

        // 게임 룰
        private static int GameRule()
        {
            // 가로 승리 조건
            if (num[0] == num[1] && num[1] == num[2])
            {
                return 1;
            }
            else if (num[3] == num[4] && num[4] == num[5])
            {
                return 1;
            }
            else if (num[6] == num[7] && num[7] == num[8])
            {
                return 1;
            }
            // 세로 승리 조건
            else if (num[0] == num[3] && num[3] == num[6])
            {
                return 1;
            }
            else if (num[1] == num[4] && num[4] == num[7])
            {
                return 1;
            }
            else if (num[2] == num[5] && num[5] == num[8])
            {
                return 1;
            }
            // 대각선 승리 조건
            else if (num[0] == num[4] && num[4] == num[8])
            {
                return 1;
            }
            else if (num[2] == num[4] && num[4] == num[6])
            {
                return 1;
            }
            // 무승부
            if (cnt == 9)
            {
                return 0;
            }
            //게임이 안끝난 경우
            return -1;
        }

        // 다음 행동
        private static void NextTurn()
        {
            // 게임이 안끝난 경우
            if (isGameOver == -1)
            {
                turn++;
                StartGame();
            }
            // 무승부
            else if (isGameOver == 0)
            {
                PrintBoard();
                Console.WriteLine("\n\n무승부입니다.");
            }
            // 승리
            else
            {
                PrintBoard();
                Console.WriteLine("\n\n게임이 끝났습니다.");
                Console.WriteLine($"플레이어 {turn}의 승리입니다!");
            }
        }
    }
}