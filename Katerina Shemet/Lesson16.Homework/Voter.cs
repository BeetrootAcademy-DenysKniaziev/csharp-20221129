using System.Text.RegularExpressions;

namespace Voting
{
    class Voter
    {
        private String firstName, lastName;
        DateTime birth;
        String format = "dd/MM/yyyy";
        private String partyAffliation;
        private String idNumber = null;
        private int ssn;
        private String homeAddress, municipalityHome, countyHome, zipCodeHome;
        private String mailingAddress, municipalityMailing, countyMailing, zipCodeMailing;
        private String gender;
        private bool isCriminal;

        public Voter()
        {
            setName();
            setBirth();
            setGender();
            setAddress();
            setCriminalRecord();
        }

        public bool compare(Voter v)
        {
            if (v.getFirstName().Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                v.getLastName().Equals(lastName, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public bool ofAge()
        {
            int yearsOld = DateTime.Today.Year - birth.Year;
            if (DateTime.Today < birth.AddYears(yearsOld))
                yearsOld--;
            if (yearsOld < 18)
                return false;
            return true;
        }

        public void setName()
        {
            bool correct = false;
            bool correctName = false;

            do
            {
                do
                {
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    firstName = Regex.Replace(firstName, "[^A-Za-z]", "");
                    if (String.IsNullOrEmpty(firstName))
                        Console.WriteLine("Invalid first name");
                    else
                        correct = true;
                } while (!correct);

                correct = false;

                do
                {
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    lastName = Regex.Replace(lastName, "[^A-Za-z]", "");
                    if (String.IsNullOrEmpty(lastName))
                        Console.WriteLine("Invalid last name");
                    else
                        correct = true;
                } while (!correct);

                Console.Write(firstName + " " + lastName + ", is this correct (y/n)? ");
                if ((Console.ReadLine()).Equals("y", System.StringComparison.OrdinalIgnoreCase))
                    correctName = true;
            } while (!correctName);
        }

        public void printFullName()
        {
            Console.WriteLine(firstName + " " + lastName);
        }

        public String getFirstName()
        {
            return firstName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public void setGender()
        {
            bool correct = false;
            bool correctGender = false;

            do
            {
                do
                {
                    Console.Write("Gender (M/F/O): ");
                    gender = Console.ReadLine();

                    gender = Regex.Replace(gender, "[^MmFmOo]", "");
                    if (String.IsNullOrEmpty(gender) || gender.Length != 1)
                        Console.WriteLine("Invalid entry");
                    else
                        correct = true;
                } while (!correct);

                Console.Write(gender + ", is this correct (y/n)? ");
                if ((Console.ReadLine()).Equals("y", System.StringComparison.OrdinalIgnoreCase))
                    correctGender = true;
            } while (!correctGender);
        }

        public void printGender()
        {
            Console.WriteLine(gender);
        }

        public String getGender()
        {
            return gender;
        }

        public void setBirth()
        {
            int birthMonth = 11, birthDay = 1, birthYear = 1991;
            bool correct = false;
            bool correctBirth = false;

            do
            {
                do
                {
                    Console.Write("Birthday (DD): ");
                    String t = Console.ReadLine().Trim();
                    t = Regex.Replace(t, "[^0-9]", "");
                    if (String.IsNullOrEmpty(t) || t.Length != 2)
                        Console.WriteLine("Invalid entry");
                    else
                    {
                        if (0 < Convert.ToInt32(t) && Convert.ToInt32(t) < 32)
                        {
                            birthDay = Convert.ToInt32(t);
                            correct = true;
                        }
                        else
                            Console.WriteLine("Invalid number");
                    }

                } while (!correct);

                correct = false;

                do
                {
                    Console.Write("Birthmonth (MM): ");
                    String t = Console.ReadLine().Trim();
                    t = Regex.Replace(t, "[^0-9]", "");
                    if (String.IsNullOrEmpty(t) || t.Length != 2)
                        Console.WriteLine("Invalid entry");
                    else
                    {
                        if (0 < Convert.ToInt32(t) && Convert.ToInt32(t) < 13)
                        {
                            if (birthDay == 31 && (Convert.ToInt32(t) == 4 || Convert.ToInt32(t) == 6 || Convert.ToInt32(t) == 11))
                                Console.WriteLine("Incompatible month");
                            else if (Convert.ToInt32(t) == 2 && birthDay > 29)
                                Console.WriteLine("Incompatible month");
                            else
                            {
                                birthMonth = Convert.ToInt32(t);
                                correct = true;
                            }
                        }
                        else
                            Console.WriteLine("Invalid number");
                    }
                } while (!correct);

                correct = false;

                do
                {
                    Console.Write("Birthyear (YYYY): ");
                    String t = Console.ReadLine().Trim();
                    t = Regex.Replace(t, "[^0-9]", "");
                    if (String.IsNullOrEmpty(t) || t.Length != 4)
                        Console.WriteLine("Invalid entry");
                    else
                    {
                        if (birthMonth == 2 && birthDay == 29)
                        {
                            if (((Convert.ToInt32(t) % 4 == 0) && ((Convert.ToInt32(t) % 100 != 0) || (Convert.ToInt32(t) % 400 == 0))) == false)
                                Console.WriteLine("Incompatible year");
                            else
                            {
                                birthYear = Convert.ToInt32(t);
                                correct = true;
                            }
                        }
                        else
                        {
                            birthYear = Convert.ToInt32(t);
                            correct = true;
                        }
                    }
                } while (!correct);

                birth = new DateTime(birthYear, birthMonth, birthDay);

                Console.Write(birth.Day + "/" + birth.Month + "/" + birth.Year + ", is this correct (y/n)? ");
                if ((Console.ReadLine()).Equals("y", System.StringComparison.OrdinalIgnoreCase))
                    correctBirth = true;
            } while (!correctBirth);
        }

        public void printBirth()
        {
            Console.WriteLine(birth.ToString(format));
        }

        

        public void setAddress()
        {
            bool correctAddress = false;
            bool correct;
            String t = null;

            do
            {
                correct = false;

                do
                {
                    Console.Write("Zip code: ");
                    t = Console.ReadLine().Trim();
                    t = Regex.Replace(t, "[^0-9]", "");
                    if (String.IsNullOrEmpty(t) || t.Length != 5)
                        Console.WriteLine("Invalid entry");
                    else
                    {
                        zipCodeHome = t;
                        correct = true;
                    }
                } while (!correct);

                correct = false;

                do
                {
                    Console.Write("County: ");
                    t = Console.ReadLine().Trim();
                    t = Regex.Replace(t, "[^A-Za-z(' ')]", "");
                    if (String.IsNullOrEmpty(t))
                        Console.WriteLine("Invalid entry");
                    else
                    {
                        countyHome = t;
                        correct = true;
                    }
                } while (!correct);

                correct = false;

                do
                {
                    Console.Write("Municipality/Town/City: ");
                    t = Console.ReadLine().Trim();
                    t = Regex.Replace(t, "[^A-Za-z(' ')]", "");
                    if (String.IsNullOrEmpty(t))
                        Console.WriteLine("Invalid entry");
                    else
                    {
                        municipalityHome = t;
                        correct = true;
                    }
                } while (!correct);

                correct = false;

                do
                {
                    Console.Write("Home address: ");
                    t = Console.ReadLine().Trim();
                    t = Regex.Replace(t, "[^A-Za-z0-9(' ')]", "");
                    if (String.IsNullOrEmpty(t))
                        Console.WriteLine("Invalid entry");
                    else
                    {
                        homeAddress = t;
                        correct = true;
                    }
                } while (!correct);

                Console.Write(homeAddress + "\n" + municipalityHome + ", " + countyHome + ", NJ " + zipCodeHome + "\nIs this correct (y/n)? ");
                if ((Console.ReadLine()).Equals("y", System.StringComparison.OrdinalIgnoreCase))
                    correctAddress = true;
            } while (!correctAddress);

            Console.Write("Do you have a mailing address different from your home (y/n)? ");
            if ((Console.ReadLine()).Equals("y", System.StringComparison.OrdinalIgnoreCase))
            {
                correctAddress = false;

                do
                {
                    correct = false;

                    do
                    {
                        Console.Write("Mailing zip code: ");
                        t = Console.ReadLine().Trim();
                        t = Regex.Replace(t, "[^0-9]", "");
                        if (String.IsNullOrEmpty(t) || t.Length != 5)
                            Console.WriteLine("Invalid entry");
                        else
                        {
                            zipCodeMailing = t;
                            correct = true;
                        }
                    } while (!correct);

                    correct = false;

                    do
                    {
                        Console.Write("Mailing county: ");
                        t = Console.ReadLine().Trim();
                        t = Regex.Replace(t, "[^A-Za-z(' ')]", "");
                        if (String.IsNullOrEmpty(t))
                            Console.WriteLine("Invalid entry");
                        else
                        {
                            countyMailing = t;
                            correct = true;
                        }
                    } while (!correct);

                    correct = false;

                    do
                    {
                        Console.Write("Mailing municipality/town/city: ");
                        t = Console.ReadLine().Trim();
                        t = Regex.Replace(t, "[^A-Za-z(' ')]", "");
                        if (String.IsNullOrEmpty(t))
                            Console.WriteLine("Invalid entry");
                        else
                        {
                            municipalityMailing = t;
                            correct = true;
                        }
                    } while (!correct);

                    correct = false;

                    do
                    {
                        Console.Write("Mailing address:");
                        t = Console.ReadLine().Trim();
                        t = Regex.Replace(t, "[^A-Za-z0-9(' ')]", "");
                        if (String.IsNullOrEmpty(t))
                            Console.WriteLine("Invalid entry");
                        else
                        {
                            mailingAddress = t;
                            correct = true;
                        }
                    } while (!correct);

                    Console.Write(mailingAddress + "\n" + municipalityMailing + ", " + countyMailing + ", NJ " + zipCodeMailing + "\nIs this correct (y/n)? ");
                    if ((Console.ReadLine()).Equals("y", System.StringComparison.OrdinalIgnoreCase))
                        correctAddress = true;

                } while (!correctAddress);
            }
        }

        public void printAddress()
        {
            if (!String.IsNullOrEmpty(mailingAddress))
            {
                Console.Write("Home address:\n");
                Console.WriteLine(homeAddress + "\n" + municipalityHome + ", " + countyHome + ", NJ " + zipCodeHome);

                Console.Write("Mailing address:\n");
                Console.Write(mailingAddress + "\n" + municipalityMailing + ", " + countyMailing + ", NJ " + zipCodeMailing);

                return;
            }

            Console.Write("Home address:\n");
            Console.WriteLine(homeAddress + "\n" + municipalityHome + ", " + countyHome + ", NJ " + zipCodeHome);
        }

        public void setCriminalRecord()
        {
            int count = 0;
            do
            {
                Console.Write("Are you currently in prison or on probation (y/n)? ");
                String t = Console.ReadLine();
                if (t.Equals("y", System.StringComparison.OrdinalIgnoreCase))
                {
                    isCriminal = true;
                    count = 1;
                }
                else if (t.Equals("n", System.StringComparison.OrdinalIgnoreCase))
                {
                    isCriminal = false;
                    count = 1;
                }
            } while (count == 0);
        }

        public bool getCriminalRecord()
        {
            return isCriminal;
        }

        public String getHomeAddress()
        {
            return ("Home address: " + homeAddress + " " + municipalityHome + ", " + countyHome + ", NJ " + zipCodeHome);
        }

        public String getMailingAddress()
        {
            if (String.IsNullOrEmpty(mailingAddress))
            {
                return ("Home address: " + homeAddress + " " + municipalityHome + ", " + countyHome + ", NJ " + zipCodeHome);
            }

            return ("Mailing address: " + mailingAddress + " " + municipalityMailing + ", " + countyMailing + ", NJ " + zipCodeMailing);
        }
    }
}

