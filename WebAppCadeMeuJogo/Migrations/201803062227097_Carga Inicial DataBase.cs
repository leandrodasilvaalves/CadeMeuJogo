namespace WebAppCadeMeuJogo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CargaInicialDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.amigo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        apelido = c.String(maxLength: 100, unicode: false),
                        nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        dataNascimento = c.String(maxLength: 100, unicode: false),
                        cpf = c.String(maxLength: 100, unicode: false),
                        dataCadastro = c.DateTime(nullable: false),
                        ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.emprestimo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dataInicio = c.DateTime(nullable: false),
                        dataFim = c.DateTime(nullable: false),
                        amigoId = c.Int(nullable: false),
                        dataCadastro = c.DateTime(nullable: false),
                        ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.amigo", t => t.amigoId)
                .Index(t => t.amigoId);
            
            CreateTable(
                "dbo.jogo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        categoriaId = c.Int(nullable: false),
                        dataCadastro = c.DateTime(nullable: false),
                        ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categoria", t => t.categoriaId)
                .Index(t => t.categoriaId);
            
            CreateTable(
                "dbo.categoria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(maxLength: 100, unicode: false),
                        dataCadastro = c.DateTime(nullable: false),
                        ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.emprestimos_jogos",
                c => new
                    {
                        emprestimoId = c.Int(nullable: false),
                        jogoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.emprestimoId, t.jogoId })
                .ForeignKey("dbo.emprestimo", t => t.emprestimoId)
                .ForeignKey("dbo.jogo", t => t.jogoId)
                .Index(t => t.emprestimoId)
                .Index(t => t.jogoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.emprestimos_jogos", "jogoId", "dbo.jogo");
            DropForeignKey("dbo.emprestimos_jogos", "emprestimoId", "dbo.emprestimo");
            DropForeignKey("dbo.jogo", "categoriaId", "dbo.categoria");
            DropForeignKey("dbo.emprestimo", "amigoId", "dbo.amigo");
            DropIndex("dbo.emprestimos_jogos", new[] { "jogoId" });
            DropIndex("dbo.emprestimos_jogos", new[] { "emprestimoId" });
            DropIndex("dbo.jogo", new[] { "categoriaId" });
            DropIndex("dbo.emprestimo", new[] { "amigoId" });
            DropTable("dbo.emprestimos_jogos");
            DropTable("dbo.categoria");
            DropTable("dbo.jogo");
            DropTable("dbo.emprestimo");
            DropTable("dbo.amigo");
        }
    }
}
