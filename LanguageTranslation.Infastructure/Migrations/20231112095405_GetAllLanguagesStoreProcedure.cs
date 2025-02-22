using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageTranslation.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class GetAllLanguagesStoreProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var command = @"CREATE PROCEDURE GetAllLanguagesStoreProcedure
                        AS
                        BEGIN
	                        SELECT * FROM [LanguageDb].[dbo].[Language];
                        END 
                        GO";

            migrationBuilder.Sql(command);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var command = "DROP PROCEDURE GetAllLanguagesStoreProcedure";
            migrationBuilder.Sql(command);
        }
    }
}
