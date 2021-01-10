using FormManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormManagementApp.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var user = new User()
            {
                Id = 1,
                UserName = "cumaaliacar",
                Password = "1234"
            };
            var form = new Form()
            {
                Ad="Cumaali",
                Soyad="Acar",
                CreatedAt=new DateTime(2017,07,10),
                CreatedBy=1,
                Description="Form Description daha sonra girilecektir.",
                Name="Yeni",
                UserId=1,
                Yas=25
            };
            context.UserModels.Add(user);
            context.FormModels.Add(form);
            context.SaveChanges();
            base.Seed(context);
        }

    }
}