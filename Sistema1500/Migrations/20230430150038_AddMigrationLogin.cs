using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema1500.Migrations
{
    public partial class AddMigrationLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Circles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Fee = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Enterprise = table.Column<string>(nullable: true),
                    Duration = table.Column<float>(nullable: false),
                    Value = table.Column<float>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeConsultors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Fee = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeConsultors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CircleId = table.Column<int>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    BornDate = table.Column<DateTime>(nullable: false),
                    NivelStudy = table.Column<int>(nullable: false),
                    University = table.Column<string>(nullable: true),
                    GraduateDate = table.Column<DateTime>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Enterprise = table.Column<string>(nullable: true),
                    Recommendation = table.Column<bool>(nullable: false),
                    IsStudy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    CircleId = table.Column<int>(nullable: false),
                    ThemeId = table.Column<int>(nullable: false),
                    OportunityLearning = table.Column<string>(nullable: true),
                    Note = table.Column<float>(nullable: false),
                    Commnent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Learnings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    CircleId = table.Column<int>(nullable: false),
                    ThemeId = table.Column<int>(nullable: false),
                    OportunityLearning = table.Column<string>(nullable: true),
                    LearningAction = table.Column<string>(nullable: true),
                    MeasurementDate = table.Column<DateTime>(nullable: false),
                    MeasurementForm = table.Column<float>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Learnings_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Learnings_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActualStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    CircleId = table.Column<int>(nullable: false),
                    TypeConsultorId = table.Column<int>(nullable: false),
                    TypeObject = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimePlanned = table.Column<float>(nullable: false),
                    Value = table.Column<float>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    RealTime = table.Column<float>(nullable: false),
                    Delivered = table.Column<bool>(nullable: false),
                    RealValue = table.Column<float>(nullable: false),
                    Productivity = table.Column<float>(nullable: false),
                    Sprint = table.Column<DateTime>(nullable: false),
                    FinalValue = table.Column<float>(nullable: false),
                    PersonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualStates_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualStates_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActualStates_AspNetUsers_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActualStates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualStates_TypeConsultors_TypeConsultorId",
                        column: x => x.TypeConsultorId,
                        principalTable: "TypeConsultors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypePerson = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    FeedbackId = table.Column<int>(nullable: false),
                    PersonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonFeedbacks_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonFeedbacks_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonFeedbacks_AspNetUsers_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonLearnings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypePerson = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    LearningId = table.Column<int>(nullable: false),
                    PersonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLearnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonLearnings_Learnings_LearningId",
                        column: x => x.LearningId,
                        principalTable: "Learnings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLearnings_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonLearnings_AspNetUsers_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoursDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualStateId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    RealTime = table.Column<float>(nullable: false),
                    Delivered = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoursDays_ActualStates_ActualStateId",
                        column: x => x.ActualStateId,
                        principalTable: "ActualStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoursDays_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoursDays_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualStates_CircleId",
                table: "ActualStates",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualStates_PersonId",
                table: "ActualStates",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualStates_PersonId1",
                table: "ActualStates",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_ActualStates_ProjectId",
                table: "ActualStates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualStates_TypeConsultorId",
                table: "ActualStates",
                column: "TypeConsultorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CircleId",
                table: "AspNetUsers",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CircleId",
                table: "Feedbacks",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ThemeId",
                table: "Feedbacks",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursDays_ActualStateId",
                table: "HoursDays",
                column: "ActualStateId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursDays_PersonId",
                table: "HoursDays",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursDays_ProjectId",
                table: "HoursDays",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Learnings_CircleId",
                table: "Learnings",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Learnings_ThemeId",
                table: "Learnings",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFeedbacks_FeedbackId",
                table: "PersonFeedbacks",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFeedbacks_PersonId",
                table: "PersonFeedbacks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFeedbacks_PersonId1",
                table: "PersonFeedbacks",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLearnings_LearningId",
                table: "PersonLearnings",
                column: "LearningId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLearnings_PersonId",
                table: "PersonLearnings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLearnings_PersonId1",
                table: "PersonLearnings",
                column: "PersonId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HoursDays");

            migrationBuilder.DropTable(
                name: "PersonFeedbacks");

            migrationBuilder.DropTable(
                name: "PersonLearnings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ActualStates");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Learnings");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TypeConsultors");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Circles");
        }
    }
}
