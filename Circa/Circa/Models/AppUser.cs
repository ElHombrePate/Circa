using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Circa.Models
{
    public class AppUser
    {
        private int id;
        private string nickname = "<Sin Apodo>";
        private List<CalendarEvent> events;
        //private ObservableCollection<CalendarEvent> events = new ObservableCollection<CalendarEvent>();

        public AppUser(int id, string nickname)
        {
            Id = id;
            Nickname = nickname;
        }

        public AppUser(int id, string nickname, List<CalendarEvent> events)
        {
            Id = id;
            Nickname = nickname;
            Events = events;
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
        public List<CalendarEvent> Events { get => events; set => events = value; }
    }
}