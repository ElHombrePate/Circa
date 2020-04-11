using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Circa.Models
{
    public class CalendarEvent
    {
        private const string DEFAULT_TITLE = "<Sin título>";
        private const string DEFAULT_DESCRIPTION = "<Sin ubicación>";
        private const string DEFAULT_UBICATION = "<Sin ubicacion>";
        private const string DEFAULT_FIELD = "<Sin tipo>";
        private static readonly DateTime VOTING_DEADLINE = DateTime.UtcNow.AddDays(7);

        // public static readonly Color Black = new Color(0, 0, 0);

        public static readonly string[] eventFieldArray = new string[]
        {
            "Familia",
            "Trabajo",
            "Amigos",
            "Médico"
        };

        //private int id;
        private string title;
        private string description;
        private string field;
        private string ubication;
        //collection notas
        private AppUser admin;
        private DateTime votingDeadline = DateTime.UtcNow;
        private List<DateOption> possibleDates = new List<DateOption>();

        
        public CalendarEvent(AppUser admin) {
            Title = DEFAULT_TITLE;
            Description = DEFAULT_DESCRIPTION;
            Ubication = DEFAULT_UBICATION;
            Field = DEFAULT_FIELD;
            Admin = admin;
        }
        

        public CalendarEvent(string title, string description, string field, AppUser admin, DateTime voteLimit, List<DateOption> possibleDates)
        {
            Title = title;
            Description = description;
            Field = field;
            Admin = admin;
            VotingDeadline = voteLimit;
            SetPossibleDates(possibleDates);
        }

        public static List<DateOption> createUserDatesList(List<DateTime> toBeAddedDates, AppUser proposer)
        {
            var votedDates = new List<DateOption>();
            
            if(toBeAddedDates != null && proposer != null)
            {
                //toBeAddedDates.Sort();


                foreach (DateTime item in toBeAddedDates)
                {
                    votedDates.Add(new DateOption(item, new AppUser(proposer.Id, proposer.Nickname)));
                }
            }

            votedDates.Sort(); //Por seguridad, aunque en prinicipio inececesario

            return votedDates;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Title);
            sb.Append(" - ");
            sb.Append(Admin.Nickname);
            sb.Append(" - ");
            sb.Append(votingDeadline);

            return sb.ToString();
        }

        //public string VoteLimitDate() => VoteLimit.Vote.Day.ToString();

        //public string VoteLimitTime() => VoteLimit.DateTime.Day.ToString();

        //public override string VoteLimit.ToString() {}

        

        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Ubication { get => ubication; set => ubication = value; }
        public string Field { get => field; set => field = value; }
        internal AppUser Admin { get => admin; set => admin = value; }
        public DateTime VotingDeadline { get => votingDeadline; set => votingDeadline = value; }

        public List<DateOption> GetPossibleDates()
        {
            return possibleDates;
        }

        public void SetPossibleDates(List<DateOption> value)
        {
            possibleDates = value;
        }




        /*
                public int Id
                {
                    get => Id;
                    private set
                    {
                        if(Id == 0)
                        {
                            Random rnd = new Random();
                            Id = rnd.Next(1, 10000);
                        }

                    }
                }

                public string Title {
                    get => Title;
                    set
                    {
                        if((value.Length>0) && (value.Length < 30))
                        {
                            Title = value;
                        }

                    }
                }
        */
    }
}
