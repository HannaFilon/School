using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace School.DAL.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Title", "IsActivated" },
                values: new object[]
                {
                    Guid.NewGuid(),
                    "Maths",
                    false
                });

            migrationBuilder.InsertData(
               table: "Courses",
               columns: new[] { "Id", "Title", "IsActivated" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Physics",
                    false
               });

            migrationBuilder.InsertData(
               table: "Courses",
               columns: new[] { "Id", "Title", "IsActivated" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Chemistry",
                    false
               });

            migrationBuilder.InsertData(
               table: "Courses",
               columns: new[] { "Id", "Title", "IsActivated" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Languages",
                    false
               });

            migrationBuilder.InsertData(
               table: "Courses",
               columns: new[] { "Id", "Title", "IsActivated" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Geography",
                    false
               });

            migrationBuilder.InsertData(
               table: "Courses",
               columns: new[] { "Id", "Title", "IsActivated" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Biology",
                    false
               });

            migrationBuilder.InsertData(
               table: "Courses",
               columns: new[] { "Id", "Title", "IsActivated" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Computer_studies",
                    false
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Robert P Larson",
                    DateTime.Parse("2010-04-12"),
                    "174 Whiteman Street, MARSTONS MILLS, Massachusetts, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Christine Bartlett",
                    DateTime.Parse("2008-10-05"),
                    "402 Cambridge Court, Springdale, Arkansas, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "James Duell",
                    DateTime.Parse("2010-02-17"),
                    "1246 Newton Street, Minneapolis, Minnesota, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Elaine J Jones",
                    DateTime.Parse("2009-06-11"),
                    "79 Armory Road, Wilmington, North Carolina, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Leon B Dominguez",
                    DateTime.Parse("2011-03-30"),
                    "4687 Brownton Road, Jackson, Mississippi, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Jay Cole",
                    DateTime.Parse("2009-05-05"),
                    "3609 McDowell Street, Nashville, Tennessee, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Annie W Miller",
                    DateTime.Parse("2010-12-21"),
                    "3268 Meadow Drive, Missoula, Montana, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Derick L Stockwell",
                    DateTime.Parse("2009-07-24"),
                    "3631 Renwick Drive, Philadelphia, Pennsylvania, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Jessica Silva",
                    DateTime.Parse("2008-09-08"),
                    "3056 Tanglewood Road, SAN SABA, Texas, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Marin J Putman",
                    DateTime.Parse("2010-11-27"),
                    "1704 Pike Street, San Diego, California, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Concetta Gagnon",
                    DateTime.Parse("2010-11-27"),
                    "4847 South Street, Seminole, Texas, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Donald Sova",
                    DateTime.Parse("2010-11-27"),
                    "4934 Chapel Street, WASHINGTON, District of Columbia, USA"
               });

            migrationBuilder.InsertData(
               table: "Students",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Carl Fitting",
                    DateTime.Parse("2010-11-27"),
                    "2141 Andell Road, Columbus, Ohio, USA"
               });

            migrationBuilder.InsertData(
               table: "Teachers",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Lizette A Lee",
                    DateTime.Parse("1992-02-13"),
                    "1647 Coulter Lane, Richmond, Virginia, USA"
               });

            migrationBuilder.InsertData(
               table: "Teachers",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Al L Fischer",
                    DateTime.Parse("1967-09-03"),
                    "3539 Smith Street, Rehoboth, Massachusetts, USA"
               });

            migrationBuilder.InsertData(
               table: "Teachers",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "William F Cano",
                    DateTime.Parse("1984-05-25"),
                    "2396 Woodstock Drive, Pasadena, California, USA"
               });

            migrationBuilder.InsertData(
               table: "Teachers",
               columns: new[] { "Id", "FullName", "DateOfBirth", "Address" },
               values: new object[]
               {
                    Guid.NewGuid(),
                    "Debbie J Mancini",
                    DateTime.Parse("1984-05-25"),
                    "2396 Woodstock Drive, Pasadena, California, USA"
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
