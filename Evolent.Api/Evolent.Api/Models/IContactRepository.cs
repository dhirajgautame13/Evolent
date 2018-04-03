using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Api.Models
{
    public interface IContactRepository
    {
        void Update(Contact updatedContact);

        Contact Get(int id);

        IQueryable<Contact> GetAll();

        void Post(Contact contact);

        Contact Delete(int id); 
    }
}
