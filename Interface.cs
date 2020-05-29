using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG {
    class Interface {

        // 시작 인터페이스
        public void StartInterface () {
            Console.WriteLine ("========================================");
            Console.WriteLine ("\n\n");
            Console.WriteLine (String.Format ("{0}", "Text RPG").PadLeft (40 - (20 - ("Text RPG".Length / 2))));
            Console.WriteLine ("");
            Console.WriteLine (String.Format ("{0, 30}", "by 성태"));
            Console.WriteLine ("\n\n");
            Console.WriteLine ("========================================");
            Console.WriteLine (String.Format ("{0,20}", "시작하려면 아무 키나 입력"));

        }

        // 기본 인터페이스
        public void MainInterface () {
            Console.WriteLine ("★명령어★");
            Console.WriteLine ("-restart : 게임을 재시작합니다.");
            Console.WriteLine ("-attack : 공격합니다.");
            Console.WriteLine ("-achivement : 도전과제를 확인합니다.");
            Console.WriteLine ("-quit : 게임을 종료합니다.");
            Console.WriteLine ("\n");
        }

        // 플레이어 능력치 인터페이스
        public void PlayerStatInterface () {
            Console.WriteLine ("★명령어★");
            Console.WriteLine ("-start : 게임을 시작합니다.");
            Console.WriteLine ("-restart : 게임을 재시작합니다.");
            Console.WriteLine ("-reroll : 능력치를 재설정합니다.");
            Console.WriteLine ("-quit : 게임을 종료합니다.");
            Console.WriteLine ("\n");
            Console.WriteLine ("플레이어 능력치를 설정합니다.\n");
        }

        // 플레이어 인터페이스
        public void PlayerInterface (Info player) {
            Console.WriteLine ("==========플레이어 정보==========");
            Console.WriteLine ("체력 : " + player.health);
            Console.WriteLine ("공격력 : " + player.attack);
            Console.WriteLine ("방어력 : " + player.defense);
            Console.WriteLine ("크리티컬 : " + player.critical);
            Console.WriteLine ("회피 : " + player.evade);
            Console.WriteLine ("\n");
        }

        // 적 인터페이스
        public void EnemyInterface (Info enemy) {
            Console.WriteLine ("==========적 정보==========");
            Console.WriteLine ("체력 : " + enemy.health);
            Console.WriteLine ("공격력 : " + enemy.attack);
            Console.WriteLine ("방어력 : " + enemy.defense);
            Console.WriteLine ("크리티컬 : " + enemy.critical);
            Console.WriteLine ("회피 : " + enemy.evade);
            Console.WriteLine ("\n");
        }

        // 도전과제 인터페이스
        public void AchivementInterface () {
            Console.Clear ();
            Console.WriteLine ("========== 도전과제 ==========");
            Console.WriteLine ("누적 데미지");

            // Damage Achivement
            for(int i = 0; i < 4; i++) {
                int challenge = 100 * (int)Math.Pow (2, i);
                if (TextRPG.DMG[i])
                    Console.WriteLine (challenge + " (달성)");
                else {
                    Console.WriteLine (challenge + " (미달성)");
                }
            }
            Console.WriteLine ("");

            // Critical Achivement
            Console.WriteLine ("누적 크리티컬");
            for (int i = 0; i < 4; i++) {
                int challenge = (int)Math.Pow (2, i + 1);
                if (TextRPG.CRI[i])
                    Console.WriteLine (challenge + " (달성)");
                else {
                    Console.WriteLine (challenge + " (미달성)");
                }
            }
            Console.WriteLine ("");

            // Evade Achivement
            Console.WriteLine ("누적 회피");
            for (int i = 0; i < 4; i++) {
                int challenge = (int)Math.Pow (2, i + 1);
                if (TextRPG.EVA[i])
                    Console.WriteLine (challenge + " (달성)");
                else {
                    Console.WriteLine (challenge + " (미달성)");
                }
            }
            Console.WriteLine ("");

            // Clear Achivement
            Console.WriteLine ("누적 클리어");
            Console.WriteLine (TextRPG.TotalClear + " 회");
            Console.WriteLine ("");

            // Death Achivement
            Console.WriteLine ("누적 사망");
            Console.WriteLine (TextRPG.TotalDeath + " 회");
            Console.WriteLine ("");
        }

        // 게임 종료시 인터페이스
        public void GameEndInterface () {
            Console.WriteLine ("★명령어★");
            Console.WriteLine ("-restart : 게임을 재시작합니다.");
            Console.WriteLine ("-quit : 게임을 종료합니다.");
            Console.WriteLine ("\n");
        }

    }
}
