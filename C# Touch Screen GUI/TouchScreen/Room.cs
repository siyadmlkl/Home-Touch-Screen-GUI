﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KNXLib;

namespace TouchScreen
{
    public class Room
    {
        public Switch _Switch = new Switch();
        public Dimmer _Dimmer = new Dimmer();
        public AC _AC = new AC();
        public string RoomName { get; set; }
        public string FireAlarm_Addr { get; set; }
        public bool FireAlarm { get; set; }

        public Room(string roomname)
        {
            this.RoomName = roomname;
        }  
    }
}

