using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<long>(type: "bigint", nullable: false),
                    EducationLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    PastExperiences_Sales = table.Column<bool>(type: "bit", nullable: false),
                    PastExperiences_Support = table.Column<bool>(type: "bit", nullable: false),
                    InternetTest_DownloadSpeed = table.Column<double>(type: "float", nullable: false),
                    InternetTest_UploadSpeed = table.Column<double>(type: "float", nullable: false),
                    WritingScore = table.Column<double>(type: "float", nullable: false),
                    ReferralCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasMinimunRequirementsForEligibility = table.Column<bool>(type: "bit", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MinimumScore = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferralCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eligibility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectedProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eligibility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eligibility_Pro_ProId",
                        column: x => x.ProId,
                        principalTable: "Pro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eligibility_Project_SelectedProjectId",
                        column: x => x.SelectedProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ElegibleProjects",
                columns: table => new
                {
                    ElegibleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EligibleProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElegibleProjects", x => new { x.ElegibleId, x.EligibleProjectsId });
                    table.ForeignKey(
                        name: "FK_ElegibleProjects_Eligibility_ElegibleId",
                        column: x => x.ElegibleId,
                        principalTable: "Eligibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElegibleProjects_Project_EligibleProjectsId",
                        column: x => x.EligibleProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InelegibleProjects",
                columns: table => new
                {
                    InelegibleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IneligibleProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InelegibleProjects", x => new { x.InelegibleId, x.IneligibleProjectsId });
                    table.ForeignKey(
                        name: "FK_InelegibleProjects_Eligibility_InelegibleId",
                        column: x => x.InelegibleId,
                        principalTable: "Eligibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InelegibleProjects_Project_IneligibleProjectsId",
                        column: x => x.IneligibleProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Created", "CreatedBy", "MinimumScore", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("0e6faf34-8fa0-4efe-94db-c5fe1171c587"), null, null, 10, null, null, "Calculate the Dark Matter of the universe for Nasa" },
                    { new Guid("15c03f0a-0cf5-4da3-a662-446c76d095b5"), null, null, 3, null, null, "Attend to users support for a YXZ Company" },
                    { new Guid("5ff11d56-9b9d-4e9f-9be1-90609fc426ee"), null, null, 5, null, null, "Determine if the Schrodinger's cat is alive" },
                    { new Guid("873f4ece-db97-4a63-8e8f-1712e9659b60"), null, null, 2, null, null, "Collect specific people information from their social media for XPTO Company" }
                });

            migrationBuilder.InsertData(
                table: "ReferralCode",
                columns: new[] { "Id", "Code" },
                values: new object[] { new Guid("3811e1db-55ae-48f9-a220-427cf1ae1b0d"), "token1234" });

            migrationBuilder.CreateIndex(
                name: "IX_ElegibleProjects_EligibleProjectsId",
                table: "ElegibleProjects",
                column: "EligibleProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Eligibility_ProId",
                table: "Eligibility",
                column: "ProId");

            migrationBuilder.CreateIndex(
                name: "IX_Eligibility_SelectedProjectId",
                table: "Eligibility",
                column: "SelectedProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InelegibleProjects_IneligibleProjectsId",
                table: "InelegibleProjects",
                column: "IneligibleProjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElegibleProjects");

            migrationBuilder.DropTable(
                name: "InelegibleProjects");

            migrationBuilder.DropTable(
                name: "ReferralCode");

            migrationBuilder.DropTable(
                name: "Eligibility");

            migrationBuilder.DropTable(
                name: "Pro");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
