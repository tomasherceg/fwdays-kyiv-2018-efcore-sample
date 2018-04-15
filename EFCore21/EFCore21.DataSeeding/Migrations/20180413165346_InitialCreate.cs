using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore21.DataSeeding.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    PublishedDate = table.Column<DateTime>(nullable: true),
                    BlogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: true),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Entity Framework Team Blog" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, ".NET Team Blog" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "BlogId", "Content", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Today, we are announcing .NET Core 2.1 Preview 2. The release is now ready for broad testing, as we get closer to a final build within the next two to three months. We’d appreciate any feedback that you have. ASP.NET Core 2.1 Preview 2 and Entity Framework 2.1 Preview 2 are also releasing today. You…", new DateTime(2018, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Announcing Entity Framework Core 2.1 Preview 2" },
                    { 2, 2, "Have you had to design general purpose “metadata” tables in your SQL database that basically store column names and values? Do you often serialize/de-serialize XML or JSON from your SQL tables to handle volatile schemas and data? .NET developers have traditionally worked with relational database management systems (RDMS) like SQL Server. RDMS systems have withstood…", new DateTime(2018, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explore CosmosDB with .NET Core and MongoDB" },
                    { 3, 2, "The user interface (UI) of any application is critical in making your app convenient and efficient for the folks using it. When developing applications for Enterprise use, a good UI can shave time off an entire company’s workflow. Visual Studio is investing in new tools to improve the productivity of Windows desktop developers and we’d love your…", new DateTime(2018, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calling all Desktop Developers: how should UI development be improved?" },
                    { 4, 2, "Today, we are happy to share an Early Access build with the .NET Framework 4.7.2 Developer Pack. The .NET Framework 4.7.2 Developer Pack lets developers build applications that target the .NET Framework 4.7.2 by using Visual Studio 2017, Visual Studio 2015 or other IDEs. This is a single package that bundles the .NET Framework 4.7.2, the…", new DateTime(2018, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), ".NET Framework 4.7.2 Developer Pack Early Access build 3056 is available!" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorName", "CreatedDate", "IpAddress", "PostId", "Text", "Type" },
                values: new object[] { 3, "Greg", new DateTime(2018, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "134.56.2.34", 1, "Cannot wait til I try it!", "Suggestion" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorName", "CreatedDate", "IpAddress", "PostId", "Text", "Type" },
                values: new object[] { 1, "Thomas", new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "218.1.146.14", 3, "Awesome news!", "Question" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorName", "CreatedDate", "IpAddress", "PostId", "Text", "Type" },
                values: new object[] { 2, "Bill [MSFT]", new DateTime(2018, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "199.34.52.20", 3, "Thank you, we hope this helps.", "General" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
