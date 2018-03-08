namespace WebAppCadeMeuJogo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecaorelacionamentoEmprestimo_Jogo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.emprestimos_jogos", newName: "emprestimo_jogo");
            AddColumn("dbo.emprestimo_jogo", "ativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.emprestimo_jogo", "ativo");
            RenameTable(name: "dbo.emprestimo_jogo", newName: "emprestimos_jogos");
        }
    }
}
