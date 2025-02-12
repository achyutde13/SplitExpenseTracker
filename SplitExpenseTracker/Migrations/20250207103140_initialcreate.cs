using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtSettlements_Members_OwedToId",
                table: "DebtSettlements");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtSettlements_Members_OwerId",
                table: "DebtSettlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Members_IsCreditFromId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_IsCreditFromId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "IsCredit",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "IsCreditFromId",
                table: "Expenses");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtSettlements_Members_OwedToId",
                table: "DebtSettlements",
                column: "OwedToId",
                principalTable: "Members",
                principalColumn: "Member_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtSettlements_Members_OwerId",
                table: "DebtSettlements",
                column: "OwerId",
                principalTable: "Members",
                principalColumn: "Member_Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtSettlements_Members_OwedToId",
                table: "DebtSettlements");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtSettlements_Members_OwerId",
                table: "DebtSettlements");

            migrationBuilder.AddColumn<bool>(
                name: "IsCredit",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IsCreditFromId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_IsCreditFromId",
                table: "Expenses",
                column: "IsCreditFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtSettlements_Members_OwedToId",
                table: "DebtSettlements",
                column: "OwedToId",
                principalTable: "Members",
                principalColumn: "Member_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtSettlements_Members_OwerId",
                table: "DebtSettlements",
                column: "OwerId",
                principalTable: "Members",
                principalColumn: "Member_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Members_IsCreditFromId",
                table: "Expenses",
                column: "IsCreditFromId",
                principalTable: "Members",
                principalColumn: "Member_Id");
        }
    }
}
