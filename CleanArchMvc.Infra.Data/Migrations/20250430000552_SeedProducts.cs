using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Caderno espiral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno1.jpg', 1)");

            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Estojo escolar', 'Estojo escolar com 3 divisórias', 5.99, 70, 'estojo1.jpg', 1)");

            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Borracha escolar', 'Borracha branca', 1.99, 100, 'borracha1.jpg', 1)");

            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Caneta esferográfica', 'Caneta azul', 2.50, 200, 'caneta1.jpg', 1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql(
                "DELETE FROM Products");
        }
    }
}
