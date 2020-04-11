using System;
using System.Collections.Generic;
using System.Text;

namespace Circa.Models
{
    public class DateOption
    {
        //private int id;
        private DateTime date = new DateTime();
        private AppUser proposer;
        List<AppUser> voters;

        public DateOption(DateTime date, AppUser proposer)
        {
            Date = date;
            Proposer = proposer;
            Voters = new List<AppUser>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(date.Day);
            sb.Append(" de ");
            sb.Append(date.Month);
            sb.Append(" de ");
            sb.Append(date.Year);
            sb.Append(" - ");
            sb.Append(Proposer.Nickname);

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return Date.Equals(date.Date);
        }

        public DateTime Date { get => date; set => date = value; }
        public AppUser Proposer { get => proposer; set => proposer = value; }
        public List<AppUser> Voters { get => voters; set => voters = value; }
    }
}
