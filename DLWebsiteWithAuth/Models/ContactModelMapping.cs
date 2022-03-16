using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWebsiteWithAuth.Models
{
    public class ContactModelMapping : Profile
    {
        public ContactModelMapping()
        {
            CreateMap<ClientReferral, ContactModel>();
        }
    }
}