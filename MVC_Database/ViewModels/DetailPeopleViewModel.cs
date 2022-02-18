﻿using MVC_Database.Models;
using System.Collections.Generic;

namespace MVC_Database.ViewModels
{
    public class DetailPeopleViewModel
    {
        public DetailPeopleViewModel()
        {
        }

        public DetailPeopleViewModel(Person person,string country)
        {
            Id = person.Id;
            Name = person.Name;
            Tele = person.Tele;
            CityId = person.CityId;
            Country = country;
        
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Tele { get; set; }

        public string CityId { get; set; }
        
        public string Country { get; set; }


    }
}