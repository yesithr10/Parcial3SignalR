using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArriendosInmuebles",
                columns: table => new
                {
                    MatriculaInmueble = table.Column<string>(nullable: false),
                    IdentificacionArrendatario = table.Column<string>(nullable: true),
                    NombreArrendatario = table.Column<string>(nullable: true),
                    MesesAlquiler = table.Column<int>(nullable: false),
                    ValorDeposito = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArriendosInmuebles", x => x.MatriculaInmueble);
                });

            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    MatriculaInmobiliaria = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    ValorArriendo = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.MatriculaInmobiliaria);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArriendosInmuebles");

            migrationBuilder.DropTable(
                name: "Inmuebles");
        }
    }
}
