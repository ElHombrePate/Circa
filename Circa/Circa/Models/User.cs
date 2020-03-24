using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Circa.Models
{
    public class User
    {
        private int id;
        private string nickname = "<Sin Apodo>";
        private ObservableCollection<CalendarEvent> events = new ObservableCollection<CalendarEvent>();

        public User(int id, string nickname, ObservableCollection<CalendarEvent> events)
        {
            Id = id;
            Nickname = nickname;
            Events = events;
        }

        public User(int id, string nickname) 
        {
            Id = id;
            Nickname = nickname;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Id);
            sb.Append(Nickname);

            return sb.ToString();
        }

        public int Id { get => id; set => id = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public ObservableCollection<CalendarEvent> Events { get => events; set => events = value; }
    }
}