namespace WebAppCadeMeuJogo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Column_Disponivel_EntityJogo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jogo", "disponivel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.jogo", "disponivel");
        }
    }
}
