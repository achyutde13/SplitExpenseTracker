using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class apptodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Member_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Member_Id);
                });

            migrationBuilder.CreateTable(
                name: "DebtSettlements",
                columns: table => new
                {
                    SettlementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwerId = table.Column<int>(type: "int", nullable: false),
                    OwedToId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtSettlements", x => x.SettlementId);
                    table.ForeignKey(
                        name: "FK_DebtSettlements_Members_OwedToId",
                        column: x => x.OwedToId,
                        principalTable: "Members",
                        principalColumn: "Member_Id");
                    table.ForeignKey(
                        name: "FK_DebtSettlements_Members_OwerId",
                        column: x => x.OwerId,
                        principalTable: "Members",
                        principalColumn: "Member_Id");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Expense_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidById = table.Column<int>(type: "int", nullable: false),
                    IsCredit = table.Column<bool>(type: "bit", nullable: false),
                    IsCreditFromId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Expense_Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Members_IsCreditFromId",
                        column: x => x.IsCreditFromId,
                        principalTable: "Members",
                        principalColumn: "Member_Id");
                    table.ForeignKey(
                        name: "FK_Expenses_Members_PaidById",
                        column: x => x.PaidById,
                        principalTable: "Members",
                        principalColumn: "Member_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtSettlements_OwedToId",
                table: "DebtSettlements",
                column: "OwedToId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtSettlements_OwerId",
                table: "DebtSettlements",
                column: "OwerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_IsCreditFromId",
                table: "Expenses",
                column: "IsCreditFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaidById",
                table: "Expenses",
                column: "PaidById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtSettlements");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
