namespace WebAppCadeMeuJogo.Models.Entitys
{
    public class EmprestimoJogo
    {
        public int EmprestimoId { get; set; }
        public virtual Emprestimo  Emprestimo { get; set; }

        public int JogoId { get; set; }
        public virtual Jogo Jogo { get; set; }

        public bool Ativo { get; set; }

    }
}