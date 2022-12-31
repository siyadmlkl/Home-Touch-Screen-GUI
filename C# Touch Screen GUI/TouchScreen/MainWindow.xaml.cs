using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using KNXLib;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TouchScreen
{
    
    public partial class MainWindow : Window
    {
        public static KnxConnection KCon;
        public string State;
        public string Address;
        
        SQLiteConnection DCon = new SQLiteConnection("Data Source=HAS.db;Version=3;");
        Room Room1 = new Room("Room1");//Living
        Room Room2 = new Room("Room2");//Dining
        Room Room3 = new Room("Room3");//Bedroom-1
        //Room Room4 = new Room("Room4");//
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
            Thermostat.kcon = KCon;
            
            ReadAddresses();
            Room1._Switch.Lights = new Button[] { L1, L2, L3, L4,};
            Room2._Switch.Lights = new Button[] { L5,L6,L7,L8 };
            Room3._Switch.Lights = new Button[] { L10, L11, L12, L13 };
        }
        private void ReadAddresses()
        {
            DCon.Open();
            GroupAddress.ReadAddress(Room1, DCon);
            GroupAddress.ReadAddress(Room2, DCon);
            GroupAddress.ReadAddress(Room3, DCon);
            DCon.Close();
        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KCon.Disconnect();
        }
        //Room1 light switch
        public void Room1_Light_Click(object sender, RoutedEventArgs e)
        {
            Room1._Switch.OnOff();          
        }
        //Room2 light switch
        public void Room2_Light_Click(object sender, RoutedEventArgs e)
        {
            Room2._Switch.OnOff();
        }
        //Room3 light switch
        private void Room3_Light_Click(object sender, RoutedEventArgs e)
        {
            Room3._Switch.OnOff();
        }
        //Room1 AC
        private void Room1_ACbutton_Click(object sender, RoutedEventArgs e)
        {
            if(Room1._AC.DisplayThermostat == false)
            {
                Thermostat Room1Thermostat = new Thermostat(Room1,"LIVING",100,100);
                Room1._AC.DisplayThermostat = true;
                Room1Thermostat.Show();
            }  
        }
        //Room3 AC
        private void Room3_ACbutton_Click(object sender, RoutedEventArgs e)
        {
            if (Room3._AC.DisplayThermostat == false)
            {
                Thermostat Room3Thermostat = new Thermostat(Room3, "LIVING", 100, 800);
                Room3._AC.DisplayThermostat = true;
                Room3Thermostat.Show();
            }
        }
        //Event handling of KNX activities
        private void Event(string address, string state)
        {
           State =state;
           Address = address;
           this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, 
               new Action(() => { DisplayUpdate(); }));
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
        //Updating displays when Event invokes
        private void DisplayUpdate()
        {
            //Change values of Room1
            if(Address==Room1._AC.Room_Temp_Addr)//room temperature
            {
                Room1._AC.RoomTemp = KCon.FromDataPoint("9.001", State).ToString();
                Room1_ACbutton.Content = Room1._AC.RoomTemp;
            }
            else if (Address == Room1._Switch.SW_Addr)//light switch
            {
                Room1._Switch.SW_state = ConvertToBool(State);
                Room1._Switch.StatusChange();
            }

            //Change values of Room2

            else if (Address == Room2._Switch.SW_Addr)//light switch
            {
                Room2._Switch.SW_state = ConvertToBool(State);
                Room2._Switch.StatusChange();
            }

            //change values of Room3
            if (Address == Room3._AC.Room_Temp_Addr)//room temperature
            {
                Room3._AC.RoomTemp = KCon.FromDataPoint("9.001", State).ToString();
                Room3_ACbutton.Content = Room3._AC.RoomTemp;
            }
            else if (Address == Room3._Switch.SW_Addr)//light switch
            {
                Room3._Switch.SW_state = ConvertToBool(State);
                Room3._Switch.StatusChange();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
    }
}
