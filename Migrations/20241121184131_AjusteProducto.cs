using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ejemploReporte.Migrations
{
    /// <inheritdoc />
    public partial class AjusteProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarcaProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModeloProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MedidasProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColorProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrecioCosto = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    PrecioVenta = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    EliminadoProducto = table.Column<bool>(type: "bit", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
