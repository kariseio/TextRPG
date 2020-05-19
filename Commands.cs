using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace TextRPG {

    class Commands {

        public static int totalDMG = 0;
        public static int totalCritical = 0;
        public static int totalEvade = 0;

        public static void Restart(Info player, Info enemy, ref int count) {
            count = 1;
            player.health = 100;
            TextRPG.RandEnemy (enemy);
            totalDMG = totalCritical = totalEvade = 0;
            Console.WriteLine ("게임을 재실행합니다.\n");
        }

        public static void Quit() {
            Console.WriteLine ("게임을 종료합니다");
            Thread.Sleep (1000);
            Environment.Exit (0);
        }

        public static void Attack(Info player, Info enemy) {
            try {
                if (enemy.health <= 0 || player.health <= 0)
                    return;

                Random rand = new Random ();
                int DMG;
                int playerHealth = player.health, enemyHealth = enemy.health;

                int playerPower = player.attack - enemy.defense;
                if (playerPower <= 0)
                    playerPower = 1;
                int enemyPower = enemy.attack - player.defense;
                if (enemyPower <= 0)
                    enemyPower = 1;

                
                if (rand.Next (0, 100) > enemy.evade) {
                    
                    DMG = rand.Next ((int)(playerPower * 0.5), (int)(playerPower * 1.5));

                    if (rand.Next (0, 100) < player.critical) {
                        Console.WriteLine ("플레이어 크리틸컬!");
                        DMG *= 2;
                        if (DMG < 2)
                            DMG = 2;
                        totalCritical++;
                    }
                    enemy.health -= DMG;
                    totalDMG += DMG;
                    if (enemy.health < 0)
                        enemy.health = 0;

                    Console.WriteLine ("적에게 " + DMG + "만큼의 피해를 입힘");
                    Console.WriteLine ("적 체력 " + enemyHealth + " => " + enemy.health);
                } else {
                    Console.WriteLine ("적이 회피하였습니다.");
                }

                Console.WriteLine (""); // 줄바꿈


                if (rand.Next (0, 100) > player.evade) {
                    
                    DMG = rand.Next ((int)(enemyPower * 0.8), (int)(enemyPower * 5.2));

                    if (rand.Next (0, 100) < enemy.critical) {
                        Console.WriteLine ("적 크리틸컬!");
                        DMG *= 2;
                        
                        if (DMG < 2)
                            DMG = 2;
                    }

                    player.health -= DMG;
                    if (player.health < 0)
                        player.health = 0;

                    Console.WriteLine ("적에게 " + DMG + "만큼의 피해를 입음");
                    Console.WriteLine ("플레이어 체력 " + playerHealth + " => " + player.health);
                } else {
                    Console.WriteLine ("플레이어가 회피하였습니다.");
                    totalEvade++;
                }

                Console.WriteLine (""); // 줄바꿈


                if (player.health <= 0) {
                    Console.WriteLine ("사망하였습니다.");
                    Quit ();
                }
            } catch(Exception e) {
                Console.WriteLine (e.ToString ());
            }
        }

        public static void Achivement () {
            Console.Clear ();
            Console.WriteLine ("========== 도전과제 ==========");
            Console.WriteLine ("누적 데미지");
            if (TextRPG.DMG1)
                Console.WriteLine ("50 (달성)");
            else {
                Console.WriteLine ("50 (미달성)");
            }

            if (TextRPG.DMG2)
                Console.WriteLine ("100 (달성)");
            else {
                Console.WriteLine ("100 (미달성)");
            }

            if (TextRPG.DMG3)
                Console.WriteLine ("200 (달성)");
            else {
                Console.WriteLine ("200 (미달성)");
            }
            Console.WriteLine ("");

            Console.WriteLine ("크리티컬 횟수");
            if (TextRPG.CRI1)
                Console.WriteLine ("3 (달성)");
            else {
                Console.WriteLine ("3 (미달성)");
            }

            if (TextRPG.CRI2)
                Console.WriteLine ("5 (달성)");
            else {
                Console.WriteLine ("5 (미달성)");
            }

            if (TextRPG.CRI3)
                Console.WriteLine ("10 (달성)");
            else {
                Console.WriteLine ("10 (미달성)");
            }
            Console.WriteLine ("");

            Console.WriteLine ("회피 횟수");
            if (TextRPG.EVA1)
                Console.WriteLine ("3 (달성)");
            else {
                Console.WriteLine ("3 (미달성)");
            }

            if (TextRPG.EVA2)
                Console.WriteLine ("5 (달성)");
            else {
                Console.WriteLine ("5 (미달성)");
            }

            if (TextRPG.EVA3)
                Console.WriteLine ("10 (달성)");
            else {
                Console.WriteLine ("10 (미달성)");
            }
            Console.WriteLine ("");
        }

        // 명령어 입력 받는 함수
        public static void ReadCommands (Info player, Info enemy, ref int count) {
            string command;
            Console.Write ("Command : ");
            command = Console.ReadLine ().ToLower (); // 소문자로 입력받음
            switch (command) {
                case "-restart":
                    Commands.Restart (player, enemy, ref count);
                    break;

                case "-quit":
                    Commands.Quit ();
                    break;

                case "-achivement":
                    Commands.Achivement ();
                    break;

                case "-attack":
                    Commands.Attack (player, enemy);
                    break;

                default:
                    Console.WriteLine ("명령어에 해당하지 않는 입력\n");
                    ReadCommands (player, enemy, ref count);
                    break;
            }
        }

        public static void GameEndCommands (Info player, Info enemy, ref int count) {
            string command;
            Console.Write ("Command : ");
            command = Console.ReadLine ().ToLower (); // 소문자로 입력받음
            switch (command) {
                case "-restart":
                    Commands.Restart (player, enemy, ref count);
                    break;

                case "-quit":
                    Commands.Quit ();
                    break;

                default:
                    Console.WriteLine ("명령어에 해당하지 않는 입력\n");
                    GameEndCommands (player, enemy, ref count);
                    break;
            }
        }

    }
}
