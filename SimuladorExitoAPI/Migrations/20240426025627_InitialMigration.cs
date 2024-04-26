using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorExitoAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Career",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Career", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Career_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Milestone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ElapsedYears = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Context = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CareerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Milestone_Career_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Career",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EstimatedRemuneration = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Sector = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    InfoSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PossibleWorkplaces = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarrerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_Career_CarrerId",
                        column: x => x.CarrerId,
                        principalTable: "Career",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Postgraduate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostLevel = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    CareerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postgraduate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Postgraduate_Career_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Career",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilestonePositions",
                columns: table => new
                {
                    MilestoneId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilestonePositions", x => new { x.MilestoneId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_MilestonePositions_Milestone_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "Milestone",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilestonePositions_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MilestonePostgraduates",
                columns: table => new
                {
                    MilestoneId = table.Column<int>(type: "int", nullable: false),
                    PostgraduateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilestonePostgraduates", x => new { x.MilestoneId, x.PostgraduateId });
                    table.ForeignKey(
                        name: "FK_MilestonePostgraduates_Milestone_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "Milestone",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilestonePostgraduates_Postgraduate_PostgraduateId",
                        column: x => x.PostgraduateId,
                        principalTable: "Postgraduate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Career_FacultyId",
                table: "Career",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Career_Slug",
                table: "Career",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_CareerId",
                table: "Milestone",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_MilestonePositions_PositionId",
                table: "MilestonePositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_MilestonePostgraduates_PostgraduateId",
                table: "MilestonePostgraduates",
                column: "PostgraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_CarrerId",
                table: "Position",
                column: "CarrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Postgraduate_CareerId",
                table: "Postgraduate",
                column: "CareerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MilestonePositions");

            migrationBuilder.DropTable(
                name: "MilestonePostgraduates");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Milestone");

            migrationBuilder.DropTable(
                name: "Postgraduate");

            migrationBuilder.DropTable(
                name: "Career");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
