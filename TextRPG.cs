using System;

namespace TextRPG {
    class TextRPG {
        static void Main (string[] args) {
            string input = null;
            int count = 1;


            Info player = new Info (100, 5, 5, 3.0f, 2.0f);
            Info enemy = new Info (10, 2, 3, 5.0f, 10.0f);

            Interface.StartInterface ();
            Console.ReadKey ();
            Console.Clear ();
            

            while(true) {
                Interface.MainInterface (count);
                Interface.PlayerInterface (player);
                //Interface.EnemyInterface (enemy);
                ReadCommands (ref input);

                Console.ReadKey (); // getchar() 대용으로 사용중
            }

        }

        // 명령어 입력 받는 함수
        public static void ReadCommands(ref string command) {

            Console.Write ("Command : ");
            command = Console.ReadLine ().ToLower(); // 소문자로 입력받음
            switch (command) {
                case "-start":
                    Commands.start ();
                    break;

                case "-restart":
                    Commands.restart ();
                    break;

                case "-quit":
                    Commands.quit ();
                    break;

                case "-attack":
                    Commands.attack ();
                    break;

                default:
                    Console.WriteLine ("명령어에 해당하지 않는 입력");
                    ReadCommands (ref command);
                    break;
                }

            
        }
    }

    // 정보 클래스 (아군, 적)
    class Info {
        public int health { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public float critical { get; set; }
        public float evade { get; set; }

        public Info(int health, int attack, int defense, float critical, float evade) {
            this.health = health;
            this.attack = attack;
            this.defense = defense;
            this.critical = critical;
            this.evade = evade;
        }
    }
    
}
