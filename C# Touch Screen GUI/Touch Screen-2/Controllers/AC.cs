using KNXLib;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Windows.Media.Effects;
using System;
using System.Timers;
using System.Threading.Tasks;

namespace Touch_Screen_2
{
    public class AC
    {
        public string Speed_Addr { get; set; }
        public string Auto_Addr { get; set; }
        public string SpeedStatus_Addr { get; set; }
        public string SpeedStatus { get; }
        public string Set_Temp_Addr { get; set; }
        public string Room_Temp_Addr { get; set; }
        public bool AutoState { get; set; }
        public int Speed { get; set; }
        public string RoomTemp { get; set; }
        public string SetTemp { get; set; }
        public Button ACsw { get; set; }
        public TextBox DispSetTemp;
        public TextBox Display=new TextBox();
        public Button IncTemp;
        public Button DecTemp;
        public static KnxConnection _connection;
        public static System.Timers.Timer DisplayTime;

        public void Speed_Change()
        {
            switch (Speed)
            {
                case 1:
                    _connection.Action(Speed_Addr, true);
                    Thread.Sleep(200);
                    Speed = 2;
                    break;
                case 2:
                    _connection.Action(Speed_Addr, true);
                    Thread.Sleep(200);
                    Speed = 3;
                    break;
                case 3:
                    _connection.Action(Speed_Addr, false);
                    Thread.Sleep(200);
                    _connection.Action(Speed_Addr, false);
                    Thread.Sleep(200);
                    _connection.Action(Speed_Addr, false);
                    Thread.Sleep(200);
                    Speed = 0;
                    break;
                case 0:
                    _connection.Action(Speed_Addr, true);
                    Thread.Sleep(200);
                    Speed = 1;
                    break;
            }
        }
        public async void Inc_Temp()
        {
            
            double STemp = Convert.ToDouble(SetTemp);
            STemp = STemp + 0.5;
            SetTemp = STemp.ToString();
            byte[] Temp = _connection.ToDataPoint("9.001",SetTemp);
            _connection.Action(Set_Temp_Addr, Temp);
            Display.Text = SetTemp;
            await Task.Delay(1000);
            Display.Text = RoomTemp;
        }
        public void Dec_Temp()
        {
            double STemp = Convert.ToDouble(SetTemp);
            if (STemp <= 18.0)
            { STemp = 18.0; }
            STemp = STemp - 0.5;
            SetTemp = STemp.ToString();
            byte[] Temp = _connection.ToDataPoint("9.001", SetTemp);
            _connection.Action(Set_Temp_Addr, Temp);
        }
        public void OnOff()
        {

            if (AutoState == false)
            {
                AutoState = true;
                _connection.Action(Auto_Addr, true);
                //StatusChangei(SW,Rect);
                Thread.Sleep(100);
            }
            else
            {

                AutoState = false;
                _connection.Action(Auto_Addr, false);
                Thread.Sleep(100);

               // _connection.Action(Speed_Addr, false);
               // Thread.Sleep(200);
               // _connection.Action(Speed_Addr, false);
               // Thread.Sleep(200);
               // _connection.Action(Speed_Addr, false);
               // Thread.Sleep(200);
            }
        }
        public void StatusChangei()
        {
            //Room = (Button[])room;
            
            BlurBitmapEffect efect = new BlurBitmapEffect();
            if (AutoState== true)
            {
                    ACsw.BorderBrush = Brushes.SkyBlue;
                    ACsw.Background = Brushes.SkyBlue;
                    efect.Radius = 5;
                    ACsw.BitmapEffect = efect;
            }
            else
            {
                    ACsw.BorderBrush = Brushes.Gray;
                    ACsw.Background = Brushes.Transparent;
                    efect.Radius = 2;
                    ACsw.BitmapEffect = efect;
            }
        }
    }
}
