namespace Cadastro.Domain.Alunos.Interfaces
{
    public interface IAlunoService
    {
        Aluno Adicionar(Aluno aluno);
        Aluno Atualizar(Aluno aluno);
    }
}