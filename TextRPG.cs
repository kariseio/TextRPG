using System;

namespace TextRPG {
    class TextRPG {
        public static int count = 0; // 몇번째 적인지

        public static int TotalDMG = 0, TotalCritical = 0, TotalEvade = 0,
            TotalClear = 0, TotalDeath = 0;

        public static void Main (string[] args) {

            Info player = new Info ();
            Info enemy = new Info ();

            //승률 확인
            //WinRate.showRate (player, enemy);
            //Console.ReadKey ();

            Interface Interface = new Interface ();
            Commands Commands = new Commands ();
            TextRPG TextRPG = new TextRPG ();

            // 시작 화면 인터페이스
            Interface.StartInterface ();
            Console.ReadKey ();
            Console.Clear ();

            // goto 문 사용해서 restart시 여기로 (이거 괜찮은 걸까?) => 아닌 걸로 판명

            // 처음 부분으로 돌아가려면?

            // 게임 실행 전 플레이어 능력치 굴림
            TextRPG.SetPlayer (player);
            Console.Clear ();


            // reroll 기능 추가

            // start로 실행


            while (count <= 10) {
                // interface + count
                Interface.MainInterface ();
                if (count == 0)
                    Console.WriteLine ("적을 10마리 처치하면 승리!!\n");
                if (enemy.health <= 0 || count == 0) {
                    Console.WriteLine (++count + "번째 적을 마주쳤습니다.\n");
                    enemy = new Info ();
                    TextRPG.RandEnemy (enemy);
                }
                if (count > 0)
                    Console.WriteLine (count + " / 10");

                // show interface
                Interface.PlayerInterface (player);
                Interface.EnemyInterface (enemy);
                Commands.ReadCommands (player, enemy);

                TextRPG.IsAchivement ();

                // 0 health
                if (player.health <= 0) {
                    Console.ReadKey ();
                    TextRPG.GameOver (player, enemy);
                }

                // kill enemy
                if (enemy.health <= 0) {
                    Console.WriteLine ("적을 처치했습니다!!\n");
                    // Game Clear
                    if (count > 9) {
                        Console.ReadKey ();
                        TextRPG.GameClear (player, enemy);
                    }
                }
                Console.ReadKey ();
                Console.Clear ();
            }
        }

        public void SetPlayer (Info player) {
            Interface Interface = new Interface ();
            Commands Commands = new Commands ();
            TextRPG TextRPG = new TextRPG ();

            TextRPG.RandPlayer (player); // 능력치 돌리고
            Interface.PlayerStatInterface (); // 명령어 보여주고
            Interface.PlayerInterface (player);  // 능력치 보여주고
            Commands.PlayerStatCommands (player); // 입력 받음
        }

        public void RandPlayer (Info player) {
            Random rand = new Random ();
            player.health = rand.Next (90, 110);
            player.attack = rand.Next (10, 20);
            player.defense = rand.Next (4, 8);
            player.critical = rand.Next (10, 25);
            player.evade = rand.Next (10, 20);
        }

        public void RandEnemy (Info enemy) {
            Random rand = new Random ();
            enemy.health = rand.Next (10, 25);
            enemy.attack = rand.Next (5, 10);
            enemy.defense = rand.Next (3, 6);
            enemy.critical = rand.Next (5, 10);
            enemy.evade = rand.Next (5, 20);
        }

        public void GameClear (Info player, Info enemy) {
            Interface Interface = new Interface ();
            Commands Commands = new Commands ();
            TotalClear++;
            Console.Clear ();
            Interface.GameEndInterface ();
            Console.WriteLine ("축하합니다!");
            Console.WriteLine ("게임 클리어!\n");
            Console.WriteLine ("재실행하시겠습니까?\n");
            Commands.GameOverCommands (player, enemy);
        }
        

        public void GameOver (Info player, Info enemy) {
            Interface Interface = new Interface ();
            Commands Commands = new Commands ();
            TotalDeath++;
            Console.Clear ();
            Interface.GameEndInterface ();
            Console.WriteLine ("사망하셨습니다.");
            Console.WriteLine ("재실행하시겠습니까?\n");
            Commands.GameOverCommands (player, enemy);
        }

        public static bool[] DMG = new bool[10];
        public static bool[] CRI = new bool[10];
        public static bool[] EVA = new bool[10];
        public void IsAchivement () {
            // Damage Achivement
            for (int i = 0; i < 4; i++) {
                int challenge = 100 * (int)Math.Pow (2, i);
                int nextChallenge;

                if (i < 3) {
                    nextChallenge = 100 * (int)Math.Pow (2, i + 1);
                } else
                    nextChallenge = int.MaxValue;

                if (DMG[i] == false && TotalDMG < nextChallenge) {
                    if (TotalDMG >= challenge) {
                        Console.WriteLine ("도전과제");
                        Console.WriteLine ("누적 피해량 " + challenge + "달성!!\n");
                        DMG[i] = true;
                    }
                } else if (TotalDMG >= nextChallenge) {
                    DMG[i] = true;
                }
            }

            // Critical Achivement
            for (int i = 0; i < 4; i++) {
                int challenge = (int)Math.Pow (2, i + 1);
                int nextChallenge;

                if (i < 3) {
                    nextChallenge = (int)Math.Pow (2, i + 2);
                } else
                    nextChallenge = int.MaxValue;

                if (CRI[i] == false && TotalCritical < nextChallenge) {
                    if (TotalCritical >= challenge) {
                        Console.WriteLine ("도전과제");
                        Console.WriteLine ("누적 크리티컬 " + challenge + "달성!!\n");
                        CRI[i] = true;
                    }
                } else if (TotalCritical >= nextChallenge) {
                    CRI[i] = true;
                }
            }

            // Evade Achivement
            for (int i = 0; i < 4; i++) {
                int challenge = (int)Math.Pow (2, i + 1);
                int nextChallenge;

                if (i < 3) {
                    nextChallenge = (int)Math.Pow (2, i + 2);
                } else
                    nextChallenge = int.MaxValue;

                if (EVA[i] == false && TotalEvade < nextChallenge) {
                    if (TotalEvade >= challenge) {
                        Console.WriteLine ("도전과제");
                        Console.WriteLine ("누적 회피 " + challenge + "달성!!\n");
                        EVA[i] = true;
                    }
                } else if (TotalEvade >= nextChallenge) {
                    EVA[i] = true;
                }
            }
        }  
    }

    // 정보 클래스 (아군, 적)
    class Info {
        public int health { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int critical { get; set; }
        public int evade { get; set; }

        public Info() {

        }

        public Info(int health, int attack, int defense, int critical, int evade) {
            this.health = health;
            this.attack = attack;
            this.defense = defense;
            this.critical = critical;
            this.evade = evade;
        }
    }
}
