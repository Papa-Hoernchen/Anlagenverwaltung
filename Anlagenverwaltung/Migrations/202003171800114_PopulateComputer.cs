namespace Anlagenverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateComputer : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Computers " +
                "(Id, Hersteller, MacAdresse, Einkaufspreis, Einkaufsdatum, ArbeitsspeicherId, MausId, ProzessorId, TastaturId)" +
                "VALUES (1, 'Terra-PC', 'abc-2w2-2ww-bb', 1024.00, '2018-03-03', 2, 1, 4, 1)");

            Sql("INSERT INTO Computers " +
                "(Id, Hersteller, MacAdresse, Einkaufspreis, Einkaufsdatum, ArbeitsspeicherId, MausId, ProzessorId, TastaturId)" +
                "VALUES (2, 'Terra-PC', 'fbc-5w2-8wj-bb', 1002.00, '2018-01-20', 3, 2, 1, 2)");

            Sql("INSERT INTO Computers " +
                "(Id, Hersteller, MacAdresse, Einkaufspreis, Einkaufsdatum, ArbeitsspeicherId, MausId, ProzessorId, TastaturId)" +
                "VALUES (3, 'Terra-PC', 'fxc-1w8-8wj-bb', 1500.00, '2019-01-05', 3, 4, 2, 4)");

            Sql("INSERT INTO Computers " +
                "(Id, Hersteller, MacAdresse, Einkaufspreis, Einkaufsdatum, ArbeitsspeicherId, MausId, ProzessorId, TastaturId)" +
                "VALUES (4, 'ASUS', 'lxv-1p8-8wj-bb', 329.99, '2020-02-03', 1, 4, 2, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
