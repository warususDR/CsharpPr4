using System;
using System.Threading.Tasks;
using PracticeDateHandling.Tools;

namespace PracticeDateHandling.Models
{
    public class Person
    {
        //properties

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;
        private string _sunSign;
        private string _chineseSign;
        private bool _isAdult;
        private bool _isBirthday;

        //constructor
        public Person(string name, string surname, string email, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;
            SunSign = Utilities.Zodiac(Birthday);
            ChineseSign = Utilities.ChineseZodiac(Birthday);
            IsAdult = Utilities.getAge(Birthday) >= 18;
            IsBirthday = (Birthday.Day == DateTime.Now.Day) && (Birthday.Month == DateTime.Now.Month);

        }
        //getters setters
        public string Name
        {
            get { return _name; }
            set
            {
                Utilities.CheckName(value);
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                Utilities.CheckName(value);
                _surname = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                Utilities.IsValidEmail(value);
                _email = value;
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                Utilities.CheckBirthday(value);
                _birthday = value;
            }
        }
        public string SunSign
        {
            get { return _sunSign; }
            private set
            {
                _sunSign = value;
            }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            private set
            {
                _chineseSign = value;
            }
        }

        public bool IsAdult
        {
            get
            {
                return _isAdult;
            }
            private set
            {
                _isAdult = value;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
            private set { _isBirthday = value; }
        }
    }
}