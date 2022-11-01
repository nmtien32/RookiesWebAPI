using System;
using RookiesWebAPI.Models;

namespace RookiesMVC.Service
{
    public class PersonService : IPersonService
    {
        private static List<PersonModel> _people = new List<PersonModel>{
               new PersonModel( "Van Nam","Le", "Female",new DateTime(2001,29,12),"0123789456","ThanhHoa",true ),
                new PersonModel( "Quynh Anh","Ngo", "Male",new DateTime(2002,27,11),"0123887555","HaNoi",true ),
                new PersonModel( "Ngoc Son","Pham", "Male",new DateTime(1999,08,9),"0123854789","QuangNinh",false ),
                new PersonModel( "Ba Xuan","Nguyen", "Male",new DateTime(2003,15,08),"0123654785","ThanhHoa",true ),
                new PersonModel( "Minh Tien","Nguyen", "Female",new DateTime(2000,02,03),"0123963852","NamDinh",false )
        };
        public List<PersonModel> GetAll()
        {
            return _people;
        }
        public PersonModel? GetOne(int index)
        {
            if (index >= 0 && index <= _people.Count)
            {
                return _people[index];
            }
            return null;
        }

        public PersonModel Create(PersonModel model)
        {
            _people.Add(model);
            return model;
        }
        public PersonModel? Update(int index, PersonModel model)
        {
            if (index >= 0 && index <= _people.Count)
            {
                _people[index] = model;
                return model;
            }
            return null;
        }
        public PersonModel? Delete(int index)
        {
            if (index >= 0 && index <= _people.Count)
            {
                var person = _people[index];
                _people.RemoveAt(index);
                return person;
            }
            return null;
        }
    }
}