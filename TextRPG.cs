using System;

namespace TextRPG {
    class TextRPG {
        public static void Main (string[] args) {
            int count = 0; // 몇번째 적인지

            Info player = new Info (100, 1000, 5, 5, 7);
            Info enemy = new Info();

            Interface Interface = new Interface ();
            Commands Commands = new Commands ();
            TextRPG TextRPG = new TextRPG ();

            // 시작 화면 인터페이스
            Interface.StartInterface ();
            Console.ReadKey ();
            Console.Clear ();


            while (count <= 10) {

                Interface.MainInterface (count);
                if (count == 0)
                    Console.WriteLine ("적을 10마리 처치하면 승리!!\n");
                if (enemy.health <= 0) {
                    Console.WriteLine (++count + "번째 적을 마주쳤습니다.\n");
                    enemy = new Info ();
                    TextRPG.RandEnemy (enemy);
                }
                if (count > 0)
                    Console.WriteLine (count + " / 10");



                Interface.PlayerInterface (player);
                Interface.EnemyInterface (enemy);
                Commands.ReadCommands (player, enemy, ref count);

                TextRPG.IsAchivement ();

                if (enemy.health <= 0) {
                    Console.WriteLine ("적을 처치했습니다!!\n");
                    if (count > 9) {
                        Console.ReadKey ();
                        count++;
                        TextRPG.GameEnd (player, enemy, ref count);
                        enemy = new Info ();
                        TextRPG.RandEnemy (enemy);
                    }
                }
                Console.ReadKey (); // getchar() 대용으로 사용중
                Console.Clear ();
            }
        }


        public void RandEnemy (Info enemy) {
            Random rand = new Random ();
            enemy.health = rand.Next (7, 16);
            enemy.attack = rand.Next (3, 8);
            enemy.defense = rand.Next (1, 3);
            enemy.critical = rand.Next (3, 8);
            enemy.evade = rand.Next (20, 45);
        }

        public void GameEnd (Info player, Info enemy, ref int count) {
            Console.Clear ();
            Interface.GameEndInterface (0);
            Console.WriteLine ("축하합니다!");
            Console.WriteLine ("게임 클리어!\n");

            Console.WriteLine ("재실행하시겠습니까?\n");
            Commands.GameEndCommands (player, enemy, ref count);
        }

        public bool[] DMG = new bool[3];
        public bool[] CRI = new bool[3];
        public bool[] EVA = new bool[3];
        public void IsAchivement () {
            Commands Commands = new Commands ();
            if(DMG[0] == false && Commands.totalDMG < 100) {
                if(Commands.totalDMG >= 50) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 피해량 50달성!!\n");
                    DMG[0] = true;
                }
            } else if(DMG[1] == false && Commands.totalDMG < 200) {
                if (Commands.totalDMG >= 100) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 피해량 100달성!!\n");
                    DMG[0] = true;
                    DMG[1] = true;
                }
            } else if (DMG[2] == false) {
                if (Commands.totalDMG >= 200) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 피해량 200달성!!\n");
                    DMG[0] = true;
                    DMG[1] = true;
                    DMG[2] = true;
                }
            }

            if (CRI[0] == false) {
                if (Commands.totalCritical >= 3) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 크리티컬 3달성!!\n");
                    CRI[0] = true;
                }
            } else if (CRI[1] == false) {
                if (Commands.totalCritical >= 5) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 크리티컬 5달성!!\n");
                    CRI[1] = true;
                }
            } else if (CRI[2] == false) {
                if (Commands.totalCritical >= 10) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 크리티컬 10달성!!\n");
                    CRI[2] = true;
                }
            }

            if (EVA[0] == false) {
                if (Commands.totalEvade >= 3) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 회피 3달성!!\n");
                    EVA[0] = true;
                }
            } else if (EVA[1] == false) {
                if (Commands.totalEvade >= 5) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 회피 5달성!!\n");
                    EVA[1] = true;
                }
            } else if (EVA[2] == false) {
                if (Commands.totalEvade >= 10) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 회피 10달성!!\n");
                    EVA[2] = true;
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
