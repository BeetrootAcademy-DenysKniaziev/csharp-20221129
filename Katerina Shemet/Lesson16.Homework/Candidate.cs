
namespace Voting
{
    class Candidate
    {
        private String firstName, lastName;
        private String politicalParty;
        private String position;
        private int votes;


        public Candidate(String f, String l, String pos, String pP)
        {
            firstName = f;
            lastName = l;
            politicalParty = pP;
            position = pos;
            votes = 0;
        }

        public String getFullName()
        {
                return (firstName + " " + lastName);   
        }

        public String getParty()
        {
            return politicalParty;
        }

        public String getPosition()
        {
            return position;
        }

        public void printSlogan()
        {  
            Console.Write(firstName + " " + lastName + ", " + politicalParty + " for " + politicalParty);
        }

        public void vote()
        {
            votes++;
        }

        public int getVotes()
        {
            return votes;
        }
    }
}

