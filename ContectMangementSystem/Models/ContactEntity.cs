using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContectMangementSystem.Models
{
    public class ContactEntity : DbContext
    {
        public ContactEntity(DbContextOptions<ContactEntity> options) : base(options)
        {

        }

        DbSet<ContactModel>contactModels{ get; set; }
    }
}
