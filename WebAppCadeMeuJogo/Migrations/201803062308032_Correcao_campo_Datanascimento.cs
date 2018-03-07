namespace WebAppCadeMeuJogo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcao_campo_Datanascimento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.amigo", "dataNascimento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.amigo", "dataNascimento", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
