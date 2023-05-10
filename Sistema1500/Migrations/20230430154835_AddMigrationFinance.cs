using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema1500.Migrations
{
    public partial class AddMigrationFinance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "AspNetUserTokens",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginProvider",
            //    table: "AspNetUserTokens",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ProviderKey",
            //    table: "AspNetUserLogins",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginProvider",
            //    table: "AspNetUserLogins",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Captures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostCenter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enterprise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EnterpriseId = table.Column<int>(nullable: false),
                    Balance = table.Column<float>(nullable: false),
                    InitialBalance = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Enterprise_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    CashDate = table.Column<DateTime>(nullable: false),
                    MonthDate = table.Column<DateTime>(nullable: false),
                    CompeteDate = table.Column<DateTime>(nullable: false),
                    CompeteMonthDate = table.Column<DateTime>(nullable: false),
                    CostCenterId = table.Column<int>(nullable: true),
                    CapturesId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    BankAccountId = table.Column<int>(nullable: true),
                    TargetBill = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<float>(nullable: false),
                    Validated = table.Column<bool>(nullable: false),
                    Plan = table.Column<bool>(nullable: false),
                    BankValueMoment = table.Column<float>(nullable: false),
                    EnterpriseBankValueMoment = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_Captures_CapturesId",
                        column: x => x.CapturesId,
                        principalTable: "Captures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_EnterpriseId",
                table: "BankAccount",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_BankAccountId",
                table: "Expense",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CapturesId",
                table: "Expense",
                column: "CapturesId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CostCenterId",
                table: "Expense",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_PersonId",
                table: "Expense",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Captures");

            migrationBuilder.DropTable(
                name: "CostCenter");

            migrationBuilder.DropTable(
                name: "Enterprise");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);
        }
    }
}
