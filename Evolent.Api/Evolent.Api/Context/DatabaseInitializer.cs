using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Evolent.Api.Models;

namespace Evolent.Api.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext> 
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            var contact = new List<Contact> {
                                                new Contact{FirstName= "Daniel",LastName="Roth", Email="daroth@microsoft.com", PhoneNumber="9876543210",Status=true},
                                                new Contact{FirstName= "Glenn",LastName="Block", Email="gblock@microsoft.com", PhoneNumber="9876543211",Status=true},
                                                new Contact{FirstName= "Howard",LastName="Dierking", Email="howard@microsoft.com", PhoneNumber="9876543212",Status=true},
                                                new Contact{FirstName= "Yavor",LastName="Georgiev", Email="yavorg@microsoft.com", PhoneNumber="9876543213",Status=true},
                                                new Contact{FirstName= "Jeff",LastName="Handley", Email="jeff.handley@microsoft.com", PhoneNumber="9876543214",Status=true},
                                            };

            foreach (var item in contact)
            {
                context.Contacts.Add(item);
            }
        
            context.SaveChanges();
        }  
    }
}