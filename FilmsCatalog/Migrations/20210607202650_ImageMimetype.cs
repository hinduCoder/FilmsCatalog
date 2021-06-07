using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsCatalog.Migrations
{
    public partial class ImageMimetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Image_PosterId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "Images",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Images_PosterId",
                table: "Movies",
                column: "PosterId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Images_PosterId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "Images");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Image_PosterId",
                table: "Movies",
                column: "PosterId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
