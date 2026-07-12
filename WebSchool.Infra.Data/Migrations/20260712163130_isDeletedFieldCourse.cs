using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSchool.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class isDeletedFieldCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Course",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Course");
        }
    }
}
