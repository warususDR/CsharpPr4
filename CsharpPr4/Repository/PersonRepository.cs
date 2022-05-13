using PracticeDateHandling.Models;
using PracticeDateHandling.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CsharpPr4.Repository
{
    class PersonRepository
    {
        private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PersonRepStorage", "Persons");
        private void Fill()
        {          
            List<Person> ps = new List<Person>();
            ps.Add(new Person("Jack", "Frost", "carry@gmail.com", DateTime.Parse("28/02/1950"))); //0
            ps.Add(new Person("Jack", "Freeze", "marry@gmail.com", DateTime.Parse("28/02/1952"))); //1
            ps.Add(new Person("John", "Frost", "garry@gmail.com", DateTime.Parse("28/02/1989"))); //2
            ps.Add(new Person("Jill", "Frost", "okay@gmail.com", DateTime.Parse("29/03/2012"))); //3
            ps.Add(new Person("Jack", "Frost", "jarry@gmail.com", DateTime.Parse("28/02/1950"))); //4
            ps.Add(new Person("Jack", "Freeman", "baideny@gmail.com", DateTime.Parse("05/02/2002"))); //5
            ps.Add(new Person("John", "Freeman", "baideni@gmail.com", DateTime.Parse("05/02/2013"))); //6
            ps.Add(new Person("Jack", "Freeman", "baidene@gmail.com", DateTime.Parse("05/02/2002"))); //7
            ps.Add(new Person("Jeremy", "Freeman", "bye@gmail.com", DateTime.Parse("10/03/2002"))); //8
            ps.Add(new Person("John", "Doe", "siranyi@gmail.com", DateTime.Parse("10/01/2010"))); //9
            ps.Add(new Person("Jack", "Sojim", "japanese@gmail.com", DateTime.Parse("10/02/1980"))); //10
            ps.Add(new Person("Sara", "Freeman", "baideri@gmail.com", DateTime.Parse("05/02/2002"))); //11
            ps.Add(new Person("Sirin", "Raki", "warus@gmail.com", DateTime.Parse("05/10/2002"))); //12
            ps.Add(new Person("Mary", "Raki", "world@gmail.com", DateTime.Parse("10/03/2005"))); //13
            ps.Add(new Person("Jack", "Freewoman", "baidena@gmail.com", DateTime.Parse("05/02/2002"))); //14
            ps.Add(new Person("Maria", "Nearl", "arknight@gmail.com", DateTime.Parse("10/03/1976"))); //15
            ps.Add(new Person("Maria", "Jenkins", "warrior@gmail.com", DateTime.Parse("10/03/2003"))); //16
            ps.Add(new Person("Marta", "Nearl", "charry@gmail.com", DateTime.Parse("10/05/2000"))); //17
            ps.Add(new Person("Melon", "Carnage", "zeldafan@gmail.com", DateTime.Parse("23/03/1960"))); //18
            ps.Add(new Person("Zack", "Carrot", "enjoyer@gmail.com", DateTime.Parse("18/06/1990"))); //19
            ps.Add(new Person("Jeremy", "Raven", "observer@gmail.com", DateTime.Parse("10/03/1993"))); //20
            ps.Add(new Person("Moritz", "Storm", "sharp@gmail.com", DateTime.Parse("23/03/2001"))); //21
            ps.Add(new Person("Ronald", "Rapper", "americanboy@gmail.com", DateTime.Parse("16/07/2003"))); //22
            ps.Add(new Person("Sergio", "Stucker", "quest@gmail.com", DateTime.Parse("10/03/1993"))); //23
            ps.Add(new Person("Steven", "Queen", "novelist@gmail.com", DateTime.Parse("15/09/1967"))); //24
            ps.Add(new Person("Harry", "Potter", "wizardry@gmail.com", DateTime.Parse("20/07/1995"))); //25
            ps.Add(new Person("Sharon", "Stone", "outlast@gmail.com", DateTime.Parse("14/09/1987"))); //26
            ps.Add(new Person("Patty", "Crazy", "brimstone@gmail.com", DateTime.Parse("12/07/1996"))); //27
            ps.Add(new Person("Jack", "Pureboy", "virgolover@gmail.com", DateTime.Parse("15/08/1991"))); //28
            ps.Add(new Person("Serenoa", "Johnson", "shikimori@gmail.com", DateTime.Parse("25/01/1976"))); //29
            ps.Add(new Person("Stephan", "Streber", "applepie@gmail.com", DateTime.Parse("23/07/1999"))); //30
            ps.Add(new Person("Catherine", "Fullbody", "atlus@gmail.com", DateTime.Parse("25/03/1995"))); //31
            ps.Add(new Person("Jeremy", "Catlove", "cringe@gmail.com", DateTime.Parse("15/10/2000"))); //32
            ps.Add(new Person("Stranger", "Cavernmage", "magician@gmail.com", DateTime.Parse("23/04/1999"))); //33
            ps.Add(new Person("Rossino", "Caveman", "bored@gmail.com", DateTime.Parse("20/08/1989"))); //34
            ps.Add(new Person("Patty", "Endplease", "stopit@gmail.com", DateTime.Parse("05/09/2002"))); //35
            ps.Add(new Person("Alex", "Crouge", "japper@gmail.com", DateTime.Parse("25/11/1978"))); //36
            ps.Add(new Person("Rager", "Carrot", "jeger@gmail.com", DateTime.Parse("18/07/1965"))); //37
            ps.Add(new Person("James", "Lebron", "ok@gmail.com", DateTime.Parse("11/10/2000"))); //38
            ps.Add(new Person("Volodymyr", "Stepanenko", "boredom@gmail.com", DateTime.Parse("12/02/1983"))); //39
            ps.Add(new Person("Ivan", "Petrenko", "crybaby@gmail.com", DateTime.Parse("21/05/1981"))); //40
            ps.Add(new Person("Jeremy", "Raven", "observer@gmail.com", DateTime.Parse("10/03/1993"))); //41
            ps.Add(new Person("James", "Strong", "blossom@gmail.com", DateTime.Parse("13/07/1990"))); //42
            ps.Add(new Person("Cat", "Trager", "working@gmail.com", DateTime.Parse("17/02/1991"))); //43
            ps.Add(new Person("Richard", "Trager", "dogger@gmail.com", DateTime.Parse("12/06/1999"))); //44
            ps.Add(new Person("Hilory", "Croatian", "armer@gmail.com", DateTime.Parse("14/09/1990"))); //45
            ps.Add(new Person("Hilory", "Lager", "armen@gmail.com", DateTime.Parse("15/08/1991"))); //46
            ps.Add(new Person("Hilory", "Roger", "armem@gmail.com", DateTime.Parse("16/07/1992"))); //47
            ps.Add(new Person("Hilory", "Carter", "armel@gmail.com", DateTime.Parse("17/06/1993"))); //48
            ps.Add(new Person("John", "Endguy", "finally@gmail.com", DateTime.Parse("23/04/2002"))); //49

            foreach (var person in ps)
            {
                AddOrUpdate(person);
            }
        }
        public PersonRepository()
        {
            if (!Directory.Exists(BaseFolder))
            {
                Directory.CreateDirectory(BaseFolder);
                Fill();
            }
        }

        public async Task AddOrUpdateAsync(Person obj)
        {
            var stringObj = JsonSerializer.Serialize(obj);
            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, obj.Email), append: false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public void AddOrUpdate(Person obj)
        {
            var stringObj = JsonSerializer.Serialize(obj);
            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, obj.Email), append: false))
            {
                sw.Write(stringObj);
            }
        }

        public void Delete(string email)
        {
            string filePath = Path.Combine(BaseFolder, email);
            if (!File.Exists(filePath)) throw new FileNotFoundException();
            File.Delete(filePath);
        }

        public async Task<Person> GetPersonAsync(string email)
        {
            string stringObj = null;
            string filePath = Path.Combine(BaseFolder, email);

            if (!File.Exists(filePath)) return null;
            using(StreamReader sr = new StreamReader(filePath))
            {
                stringObj = await sr.ReadToEndAsync();
            }
            return JsonSerializer.Deserialize<Person>(stringObj);
        }

        public List<Person> GetAll()
        {
            var res = new List<Person>();

            foreach(var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sr = new StreamReader(file))
                {
                    stringObj = sr.ReadToEnd();
                }

                res.Add(JsonSerializer.Deserialize<Person>(stringObj));
            }

            return res;
        }

    }
}
