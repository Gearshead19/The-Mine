using System;
using System.Collections.Generic;
using static System.Console;
using static System.ConsoleColor;

//Fix battle system. Doesnt do what I want it too.

namespace TheMine
{
    class Program
    {
        static void Main()
        {
            Title = "The Mine";
            MainMenu.Menu();
        }
    }
    class MainMenu
    {
        static string GameTitle = @"   
 /////////////////////////////////////// _____  _           __  __  _            //////////////////////////////////
 ///////////////////////////////////////|_   _|| |_   ___  |  \/  |(_) _ _   ___ //////////////////////////////////
 ///////////////////////////////////////  | |  | ' \ / -_) | |\/| || || ' \ / -_)//////////////////////////////////
 ///////////////////////////////////////  |_|  |_||_|\___| |_|  |_||_||_||_|\___|//////////////////////////////////";
        static string Start = "Press <Enter> to Start";
        public static string CharacterName = "John Doe";
        public static void Menu()
        {
            
            Game.Prompts(GameTitle + "\n");
            SetCursorPosition((WindowWidth - Start.Length) / 2, CursorTop);
            Game.Prompts(Start);
            ReadKey();
            Clear();
            EnterName();
        }
        public static void EnterName()
        {
            Game.Prompts("Please enter your name....");
            CharacterName = ReadLine();
            Clear();
            if (CharacterName == "")
            {
                EnterName();
            }
            Clear();
            Game.Start();
        }
    }
    class Game
    {
        //Questions/Replies
        static string Question1 = "How long have those creatures been attacking the town?";
        static string Question2 = "Looks dangerous...got anything to help me in there?";
        static string LinkReply = "......";

        //Player Stats
        public static int Health = 15;
        public static int pAttk = Rando.Rng(2, 3);
        public static int Knife = 3;

        //Monster Stats
        public static int mHealth = 10;
        public static int mAttk = Rando.RngM(3, 4);
        public static void Start()
        {
            string input = "";
            OldMan("Welcome " + MainMenu.CharacterName + ", you must be tired after the long way here?\n");
            ReadKey();
            Player(MainMenu.CharacterName + ":......\n");
            ReadKey();
            Clear();
            command1();
            void command1()
            {
                OldMan("No need to answer...Well, I'm assuming your going to go check out that Mine I called you about?\n");
                Prompts("Yes   -   No\n");
                input = ReadLine();
                Clear();
                switch (input)
                {
                    case "Yes":
                        OldMan("Right-o my dude, well let me show you around back.");
                        ReadKey();
                        Clear();
                        break;
                    case "No":
                        OldMan("Haha, sure you big kidder. Why else would you be here. Well let me show you around back.");
                        ReadKey();
                        Clear();
                        break;
                    default:
                        command1();
                        break;

                }
            }
            OldMan("There see. That's where those creatures are coming from.\n");
            ReadKey();
            Prompts("The old dude points at an abandoned mine.");
            ReadKey();
            Clear();
            command2();
            void command2()
            {
                Player(MainMenu.CharacterName + ":....\n");
            Prompts("\nA) " + Question1);
            Prompts("\nB) " + Question2);
            Prompts("\nC) " + LinkReply);
            input = ReadLine();
            Clear();
            
                switch (input)
                {
                    case "A":
                        OldMan("Shii my guy those baddies been attacking us for about a month now.");
                        ReadKey();
                        Prompts("\nB) " + Question2);
                        Prompts("\nC) " + LinkReply);
                        input = ReadLine();
                        Clear();
                        switch (input)
                        {
                            case "B":
                                OldMan("Oh yeee, it's dangerous to go alone. I found this in my shed before you arrived.\n");
                                ReadKey();
                                Prompts("You obtained <Flashlight>.");
                                Items.Inventory.Add("Flashlight");
                                ReadKey();
                                Clear();
                                OldMan("Aight then, I won't hold ya. On your way now.");
                                ReadKey();
                                Clear();
                                break;
                            case "C":
                                OldMan("Aight then, I won't hold ya. On your way now.");
                                ReadKey();
                                Clear();
                                break;
                            default:
                                goto case "C";
                               
                        }
                        break;
                    case "B":
                        OldMan("Oh yeee, it's dangerous to go alone. I found this in my shed before you arrived.\n");
                        ReadKey();
                        Prompts("You obtained <Flashlight>.\n");
                        Items.Inventory.Add("Flashlight");
                        ReadKey();
                        Prompts("A) " + Question1);
                        Prompts("\nC) " + LinkReply);
                        input = ReadLine();
                        Clear();
                        switch (input)
                        {
                            case "A":
                                OldMan("Shii my guy those baddies been attacking us for about a month now.\n");
                                ReadKey();
                                Clear();
                                OldMan("Aight then, I won't hold ya. On your way now.");
                                ReadKey();
                                Clear();
                                break;
                            case "C":
                                OldMan("Aight then, I won't hold ya. On your way now.");
                                ReadKey();
                                Clear();
                                break;
                            default:
                                goto case "C";
                        }

                        break;
                    case "C":
                        OldMan("Huh...you don't say much do ya? Well whatever, please just go stop them critters from attacking us.");
                        ReadKey();
                        Clear();
                        break;
                    default :
                        command2();
                        break;
                }
            }
            Prompts("You head towards the entrance of the mine.");
            ReadKey();
            Clear();
            R1();

        }
        public static void R1()//Entrance.
        {
            string input = "";
            Prompts("As you enter you realize it's very dark in here.\n");
            ReadKey();
            Player(MainMenu.CharacterName + ":......\n");
            ReadKey();
            Clear();

            if (Items.Inventory.Contains("Flashlight"))
            {
                Prompts("You use the <Flashlight> the old dude gave you.\n");
                ReadKey();
                Clear();

            }
            else
            {
                Prompts("You head in further.....\n");
                ReadKey();
                Prompts("Suddenly you feel something bite your leg!\n");
                ReadKey();
                Prompts("Without hesitation, a creature drags you into the darkness......\n");
                ReadKey();
                Dead("CRUSH.....TEAR...RIP...dip..dip..dip..........");
                ReadKey();
                Clear();
                Dead("GAME OVER");
                ReadKey();
                Clear();
                Prompts("Retry?\n");
                Prompts("Yes   -   No\n");
                input = ReadLine();
                Clear();
                switch(input)
                {
                    case "Yes":
                        Game.Start();
                        break;
                    case "No":
                        return;
                    default:
                        goto case "No";
                       
                }
            }
            Prompts("You look around the entrance.");
            ReadKey();
            Clear();
            Prompts("A monster suddenly sees you and attacks!");
            ReadKey();
            Monster("RWAORRR!!");
            Clear();
            Prompts("FIGHT FOR YOUR LIFE!");
            ReadKey();
            Clear();
            Fight1();

            //Battle!
            void Fight1()
            {
                if (Health >= 0)
                {
                    Player(MainMenu.CharacterName + ":........!\n\n");
                    SetCursorPosition((WindowWidth - Health) / 2, CursorLeft);
                    SetCursorPosition((WindowWidth - mHealth) / 3, CursorLeft);
                    Prompts("Player HP:" + Health);
                    Prompts("Monster HP:" + mHealth);
                    Prompts("A) Attack \nB) Block \nC) Heal \nD)Run ");
                    input = ReadLine();
                    Clear();

                    switch (input)
                    {
                        case "A":
                            Prompts("Pow!\n");
                            ReadKey();
                            Prompts("You've inflicted " + pAttk + " damage!\n");
                            mHealth = mHealth - pAttk;
                            ReadKey();
                            Clear();

                            if (mHealth >= 0)
                            {
                                Prompts("You're wide open!!\n");
                                ReadKey();
                                Prompts("Monster slashed you! You've taken " + mAttk + " damage!\n");
                                Health = Health - mAttk;
                                ReadKey();
                                Clear();
                                Fight1();
                                
                            }
                            Fight1();
                            break;
                    }
                }
                else if (Health <= 0)
                {
                    Prompts("You have been killed!\n");
                    ReadKey();
                    Clear();
                    Dead("Game Over.....");
                    ReadKey();
                    Clear();
                    return;
                }
                if (mHealth <= 0 && Health >=0)
                {
                    Prompts("You defeated the monster!");
                    ReadKey();
                    Clear();
                }
                Prompts("You've won, now move on!");
                ReadKey();
                Clear();
            }
            
        }
        public static void R2()//Reception Room.
        {

        }
        public static void R3()//Bridge.
        {

        }
        public static void R4()//Mine1.
        {

        }
        public static void R5()//Mine2.
        {

        }
        public static void R6()//Generator Room.
        {

        }
        public static void R7()//Mine3.
        {

        }
        public static void R8()//Control Room.
        {

        }
        public static void R9()//Hallway.
        {

        }
        public static void R10()//Office.
        {

        }
        public static void R11()//Upper Bridge.
        {

        }
        public static void R12()//Storage.
        {

        }
        public static void R13()//Mine Cart Room.
        {

        }
        public static void R14()//Dark Room.
        {

        }
        public static void R15()//Rails.
        {

        }
        public static void R16()//Barricade Room.
        {

        }
        public static void R17()//Boss Room.
        {

        }




        //Voices//

        public static void Prompts(string message)
        {
            ForegroundColor = Cyan;
            WriteLine(message);
            ResetColor();
        }
        public static void Player(string message)
        {
            ForegroundColor = Green;
            Write(message);
            ResetColor();
        }
        public static void OldMan(string message)
        {
            ForegroundColor = White;
            WriteLine(message);
            ResetColor();
        }
        public static void Dead(string message)
        {
            ForegroundColor = Red;
            WriteLine(message);
            ResetColor();
        }
        public static void Monster(string message)
        {
            ForegroundColor = DarkRed;
            WriteLine(message);
            ResetColor();
        }
    }
    class Player
    {
        public static int Health = 15;
        public static int pAttk = 2;
        public static int Knife = 3;
        public static void Stats()
        {
        Health = 15;
        pAttk = 2;
        Knife = 3;
            if (Items.Inventory.Contains("Knife"))
            {
                pAttk = Knife + pAttk;
            }

        }
       
    }
    class Enemy
    {
        public static int mHealth = 10;
        public static int mAttk = 3;
        
        public static void Monster1()
        {
            int mHealth;
            int mAttk;
            mHealth = 10;
            mAttk = 3;
        }
    }
    class Battle
    {
        public static void Fight1()
        {
            
        }
    }
    class BattleTest
    {
        public static object Start { get; private set; }

        public static void Fight()
        {
            

            Game.Prompts("Player Attacks!");
        int pAttack = Rando.Rng(5, 10);
        Game.Prompts("\nPlayer did " + pAttack + "!");
        ReadKey();
        Clear();
            if (pAttack >=9)
            {
                Game.Prompts("Critical Hit!!");
        ReadKey();
        Clear();

    }
            else
            {
                Game.Prompts("Nice Hit!");
                   ReadKey();
                   Clear();
             }
           Game.Prompts("Continue fourth!");
           ReadKey();
           Clear();
            

        }
        
        

           
    }
    class Items
    {
        public static List<string> Inventory = new List<string>();
        
        //Items//
        //Knife.
        //Flashlight.
        //Storage Key.
        //Rubber Chicken.

    }
    class Mechanics
    {

    }
    class Rando
    {
        public static int Rng(int min, int max)
        {
            Random random = new Random();
            return random.Next(2, 3);
        }
        public static int RngM(int min, int max)
        {
            Random random = new Random();
            return random.Next(3, 4);
        }
    }
}
