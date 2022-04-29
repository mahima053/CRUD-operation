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
            
            Delete.Table("Employee");
        }

        public override void Up()
        {
            Create.Table("Employee")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("First_Name").AsString().NotNullable()
                .WithColumn("Last_Name").AsString().NotNullable()
                .WithColumn("Age").AsInt32().NotNullable()
                .WithColumn("City").AsString().NotNullable()
                .WithColumn("Gender").AsString().NotNullable()
                .WithColumn("State").AsString().NotNullable()
                .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee","Id");

        }
    }
}
