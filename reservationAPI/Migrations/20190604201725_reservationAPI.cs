using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace reservationAPI.Migrations
{
    public partial class reservationAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetingroom",
                columns: table => new
                {
                    IdMeetingroom = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Roomname = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetingroom", x => x.IdMeetingroom);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    IdAppointment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: true),
                    End = table.Column<DateTime>(nullable: true),
                    MeetingroomIdMeetingroom = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.IdAppointment);
                    table.ForeignKey(
                        name: "FK_Appointment_Meetingroom_MeetingroomIdMeetingroom",
                        column: x => x.MeetingroomIdMeetingroom,
                        principalTable: "Meetingroom",
                        principalColumn: "IdMeetingroom",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_MeetingroomIdMeetingroom",
                table: "Appointment",
                column: "MeetingroomIdMeetingroom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Meetingroom");
        }
    }
}
