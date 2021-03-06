﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Units.Infantry;
using Commands;


namespace Units.Buildings
{
    class TownCenter : UnitInfo, IResourceDrop
    {
        public TownCenter()
        {
            Name = "Campfire";
            Cost.Food = 1000;
            Cost.Stone = 500;
            MaxHealth = 1500;
            Prefab = UnityEngine.Resources.Load("Buildings/prim_TownCenter") as UnityEngine.GameObject;
            UnitCommands.Add(typeof(Commands.ProduceUnit<Worker>));
            UnitCommands.Add(typeof(Commands.ProduceUnit<Warrior>));
            Speed = 0;
        }


        
    }
}
