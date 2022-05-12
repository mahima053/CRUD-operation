using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;

namespace EmployeeRegistrationCRUD.Password
{
    [Migration(09052022100000)]
    public class Migration_09052022100000 : Migration
    {
        public override void Down()
        {
            Delete.Table("passwordModels");
        }

        public override void Up()
        {
            Create.Table("passwordModels")
                    .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                    .WithColumn("Email").AsString().NotNullable()
                    .WithColumn("Password").AsString().NotNullable()
                    .WithColumn("Expiry_Date").AsDateTime().NotNullable()
                    .WithColumn("Created_On").AsDateTime().NotNullable()
                    .WithColumn("Created_By").AsGuid().NotNullable()
                    .WithColumn("Updated_On").AsDateTime().NotNullable()
                    .WithColumn("Updated_By ").AsGuid().NotNullable()
                    .WithColumn("User_Id").AsGuid().NotNullable().ForeignKey("Employees", "Id");


        }
    }
}
