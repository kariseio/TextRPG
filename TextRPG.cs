using System;

namespace TextRPG {
    class TextRPG {
        public static void Main (string[] args) {
            int count = 0; // 몇번째 적인지

            Info player = new Info (100, 10, 5, 5, 7);
            Info enemy = new Info();


            // 시작 화면 인터페이스
            Interface.StartInterface ();
            Console.ReadKey ();
            Console.Clear ();


            while (count < 10) {

                Interface.MainInterface (count);
                if (count == 0)
                    Console.WriteLine ("적을 10마리 처치하면 승리!!\n");
                if (enemy.health <= 0) {
                    Console.WriteLine (++count + "번째 적을 마주쳤습니다.\n");
                    enemy = new Info ();
                    RandEnemy (enemy);
                }
                if (count > 0)
                    Console.WriteLine (count + " / 10");



                Interface.PlayerInterface (player);
                Interface.EnemyInterface (enemy);
                Commands.ReadCommands (player, enemy, ref count);

                IsAchivement ();

                if (enemy.health <= 0) {
                    Console.WriteLine ("적을 처치했습니다!!\n");
                    if (count >= 9) {
                        Console.ReadKey ();
                        count++;
                        GameEnd (player, enemy, ref count);
                        enemy = new Info ();
                        RandEnemy (enemy);
                    }
                }
                Console.ReadKey (); // getchar() 대용으로 사용중
                Console.Clear ();
            }
        }


        public static  void RandEnemy (Info enemy) {
            Random rand = new Random ();
            enemy.health = rand.Next (7, 16);
            enemy.attack = rand.Next (3, 8);
            enemy.defense = rand.Next (1, 3);
            enemy.critical = rand.Next (3, 8);
            enemy.evade = rand.Next (20, 45);
        }

        public static void GameEnd (Info player, Info enemy, ref int count) {
            Console.Clear ();
            Interface.GameEndInterface (0);
            Console.WriteLine ("축하합니다!");
            Console.WriteLine ("게임 클리어!\n");

            Console.WriteLine ("재실행하시겠습니까?\n");
            Commands.GameEndCommands (player, enemy, ref count);
        }

        public static bool DMG1, DMG2, DMG3;
        public static bool CRI1, CRI2, CRI3;
        public static bool EVA1, EVA2, EVA3;
        public static void IsAchivement () {
            if(DMG1 == false && Commands.totalDMG < 100) {
                if(Commands.totalDMG >= 50) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 피해량 50달성!!\n");
                    DMG1 = true;
                }
            } else if(DMG2 == false && Commands.totalDMG < 200) {
                if (Commands.totalDMG >= 100) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 피해량 100달성!!\n");
                    DMG1 = true;
                    DMG2 = true;
                }
            } else if (DMG3 == false) {
                if (Commands.totalDMG >= 200) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 피해량 200달성!!\n");
                    DMG1 = true;
                    DMG2 = true;
                    DMG3 = true;
                }
            }

            if (CRI1 == false) {
                if (Commands.totalCritical >= 3) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 크리티컬 3달성!!\n");
                    CRI1 = true;
                }
            } else if (CRI2 == false) {
                if (Commands.totalCritical >= 5) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 크리티컬 5달성!!\n");
                    CRI2 = true;
                }
            } else if (CRI3 == false) {
                if (Commands.totalCritical >= 10) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 크리티컬 10달성!!\n");
                    CRI3 = true;
                }
            }

            if (EVA1 == false) {
                if (Commands.totalEvade >= 3) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 회피 3달성!!\n");
                    EVA1 = true;
                }
            } else if (EVA2 == false) {
                if (Commands.totalEvade >= 5) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 회피 5달성!!\n");
                    EVA2 = true;
                }
            } else if (EVA3 == false) {
                if (Commands.totalEvade >= 10) {
                    Console.WriteLine ("도전과제");
                    Console.WriteLine ("누적 회피 10달성!!\n");
                    EVA3 = true;
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
