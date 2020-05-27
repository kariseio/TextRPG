using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG {
    class WinRate {


        public static void showRate (Info player, Info enemy) {
            TextRPG TextRPG = new TextRPG ();

            double count = 0;

            // 1000번 실행
            for (int i = 0; i < 1000; i++) {
                TextRPG.RandPlayer (player);
                
                // 10마리 잡음
                for(int j = 0; j < 10; j++) {

                    TextRPG.RandEnemy (enemy);

                    while (enemy.health > 0 && player.health > 0) {
                        battle (player, enemy);
                        
                    }

                    if (player.health <= 0)
                        break;
                }
                if (player.health > 0)
                    count++;

            }

            Console.WriteLine ("승률: " + count/10 + "%");
        }
        
        public static void battle (Info player, Info enemy) {
            Random rand = new Random ();
            int DMG;

            int playerPower = player.attack - enemy.defense;
            if (playerPower <= 0)
                playerPower = 1;
            int enemyPower = enemy.attack - player.defense;
            if (enemyPower <= 0)
                enemyPower = 1;

            if (rand.Next (0, 100) > enemy.evade) {
                DMG = rand.Next ((int)(playerPower * 0.5), (int)(playerPower * 1.5));
                if (rand.Next (0, 100) < player.critical) {
                    DMG *= 2;
                    if (DMG < 2)
                        DMG = 2;
                }
                enemy.health -= DMG;
                if (enemy.health < 0)
                    enemy.health = 0;
            }

            if (rand.Next (0, 100) > player.evade) {
                DMG = rand.Next ((int)(enemyPower * 0.8), (int)(enemyPower * 5.2));
                if (rand.Next (0, 100) < enemy.critical) {
                    DMG *= 2;
                    if (DMG < 2)
                        DMG = 2;
                }
                player.health -= DMG;
                if (player.health < 0)
                    player.health = 0;
            }
        }

    }
}
