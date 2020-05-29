using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_Quotes.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuotesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuotesId);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuotesId", "Author", "InsertDate", "Text" },
                values: new object[,]
                {
                    { 1, "Вадим Зеланд", new DateTime(2020, 5, 29, 20, 39, 27, 471, DateTimeKind.Local), "Чудо произойдет только в том случае, если вы сломаете привычный стереотип и будете думать не о средствах достижения, а о самой цели" },
                    { 2, "Вадим Зеланд", new DateTime(2020, 5, 29, 20, 39, 27, 495, DateTimeKind.Local), "Вы никогда ничего не измените, если будете бороться с существующим. Чтобы что-то изменить, постройте новую модель и сделайте существующее устаревшим." },
                    { 3, "Генри Форд", new DateTime(2020, 5, 29, 20, 39, 27, 495, DateTimeKind.Local), "Везет человеку, которому удается уйти из этого мира живым." },
                    { 4, "Альберт Эйнштейн", new DateTime(2020, 5, 29, 20, 39, 27, 495, DateTimeKind.Local), "Я научился смотреть на смерть как на старый долг, который рано или поздно придется заплатить" },
                    { 5, "Кин Хаббард", new DateTime(2020, 5, 29, 20, 39, 27, 495, DateTimeKind.Local), "Что бы там ни было, никогда не принимайте жизнь слишком всерьез – вам из нее живьем все равно не выбраться" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
