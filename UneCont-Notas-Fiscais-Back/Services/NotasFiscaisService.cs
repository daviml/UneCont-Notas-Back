using UneCont_Notas_Fiscais.Models;

public class NotasFiscaisService
{
    private static readonly List<NotasFiscais> _notas = new List<NotasFiscais>();

    // Contador estático para gerar IDs
    private static int _nextId = 1;

    // Construtor: Adiciona dados iniciais à lista
    public NotasFiscaisService()
    {
        // Adiciona 3 notas fiscais de exemplo
        _notas.Add(new NotasFiscais
        {
            Id = _nextId++,
            NumeroDaNota = 101,
            NomeCliente = "Tech Solutions Ltda.",
            Valor = 550.75m,
            DataEmissao = new DateOnly(2025, 9, 15),
            DataHoraCadastro = DateTime.Now.AddMinutes(-2000) // Exemplo de data de cadastro
        });

        _notas.Add(new NotasFiscais
        {
            Id = _nextId++,
            NumeroDaNota = 102,
            NomeCliente = "Inovatech S.A.",
            Valor = 200.00m,
            DataEmissao = new DateOnly(2025, 9, 14),
            DataHoraCadastro = DateTime.Now.AddMinutes(-1500)
        });

        _notas.Add(new NotasFiscais
        {
            Id = _nextId++,
            NumeroDaNota = 103,
            NomeCliente = "Unecont Tecnologia e Gestao Integrada LTDA",
            Valor = 1250.50m,
            DataEmissao = new DateOnly(2025, 9, 10),
            DataHoraCadastro = DateTime.Now.AddMinutes(-100)
        });
    }

    public NotasFiscais Add(NotasFiscais novaNota)
    {
        // Adicione um ID à nota antes de inseri-la
        novaNota.Id = _nextId++;
        novaNota.DataHoraCadastro = DateTime.Now;
        _notas.Add(novaNota);
        return novaNota;
    }

    public IEnumerable<NotasFiscais> GetAll()
    {
        return _notas;
    }

    // Método para buscar notas por nome do cliente
    public IEnumerable<NotasFiscais> GetByNome(string nome)
    {
        // Se a busca for vazia, retorna todas as notas
        if (string.IsNullOrEmpty(nome))
        {
            return _notas;
        }

        // Usa LINQ para filtrar a lista
        // Procura por notas cujo NomeCliente contenha o texto da busca (ignorando maiúsculas/minúsculas)
        return _notas.Where(n =>
            n.NomeCliente.IndexOf(nome, StringComparison.OrdinalIgnoreCase) >= 0);
    }

    public NotasFiscais GetById(int id)
    {
        return _notas.FirstOrDefault(n => n.Id == id);
    }

    public bool Delete(int id)
    {
        var nota = _notas.FirstOrDefault(n => n.Id == id);
        if (nota == null)
        {
            return false;
        }
        _notas.Remove(nota);
        return true;
    }
}