using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;

namespace EmployeeRegistrationCRUD.Migrations
{
    [Migration(0405202210000)]
    public class Migration_0405202210000 : Migration
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
                .WithColumn("ExpiryDate").AsDate().NotNullable()
                .WithColumn("CreatedOn").AsDate().NotNullable()
                .WithColumn("CreatedBy").AsGuid().NotNullable()
                .WithColumn("UpdatedOn").AsDateTime().NotNullable()
                .WithColumn("UpdatedBy ").AsGuid().NotNullable()
                .WithColumn("UserId").AsGuid().NotNullable().ForeignKey("Employees", "Id");

        }
    }
}
