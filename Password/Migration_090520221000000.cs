using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;

namespace EmployeeRegistrationCRUD.Password
{
    [Migration(090520221000000)]
    public class Migration_090520221000000 : Migration
    {
        public override void Down()
        {
            Delete.Table("UserAuthentication");

        }

        public override void Up()
        {
            Create.Table("UserAuthentication")
                    .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                    .WithColumn("Email").AsString().NotNullable()
                    .WithColumn("Password").AsString().NotNullable()
                    .WithColumn("Expiry_Date").AsDateTimeOffset().NotNullable()
                    .WithColumn("Created_On").AsDate().NotNullable()
                    .WithColumn("Created_By").AsGuid().NotNullable()
                    .WithColumn("Updated_On").AsDateTime().NotNullable()
                    .WithColumn("Updated_By ").AsGuid().NotNullable()
                    .WithColumn("User_Id").AsGuid().NotNullable().ForeignKey("Employees", "Id");

        }
    }
}
