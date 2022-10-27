using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeloWorldSystem.Data.Migrations
{
    public partial class MakeLikesToHaveOnlyCreationDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLike_Activities_ActivityId",
                table: "ActivityLike");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLike_AspNetUsers_UserId",
                table: "ActivityLike");

            migrationBuilder.DropForeignKey(
                name: "FK_Waypoint_Activities_ActivityId",
                table: "Waypoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Waypoint",
                table: "Waypoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityLike",
                table: "ActivityLike");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ActivityLike");

            migrationBuilder.RenameTable(
                name: "Waypoint",
                newName: "Waypoints");

            migrationBuilder.RenameTable(
                name: "ActivityLike",
                newName: "ActivityLikes");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityLike_UserId",
                table: "ActivityLikes",
                newName: "IX_ActivityLikes_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Waypoints",
                table: "Waypoints",
                columns: new[] { "ActivityId", "OrderNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityLikes",
                table: "ActivityLikes",
                columns: new[] { "ActivityId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLikes_Activities_ActivityId",
                table: "ActivityLikes",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLikes_AspNetUsers_UserId",
                table: "ActivityLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Waypoints_Activities_ActivityId",
                table: "Waypoints",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLikes_Activities_ActivityId",
                table: "ActivityLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLikes_AspNetUsers_UserId",
                table: "ActivityLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Waypoints_Activities_ActivityId",
                table: "Waypoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Waypoints",
                table: "Waypoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityLikes",
                table: "ActivityLikes");

            migrationBuilder.RenameTable(
                name: "Waypoints",
                newName: "Waypoint");

            migrationBuilder.RenameTable(
                name: "ActivityLikes",
                newName: "ActivityLike");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityLikes_UserId",
                table: "ActivityLike",
                newName: "IX_ActivityLike_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ActivityLike",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Waypoint",
                table: "Waypoint",
                columns: new[] { "ActivityId", "OrderNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityLike",
                table: "ActivityLike",
                columns: new[] { "ActivityId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLike_Activities_ActivityId",
                table: "ActivityLike",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLike_AspNetUsers_UserId",
                table: "ActivityLike",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Waypoint_Activities_ActivityId",
                table: "Waypoint",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
