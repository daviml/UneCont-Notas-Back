using UneCont_Notas_Fiscais.Models;

public class NotasFiscaisService
{
    private static readonly List<NotasFiscais> _notas = new List<NotasFiscais>();

    // Contador estático para gerar IDs
    private static int _nextId = 1;

    public NotasFiscais Add(NotasFiscais novaNota)
    {
        // Adicione um ID à nota antes de inseri-la
        novaNota.Id = _nextId++;
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