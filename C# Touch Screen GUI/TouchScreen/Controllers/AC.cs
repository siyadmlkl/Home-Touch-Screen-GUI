using KNXLib;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Windows.Media.Effects;
using System;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Linq.Expressions;

namespace TouchScreen
{
    public class AC
    {
        public string Speed_Addr { get; set; }
        public int Speed { get; set; }
        public string SpeedCMD_Addr { get; set; }
        public int SpeedCMD { get; set; }
        public string Auto_Addr { get; set; }
        public bool AutoState { get; set; }
        public string Set_Temp_Addr { get; set; }
        public string Room_Temp_Addr { get; set; }
        public string RoomTemp { get; set; }
        public string SetTemp { get; set; }
        public bool DisplayThermostat { get; set; }
        public Button ACsw { get; set; }
        public Button IncTemp { get; set; }
        public Button DecTemp { get; set; }
        public Button ACspeed { get; set; }
        public TextBox DispSetTemp { get; set; }
        public TextBox Display=new TextBox();

        public static KnxConnection _connection;
        public static System.Timers.Timer DisplayTime;

        public void Speed_Change()
        {
            //SpeedConvert();
            try
            {
                switch (Speed)
                {
                    case 1:
                        _connection.Action(SpeedCMD_Addr, true);
                        Thread.Sleep(200);
                        Speed = 2;
                        break;
                    case 2:
                        _connection.Action(SpeedCMD_Addr, true);
                        Thread.Sleep(200);
                        Speed = 3;
                        break;
                    case 3:
                        _connection.Action(SpeedCMD_Addr, false);
                        Thread.Sleep(200);
                        _connection.Action(SpeedCMD_Addr, false);
                        Thread.Sleep(200);
                        _connection.Action(SpeedCMD_Addr, false);
                        Thread.Sleep(200);
                        Speed = 0;
                        break;
                    case 0:
                        _connection.Action(SpeedCMD_Addr, true);
                        Thread.Sleep(200);
                        Speed = 1;
                        break;
                }
                //ACspeed.Content = Speed.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void SpeedConvert()
        {
            if (Speed == 0)
            {
                SpeedCMD = 0;
            }
            if (Speed ==1)
            {
                SpeedCMD = 1;
            }
            else if (Speed==2)
            {
                SpeedCMD = 2;
            }
            else
            {
                SpeedCMD = 3;
            }
        }
        public async void Inc_Temp()
        {
            
            double STemp = Convert.ToDouble(SetTemp);
            STemp = STemp + 0.5;
            SetTemp = STemp.ToString("F");
            byte[] Temp = _connection.ToDataPoint("9.001",SetTemp);
            _connection.Action(Set_Temp_Addr, Temp);
            Display.Text = SetTemp;
            await Task.Delay(2000);
            Display.Text = RoomTemp;
        }
        public async void Dec_Temp()
        {
            double STemp = Convert.ToDouble(SetTemp);
            STemp = STemp - 0.5;
            SetTemp = STemp.ToString("F");
            byte[] Temp = _connection.ToDataPoint("9.001", SetTemp);
            _connection.Action(Set_Temp_Addr, Temp);
            Display.Text = SetTemp;
            await Task.Delay(2000);
            Display.Text = RoomTemp;
        }
        public void OnOff()
        {
            if (AutoState == false)
            {
                AutoState = true;
                _connection.Action(Auto_Addr, true);
                Thread.Sleep(100);
            }
            else
            {
                AutoState = false;
                _connection.Action(Auto_Addr, false);
                Thread.Sleep(100);
            }
            
        }
        public void StatusChange()
        {
            try
            {
                if (AutoState == true)
                {
                    ACsw.Foreground = Brushes.White;
                    ACsw.Content = "ON";

                }
                else
                {
                    ACsw.Foreground= Brushes.Gray;
                    ACsw.Content = "OFF";
                }
                if (Speed == 0)
                {
                    ACspeed.Foreground = Brushes.Gray;
                }
                else
                {
                    ACspeed.Foreground = Brushes.White;
                }
                ACspeed.Content = Speed.ToString();
                if(RoomTemp!=null)
                {
                    Display.Text = RoomTemp.ToString();
                }
                
            }
            catch(Exception)
            {
                MessageBox.Show("No valid data");
            }
        
        }
    }
}
