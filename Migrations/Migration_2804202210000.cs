using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;
using FluentMigrator.SqlServer;

namespace EmployeeRegistrationCRUD.Migrations
{
    [Migration(2804202210000)]
    public class Migration_2804202210000 : Migration
    {
        public override void Down()
        {
            
            Delete.Table("Employees");
        }

        public override void Up()
        {
            Create.Table("Employees")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("First_Name").AsString()
                .WithColumn("Last_Name").AsString()
                .WithColumn("Age").AsInt32()
                .WithColumn("City").AsString()
                .WithColumn("Gender").AsString()
                .WithColumn("State").AsString()
                .WithColumn("Contact_Number").AsInt32();
        }
    }
}
