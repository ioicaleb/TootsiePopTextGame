﻿using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Mechanics
{
    public class GameCommand : IGameCommand
    {
        public Player Player { get; set; }

        public Enemy Enemy { get; set; }

        public Combat Combat { get; set; }

        public Gameplay Game { get; set; }

        public Location Map { get; set; }

        public Prompt Prompt { get; set; }

        public List<int> Entries { get; }

        public virtual void Execute(int input) 
        {
            switch (input)
            {
                case 1:
                    CreateCommands();
                    break;
                case 2:
                    string name = Prompt.GetName();
                    Player = Player.CreatePlayer(name);
                    break;
                case 3:
                    string thingToDo = Prompt.GetAction();
                    string command = Prompt.StringToInput(thingToDo, 1);
                    string target = Prompt.StringToInput(thingToDo, 2);
                    Game.ActOnInput(command, target);
                    break;
                case 4:
                    Combat.Encounter();
                    break;
                case 5:
                    Map.CreateMap();
                    break;
                default:
                    break;
            }
            
        }

        public void CreateCommands()
        {
            Player = new Player();
            Prompt = new Prompt();
            Enemy = new Enemy();
            Map = new Location();
            Combat = new Combat();
            Game = new Gameplay();
        }
    }
}