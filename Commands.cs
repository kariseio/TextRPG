using System;


namespace TextRPG {

    class Commands {

        public static int TotalDMG { get; set; } = 0;
        public static int TotalCritical { get; set; } = 0;
        public static int TotalEvade { get; set; } = 0;

        public void Restart(Info player, Info enemy, ref int count) {
            TextRPG TextRPG = new TextRPG ();

            Console.WriteLine ("게임을 재실행합니다.\n");
            Console.ReadKey ();
            Console.Clear ();
            TextRPG.SetPlayer (player);

            count = 0;

            TextRPG.RandEnemy (enemy);
            TotalDMG = TotalCritical = TotalEvade = 0;
        }

        public void Restart(Info player) {
            TextRPG TextRPG = new TextRPG ();
            Console.WriteLine ("게임을 재실행합니다.\n");
            Console.ReadKey ();
            Console.Clear ();
            TextRPG.SetPlayer (player);
            Console.Clear ();
        }

        public void Quit() {
            Console.WriteLine ("게임을 종료합니다");
            Console.ReadKey ();
            Environment.Exit (0);
        }

        public void Attack(Info player, Info enemy) {

            // Attack function
            // power = attack - defense
            // Critical = 2 * DMG;
            // if Critical damage less than 2, DMG = 2
            // Player and Enemy can be damaged randomly near the power


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
                        TotalCritical++;
                    }
                    enemy.health -= DMG;
                    TotalDMG += DMG;
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
                    TotalEvade++;
                }

                Console.WriteLine (""); // 줄바꿈


                
            } catch(Exception e) {
                Console.WriteLine (e.ToString ());
            }
        }

        public void Achivement () {
            Interface Interface = new Interface ();
            Interface.AchivementInterface ();
        }

        // 명령어 입력 받는 함수
        public void ReadCommands (Info player, Info enemy, ref int count) {
            Commands Commands = new Commands ();
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

        public void PlayerStatCommands (Info player) {
            Commands Commands = new Commands ();
            TextRPG TextRPG = new TextRPG ();
            string command;
            Console.Write ("Command : ");
            command = Console.ReadLine ().ToLower (); // 소문자로 전환
            switch (command) {
                case "-start":
                    Console.WriteLine ("게임을 시작합니다.");
                    Console.ReadKey ();
                    break;

                case "-restart":
                    Commands.Restart (player);
                    break;

                case "-reroll":
                    Console.WriteLine ("능력치를 재설정합니다.");
                    Console.ReadKey ();
                    Console.Clear ();
                    TextRPG.SetPlayer (player);
                    break;

                case "-quit":
                    Commands.Quit ();
                    break;

                default:
                    Console.WriteLine ("명령어에 해당하지 않는 입력\n");
                    PlayerStatCommands (player);
                    break;
            }
        }

        public void GameOverCommands (Info player, Info enemy, ref int count) {
            Commands Commands = new Commands ();
            string command;
            Console.Write ("Command : ");
            command = Console.ReadLine ().ToLower (); // 소문자로 전환
            switch (command) {
                case "-restart":
                    Commands.Restart (player, enemy, ref count);
                    break;

                case "-quit":
                    Commands.Quit ();
                    break;

                default:
                    Console.WriteLine ("명령어에 해당하지 않는 입력\n");
                    GameOverCommands (player, enemy, ref count);
                    break;
            }
        }

    }
}
