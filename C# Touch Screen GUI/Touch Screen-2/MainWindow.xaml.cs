using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using KNXLib;
using System;
using System.Linq;
using System.Threading;

namespace Touch_Screen_2
{
    
    public partial class MainWindow : Window
    {
        public static KnxConnection KCon;
        public string State;
        public string Address;
        public static System.Timers.Timer DisplayTimer;

        SQLiteConnection DCon = new SQLiteConnection("Data Source=D:/Development/Touch Screen Projects/Touch Screen-2/HAS.db;Version=3;");

        
        Room Room1 = new Room("Room1");//Living
        Room Room2 = new Room("Room2");//Dining
        Room Room3 = new Room("Room3");//Kitchen
        Room Room4 = new Room("Room4");//Bedroom-1
        //Room Room5 = new Room("Room5");
        //Room Room6 = new Room("Room6");
        //Room Room7 = new Room("Room7");
        //Room Room8 = new Room("Room8");
        //Room Room9 = new Room("Room9");
        //Room Room10 = new Room("Room10");

        public MainWindow()
        {
            InitializeComponent();
            //Kcon = new KnxConnectionTunneling("10.3.5.222", 3671, "10.3.5.235", 3671) { Debug = false };
            KCon = new KnxConnectionRouting { Debug = false, ActionMessageCode = 0x29 };
            KCon.KnxEventDelegate += Event;
            KCon.Connect();
            Switch._connection = KCon;
            Dimmer._connection = KCon;
            AC._connection = KCon;
            ReadAddresses();
            Room1._Switch.Lights = new Button[] { L1, L2, L3, L4, L5, L6 };
            Room2._Switch.Lights = new Button[] { L11,L12,L13,L14 };

            Room1._AC.Display = Room1_Display;
            Room1._AC.ACsw = this.Liv_ACsw;
            KCon.RequestStatus(Room1._AC.Room_Temp_Addr);
            
        }
        private void ReadAddresses()
        {
            DCon.Open();
            GroupAddress.ReadAddress(Room1, DCon);
            GroupAddress.ReadAddress(Room2, DCon);
            GroupAddress.ReadAddress(Room3, DCon);
            GroupAddress.ReadAddress(Room4, DCon);
            DCon.Close();
        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KCon.Disconnect();
        }
        public void Room1_Light_Click(object sender, RoutedEventArgs e)
        {
            Room1._Switch.OnOff();          
        }

        public void Room2_Light_Click(object sender, RoutedEventArgs e)
        {
            Room2._Switch.OnOff();
        }

        private void Kitchen_Light_Click(object sender, RoutedEventArgs e)
        {
            Room4._Switch.OnOff();

       }

        private void Bed1_Light_Click(object sender, RoutedEventArgs e)
        {
            Room3._Switch.OnOff();
        }

        private void Event(string address, string state)
        {
            // Console.WriteLine(address+", "+state);
           State =state;
           Address = address;
           this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => { DisplayUpdate(); }));
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
        private void DisplayUpdate()
        {
            
            DisplayAddress.Text = Address;
            DisplayState.Text = State;
            if(Address==Room1._AC.Room_Temp_Addr)
            {
                Room1._AC.RoomTemp = KCon.FromDataPoint("9.001", State).ToString();
                Room1._AC.Display.Text = Room1._AC.RoomTemp;
            }
            else if(Address == Room1._AC.Set_Temp_Addr)
            {
                Room1._AC.SetTemp = KCon.FromDataPoint("9.001", State).ToString();
                DisplayState.Text = Room1._AC.SetTemp;
            }
            else if(Address==Room2._Switch.SW_Addr)
            {
                Room2._Switch.SW_state = ConvertToBool(State);
                Room2._Switch.StatusChangei();
            }
            else if (Address == Room1._Switch.SW_Addr)
            {
                Room1._Switch.SW_state = ConvertToBool(State);
                Room1._Switch.StatusChangei();
            }
            else if (Address == Room1._AC.Auto_Addr)
            {
                Room1._AC.AutoState = ConvertToBool(State);
                Room1._AC.StatusChangei();
            }

            //Kitchen1._Switch.StatusChangei();
        }

        public void Liv_Temp_Inc(object sender, RoutedEventArgs e)
        {
            Room1._AC.Inc_Temp();
        }
        public void OnTimedEvent(object Source,object sender)
        {
            Room1._AC.Display.Text = Room1._AC.RoomTemp;
        }

        private void Liv_Temp_Dec(object sender, RoutedEventArgs e)
        {
            Room1._AC.Dec_Temp();
        }

        private void Liv_AC_ONOFF(object sender, RoutedEventArgs e)
        {
            Room1._AC.OnOff();
        }

    }
}
