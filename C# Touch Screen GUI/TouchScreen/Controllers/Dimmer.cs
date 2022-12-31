using System;
using System.Windows.Controls;
using System.Threading;
using KNXLib;

namespace TouchScreen
{
    public class Dimmer
    {
        public int Intensity;
        public string Dim_Addr;
        public static KnxConnection _connection;

        public void Dimming(object sender)
        {
            
            //Intensity = Convert.ToInt32(Dm.Value*25);
            _connection.Action(Dim_Addr, 127);
            //_connection.Action("0/7/31", true);
            _connection.Action(Dim_Addr,6);
        }
    }
}
