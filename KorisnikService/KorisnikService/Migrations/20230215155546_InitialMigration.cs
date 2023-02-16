using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KorisnikService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
	   /// <inheritdoc />
	   protected override void Up(MigrationBuilder migrationBuilder)
	   {
		  migrationBuilder.CreateTable(
			 name: "Korisnici",
			 columns: table => new
			 {
				ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Naziv = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
				Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
				So = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Ime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
				Prezime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
				Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
				Tip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
			 },
			 constraints: table =>
			 {
				table.PrimaryKey("PK_Korisnici", x => x.ID);
			 });

		  migrationBuilder.InsertData(
			 table: "Korisnici",
			 columns: new[] { "ID", "Email", "Ime", "Lozinka", "Naziv", "Prezime", "So", "Tip" },
			 values: new object[,]
			 {
				{ new Guid("12ac5ef6-a637-4e6b-9c5d-e2907933f60b"), "marinkovic.it20.2019@uns.ac.rs", "Luka", "7A8nJgLFzVYua9gRfT4kK3f5torz+5eQQsjsBvaag2EUCLnn1Ec/qnk695qVnIgyQxR63Wj0XPXDRk6krryAChCLkh1obe2BR3nbTxnzOdE2r87NR8kDauCsBDOVyCh98pdtjOQz7koedlxnk6m9UOJnnmVeZaXklnKEU4D6jYsGo9KzECvPY4wUiL9+DG992G3Cbe1WfcMnESvdkqg6hVTfWEJm9Jy6adpWl6Zk1RkmyGYyQoAEvT8SnHCL7DmdNR5V/wqbT0ODdYCKShS2jRSnS/mKzrl0o3FOJTvGzCGe4sNRiI6lsVGUlCtxwbHqphX0EJFMNpwNTOFBtB2JOw==", "it20-2019", "Marinkovic", "OTXOXJOScugC", "ADMIN" },
				{ new Guid("24a02c12-485b-43ef-9ce2-4dd90ab26385"), "maglov.it75.2019@uns.ac.rs", "Milan", "FsP1byx0BDXyWASzEynJzPdYy7xG/B2BZ2biDr7vMfx2+/nxqv5WVy6w9aH37lmo/3AUobfSSVwRl1llWI9UMnbd3L/AnSxBuZK/IzEMhkP/0C9PKgXOhmQUzXipXFJDCOdYDAmJlfg9IqA1k9GMq98YB+tl++61a0JheCnA9Z7H3qbQ+i33vOaJ8QTJNebSoF4mUMOBlh9HeUJVMV+QH8hUly1x4dOulffnBmZb53vzO172JDn77vyDHz0nFNQ2W5DuO1bzpV+H3j8dwU8tV4b67lTlLnZEsuY5Ce8pXKyDTRkXgcZpxUSa8G6jMop4eX6MgRbCNAiI4eeITSdMFA==", "it75-2019", "Maglov", "9+RF8bbcEC0S", "ADMIN" },
				{ new Guid("25c5d21e-8791-4431-8311-0b3825215865"), "rakic.it19.2019@uns.ac.rs", "Petar", "p6c/KFeRpPg1mTAc5BygIk92qcR1nphLkDggT4vqkg32u7uCdjwizwT5nbZc3uKUfMEf72+h65D2k507XMLU90w7WAVt1gIx3Ceqbrgz/Fwr/FWwDPrZKXQ5S8iefWW0ug+VlC//ZSStmJCAqvwc8L81WjoEZQGf0E0k9usOVBG7gPl8HN+MaHuSAwcgWy+W1ME19C7ou+30RZDtMIwt5XrB/NE65wQp1GDeR33vC52r7+IMteZMtI7cZ41eKGBIoaQYgcnb5Bs2vXZRiBvKMQNYLbiXOo6JvYHAyqeznMgKUW4pbaRJnCr4B6zLZ7fQnTWDWGhxbTdqkNwqbQI7ug==", "it19-2019", "Rakic", "mIAnpo2MvHrp", "ADMIN" },
				{ new Guid("3ef835af-df00-49ff-b8f3-9a0e0a21af2d"), "dejanovic.it42.2019@uns.ac.rs", "Elena", "e47zM/fAmzDcVUHtPEJRGSLjSBgODFB53Sss3FR805tkaseksyXeFJPK25uRG/jj3uhCUjdYNu5UPBRYYjMWMPX/L4Yh3gVlTdSMlThMxlJ6hhUfOTEppsRRsLGlw8kI6V1+TlgvGihaNnzVJJA21jcA4etse2AX4BHdDwGDG19XAB8x9WMCAmIoNnf5LiNcfAe22R69J4v7y8b+Mr70tRuLKYw6rhvxtLv9gz074mlgzq6wcglveSW1dCDH4i1XErJSI7YAEhkwHLF0ZnjV4SebvpYMTUcI7WD5Whd00PpCOjJnknyPh0noxxXMWVlbbU7x4yf2ga+CTcIec5RYHw==", "it42-2019", "Dejanovic", "3ThdmDa7Jnit", "ADMIN" },
				{ new Guid("a0f34818-02ca-45fd-ad61-7978aebadd20"), "peric.it30.2019@uns.ac.rs", "Aleksandar", "F9HVOcz1gFGN0M53W0FpsGoEvzw2CQ5F4hs/JkN7ItaLS6wfst7xzBNYN4IzJH5Ef87E96IKqyEf+RsLmnxFPhtZ3Iol3vFm+Long1NVCZltqEbDUlv47vgO2hlC45G55VKoeLELbGF2g0H+V44vPI3ZhURqbuUepNnc7fBa1FprYqHP3jrgOOabXaCt8iBnJN66J9QRXA2v5a9JkBgqeqbAMukrw+loTOw/8KXsVIlgCojN23/JoLCVgIkmSjIcpOObOer8unfhknRTvb5as63+dNezcYMhVj412B4+wB8NJA6O9kfDCgBl5n2IzpawMqGp0VxWeOnET0CbgjaEAQ==", "it30-2019", "Peric", "B2W9jMQOmhkj", "ADMIN" },
				{ new Guid("ddcf1629-633e-46a9-a37f-40ace3f4a04a"), "mucibabic.it23.2019@uns.ac.rs", "Vasilije", "ZyhwjnZAIzQJnH4EndcPAOJ0/6FS6SeI0YVzR5szdabRjhzyBO7QGajjyHXm2CnBzOvmNcpGr1xX/lTCI5gXp48IRSfVB9XCWm32VzPYysZ4nyJ3hNWIJFUX4wRcSSYlUxe0APr9leWaemrj7CkKqJeXsZZmj6a5B6OgWTfbUpac31QsJKOGmBJmqY3Y2eySfYc7xRg9j9Vja8G9RRtX9YUrDPj6mlyAJAcFbe46G4YWXb/xu0kj0y9Tmo7TZU+Y2nUtT0zwUkquc/uIx6IsJj0Am4HHh8J6uC71runymrT3OjWBxAeUdUYPjHlLyaL5xEiY3UuDJlmTrBOaVqZn6Q==", "it23-2019", "Mucibabic", "+BP4FGb6dk3f", "ADMIN" }
			 });
	   }

	   /// <inheritdoc />
	   protected override void Down(MigrationBuilder migrationBuilder)
	   {
		  migrationBuilder.DropTable(
			 name: "Korisnici");
	   }
    }
}
