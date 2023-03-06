using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TPT2à : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passenger_PassengerPassportNumber",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Vols_FlightId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket");
             
            migrationBuilder.DropIndex(
                name: "IX_Ticket_PassengerPassportNumber",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PassengerPassportNumber",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerFk",
                table: "Ticket",
                column: "PassengerFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passenger_PassengerFk",
                table: "Ticket",
                column: "PassengerFk",
                principalTable: "Passenger",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Vols_FlightFk",
                table: "Ticket",
                column: "FlightFk",
                principalTable: "Vols",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passenger_PassengerFk",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Vols_FlightFk",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_PassengerFk",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengerPassportNumber",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerPassportNumber",
                table: "Ticket",
                column: "PassengerPassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passenger_PassengerPassportNumber",
                table: "Ticket",
                column: "PassengerPassportNumber",
                principalTable: "Passenger",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Vols_FlightId",
                table: "Ticket",
                column: "FlightId",
                principalTable: "Vols",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
