using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using KNXLib;
using System;
using System.Linq;
using System.Threading;

namespace TouchScreen
{
    /// <summary>
    /// Interaction logic for Room1Thermostat.xaml
    /// </summary>
    public partial class Thermostat : Window
    {
        private AC ac;
        public string State;
        public string Address;
        public static KnxConnection kcon;
        public Thermostat(Room room, string roomname, double top, double left)
        {
            InitializeComponent();
            this.Top = top;
            this.Left = left;
            this.Topmost = true;
            ac = room._AC;
            ac.Display = Display;
            ac.IncTemp=IncTemp;
            ac.DecTemp=DecTemp;
            ac.ACspeed=ACspeed;
            ac.ACsw=ACsw;
            kcon.KnxEventDelegate += Event;
            Display = ac.Display;
            ac.StatusChange();
            lblName.Content = roomname + " THERMOSTAT";
        }
        private void Event(string address, string state)
        {
            State = state;
            Address = address;
            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => { DisplayUpdate(); }));
        }
        private void DisplayUpdate()
        {
            //Change values of Room1
            if (Address == ac.Room_Temp_Addr)//room temperature
            {
                ac.RoomTemp = kcon.FromDataPoint("9.001", State).ToString();
                ac.StatusChange();
            }
            else if (Address == ac.Set_Temp_Addr)//set temperature
            {
                ac.SetTemp = kcon.FromDataPoint("9.001", State).ToString();
            }
            else if (Address == ac.Speed_Addr)//fan speed
            {
                ac.Speed = Convert.ToInt32(kcon.FromDataPoint("5.004", State));
                Thread.Sleep(100);
                ac.StatusChange();
            }
            else if (Address == ac.Auto_Addr)//AC auto
            {
                ac.AutoState = ConvertToBool(State);
                ac.StatusChange();
            }

        }
        public bool ConvertToBool(string state)
        {
            bool status;
            var data = string.Empty;

            if (state.Length == 1)
            {
                data = ((byte)state[0]).ToString();
            }
            else
            {
                var bytes = new byte[state.Length];
                for (var i = 0; i < state.Length; i++)
                {
                    bytes[i] = Convert.ToByte(state[i]);
                }

                data = state.Aggregate(data, (current, t) => current + t.ToString());
            }
            if (data == "0")
            {
                status = false;
            }
            else
            {
                status = true;
            }
            return status;
        }
        private void ACsw_Click(object sender, RoutedEventArgs e)
        {
            ac.OnOff();
            //Display1.Text = ac.Set_Temp_Addr;
        }

        private void IncTemp_Click(object sender, RoutedEventArgs e)
        {
            ac.Inc_Temp();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ac.DisplayThermostat = false;
            this.Close();
        }

        private void ACspeed_Click(object sender, RoutedEventArgs e)
        {
            ac.Speed_Change();
        }

        private void DecTemp_Click(object sender, RoutedEventArgs e)
        {
            ac.Dec_Temp();
        }
    }
}