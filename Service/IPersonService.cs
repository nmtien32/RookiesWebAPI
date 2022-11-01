using System;
using RookiesWebAPI.Models;

namespace RookiesWebAPI.Service
{
    public interface IPersonService
    {
        List<PersonModel> GetAll();
        PersonModel? GetOne(int index);
        PersonModel Create(PersonModel model);
        PersonModel? Update(int index, PersonModel model);
        PersonModel? Delete(int index);
    }
}