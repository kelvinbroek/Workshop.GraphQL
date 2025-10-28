using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workshop.GraphQL.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthOfPlace",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hobbies",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephonenumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "BirthOfPlace", "Country", "Hobbies", "Telephonenumber", "Zipcode" },
                values: new object[] { "123 Main St", "New York", "USA", "[\"Reading\",\"Hiking\"]", "555-1234", "12345" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "BirthOfPlace", "Country", "Hobbies", "Telephonenumber", "Zipcode" },
                values: new object[] { "456 Oak Ave", "Chicago", "USA", "[\"Gaming\"]", "555-5678", "67890" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "BirthOfPlace", "Country", "Hobbies", "Telephonenumber", "Zipcode" },
                values: new object[] { "789 Pine Ln", "San Francisco", "USA", "[\"Skiing\",\"Cooking\"]", "555-9012", "10112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "DepartmentId", "Address", "BirthOfPlace", "Country", "Hobbies", "Telephonenumber", "Zipcode" },
                values: new object[,]
                {
                    { 4, "Employee 4", 1, "101 Maple St", "Los Angeles", "USA", "[]", "555-1111", "22222" },
                    { 5, "Employee 5", 2, "202 Birch Rd", "Houston", "USA", "[]", "555-2222", "33333" },
                    { 6, "Employee 6", 3, "303 Cedar Ave", "Phoenix", "USA", "[]", "555-3333", "44444" },
                    { 7, "Employee 7", 1, "404 Elm St", "Philadelphia", "USA", "[]", "555-4444", "55555" },
                    { 8, "Employee 8", 2, "505 Spruce Ln", "San Antonio", "USA", "[]", "555-5555", "66666" },
                    { 9, "Employee 9", 3, "606 Willow Dr", "San Diego", "USA", "[]", "555-6666", "77777" },
                    { 10, "Employee 10", 1, "707 Redwood Ct", "Dallas", "USA", "[]", "555-7777", "88888" },
                    { 11, "Employee 11", 2, "808 Aspen Way", "San Jose", "USA", "[]", "555-8888", "99999" },
                    { 12, "Employee 12", 3, "909 Sequoia Blvd", "Austin", "USA", "[]", "555-9999", "10000" },
                    { 13, "Employee 13", 1, "111 Cypress St", "Jacksonville", "USA", "[]", "555-1010", "11111" },
                    { 14, "Employee 14", 2, "222 Magnolia Rd", "Fort Worth", "USA", "[]", "555-2020", "12121" },
                    { 15, "Employee 15", 3, "333 Juniper Ave", "Columbus", "USA", "[]", "555-3030", "13131" },
                    { 16, "Employee 16", 1, "444 Poplar Ln", "Charlotte", "USA", "[]", "555-4040", "14141" },
                    { 17, "Employee 17", 2, "555 Sycamore Dr", "Indianapolis", "USA", "[]", "555-5050", "15151" },
                    { 18, "Employee 18", 3, "666 Hemlock Ct", "Seattle", "USA", "[]", "555-6060", "16161" },
                    { 19, "Employee 19", 1, "777 Fir Way", "Denver", "USA", "[]", "555-7070", "17171" },
                    { 20, "Employee 20", 2, "888 Alder Blvd", "Washington", "USA", "[]", "555-8080", "18181" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BirthOfPlace",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Hobbies",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Telephonenumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Employees");
        }
    }
}
