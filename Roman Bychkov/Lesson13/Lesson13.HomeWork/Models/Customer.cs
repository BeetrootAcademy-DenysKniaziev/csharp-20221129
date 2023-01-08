using System.Text.RegularExpressions;

public class Customer
{

    string _name;
    string _lastName;
    string _phoneNumber;
    DateTime _dateOfBirth;
    public string Name
    {
        get => _name;
        set
        {
            if (Regex.IsMatch(value, @"^[A-Z]{1}[a-z]+$"))
                _name = value;
            else
                throw new ArgumentException("Invalid Name");
        }

    }
    public string LastName
    {
        get => _lastName;
        set
        {
            if (Regex.IsMatch(value, @"^[A-Z]{1}[a-z]+$"))
                _lastName = value;
            else
                throw new ArgumentException("Invalid LastName");
        }
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (Regex.IsMatch(value.ToString(), @"^[0-9]{9}$"))
                _phoneNumber = value;
            else
                throw new ArgumentException("Invalid PhoneNumber");
        }
    }

    public DateTime DateOfBorn
    {
        get => _dateOfBirth;

        set
        {
            if (value.Year > DateTime.Now.AddYears(-18).Year)
                throw new ArgumentException("This person is incomplete.");
            else
                _dateOfBirth = value;
        }
    }
    public Customer(string name, string lastName, DateTime dateOfBorn, string phoneNumber)
    {
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        DateOfBorn = dateOfBorn;
    }
    public override string ToString()
    {
        return $"{Name,10}\t{LastName, 10}\t{DateOfBorn,19:D}\t{PhoneNumber,9}";
    }
}

