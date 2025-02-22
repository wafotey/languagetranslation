using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageTranslation.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class GetAllTranslationByLanguageStoreProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var command = @"CREATE PROCEDURE GetAllTranslationByLanguageStoreProcedure(@LanguageId as UNIQUEIDENTIFIER)
                            AS
                            BEGIN
                                SELECT * FROM [LanguageDb].[dbo].[Translation] WHERE LanguageId = @LanguageId
                                ORDER BY CreatedAt DESC;
                            END 
                            GO";
            migrationBuilder.Sql(command);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var command = "DROP PROCEDURE GetAllTranslationByLanguageStoreProcedure";
            migrationBuilder.Sql(command);
        }
    }
}
