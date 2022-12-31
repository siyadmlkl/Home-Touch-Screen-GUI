using KNXLib;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Windows.Media.Effects;

namespace TouchScreen
{
    public class Switch
    {
        public string SW_Addr { get; set; }
        public bool SW_state { get; set; }       
        public static KnxConnection _connection;
        public Button[] Lights { get; set; }
        public Button SW { get; set; }
        public void OnOff()
        {
            
            if (SW_state == false)
            {
                SW_state = true;
                _connection.Action(SW_Addr, true);
                //StatusChangei(SW,Rect);
                Thread.Sleep(100);
            }
            else
            {
                
                SW_state = false;
                _connection.Action(SW_Addr, false);
                //StatusChangei(SW,Rect);
                Thread.Sleep(100);
            }
        }
        public void StatusChange()
        {
            int N = Lights.Length;
            BlurBitmapEffect efect = new BlurBitmapEffect();
            if (SW_state==true)
            {
                for(int i=0;i<N;i++)
                {
                    Lights[i].BorderBrush = Brushes.AliceBlue;
                    Lights[i].Background = Brushes.AliceBlue;                    
                    efect.Radius = 20;
                    Lights[i].BitmapEffect = efect;
                }
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    Lights[i].BorderBrush = Brushes.AliceBlue;
                    Lights[i].Background = Brushes.Black;
                    efect.Radius = 2;
                    Lights[i].BitmapEffect = efect;
                }
            }
        }
    }
}
