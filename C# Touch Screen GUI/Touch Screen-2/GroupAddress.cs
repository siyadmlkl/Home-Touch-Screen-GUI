using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;

namespace Touch_Screen_2
{
    public class GroupAddress
    {
        public static void ReadAddress(Room room, SQLiteConnection Conn)
        {
            //SQLiteConnection dcon = new SQLiteConnection();//("Data Source=D:/Development/Touch Screen Projects/Touch Screen-2/HAS.db;Version=3;");
            string Control = room.RoomName + "_Switch";
            room._Switch.SW_Addr=_addr(Control, Conn);
            Control = room.RoomName + "_Dimming";
            room._Dimmer.Dim_Addr = _addr(Control, Conn);
            Control = room.RoomName + "_Temp_Set";
            room._AC.Set_Temp_Addr = _addr(Control, Conn);
            Control = room.RoomName + "_Temp_Room";
            room._AC.Room_Temp_Addr = _addr(Control, Conn);
            Control = room.RoomName + "_AC_Auto";
            room._AC.Auto_Addr = _addr(Control, Conn);
            Control = room.RoomName + "_AC_Speed";
            room._AC.Speed_Addr = _addr(Control, Conn);
        }
        public static string _addr(string control, SQLiteConnection conn)
        {
                string Addr = "";
                SQLiteDataReader reader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT Address FROM GroupAdress WHERE RoomControl='" + control + "'";
                sqlite_cmd.ExecuteNonQuery();
                reader = sqlite_cmd.ExecuteReader();
                while (reader.Read())
                {
                    Addr = reader.GetString(0);
                }
                return Addr;
        }
        

    }
    
    
}
    

