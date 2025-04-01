using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iSchool_Solution.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Faculties_FacultyID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Courses_CourseID",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceBorrowings_AspNetUsers_StudentId",
                table: "ResourceBorrowings");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceBorrowings_LibraryResources_LibraryResourceID",
                table: "ResourceBorrowings");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Lecturers_CourseID",
                table: "Lecturers");

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("12ec5707-80a9-41f3-9fcd-eae84a472373"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("39e631cd-1bef-412c-8e1f-139d8e681dc8"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("552dbe8f-11c0-4bbe-9670-01a37277fdba"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("658c5984-1c80-4a9e-9aab-29c2e6843280"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("8953341e-d071-4ba1-92ff-12f126250adc"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("9febe164-e2d9-46d2-8e72-ffe3edc1153b"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("cafd8292-75c1-49f2-a804-72c75576454d"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("de56a00d-3226-41a4-8853-5f2f56a1d491"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("0062ca09-cb14-4848-89ba-bf67d3f47558"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("204c5a07-76d1-4cd9-b8d0-a9f03f71f0dc"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("2c3cf3e7-8d5a-4d96-a43b-7129f8609ebc"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("36748cb9-3334-4842-adeb-1dad00176201"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("39f92acc-5a6b-4ec9-b42a-6aa63ade34ac"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("39fb16d9-4838-4ede-b54c-f0e54b7c03e9"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("4c146b27-19aa-494c-b73c-4bb2e6b72181"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("6c845634-cb6d-45e2-b659-1b6e0d3764e7"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("75b2887a-e4cc-4ec4-8d6a-f79accc5a942"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("77b49912-6570-4173-a846-3240e8b6e688"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("7e78d48a-9c30-4f2b-aea5-2fe1f419629c"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("8f368706-5f28-4ae8-9311-df79be89cd87"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("8fece7d7-737e-4625-bc9a-d5392ae16a7e"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("920d6408-dc36-4da4-82dd-b8d89879c4e5"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("971b2827-460d-4eab-bf7d-5ceec95e12e9"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("9b503f55-0d9d-4a72-b36d-00007d653e19"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("9e11fb93-430a-4b00-9484-9fa5d244d7f6"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("a0153b89-8d4d-4e7b-8590-0ea0c065e680"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("a75b1f50-327c-43b6-81f3-60f6a11b2a39"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("a8fbc857-3859-4290-b237-a3c34ede9a12"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("b51eecd8-ba6b-48f8-a0c3-9db931701e30"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("c1c8f6b4-aa8a-4290-85b6-d37cf1cbd6de"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("ca8b289b-3e16-4cec-96f4-e42bc265d541"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("cbebda38-3ec2-48aa-b0ad-062272d89f1b"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("d10082ac-f3e9-4d09-b6db-cd80f309289c"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("d2de626b-f5eb-4b56-90a3-c6ebf0a3ff9b"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("da251655-a9b0-4ffc-ae14-58e05447fa21"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("dae9a67c-7463-4202-a21c-8f0768a2d004"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("dbd2656c-078b-4dac-8855-118ef5fd3f13"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("e805a0ae-aa24-4664-b92e-20e9237f7087"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("ef16e32c-5600-45a4-9a0e-2f61b63081e9"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("f51c3927-2d65-40a8-892f-986e68899f8c"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("f6077631-118c-4c78-9bdb-7a7bda448145"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("fc538f1e-42cf-438b-b715-b3760fe528c6"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("0879919f-0859-4bcf-af04-14866fb2c632"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("142e51ae-a1e0-4af2-9ccd-bf72ddcc23f8"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("224856e4-2dab-461e-9a6d-5af7e251bd6a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("2d4665dc-73ed-414d-84f9-04997affe73a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("3030cdb2-31d2-412c-b76f-f9f559d06e41"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("30ef83f3-d15e-469f-8bb9-dbfbb859d638"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("367dbb5b-8eb2-48c2-98fb-f6a6b23bb958"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("460d5cbb-99b4-4a08-b25c-c1ebaf682573"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("4760e506-6ea9-466c-b040-a24e8d6b51aa"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("51d63611-e336-4d8b-a203-512179e33000"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("5223758b-53f0-42a6-b6da-162a013a8522"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("528cdfc0-0bbb-4d7c-baa1-1c84c4c39cde"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("5359df1b-c663-42d0-98c8-b3761e8d09cf"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("5490f4c8-b071-47db-8421-9261b3de4f83"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("67501f6f-2e0d-40d1-be02-15f3a8571467"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("6ccc3b12-b813-4ecc-9969-8302f2cc212a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("7fec2139-1bd6-4da2-b482-922e33c1fe1d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("8139cdd9-c82b-4b5e-b6d0-31bb05d2a942"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("84f12965-202f-47da-acaf-3a66ede57d28"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("8c1075fc-ff0b-4b26-a77a-334371a0c3ca"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("8e689d3b-5d91-48f6-aaaf-8dd93d6add3f"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("906d3943-6221-4cc7-8b4c-9bcb82eac86d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("9dbe4a75-946b-4183-a321-1fa6ab63bd70"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("a41ec771-7d4d-411a-9c3e-b8705c3a2e00"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("a6cbe756-ea6e-4ce6-b22d-181cb1f993dc"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("a7120d6d-8ebd-46a7-a7ac-d30e88210c67"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("ab8f7b77-87d1-4991-8d94-a248dafb5f21"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("ac347fef-cc16-434a-85ba-605712c9459c"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("b422316a-4814-40fe-a20a-858e076e01a0"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("b521b4cd-2150-42c9-970f-460607af3f6a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("b86738e3-2aa6-4c01-96e4-f061900e1237"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("bc91ca56-7c40-45d2-906e-ec14d97d6c9d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("c1dd35f0-9613-42c6-bcc9-9cba05dccf76"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("c29000cb-56fb-4ca5-a615-4ec989e1976d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("c635a327-55da-4ac8-b504-6c58474805ec"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("c808894d-0539-4458-a354-aa2be3fcd02a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("ccf5cae9-b411-40ca-bf43-b9d6fce9ff94"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("cf5f6515-b2a5-4b78-80a3-fe3a09ada802"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("d2526021-0cbd-4237-afcc-06a286efe990"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("d99fbd5e-b2af-4ab0-ad1c-95b1460ce254"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("eaded960-c960-4614-91a4-56e16e0d45b2"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("eb1f3037-00d6-4d7f-91d6-d3fc8e419a8b"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("f1c00dd7-b802-4f05-bb23-01a48e6857e8"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("fbe58454-1d09-49b0-820c-0464b7b0ec86"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("fcc6657b-23e1-49e4-a163-a2e5a997fdca"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("1373fabc-d569-4702-b49d-b5843615403f"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("19ac50f6-c91d-482f-a317-f31aa1d1b5a7"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("40582ce5-c69c-4971-89ac-db91378d785b"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("46fdd54d-25b9-41d4-a8a1-1ad7f4501d55"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("68fdcb46-491e-4d2f-b520-912a603f9e0a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("b0fcc293-5634-4254-bbd3-34b63aa36774"));

            migrationBuilder.DeleteData(
                table: "RegistrationPeriods",
                keyColumn: "RegistrationPeriodID",
                keyValue: new Guid("fe0137a4-129b-4202-8992-43888f906cd0"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("2d6e37df-0e61-439b-957b-904740b3883f"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("6eb6ce00-ddd4-4c45-be84-01f00286ddee"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("8d679424-ebfb-4a05-aa3d-c9b43b99ac8d"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"));

            migrationBuilder.DeleteData(
                table: "FinancialRecords",
                keyColumn: "FinancialRecordID",
                keyValue: new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"));

            migrationBuilder.DeleteData(
                table: "FinancialRecords",
                keyColumn: "FinancialRecordID",
                keyValue: new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"));

            migrationBuilder.DeleteData(
                table: "FinancialRecords",
                keyColumn: "FinancialRecordID",
                keyValue: new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("04f4f643-b035-4715-8955-2465e277bbf5"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"));

            migrationBuilder.DeleteData(
                table: "Transcripts",
                keyColumn: "TranscriptID",
                keyValue: new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c"));

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Lecturers");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    FinancialRecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_FinancialRecords_FinancialRecordID",
                        column: x => x.FinancialRecordID,
                        principalTable: "FinancialRecords",
                        principalColumn: "FinancialRecordID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Invoices_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGatewayTransactions",
                columns: table => new
                {
                    GatewayTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GatewayName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GatewayTransactionReference = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailureCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailureMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountProcessed = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTimestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RawResponseData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGatewayTransactions", x => x.GatewayTransactionID);
                    table.ForeignKey(
                        name: "FK_PaymentGatewayTransactions_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentReminders",
                columns: table => new
                {
                    ReminderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    FinancialRecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FeeItemID = table.Column<int>(type: "int", nullable: true),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReminderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReminderType = table.Column<int>(type: "int", nullable: false),
                    SentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentReminders", x => x.ReminderID);
                    table.ForeignKey(
                        name: "FK_PaymentReminders_FeeItems_FeeItemID",
                        column: x => x.FeeItemID,
                        principalTable: "FeeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PaymentReminders_FinancialRecords_FinancialRecordID",
                        column: x => x.FinancialRecordID,
                        principalTable: "FinancialRecords",
                        principalColumn: "FinancialRecordID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentReminders_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLineItems",
                columns: table => new
                {
                    InvoiceLineItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeeItemID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLineItems", x => x.InvoiceLineItemID);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_FeeItems_FeeItemID",
                        column: x => x.FeeItemID,
                        principalTable: "FeeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222CS01000694",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "623e0d83-15bb-410e-b00c-ab6d6766627b", "AQAAAAIAAYagAAAAEPMRUYy+9LEdtWnjrCON1Y6aoCAaUvqHGnmtDrMPKxJzyHz6TQKbToOSPT6Hk7+caQ==", "7d1541ef-233a-4f6e-93a9-37a3276ee156" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), "222CS01000694" },
                column: "RegistrationPeriodID",
                value: new Guid("8f028ff7-eda7-4bd6-b9dc-f6d33c4972fc"));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), "222CS01000694" },
                column: "RegistrationPeriodID",
                value: new Guid("8f028ff7-eda7-4bd6-b9dc-f6d33c4972fc"));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), "222CS01000694" },
                column: "RegistrationPeriodID",
                value: new Guid("8f028ff7-eda7-4bd6-b9dc-f6d33c4972fc"));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), "222CS01000694" },
                column: "RegistrationPeriodID",
                value: new Guid("8f028ff7-eda7-4bd6-b9dc-f6d33c4972fc"));

            migrationBuilder.InsertData(
                table: "CourseTimeSlot",
                columns: new[] { "CourseTimeSlotID", "CourseID", "DayOfWeek", "EndTime", "LecturerID", "Location", "StartTime" },
                values: new object[,]
                {
                    { new Guid("12acd859-70a5-4a36-af06-afe44e9fe216"), new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), 5, new TimeSpan(0, 12, 30, 0, 0), "L0002", 5, new TimeSpan(0, 10, 0, 0, 0) },
                    { new Guid("61622c25-0434-4fc0-a776-ca57195a0a2e"), new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), 5, new TimeSpan(0, 9, 30, 0, 0), "L0002", 3, new TimeSpan(0, 7, 0, 0, 0) },
                    { new Guid("7378abfb-d932-428b-ab84-87a32d6de75e"), new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), 4, new TimeSpan(0, 15, 50, 0, 0), "L0001", 4, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("bab91284-ec26-439e-9852-dbd76bd594e4"), new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), 3, new TimeSpan(0, 12, 30, 0, 0), "L0002", 5, new TimeSpan(0, 10, 0, 0, 0) },
                    { new Guid("c4511bca-0142-4b03-b8a2-00f4e8d1aa8c"), new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), 1, new TimeSpan(0, 16, 30, 0, 0), "L0001", 0, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("cb1f8dad-4cb3-42c8-90e4-2cb66625f972"), new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), 3, new TimeSpan(0, 16, 30, 0, 0), "L0001", 4, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("d2d43c71-e423-4d42-b605-dcd177065b9a"), new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), 1, new TimeSpan(0, 12, 30, 0, 0), "L0001", 5, new TimeSpan(0, 10, 0, 0, 0) },
                    { new Guid("f03d7e47-92dc-4b1b-a8fd-f68c526e802a"), new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), 2, new TimeSpan(0, 16, 30, 0, 0), "L0001", 4, new TimeSpan(0, 14, 0, 0, 0) }
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("012bdf77-0b02-4d88-8da0-105ba9f1f829"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("064f2d40-55de-4ff5-a56c-c57c1dd562f4"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("0922f512-59fd-43c4-9d36-cdd18fccfb13"),
                column: "DepartmentID",
                value: new Guid("c1e22698-ee7e-45eb-8c4c-85e603306812"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("095a4f84-f388-4a49-9994-43eb52ec18e0"),
                column: "DepartmentID",
                value: new Guid("c1e22698-ee7e-45eb-8c4c-85e603306812"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("0badf6bd-77ef-4c6d-a568-912b57daf884"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("13a87b42-12ce-4cbc-8011-fc2c792f29e5"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("13c34157-f376-4a31-9391-7fdd4d7fbdb7"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("1897059a-c3fc-4cb3-a6dc-0aa23f62fc4d"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("1a46ac1d-c607-4225-9002-e14a4c1e3363"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("1b006764-b19a-402b-a17a-f9a12d5f4b76"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("1b84cd21-2550-41d3-b3d4-7a985e71d1ea"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("1f1f83d3-6271-4ac5-964f-2805ae049fa1"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("20a3f858-958e-42b0-b841-e907b592ce0e"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("20acdf30-8b86-4b77-921d-02b0bc9ee0d5"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("2274f76c-d939-47c9-89c2-8284728f2c7a"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("23665740-f571-4a6e-b3b4-8cdcb719d2fc"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("25a7e084-5ce1-48e8-bca7-9cada78ffa26"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("28a3020d-c97f-4f0b-a559-b59cfe2a6d3c"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("30677d50-b76e-4826-b24a-b7251602ee22"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("32ff3746-075f-4a74-bdaa-ed776cf854ff"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("3d27b128-0ce6-4990-9c5a-a21de5a414b5"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("3d5c9296-405d-4648-addf-2b0706b77169"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("435500b2-b00d-4a63-8571-a77f5aadc28d"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("4459b5db-fac2-4188-96ac-cf2d4e562f14"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("4e99258c-12cd-46b4-bf5b-136de3664bdb"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("520f8d39-11bd-4e16-9add-79661a45985e"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("52d2190e-c7a3-4f7b-ab3b-731e82216d02"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("564d341f-7ccf-4eb4-b250-f32d6cb1c633"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("58bbeec1-d95e-41f9-af74-a517457235c6"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("59c320f0-4ab1-4f43-bd8a-c4cfa2b687d7"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("60efbe37-61c0-4dc0-93ef-5d20358e8a30"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("62330761-ad34-4969-96c7-47eb3c70f552"),
                column: "DepartmentID",
                value: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("7e542e0d-713f-437f-8a1d-0133a004b722"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("7ff93b84-31e2-4e02-81d1-68785909ccb9"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("8041883e-8a68-42e0-8213-3f8c2669c73e"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("86293383-c8de-4941-b83a-4b7c88a53ae1"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("87097a1a-aca0-42f0-8ce3-65995891a0ea"),
                column: "DepartmentID",
                value: new Guid("0b83411d-1567-4463-a5f0-8fa87a420874"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("8f5abb46-f621-4b96-9e1b-e6e84aba4b41"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("8fd7171a-8a59-4208-aabb-1c0699259052"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("a793836a-dd04-40e6-a610-04c45c411837"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("ab899bae-a14b-4a18-8ff5-b70be8405acc"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("b8391957-9ad4-4134-8b65-86d891b57d07"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("babc17e9-4b27-4ee1-8c79-5c39179eeb68"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("c0fff6d8-640b-44a4-ba64-9c550052ef80"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("e023c552-f2a5-48a5-88d6-f13f55b6d5bb"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("e1f195d3-4c19-4b33-a3ae-f2ac1f4e243e"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("e528b274-541c-4ba6-b4a8-5480a190f7be"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("e806b9b1-e27f-48df-9534-abe0ec02a5ab"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("eeb2ed1f-1b0f-4a3c-bad3-aab3a35a4796"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("f29033fa-ffd0-4c70-8726-a4eefa5f72ef"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("f489fc5f-0029-4a95-9fa9-ec6d63a33e0c"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("fae9d171-eecf-4b51-87c6-08e9b8bb3b21"),
                column: "DepartmentID",
                value: new Guid("0b83411d-1567-4463-a5f0-8fa87a420874"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("fb4cf15a-f794-4b59-bc78-3be63b7b8310"),
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("fc6943fa-c904-4b85-9232-eba8c33c485e"),
                column: "DepartmentID",
                value: new Guid("0b83411d-1567-4463-a5f0-8fa87a420874"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("fd9a3b1a-af4d-4232-8663-bb0af5c428a0"),
                column: "DepartmentID",
                value: new Guid("0b83411d-1567-4463-a5f0-8fa87a420874"));

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyID", "BirthYear", "FacultyDescription", "FacultyName" },
                values: new object[,]
                {
                    { new Guid("1203f7e4-8551-4f3e-a0af-43ee8528cd14"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Nursing and Midwifery", "School of Nursing and Midwifery" },
                    { new Guid("556fc5aa-0a4f-4a83-a368-80ebac6d6779"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Education", "School of Education" },
                    { new Guid("7e269486-1dd1-44bc-88f8-7ab8f9f65b4e"), new DateTimeOffset(new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Arts and Social Sciences Faculty", "Faculty of Arts and Social Sciences" },
                    { new Guid("98fee642-2853-43b3-8cfc-da9b4a34063a"), new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Science Faculty", "Faculty of Science" },
                    { new Guid("9dcbecbf-d5b2-42b3-a059-8095d46196f6"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Business", "School of Business" },
                    { new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Graduate Studies", "School of Graduate Studies" }
                });

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinancialRecordID",
                value: new Guid("4ddb0207-3234-4dc8-9a81-866cecabb283"));

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinancialRecordID",
                value: new Guid("4ddb0207-3234-4dc8-9a81-866cecabb283"));

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "FinancialRecordID",
                value: new Guid("e992535c-c9c4-4c01-9af9-91e7eec5e6d5"));

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "FinancialRecordID",
                value: new Guid("e992535c-c9c4-4c01-9af9-91e7eec5e6d5"));

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "FinancialRecordID",
                value: new Guid("0dc3ffc7-01f2-4247-a423-2ec8ee79e076"));

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "FinancialRecordID",
                value: new Guid("0dc3ffc7-01f2-4247-a423-2ec8ee79e076"));

            migrationBuilder.InsertData(
                table: "FinancialRecords",
                columns: new[] { "FinancialRecordID", "AcademicYear", "AmountPaid", "LastUpdated", "OutstandingBalance", "Semester", "StudentID", "TotalFees" },
                values: new object[,]
                {
                    { new Guid("0dc3ffc7-01f2-4247-a423-2ec8ee79e076"), "2024-2025", 6000m, new DateTimeOffset(new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), -500m, 0, "222CS01000694", 5500m },
                    { new Guid("4ddb0207-3234-4dc8-9a81-866cecabb283"), "2023-2024", 4800m, new DateTimeOffset(new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, 0, "222CS01000694", 4800m },
                    { new Guid("e992535c-c9c4-4c01-9af9-91e7eec5e6d5"), "2023-2024", 5000m, new DateTimeOffset(new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200m, 1, "222CS01000694", 5200m }
                });

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "LecturerID",
                keyValue: "L0001",
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "LecturerID",
                keyValue: "L0002",
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.InsertData(
                table: "RegistrationPeriods",
                columns: new[] { "RegistrationPeriodID", "AcademicYear", "AllowCourseAdd", "AllowCourseDrop", "Description", "EndDate", "IsActive", "LateRegistrationEnd", "LateRegistrationFee", "LateRegistrationStart", "Semester", "StartDate" },
                values: new object[] { new Guid("8f028ff7-eda7-4bd6-b9dc-f6d33c4972fc"), "2024-2025", true, true, "January 2025 Registration", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "January", new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: "222CS01000694",
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: "222CS01000695",
                column: "DepartmentID",
                value: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.InsertData(
                table: "Transcripts",
                columns: new[] { "TranscriptID", "AcademicStanding", "CreditsAttempted", "CreditsEarned", "CummulativeGPA", "GeneratedDate", "StudentID", "isOfficial" },
                values: new object[] { new Guid("ddea038a-a52c-4e6e-ae9a-760c863c6ea5"), 2, 0, 0, 0.0, new DateTimeOffset(new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", false });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "BirthYear", "DepartmentDescription", "DepartmentName", "FacultyID", "RequiredCredits" },
                values: new object[,]
                {
                    { new Guid("0b83411d-1567-4463-a5f0-8fa87a420874"), new DateTimeOffset(new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Theological Studies", "Theological Studies", new Guid("7e269486-1dd1-44bc-88f8-7ab8f9f65b4e"), 90 },
                    { new Guid("11133185-3d7e-4c32-8ee5-0680ce2b1894"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Marketing", "BBA Marketing", new Guid("9dcbecbf-d5b2-42b3-a059-8095d46196f6"), 120 },
                    { new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "University Wide General Education Courses", "General Education", new Guid("98fee642-2853-43b3-8cfc-da9b4a34063a"), 30 },
                    { new Guid("1d5236cf-71a2-429d-9f8c-0428b5b19412"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Business Information Systems", "Business Information Systems", new Guid("98fee642-2853-43b3-8cfc-da9b4a34063a"), 120 },
                    { new Guid("21bb77eb-d66f-48c3-897e-e3f10aaf79c7"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MEd/MPhil Program in Educational Administration & Leadership", "MEd/MPhil Educational Administration & Leadership", new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"), 30 },
                    { new Guid("28f5c222-97a9-4ff5-9cec-b2f3a0ed87d6"), new DateTimeOffset(new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Information Technology", "Information Technology", new Guid("98fee642-2853-43b3-8cfc-da9b4a34063a"), 120 },
                    { new Guid("29433adc-57c6-45a7-a896-9bb40691e125"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Mathematics with Statistics", "Mathematics with Statistics", new Guid("98fee642-2853-43b3-8cfc-da9b4a34063a"), 120 },
                    { new Guid("3168cd6d-7493-4ec7-af43-6fedc88f9f46"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PhD Program in Business Administration", "PhD Business Administration", new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"), 45 },
                    { new Guid("390eec3a-93de-4f28-98e5-d5bcb79ed800"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Social Studies", "BEd Social Studies", new Guid("556fc5aa-0a4f-4a83-a368-80ebac6d6779"), 120 },
                    { new Guid("3ee35a62-d8d4-47b7-a8f2-6235971c1c4b"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Development Studies", "Development Studies", new Guid("7e269486-1dd1-44bc-88f8-7ab8f9f65b4e"), 120 },
                    { new Guid("4d994703-c68f-4c0b-b53d-95f019a14c35"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd English Language", "BEd English Language", new Guid("556fc5aa-0a4f-4a83-a368-80ebac6d6779"), 120 },
                    { new Guid("52f69ff4-2719-4ed0-8de3-355737fabcaa"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Diploma in Music Program", "Diploma in Music", new Guid("556fc5aa-0a4f-4a83-a368-80ebac6d6779"), 60 },
                    { new Guid("55c67c5c-28fa-4660-8e3b-c012d0df6499"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Diploma in Business Administration Program", "Diploma in Business Administration", new Guid("9dcbecbf-d5b2-42b3-a059-8095d46196f6"), 60 },
                    { new Guid("56bbf7ff-de46-4582-a091-8dc959454af4"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MBA Program in Banking & Finance", "MBA Banking & Finance", new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"), 40 },
                    { new Guid("57afdfb7-7300-440d-9967-2cd9b09f9c4c"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Biomedical Engineering", "Biomedical Engineering", new Guid("98fee642-2853-43b3-8cfc-da9b4a34063a"), 120 },
                    { new Guid("58bf33ce-8342-4e04-9b50-0c8511bb8dc4"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Management", "BEd Management", new Guid("556fc5aa-0a4f-4a83-a368-80ebac6d6779"), 120 },
                    { new Guid("5b398d02-7373-4d66-9a92-c68385659c91"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MBA Program in Accounting", "MBA Accounting", new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"), 40 },
                    { new Guid("6053a136-3975-45d2-a56d-6fa31b3e684e"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MEd/MPhil Program in Curriculum & Instruction", "MEd/MPhil Curriculum & Instruction", new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"), 30 },
                    { new Guid("68c4a0c1-69a4-442b-9c3c-32a346a9ce52"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Midwifery", "Midwifery", new Guid("1203f7e4-8551-4f3e-a0af-43ee8528cd14"), 120 },
                    { new Guid("6cd46428-0391-458f-b695-a4a4ec9dca77"), new DateTimeOffset(new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Nursing", "Nursing", new Guid("1203f7e4-8551-4f3e-a0af-43ee8528cd14"), 120 },
                    { new Guid("7759ceb1-f467-49ba-88a4-07bf83393675"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Postgraduate Diploma in Education Program", "Postgraduate Diploma in Education", new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"), 30 },
                    { new Guid("77d0a3df-783c-460e-a940-51037992cb40"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PhD Program in Computer Science", "PhD Computer Science", new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"), 45 },
                    { new Guid("88d075bb-6051-4960-b7f0-9cc4731fc6d1"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Music", "BEd Music", new Guid("556fc5aa-0a4f-4a83-a368-80ebac6d6779"), 120 },
                    { new Guid("8a25d090-c0bc-4477-9c80-80a0977da378"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Agribusiness", "Agribusiness", new Guid("98fee642-2853-43b3-8cfc-da9b4a34063a"), 120 },
                    { new Guid("8c1cebc3-4f13-4703-801b-5f19e7f72468"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Agriculture", "Agriculture", new Guid("98fee642-2853-43b3-8cfc-da9b4a34063a"), 120 },
                    { new Guid("91df7bae-8883-43bb-ad40-aa5c27a948a6"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Management", "BBA Management", new Guid("9dcbecbf-d5b2-42b3-a059-8095d46196f6"), 120 },
                    { new Guid("b3a96381-e9d9-4c24-86fc-0d5cf61d41a7"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Human Resource Management", "BBA Human Resource Management", new Guid("9dcbecbf-d5b2-42b3-a059-8095d46196f6"), 120 },
                    { new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Computer Science", "Computer Science", new Guid("98fee642-2853-43b3-8cfc-da9b4a34063a"), 120 },
                    { new Guid("c1e22698-ee7e-45eb-8c4c-85e603306812"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Accounting", "BBA Accounting", new Guid("9dcbecbf-d5b2-42b3-a059-8095d46196f6"), 120 },
                    { new Guid("c3e84797-7d32-482e-8654-8de6f4cb96ab"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MBA Program in Strategic Management", "MBA Strategic Management", new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"), 40 },
                    { new Guid("dc1b48f1-f16e-4012-85c4-5fdd1089151f"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Banking and Finance", "BBA Banking and Finance", new Guid("9dcbecbf-d5b2-42b3-a059-8095d46196f6"), 120 },
                    { new Guid("e1c4aec2-235e-4165-8f9a-3f3201bfa6eb"), new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Communication Studies", "Communication Studies", new Guid("7e269486-1dd1-44bc-88f8-7ab8f9f65b4e"), 120 },
                    { new Guid("f7362026-a241-4b75-9fa0-a70255ebcf94"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MSc/MPhil Program in Computer Science", "MSc/MPhil Computer Science", new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"), 30 },
                    { new Guid("f9a7cdcc-ea5a-42be-8937-23ac341175f7"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Information Technology", "BEd Information Technology", new Guid("556fc5aa-0a4f-4a83-a368-80ebac6d6779"), 120 },
                    { new Guid("fa3db516-1606-4537-b611-e2deea201b24"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Accounting", "BEd Accounting", new Guid("556fc5aa-0a4f-4a83-a368-80ebac6d6779"), 120 },
                    { new Guid("fc24c1cb-4b35-4171-85be-8e675d5e9685"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Mental Health Nursing", "Mental Health Nursing", new Guid("1203f7e4-8551-4f3e-a0af-43ee8528cd14"), 120 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "Amount", "FinancialRecordID", "Notes", "PaymentDate", "PaymentMethod", "PaymentStatus", "ReferenceNumber" },
                values: new object[,]
                {
                    { new Guid("166bc201-59d7-4544-9625-6ac7d63a636a"), 3000m, new Guid("e992535c-c9c4-4c01-9af9-91e7eec5e6d5"), null, new DateTimeOffset(new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "fe526553" },
                    { new Guid("34b9776b-c992-47f2-ab99-4601939e3bbb"), 100m, new Guid("0dc3ffc7-01f2-4247-a423-2ec8ee79e076"), null, new DateTimeOffset(new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2, "2177610b" },
                    { new Guid("6c1c409e-2c89-42be-b8b4-8162c4fa0d91"), 2000m, new Guid("e992535c-c9c4-4c01-9af9-91e7eec5e6d5"), null, new DateTimeOffset(new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "c8d5b814" },
                    { new Guid("83a559bf-c652-4c36-a89d-79af8a448180"), 2800m, new Guid("4ddb0207-3234-4dc8-9a81-866cecabb283"), null, new DateTimeOffset(new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 2, "f939355e" },
                    { new Guid("99d0d537-8abf-4a3e-a4a3-2987d7e7b207"), 6000m, new Guid("0dc3ffc7-01f2-4247-a423-2ec8ee79e076"), null, new DateTimeOffset(new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "6c9eed80" },
                    { new Guid("b0a81332-d5d4-4dad-88cc-a7d888a95b0c"), 2000m, new Guid("4ddb0207-3234-4dc8-9a81-866cecabb283"), null, new DateTimeOffset(new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "a4a8ea22" }
                });

            migrationBuilder.InsertData(
                table: "SemesterRecords",
                columns: new[] { "SemesterRecordID", "AcademicYear", "CreditsAttempted", "CreditsEarned", "EndDate", "Semester", "SemesterGPA", "StartDate", "StudentID", "TranscriptID" },
                values: new object[,]
                {
                    { new Guid("59010ca2-d29b-482f-9dd6-5ab521f2bd49"), "2023-2024", 0, 0, new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 0.0, new DateTimeOffset(new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("ddea038a-a52c-4e6e-ae9a-760c863c6ea5") },
                    { new Guid("5ca833fc-9ec9-4a96-b3bf-ffa8d2b52354"), "2022-2023", 0, 0, new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 0.0, new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("ddea038a-a52c-4e6e-ae9a-760c863c6ea5") },
                    { new Guid("92a7df56-02f9-4a54-84c5-14783483c468"), "2022-2023", 0, 0, new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 0.0, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("ddea038a-a52c-4e6e-ae9a-760c863c6ea5") },
                    { new Guid("95ef9ac5-1d08-4844-94ae-f4a82586b11a"), "2021-2022", 0, 0, new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 0.0, new DateTimeOffset(new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("ddea038a-a52c-4e6e-ae9a-760c863c6ea5") },
                    { new Guid("bb5f7c7e-1ee4-4190-b25f-5415d8d4a509"), "2023-2024", 0, 0, new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 0.0, new DateTimeOffset(new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("ddea038a-a52c-4e6e-ae9a-760c863c6ea5") },
                    { new Guid("ec781519-440f-4faf-9952-3510156a3681"), "2021-2022", 0, 0, new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 0.0, new DateTimeOffset(new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("ddea038a-a52c-4e6e-ae9a-760c863c6ea5") }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeID", "CourseID", "DateAwarded", "GradeLetter", "GradePoints", "Remarks", "Semester", "SemesterRecordID", "StudentID", "isCompleted" },
                values: new object[,]
                {
                    { new Guid("09581fca-33c4-4ea7-aeb2-adc56c46d528"), new Guid("ab899bae-a14b-4a18-8ff5-b70be8405acc"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("bb5f7c7e-1ee4-4190-b25f-5415d8d4a509"), "222CS01000694", true },
                    { new Guid("164d67bf-fde3-4896-8cdb-979f3ae0ef9f"), new Guid("1a46ac1d-c607-4225-9002-e14a4c1e3363"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 12, 0.0, null, 0, new Guid("ec781519-440f-4faf-9952-3510156a3681"), "222CS01000694", true },
                    { new Guid("191bcd15-46e5-477a-9d17-1a4dbce579ec"), new Guid("a793836a-dd04-40e6-a610-04c45c411837"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 0, new Guid("bb5f7c7e-1ee4-4190-b25f-5415d8d4a509"), "222CS01000694", true },
                    { new Guid("1ae71585-3568-463f-8d97-aede7670a92b"), new Guid("c0fff6d8-640b-44a4-ba64-9c550052ef80"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 1, new Guid("59010ca2-d29b-482f-9dd6-5ab521f2bd49"), "222CS01000694", true },
                    { new Guid("1aeae647-2f88-48fa-9425-994433a4ff49"), new Guid("0badf6bd-77ef-4c6d-a568-912b57daf884"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 0, new Guid("ec781519-440f-4faf-9952-3510156a3681"), "222CS01000694", true },
                    { new Guid("2249e66e-3169-43b6-ae10-f779b3b92dcb"), new Guid("1b006764-b19a-402b-a17a-f9a12d5f4b76"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("5ca833fc-9ec9-4a96-b3bf-ffa8d2b52354"), "222CS01000694", true },
                    { new Guid("25f208b9-8830-47ac-83e4-9e5df3fd7d3b"), new Guid("babc17e9-4b27-4ee1-8c79-5c39179eeb68"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("95ef9ac5-1d08-4844-94ae-f4a82586b11a"), "222CS01000694", true },
                    { new Guid("2b067db8-5e47-4550-93b0-8cc6328df935"), new Guid("eeb2ed1f-1b0f-4a3c-bad3-aab3a35a4796"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 1, new Guid("5ca833fc-9ec9-4a96-b3bf-ffa8d2b52354"), "222CS01000694", true },
                    { new Guid("2ce9ffdf-d92e-478d-91fc-1cb6caadd768"), new Guid("1f1f83d3-6271-4ac5-964f-2805ae049fa1"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("92a7df56-02f9-4a54-84c5-14783483c468"), "222CS01000694", true },
                    { new Guid("2e6a3b9a-f62a-4eb6-8c46-f478aebe9e14"), new Guid("e023c552-f2a5-48a5-88d6-f13f55b6d5bb"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 0, new Guid("bb5f7c7e-1ee4-4190-b25f-5415d8d4a509"), "222CS01000694", true },
                    { new Guid("2f079431-e7d2-4892-82e5-65d84e7fa122"), new Guid("25a7e084-5ce1-48e8-bca7-9cada78ffa26"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 0, new Guid("bb5f7c7e-1ee4-4190-b25f-5415d8d4a509"), "222CS01000694", true },
                    { new Guid("31fa5b0f-27de-4210-b5ab-000b9321ac03"), new Guid("28a3020d-c97f-4f0b-a559-b59cfe2a6d3c"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("ec781519-440f-4faf-9952-3510156a3681"), "222CS01000694", true },
                    { new Guid("32cecb7f-6ab3-41c4-b5da-71e50f39ca2d"), new Guid("23665740-f571-4a6e-b3b4-8cdcb719d2fc"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 1, new Guid("95ef9ac5-1d08-4844-94ae-f4a82586b11a"), "222CS01000694", true },
                    { new Guid("34436c48-472f-4e0e-85e9-8909d7d0604e"), new Guid("60efbe37-61c0-4dc0-93ef-5d20358e8a30"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 0, new Guid("ec781519-440f-4faf-9952-3510156a3681"), "222CS01000694", true },
                    { new Guid("358aba61-e224-4ed2-b9a6-18002f76aaba"), new Guid("b8391957-9ad4-4134-8b65-86d891b57d07"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("bb5f7c7e-1ee4-4190-b25f-5415d8d4a509"), "222CS01000694", true },
                    { new Guid("4ce939f4-5bb5-41de-8b9e-9170f2a96a7e"), new Guid("52d2190e-c7a3-4f7b-ab3b-731e82216d02"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 0, new Guid("ec781519-440f-4faf-9952-3510156a3681"), "222CS01000694", true },
                    { new Guid("4d4fabb7-7215-4e34-b5b5-7ad55cb95581"), new Guid("0922f512-59fd-43c4-9d36-cdd18fccfb13"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("92a7df56-02f9-4a54-84c5-14783483c468"), "222CS01000694", true },
                    { new Guid("52f8242e-867c-4a0d-9aa5-c09cc4a135a5"), new Guid("13a87b42-12ce-4cbc-8011-fc2c792f29e5"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 1.0, null, 1, new Guid("95ef9ac5-1d08-4844-94ae-f4a82586b11a"), "222CS01000694", true },
                    { new Guid("5a732681-f35f-4401-b077-5cb1954bbbde"), new Guid("20acdf30-8b86-4b77-921d-02b0bc9ee0d5"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 1, new Guid("59010ca2-d29b-482f-9dd6-5ab521f2bd49"), "222CS01000694", true },
                    { new Guid("737c38f3-e6aa-4565-aa4e-b24ce883a98a"), new Guid("435500b2-b00d-4a63-8571-a77f5aadc28d"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 1, new Guid("59010ca2-d29b-482f-9dd6-5ab521f2bd49"), "222CS01000694", true },
                    { new Guid("794d6346-8f82-4aef-94a6-fab441e06a40"), new Guid("20a3f858-958e-42b0-b841-e907b592ce0e"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 11, 0.0, null, 1, new Guid("95ef9ac5-1d08-4844-94ae-f4a82586b11a"), "222CS01000694", true },
                    { new Guid("7e0846b9-766f-4844-8737-ac1bf3f360f6"), new Guid("2274f76c-d939-47c9-89c2-8284728f2c7a"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 0, new Guid("ec781519-440f-4faf-9952-3510156a3681"), "222CS01000694", true },
                    { new Guid("7ee726fd-02d6-4713-9a8c-f94054c1c930"), new Guid("012bdf77-0b02-4d88-8da0-105ba9f1f829"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 1, new Guid("5ca833fc-9ec9-4a96-b3bf-ffa8d2b52354"), "222CS01000694", true },
                    { new Guid("7fbbed7b-a438-4176-af8e-97c2aadbb795"), new Guid("13c34157-f376-4a31-9391-7fdd4d7fbdb7"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 1, new Guid("95ef9ac5-1d08-4844-94ae-f4a82586b11a"), "222CS01000694", true },
                    { new Guid("81878429-4c91-486d-9ecd-bd85a1a941f0"), new Guid("32ff3746-075f-4a74-bdaa-ed776cf854ff"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 1, new Guid("5ca833fc-9ec9-4a96-b3bf-ffa8d2b52354"), "222CS01000694", true },
                    { new Guid("81b86f8d-ec07-4878-908b-f8bdfcd3fb7f"), new Guid("7e542e0d-713f-437f-8a1d-0133a004b722"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 0, new Guid("92a7df56-02f9-4a54-84c5-14783483c468"), "222CS01000694", true },
                    { new Guid("81dea6fe-6af1-47a7-9af0-02b454ab1bc8"), new Guid("520f8d39-11bd-4e16-9add-79661a45985e"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 11, 0.0, null, 0, new Guid("92a7df56-02f9-4a54-84c5-14783483c468"), "222CS01000694", true },
                    { new Guid("83fb3bec-bd4e-4d18-a9dd-78e377b78b09"), new Guid("f489fc5f-0029-4a95-9fa9-ec6d63a33e0c"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("59010ca2-d29b-482f-9dd6-5ab521f2bd49"), "222CS01000694", true },
                    { new Guid("91ac1fd4-b80b-41d8-84de-59cda11042f2"), new Guid("4459b5db-fac2-4188-96ac-cf2d4e562f14"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("92a7df56-02f9-4a54-84c5-14783483c468"), "222CS01000694", true },
                    { new Guid("99d3d6e0-f6d8-4d0a-8185-b76b27f72f64"), new Guid("095a4f84-f388-4a49-9994-43eb52ec18e0"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 1, new Guid("5ca833fc-9ec9-4a96-b3bf-ffa8d2b52354"), "222CS01000694", true },
                    { new Guid("9ffc646c-c656-474a-8e12-a57f31dbb96a"), new Guid("1b84cd21-2550-41d3-b3d4-7a985e71d1ea"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 1, new Guid("5ca833fc-9ec9-4a96-b3bf-ffa8d2b52354"), "222CS01000694", true },
                    { new Guid("aff22d54-2a43-4f3f-849b-ddc2bddeabc7"), new Guid("1897059a-c3fc-4cb3-a6dc-0aa23f62fc4d"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 0, new Guid("ec781519-440f-4faf-9952-3510156a3681"), "222CS01000694", true },
                    { new Guid("bb5d18e2-a6de-4b94-9e44-4aede8a142f6"), new Guid("fae9d171-eecf-4b51-87c6-08e9b8bb3b21"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("bb5f7c7e-1ee4-4190-b25f-5415d8d4a509"), "222CS01000694", true },
                    { new Guid("c848bd46-afca-4c03-92b5-7e4b89d4c368"), new Guid("8f5abb46-f621-4b96-9e1b-e6e84aba4b41"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("59010ca2-d29b-482f-9dd6-5ab521f2bd49"), "222CS01000694", true },
                    { new Guid("d1b0c3c2-bbac-472a-afe6-8fda756757a2"), new Guid("62330761-ad34-4969-96c7-47eb3c70f552"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 1, new Guid("95ef9ac5-1d08-4844-94ae-f4a82586b11a"), "222CS01000694", true },
                    { new Guid("d45566a9-f660-4a23-8cb3-e231e2321372"), new Guid("564d341f-7ccf-4eb4-b250-f32d6cb1c633"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 0, new Guid("92a7df56-02f9-4a54-84c5-14783483c468"), "222CS01000694", true },
                    { new Guid("d6add265-4d8d-4d75-9387-1d93b472bdf8"), new Guid("064f2d40-55de-4ff5-a56c-c57c1dd562f4"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("59010ca2-d29b-482f-9dd6-5ab521f2bd49"), "222CS01000694", true },
                    { new Guid("d7153f8e-f4f4-4222-a320-244afd8e1481"), new Guid("8041883e-8a68-42e0-8213-3f8c2669c73e"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 1, new Guid("95ef9ac5-1d08-4844-94ae-f4a82586b11a"), "222CS01000694", true },
                    { new Guid("dc8d8675-9c65-42bb-87ff-ce544a7d4e19"), new Guid("fb4cf15a-f794-4b59-bc78-3be63b7b8310"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 0, new Guid("bb5f7c7e-1ee4-4190-b25f-5415d8d4a509"), "222CS01000694", true },
                    { new Guid("dca54717-858d-49db-8d78-d1563131d543"), new Guid("59c320f0-4ab1-4f43-bd8a-c4cfa2b687d7"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 1, new Guid("5ca833fc-9ec9-4a96-b3bf-ffa8d2b52354"), "222CS01000694", true },
                    { new Guid("e3bc43c7-13e5-44d9-b6b8-c155c440fa81"), new Guid("20a3f858-958e-42b0-b841-e907b592ce0e"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("ec781519-440f-4faf-9952-3510156a3681"), "222CS01000694", true },
                    { new Guid("e47ea3c7-c15d-449c-b7df-48ef91767500"), new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 1.0, null, 1, new Guid("59010ca2-d29b-482f-9dd6-5ab521f2bd49"), "222CS01000694", true },
                    { new Guid("ec85f9e9-444a-4e21-8da3-379dec3b77ab"), new Guid("87097a1a-aca0-42f0-8ce3-65995891a0ea"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 0, new Guid("ec781519-440f-4faf-9952-3510156a3681"), "222CS01000694", true },
                    { new Guid("f1d40ac0-e6e3-41d0-a4a0-ef4f689713da"), new Guid("f29033fa-ffd0-4c70-8726-a4eefa5f72ef"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 1, new Guid("95ef9ac5-1d08-4844-94ae-f4a82586b11a"), "222CS01000694", true },
                    { new Guid("fccd268a-8152-42fc-8f0a-e895f4adbab2"), new Guid("fc6943fa-c904-4b85-9232-eba8c33c485e"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("92a7df56-02f9-4a54-84c5-14783483c468"), "222CS01000694", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_DepartmentID",
                table: "Lecturers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_FeeItemID",
                table: "InvoiceLineItems",
                column: "FeeItemID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_InvoiceID",
                table: "InvoiceLineItems",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_FinancialRecordID",
                table: "Invoices",
                column: "FinancialRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceNumber",
                table: "Invoices",
                column: "InvoiceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StudentID",
                table: "Invoices",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGatewayTransactions_GatewayName_GatewayTransactionReference",
                table: "PaymentGatewayTransactions",
                columns: new[] { "GatewayName", "GatewayTransactionReference" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGatewayTransactions_PaymentID",
                table: "PaymentGatewayTransactions",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReminders_FeeItemID",
                table: "PaymentReminders",
                column: "FeeItemID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReminders_FinancialRecordID",
                table: "PaymentReminders",
                column: "FinancialRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReminders_Status_ReminderDate",
                table: "PaymentReminders",
                columns: new[] { "Status", "ReminderDate" });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReminders_StudentID",
                table: "PaymentReminders",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                table: "Courses",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Faculties_FacultyID",
                table: "Departments",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "FacultyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Departments_DepartmentID",
                table: "Lecturers",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceBorrowings_AspNetUsers_StudentId",
                table: "ResourceBorrowings",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceBorrowings_LibraryResources_LibraryResourceID",
                table: "ResourceBorrowings",
                column: "LibraryResourceID",
                principalTable: "LibraryResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentID",
                table: "Students",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Faculties_FacultyID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Departments_DepartmentID",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceBorrowings_AspNetUsers_StudentId",
                table: "ResourceBorrowings");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceBorrowings_LibraryResources_LibraryResourceID",
                table: "ResourceBorrowings");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "InvoiceLineItems");

            migrationBuilder.DropTable(
                name: "PaymentGatewayTransactions");

            migrationBuilder.DropTable(
                name: "PaymentReminders");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Lecturers_DepartmentID",
                table: "Lecturers");

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("12acd859-70a5-4a36-af06-afe44e9fe216"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("61622c25-0434-4fc0-a776-ca57195a0a2e"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("7378abfb-d932-428b-ab84-87a32d6de75e"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("bab91284-ec26-439e-9852-dbd76bd594e4"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("c4511bca-0142-4b03-b8a2-00f4e8d1aa8c"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("cb1f8dad-4cb3-42c8-90e4-2cb66625f972"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("d2d43c71-e423-4d42-b605-dcd177065b9a"));

            migrationBuilder.DeleteData(
                table: "CourseTimeSlot",
                keyColumn: "CourseTimeSlotID",
                keyValue: new Guid("f03d7e47-92dc-4b1b-a8fd-f68c526e802a"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("0b83411d-1567-4463-a5f0-8fa87a420874"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("11133185-3d7e-4c32-8ee5-0680ce2b1894"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("1a775d93-ca09-4496-917e-4f83b4565d8d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("1d5236cf-71a2-429d-9f8c-0428b5b19412"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("21bb77eb-d66f-48c3-897e-e3f10aaf79c7"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("28f5c222-97a9-4ff5-9cec-b2f3a0ed87d6"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("29433adc-57c6-45a7-a896-9bb40691e125"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("3168cd6d-7493-4ec7-af43-6fedc88f9f46"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("390eec3a-93de-4f28-98e5-d5bcb79ed800"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("3ee35a62-d8d4-47b7-a8f2-6235971c1c4b"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("4d994703-c68f-4c0b-b53d-95f019a14c35"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("52f69ff4-2719-4ed0-8de3-355737fabcaa"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("55c67c5c-28fa-4660-8e3b-c012d0df6499"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("56bbf7ff-de46-4582-a091-8dc959454af4"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("57afdfb7-7300-440d-9967-2cd9b09f9c4c"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("58bf33ce-8342-4e04-9b50-0c8511bb8dc4"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("5b398d02-7373-4d66-9a92-c68385659c91"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("6053a136-3975-45d2-a56d-6fa31b3e684e"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("68c4a0c1-69a4-442b-9c3c-32a346a9ce52"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("6cd46428-0391-458f-b695-a4a4ec9dca77"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("7759ceb1-f467-49ba-88a4-07bf83393675"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("77d0a3df-783c-460e-a940-51037992cb40"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("88d075bb-6051-4960-b7f0-9cc4731fc6d1"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("8a25d090-c0bc-4477-9c80-80a0977da378"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("8c1cebc3-4f13-4703-801b-5f19e7f72468"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("91df7bae-8883-43bb-ad40-aa5c27a948a6"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("b3a96381-e9d9-4c24-86fc-0d5cf61d41a7"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("b729e5ec-b369-4a88-9c2a-5564fd577729"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("c1e22698-ee7e-45eb-8c4c-85e603306812"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("c3e84797-7d32-482e-8654-8de6f4cb96ab"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("dc1b48f1-f16e-4012-85c4-5fdd1089151f"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("e1c4aec2-235e-4165-8f9a-3f3201bfa6eb"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("f7362026-a241-4b75-9fa0-a70255ebcf94"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("f9a7cdcc-ea5a-42be-8937-23ac341175f7"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("fa3db516-1606-4537-b611-e2deea201b24"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("fc24c1cb-4b35-4171-85be-8e675d5e9685"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("09581fca-33c4-4ea7-aeb2-adc56c46d528"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("164d67bf-fde3-4896-8cdb-979f3ae0ef9f"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("191bcd15-46e5-477a-9d17-1a4dbce579ec"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("1ae71585-3568-463f-8d97-aede7670a92b"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("1aeae647-2f88-48fa-9425-994433a4ff49"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("2249e66e-3169-43b6-ae10-f779b3b92dcb"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("25f208b9-8830-47ac-83e4-9e5df3fd7d3b"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("2b067db8-5e47-4550-93b0-8cc6328df935"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("2ce9ffdf-d92e-478d-91fc-1cb6caadd768"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("2e6a3b9a-f62a-4eb6-8c46-f478aebe9e14"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("2f079431-e7d2-4892-82e5-65d84e7fa122"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("31fa5b0f-27de-4210-b5ab-000b9321ac03"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("32cecb7f-6ab3-41c4-b5da-71e50f39ca2d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("34436c48-472f-4e0e-85e9-8909d7d0604e"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("358aba61-e224-4ed2-b9a6-18002f76aaba"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("4ce939f4-5bb5-41de-8b9e-9170f2a96a7e"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("4d4fabb7-7215-4e34-b5b5-7ad55cb95581"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("52f8242e-867c-4a0d-9aa5-c09cc4a135a5"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("5a732681-f35f-4401-b077-5cb1954bbbde"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("737c38f3-e6aa-4565-aa4e-b24ce883a98a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("794d6346-8f82-4aef-94a6-fab441e06a40"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("7e0846b9-766f-4844-8737-ac1bf3f360f6"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("7ee726fd-02d6-4713-9a8c-f94054c1c930"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("7fbbed7b-a438-4176-af8e-97c2aadbb795"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("81878429-4c91-486d-9ecd-bd85a1a941f0"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("81b86f8d-ec07-4878-908b-f8bdfcd3fb7f"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("81dea6fe-6af1-47a7-9af0-02b454ab1bc8"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("83fb3bec-bd4e-4d18-a9dd-78e377b78b09"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("91ac1fd4-b80b-41d8-84de-59cda11042f2"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("99d3d6e0-f6d8-4d0a-8185-b76b27f72f64"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("9ffc646c-c656-474a-8e12-a57f31dbb96a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("aff22d54-2a43-4f3f-849b-ddc2bddeabc7"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("bb5d18e2-a6de-4b94-9e44-4aede8a142f6"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("c848bd46-afca-4c03-92b5-7e4b89d4c368"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("d1b0c3c2-bbac-472a-afe6-8fda756757a2"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("d45566a9-f660-4a23-8cb3-e231e2321372"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("d6add265-4d8d-4d75-9387-1d93b472bdf8"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("d7153f8e-f4f4-4222-a320-244afd8e1481"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("dc8d8675-9c65-42bb-87ff-ce544a7d4e19"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("dca54717-858d-49db-8d78-d1563131d543"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("e3bc43c7-13e5-44d9-b6b8-c155c440fa81"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("e47ea3c7-c15d-449c-b7df-48ef91767500"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("ec85f9e9-444a-4e21-8da3-379dec3b77ab"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("f1d40ac0-e6e3-41d0-a4a0-ef4f689713da"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: new Guid("fccd268a-8152-42fc-8f0a-e895f4adbab2"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("166bc201-59d7-4544-9625-6ac7d63a636a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("34b9776b-c992-47f2-ab99-4601939e3bbb"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("6c1c409e-2c89-42be-b8b4-8162c4fa0d91"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("83a559bf-c652-4c36-a89d-79af8a448180"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("99d0d537-8abf-4a3e-a4a3-2987d7e7b207"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: new Guid("b0a81332-d5d4-4dad-88cc-a7d888a95b0c"));

            migrationBuilder.DeleteData(
                table: "RegistrationPeriods",
                keyColumn: "RegistrationPeriodID",
                keyValue: new Guid("8f028ff7-eda7-4bd6-b9dc-f6d33c4972fc"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("1203f7e4-8551-4f3e-a0af-43ee8528cd14"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("556fc5aa-0a4f-4a83-a368-80ebac6d6779"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("7e269486-1dd1-44bc-88f8-7ab8f9f65b4e"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("98fee642-2853-43b3-8cfc-da9b4a34063a"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("9dcbecbf-d5b2-42b3-a059-8095d46196f6"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("db648eb3-9caa-4964-8b77-e43ccf4a4d86"));

            migrationBuilder.DeleteData(
                table: "FinancialRecords",
                keyColumn: "FinancialRecordID",
                keyValue: new Guid("0dc3ffc7-01f2-4247-a423-2ec8ee79e076"));

            migrationBuilder.DeleteData(
                table: "FinancialRecords",
                keyColumn: "FinancialRecordID",
                keyValue: new Guid("4ddb0207-3234-4dc8-9a81-866cecabb283"));

            migrationBuilder.DeleteData(
                table: "FinancialRecords",
                keyColumn: "FinancialRecordID",
                keyValue: new Guid("e992535c-c9c4-4c01-9af9-91e7eec5e6d5"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("59010ca2-d29b-482f-9dd6-5ab521f2bd49"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("5ca833fc-9ec9-4a96-b3bf-ffa8d2b52354"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("92a7df56-02f9-4a54-84c5-14783483c468"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("95ef9ac5-1d08-4844-94ae-f4a82586b11a"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("bb5f7c7e-1ee4-4190-b25f-5415d8d4a509"));

            migrationBuilder.DeleteData(
                table: "SemesterRecords",
                keyColumn: "SemesterRecordID",
                keyValue: new Guid("ec781519-440f-4faf-9952-3510156a3681"));

            migrationBuilder.DeleteData(
                table: "Transcripts",
                keyColumn: "TranscriptID",
                keyValue: new Guid("ddea038a-a52c-4e6e-ae9a-760c863c6ea5"));

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Students",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseID",
                table: "Lecturers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222CS01000694",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13a1e190-825f-4a7f-a631-bb86b40e4cf8", "AQAAAAIAAYagAAAAEFMe7jB9Q72Ru+1pr0M1POrhDPfIzTWOIgH4LMoEAWeoeYLor5HZpgnac0GT8yNpbw==", "cbbb5787-58d1-409d-88f2-ce22771e076c" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), "222CS01000694" },
                column: "RegistrationPeriodID",
                value: new Guid("fe0137a4-129b-4202-8992-43888f906cd0"));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), "222CS01000694" },
                column: "RegistrationPeriodID",
                value: new Guid("fe0137a4-129b-4202-8992-43888f906cd0"));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), "222CS01000694" },
                column: "RegistrationPeriodID",
                value: new Guid("fe0137a4-129b-4202-8992-43888f906cd0"));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), "222CS01000694" },
                column: "RegistrationPeriodID",
                value: new Guid("fe0137a4-129b-4202-8992-43888f906cd0"));

            migrationBuilder.InsertData(
                table: "CourseTimeSlot",
                columns: new[] { "CourseTimeSlotID", "CourseID", "DayOfWeek", "EndTime", "LecturerID", "Location", "StartTime" },
                values: new object[,]
                {
                    { new Guid("12ec5707-80a9-41f3-9fcd-eae84a472373"), new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), 2, new TimeSpan(0, 16, 30, 0, 0), "L0001", 4, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("39e631cd-1bef-412c-8e1f-139d8e681dc8"), new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), 4, new TimeSpan(0, 15, 50, 0, 0), "L0001", 4, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("552dbe8f-11c0-4bbe-9670-01a37277fdba"), new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), 5, new TimeSpan(0, 9, 30, 0, 0), "L0001", 5, new TimeSpan(0, 7, 0, 0, 0) },
                    { new Guid("658c5984-1c80-4a9e-9aab-29c2e6843280"), new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), 5, new TimeSpan(0, 9, 30, 0, 0), "L0002", 3, new TimeSpan(0, 7, 0, 0, 0) },
                    { new Guid("8953341e-d071-4ba1-92ff-12f126250adc"), new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), 5, new TimeSpan(0, 12, 30, 0, 0), "L0002", 5, new TimeSpan(0, 10, 0, 0, 0) },
                    { new Guid("9febe164-e2d9-46d2-8e72-ffe3edc1153b"), new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), 1, new TimeSpan(0, 16, 30, 0, 0), "L0001", 0, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("cafd8292-75c1-49f2-a804-72c75576454d"), new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), 3, new TimeSpan(0, 12, 30, 0, 0), "L0001", 4, new TimeSpan(0, 10, 0, 0, 0) },
                    { new Guid("de56a00d-3226-41a4-8853-5f2f56a1d491"), new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), 3, new TimeSpan(0, 12, 30, 0, 0), "L0002", 4, new TimeSpan(0, 10, 0, 0, 0) }
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("012bdf77-0b02-4d88-8da0-105ba9f1f829"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("064f2d40-55de-4ff5-a56c-c57c1dd562f4"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("0922f512-59fd-43c4-9d36-cdd18fccfb13"),
                column: "DepartmentID",
                value: new Guid("8fece7d7-737e-4625-bc9a-d5392ae16a7e"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("095a4f84-f388-4a49-9994-43eb52ec18e0"),
                column: "DepartmentID",
                value: new Guid("8fece7d7-737e-4625-bc9a-d5392ae16a7e"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("0badf6bd-77ef-4c6d-a568-912b57daf884"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("13a87b42-12ce-4cbc-8011-fc2c792f29e5"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("13c34157-f376-4a31-9391-7fdd4d7fbdb7"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("1897059a-c3fc-4cb3-a6dc-0aa23f62fc4d"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("1a46ac1d-c607-4225-9002-e14a4c1e3363"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("1b006764-b19a-402b-a17a-f9a12d5f4b76"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("1b84cd21-2550-41d3-b3d4-7a985e71d1ea"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("1f1f83d3-6271-4ac5-964f-2805ae049fa1"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("20a3f858-958e-42b0-b841-e907b592ce0e"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("20acdf30-8b86-4b77-921d-02b0bc9ee0d5"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("2274f76c-d939-47c9-89c2-8284728f2c7a"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("23665740-f571-4a6e-b3b4-8cdcb719d2fc"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("25a7e084-5ce1-48e8-bca7-9cada78ffa26"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("28a3020d-c97f-4f0b-a559-b59cfe2a6d3c"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("30677d50-b76e-4826-b24a-b7251602ee22"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("32ff3746-075f-4a74-bdaa-ed776cf854ff"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("3d27b128-0ce6-4990-9c5a-a21de5a414b5"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("3d5c9296-405d-4648-addf-2b0706b77169"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("435500b2-b00d-4a63-8571-a77f5aadc28d"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("4459b5db-fac2-4188-96ac-cf2d4e562f14"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("4e99258c-12cd-46b4-bf5b-136de3664bdb"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("520f8d39-11bd-4e16-9add-79661a45985e"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("52d2190e-c7a3-4f7b-ab3b-731e82216d02"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("564d341f-7ccf-4eb4-b250-f32d6cb1c633"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("58bbeec1-d95e-41f9-af74-a517457235c6"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("59c320f0-4ab1-4f43-bd8a-c4cfa2b687d7"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("60efbe37-61c0-4dc0-93ef-5d20358e8a30"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("62330761-ad34-4969-96c7-47eb3c70f552"),
                column: "DepartmentID",
                value: new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("7e542e0d-713f-437f-8a1d-0133a004b722"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("7ff93b84-31e2-4e02-81d1-68785909ccb9"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("8041883e-8a68-42e0-8213-3f8c2669c73e"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("86293383-c8de-4941-b83a-4b7c88a53ae1"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("87097a1a-aca0-42f0-8ce3-65995891a0ea"),
                column: "DepartmentID",
                value: new Guid("f6077631-118c-4c78-9bdb-7a7bda448145"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("8f5abb46-f621-4b96-9e1b-e6e84aba4b41"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("8fd7171a-8a59-4208-aabb-1c0699259052"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("a793836a-dd04-40e6-a610-04c45c411837"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("ab899bae-a14b-4a18-8ff5-b70be8405acc"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("b8391957-9ad4-4134-8b65-86d891b57d07"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("babc17e9-4b27-4ee1-8c79-5c39179eeb68"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("c0fff6d8-640b-44a4-ba64-9c550052ef80"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("e023c552-f2a5-48a5-88d6-f13f55b6d5bb"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("e1f195d3-4c19-4b33-a3ae-f2ac1f4e243e"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("e528b274-541c-4ba6-b4a8-5480a190f7be"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("e806b9b1-e27f-48df-9534-abe0ec02a5ab"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("eeb2ed1f-1b0f-4a3c-bad3-aab3a35a4796"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("f29033fa-ffd0-4c70-8726-a4eefa5f72ef"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("f489fc5f-0029-4a95-9fa9-ec6d63a33e0c"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("fae9d171-eecf-4b51-87c6-08e9b8bb3b21"),
                column: "DepartmentID",
                value: new Guid("f6077631-118c-4c78-9bdb-7a7bda448145"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("fb4cf15a-f794-4b59-bc78-3be63b7b8310"),
                column: "DepartmentID",
                value: new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("fc6943fa-c904-4b85-9232-eba8c33c485e"),
                column: "DepartmentID",
                value: new Guid("f6077631-118c-4c78-9bdb-7a7bda448145"));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("fd9a3b1a-af4d-4232-8663-bb0af5c428a0"),
                column: "DepartmentID",
                value: new Guid("f6077631-118c-4c78-9bdb-7a7bda448145"));

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyID", "BirthYear", "FacultyDescription", "FacultyName" },
                values: new object[,]
                {
                    { new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Graduate Studies", "School of Graduate Studies" },
                    { new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Science Faculty", "Faculty of Science" },
                    { new Guid("6eb6ce00-ddd4-4c45-be84-01f00286ddee"), new DateTimeOffset(new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Arts and Social Sciences Faculty", "Faculty of Arts and Social Sciences" },
                    { new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Education", "School of Education" },
                    { new Guid("8d679424-ebfb-4a05-aa3d-c9b43b99ac8d"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Nursing and Midwifery", "School of Nursing and Midwifery" },
                    { new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Business", "School of Business" }
                });

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinancialRecordID",
                value: new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"));

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinancialRecordID",
                value: new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"));

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "FinancialRecordID",
                value: new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"));

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "FinancialRecordID",
                value: new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"));

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "FinancialRecordID",
                value: new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"));

            migrationBuilder.UpdateData(
                table: "FeeItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "FinancialRecordID",
                value: new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"));

            migrationBuilder.InsertData(
                table: "FinancialRecords",
                columns: new[] { "FinancialRecordID", "AcademicYear", "AmountPaid", "LastUpdated", "OutstandingBalance", "Semester", "StudentID", "TotalFees" },
                values: new object[,]
                {
                    { new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"), "2023-2024", 5000m, new DateTimeOffset(new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200m, 1, "222CS01000694", 5200m },
                    { new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"), "2024-2025", 6000m, new DateTimeOffset(new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), -500m, 0, "222CS01000694", 5500m },
                    { new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"), "2023-2024", 4800m, new DateTimeOffset(new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, 0, "222CS01000694", 4800m }
                });

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "LecturerID",
                keyValue: "L0001",
                columns: new[] { "CourseID", "DepartmentID" },
                values: new object[] { null, new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") });

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "LecturerID",
                keyValue: "L0002",
                columns: new[] { "CourseID", "DepartmentID" },
                values: new object[] { null, new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") });

            migrationBuilder.InsertData(
                table: "RegistrationPeriods",
                columns: new[] { "RegistrationPeriodID", "AcademicYear", "AllowCourseAdd", "AllowCourseDrop", "Description", "EndDate", "IsActive", "LateRegistrationEnd", "LateRegistrationFee", "LateRegistrationStart", "Semester", "StartDate" },
                values: new object[] { new Guid("fe0137a4-129b-4202-8992-43888f906cd0"), "2024-2025", true, true, "January 2025 Registration", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "January", new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: "222CS01000694",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[] { new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"), "Computer Science" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: "222CS01000695",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[] { new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"), "Computer Science" });

            migrationBuilder.InsertData(
                table: "Transcripts",
                columns: new[] { "TranscriptID", "AcademicStanding", "CreditsAttempted", "CreditsEarned", "CummulativeGPA", "GeneratedDate", "StudentID", "isOfficial" },
                values: new object[] { new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c"), 2, 0, 0, 0.0, new DateTimeOffset(new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", false });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "BirthYear", "DepartmentDescription", "DepartmentName", "FacultyID", "RequiredCredits" },
                values: new object[,]
                {
                    { new Guid("0062ca09-cb14-4848-89ba-bf67d3f47558"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PhD Program in Computer Science", "PhD Computer Science", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 45 },
                    { new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "University Wide General Education Courses", "General Education", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 30 },
                    { new Guid("204c5a07-76d1-4cd9-b8d0-a9f03f71f0dc"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Music", "BEd Music", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("2c3cf3e7-8d5a-4d96-a43b-7129f8609ebc"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Information Technology", "BEd Information Technology", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("36748cb9-3334-4842-adeb-1dad00176201"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MEd/MPhil Program in Educational Administration & Leadership", "MEd/MPhil Educational Administration & Leadership", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 30 },
                    { new Guid("39f92acc-5a6b-4ec9-b42a-6aa63ade34ac"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Social Studies", "BEd Social Studies", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("39fb16d9-4838-4ede-b54c-f0e54b7c03e9"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Human Resource Management", "BBA Human Resource Management", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 120 },
                    { new Guid("4c146b27-19aa-494c-b73c-4bb2e6b72181"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Business Information Systems", "Business Information Systems", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("6c845634-cb6d-45e2-b659-1b6e0d3764e7"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Agribusiness", "Agribusiness", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("75b2887a-e4cc-4ec4-8d6a-f79accc5a942"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Development Studies", "Development Studies", new Guid("6eb6ce00-ddd4-4c45-be84-01f00286ddee"), 120 },
                    { new Guid("77b49912-6570-4173-a846-3240e8b6e688"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Accounting", "BEd Accounting", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("7e78d48a-9c30-4f2b-aea5-2fe1f419629c"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MBA Program in Strategic Management", "MBA Strategic Management", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 40 },
                    { new Guid("8f368706-5f28-4ae8-9311-df79be89cd87"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MSc/MPhil Program in Computer Science", "MSc/MPhil Computer Science", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 30 },
                    { new Guid("8fece7d7-737e-4625-bc9a-d5392ae16a7e"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Accounting", "BBA Accounting", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 120 },
                    { new Guid("920d6408-dc36-4da4-82dd-b8d89879c4e5"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MEd/MPhil Program in Curriculum & Instruction", "MEd/MPhil Curriculum & Instruction", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 30 },
                    { new Guid("971b2827-460d-4eab-bf7d-5ceec95e12e9"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd English Language", "BEd English Language", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("9b503f55-0d9d-4a72-b36d-00007d653e19"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Banking and Finance", "BBA Banking and Finance", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 120 },
                    { new Guid("9e11fb93-430a-4b00-9484-9fa5d244d7f6"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Mental Health Nursing", "Mental Health Nursing", new Guid("8d679424-ebfb-4a05-aa3d-c9b43b99ac8d"), 120 },
                    { new Guid("a0153b89-8d4d-4e7b-8590-0ea0c065e680"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Postgraduate Diploma in Education Program", "Postgraduate Diploma in Education", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 30 },
                    { new Guid("a75b1f50-327c-43b6-81f3-60f6a11b2a39"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Management", "BBA Management", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 120 },
                    { new Guid("a8fbc857-3859-4290-b237-a3c34ede9a12"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Agriculture", "Agriculture", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Computer Science", "Computer Science", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("b51eecd8-ba6b-48f8-a0c3-9db931701e30"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MBA Program in Accounting", "MBA Accounting", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 40 },
                    { new Guid("c1c8f6b4-aa8a-4290-85b6-d37cf1cbd6de"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Marketing", "BBA Marketing", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 120 },
                    { new Guid("ca8b289b-3e16-4cec-96f4-e42bc265d541"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MBA Program in Banking & Finance", "MBA Banking & Finance", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 40 },
                    { new Guid("cbebda38-3ec2-48aa-b0ad-062272d89f1b"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Midwifery", "Midwifery", new Guid("8d679424-ebfb-4a05-aa3d-c9b43b99ac8d"), 120 },
                    { new Guid("d10082ac-f3e9-4d09-b6db-cd80f309289c"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Diploma in Business Administration Program", "Diploma in Business Administration", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 60 },
                    { new Guid("d2de626b-f5eb-4b56-90a3-c6ebf0a3ff9b"), new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Communication Studies", "Communication Studies", new Guid("6eb6ce00-ddd4-4c45-be84-01f00286ddee"), 120 },
                    { new Guid("da251655-a9b0-4ffc-ae14-58e05447fa21"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Management", "BEd Management", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("dae9a67c-7463-4202-a21c-8f0768a2d004"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Biomedical Engineering", "Biomedical Engineering", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("dbd2656c-078b-4dac-8855-118ef5fd3f13"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Mathematics with Statistics", "Mathematics with Statistics", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("e805a0ae-aa24-4664-b92e-20e9237f7087"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PhD Program in Business Administration", "PhD Business Administration", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 45 },
                    { new Guid("ef16e32c-5600-45a4-9a0e-2f61b63081e9"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Diploma in Music Program", "Diploma in Music", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 60 },
                    { new Guid("f51c3927-2d65-40a8-892f-986e68899f8c"), new DateTimeOffset(new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Nursing", "Nursing", new Guid("8d679424-ebfb-4a05-aa3d-c9b43b99ac8d"), 120 },
                    { new Guid("f6077631-118c-4c78-9bdb-7a7bda448145"), new DateTimeOffset(new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Theological Studies", "Theological Studies", new Guid("6eb6ce00-ddd4-4c45-be84-01f00286ddee"), 90 },
                    { new Guid("fc538f1e-42cf-438b-b715-b3760fe528c6"), new DateTimeOffset(new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Information Technology", "Information Technology", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "Amount", "FinancialRecordID", "Notes", "PaymentDate", "PaymentMethod", "PaymentStatus", "ReferenceNumber" },
                values: new object[,]
                {
                    { new Guid("1373fabc-d569-4702-b49d-b5843615403f"), 2800m, new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"), null, new DateTimeOffset(new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 2, "716f1e77" },
                    { new Guid("19ac50f6-c91d-482f-a317-f31aa1d1b5a7"), 2000m, new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"), null, new DateTimeOffset(new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "4958224c" },
                    { new Guid("40582ce5-c69c-4971-89ac-db91378d785b"), 100m, new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"), null, new DateTimeOffset(new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2, "5823dc69" },
                    { new Guid("46fdd54d-25b9-41d4-a8a1-1ad7f4501d55"), 3000m, new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"), null, new DateTimeOffset(new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "cc1f49f1" },
                    { new Guid("68fdcb46-491e-4d2f-b520-912a603f9e0a"), 2000m, new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"), null, new DateTimeOffset(new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "7327bd94" },
                    { new Guid("b0fcc293-5634-4254-bbd3-34b63aa36774"), 6000m, new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"), null, new DateTimeOffset(new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "e941ebb2" }
                });

            migrationBuilder.InsertData(
                table: "SemesterRecords",
                columns: new[] { "SemesterRecordID", "AcademicYear", "CreditsAttempted", "CreditsEarned", "EndDate", "Semester", "SemesterGPA", "StartDate", "StudentID", "TranscriptID" },
                values: new object[,]
                {
                    { new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "2022/2023", 0, 0, new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 0.0, new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") },
                    { new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "2022/2023", 0, 0, new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 0.0, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") },
                    { new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "2023/2024", 0, 0, new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 0.0, new DateTimeOffset(new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") },
                    { new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "2023/2024", 0, 0, new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 0.0, new DateTimeOffset(new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") },
                    { new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "2021/2022", 0, 0, new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 0.0, new DateTimeOffset(new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") },
                    { new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "2021/2022", 0, 0, new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 0.0, new DateTimeOffset(new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeID", "CourseID", "DateAwarded", "GradeLetter", "GradePoints", "Remarks", "Semester", "SemesterRecordID", "StudentID", "isCompleted" },
                values: new object[,]
                {
                    { new Guid("0879919f-0859-4bcf-af04-14866fb2c632"), new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 1.0, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("142e51ae-a1e0-4af2-9ccd-bf72ddcc23f8"), new Guid("87097a1a-aca0-42f0-8ce3-65995891a0ea"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("224856e4-2dab-461e-9a6d-5af7e251bd6a"), new Guid("f489fc5f-0029-4a95-9fa9-ec6d63a33e0c"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("2d4665dc-73ed-414d-84f9-04997affe73a"), new Guid("1b006764-b19a-402b-a17a-f9a12d5f4b76"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("3030cdb2-31d2-412c-b76f-f9f559d06e41"), new Guid("0922f512-59fd-43c4-9d36-cdd18fccfb13"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("30ef83f3-d15e-469f-8bb9-dbfbb859d638"), new Guid("fae9d171-eecf-4b51-87c6-08e9b8bb3b21"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("367dbb5b-8eb2-48c2-98fb-f6a6b23bb958"), new Guid("babc17e9-4b27-4ee1-8c79-5c39179eeb68"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("460d5cbb-99b4-4a08-b25c-c1ebaf682573"), new Guid("28a3020d-c97f-4f0b-a559-b59cfe2a6d3c"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("4760e506-6ea9-466c-b040-a24e8d6b51aa"), new Guid("fc6943fa-c904-4b85-9232-eba8c33c485e"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("51d63611-e336-4d8b-a203-512179e33000"), new Guid("7e542e0d-713f-437f-8a1d-0133a004b722"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("5223758b-53f0-42a6-b6da-162a013a8522"), new Guid("1b84cd21-2550-41d3-b3d4-7a985e71d1ea"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("528cdfc0-0bbb-4d7c-baa1-1c84c4c39cde"), new Guid("a793836a-dd04-40e6-a610-04c45c411837"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("5359df1b-c663-42d0-98c8-b3761e8d09cf"), new Guid("012bdf77-0b02-4d88-8da0-105ba9f1f829"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("5490f4c8-b071-47db-8421-9261b3de4f83"), new Guid("0badf6bd-77ef-4c6d-a568-912b57daf884"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("67501f6f-2e0d-40d1-be02-15f3a8571467"), new Guid("2274f76c-d939-47c9-89c2-8284728f2c7a"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("6ccc3b12-b813-4ecc-9969-8302f2cc212a"), new Guid("59c320f0-4ab1-4f43-bd8a-c4cfa2b687d7"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("7fec2139-1bd6-4da2-b482-922e33c1fe1d"), new Guid("1897059a-c3fc-4cb3-a6dc-0aa23f62fc4d"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("8139cdd9-c82b-4b5e-b6d0-31bb05d2a942"), new Guid("1f1f83d3-6271-4ac5-964f-2805ae049fa1"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("84f12965-202f-47da-acaf-3a66ede57d28"), new Guid("8041883e-8a68-42e0-8213-3f8c2669c73e"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("8c1075fc-ff0b-4b26-a77a-334371a0c3ca"), new Guid("13a87b42-12ce-4cbc-8011-fc2c792f29e5"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 1.0, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("8e689d3b-5d91-48f6-aaaf-8dd93d6add3f"), new Guid("52d2190e-c7a3-4f7b-ab3b-731e82216d02"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("906d3943-6221-4cc7-8b4c-9bcb82eac86d"), new Guid("064f2d40-55de-4ff5-a56c-c57c1dd562f4"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("9dbe4a75-946b-4183-a321-1fa6ab63bd70"), new Guid("fb4cf15a-f794-4b59-bc78-3be63b7b8310"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("a41ec771-7d4d-411a-9c3e-b8705c3a2e00"), new Guid("564d341f-7ccf-4eb4-b250-f32d6cb1c633"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("a6cbe756-ea6e-4ce6-b22d-181cb1f993dc"), new Guid("23665740-f571-4a6e-b3b4-8cdcb719d2fc"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("a7120d6d-8ebd-46a7-a7ac-d30e88210c67"), new Guid("20acdf30-8b86-4b77-921d-02b0bc9ee0d5"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("ab8f7b77-87d1-4991-8d94-a248dafb5f21"), new Guid("f29033fa-ffd0-4c70-8726-a4eefa5f72ef"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("ac347fef-cc16-434a-85ba-605712c9459c"), new Guid("13c34157-f376-4a31-9391-7fdd4d7fbdb7"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("b422316a-4814-40fe-a20a-858e076e01a0"), new Guid("1a46ac1d-c607-4225-9002-e14a4c1e3363"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 12, 0.0, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("b521b4cd-2150-42c9-970f-460607af3f6a"), new Guid("8f5abb46-f621-4b96-9e1b-e6e84aba4b41"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("b86738e3-2aa6-4c01-96e4-f061900e1237"), new Guid("20a3f858-958e-42b0-b841-e907b592ce0e"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("bc91ca56-7c40-45d2-906e-ec14d97d6c9d"), new Guid("eeb2ed1f-1b0f-4a3c-bad3-aab3a35a4796"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("c1dd35f0-9613-42c6-bcc9-9cba05dccf76"), new Guid("095a4f84-f388-4a49-9994-43eb52ec18e0"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("c29000cb-56fb-4ca5-a615-4ec989e1976d"), new Guid("62330761-ad34-4969-96c7-47eb3c70f552"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("c635a327-55da-4ac8-b504-6c58474805ec"), new Guid("4459b5db-fac2-4188-96ac-cf2d4e562f14"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("c808894d-0539-4458-a354-aa2be3fcd02a"), new Guid("25a7e084-5ce1-48e8-bca7-9cada78ffa26"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("ccf5cae9-b411-40ca-bf43-b9d6fce9ff94"), new Guid("e023c552-f2a5-48a5-88d6-f13f55b6d5bb"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("cf5f6515-b2a5-4b78-80a3-fe3a09ada802"), new Guid("435500b2-b00d-4a63-8571-a77f5aadc28d"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("d2526021-0cbd-4237-afcc-06a286efe990"), new Guid("60efbe37-61c0-4dc0-93ef-5d20358e8a30"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("d99fbd5e-b2af-4ab0-ad1c-95b1460ce254"), new Guid("20a3f858-958e-42b0-b841-e907b592ce0e"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 11, 0.0, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("eaded960-c960-4614-91a4-56e16e0d45b2"), new Guid("32ff3746-075f-4a74-bdaa-ed776cf854ff"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("eb1f3037-00d6-4d7f-91d6-d3fc8e419a8b"), new Guid("520f8d39-11bd-4e16-9add-79661a45985e"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 11, 0.0, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("f1c00dd7-b802-4f05-bb23-01a48e6857e8"), new Guid("c0fff6d8-640b-44a4-ba64-9c550052ef80"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("fbe58454-1d09-49b0-820c-0464b7b0ec86"), new Guid("ab899bae-a14b-4a18-8ff5-b70be8405acc"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("fcc6657b-23e1-49e4-a163-a2e5a997fdca"), new Guid("b8391957-9ad4-4134-8b65-86d891b57d07"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_CourseID",
                table: "Lecturers",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                table: "Courses",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Faculties_FacultyID",
                table: "Departments",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "FacultyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Courses_CourseID",
                table: "Lecturers",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceBorrowings_AspNetUsers_StudentId",
                table: "ResourceBorrowings",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceBorrowings_LibraryResources_LibraryResourceID",
                table: "ResourceBorrowings",
                column: "LibraryResourceID",
                principalTable: "LibraryResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentID",
                table: "Students",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
