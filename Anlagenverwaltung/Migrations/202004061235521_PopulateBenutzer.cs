namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBenutzer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Benutzers " +
                "(PersonalNr, Nachname, Vorname)" +
                "VALUES (820, 'Wiens', 'Daniel')");

            Sql("INSERT INTO Benutzers " +
                "(PersonalNr, Nachname, Vorname)" +
                "VALUES (22, 'Ropertz', 'Wolfgang')");

            Sql("INSERT INTO Benutzers " +
                "(PersonalNr, Nachname, Vorname)" +
                "VALUES (5, 'Beine', 'Rolf')");

            Sql("INSERT INTO Benutzers " +
                "(PersonalNr, Nachname, Vorname)" +
                "VALUES (3, 'Beine', 'Bernadette')");

            Sql("INSERT INTO Benutzers " +
                "(PersonalNr, Nachname, Vorname)" +
                "VALUES (4, 'Boﬂ', 'Karl-Heinz')");

            Sql("INSERT INTO Benutzers " +
                "(PersonalNr, Nachname, Vorname)" +
                "VALUES (6, 'Boﬂ', 'Gabriela')");

            Sql("INSERT INTO Benutzers " +
                "(PersonalNr, Nachname, Vorname)" +
                "VALUES (30, 'Boﬂ', 'Sebastian')");

            Sql("INSERT INTO Benutzers " +
                "(PersonalNr, Nachname, Vorname)" +
                "VALUES (31, 'Boﬂ', 'Benedikt')");
        }
        
        public override void Down()
        {
        }
    }
}
