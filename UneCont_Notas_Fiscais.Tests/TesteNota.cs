using UneCont_Notas_Fiscais.Models;
using Xunit;

public class NotasFiscaisServiceTests
{
    // Testa se a api Adiciona Nova Nota
    [Fact]
    public void AdicionaNovaNota()
    {
        // INSERE
        var service = new NotasFiscaisService();
        var nota = new NotasFiscais { NumeroDaNota = 1, NomeCliente = "João", Valor = 100.00m };

        // EXECUTA
        service.Add(nota);
        var listaDeNotas = service.GetAll();

        // VERIFICA
        Assert.Contains(nota, listaDeNotas);
    }

    // Testa se a Busca por nome retorna os itens filtrados
    [Fact]
    public void Busca()
    {
        // INSERE
        var service = new NotasFiscaisService();
        service.Add(new NotasFiscais { NumeroDaNota = 1, NomeCliente = "João", Valor = 100.00m });
        service.Add(new NotasFiscais { NumeroDaNota = 2, NomeCliente = "Maria", Valor = 200.00m });
        service.Add(new NotasFiscais { NumeroDaNota = 3, NomeCliente = "José", Valor = 300.00m });

        // EXECUTA
        var notasFiltradas = service.GetByNome("Maria");

        // VERIFICA
        Assert.Contains(notasFiltradas, n => n.NomeCliente == "Maria");
    }

    // Testa se a busca retorna uma lista vazia quando nenhum item corresponde
    [Fact]
    public void RetornaVazio()
    {
        // INSERE
        var service = new NotasFiscaisService();
        service.Add(new NotasFiscais { NumeroDaNota = 1, NomeCliente = "João", Valor = 100.00m });

        // EXECUTA
        var notasFiltradas = service.GetByNome("Pedro");

        // VERIFICA
        Assert.Empty(notasFiltradas);
    }

    // Testa se a busca retorna a lista completa quando o nome da busca é nulo ou vazio
    [Fact]
    public void RetornaCompleto()
    {
        // INSERE
        var service = new NotasFiscaisService();
        service.Add(new NotasFiscais { NumeroDaNota = 1, NomeCliente = "João", Valor = 100.00m });
        service.Add(new NotasFiscais { NumeroDaNota = 2, NomeCliente = "Maria", Valor = 200.00m });

        // EXECUTA
        var notasSemFiltro = service.GetByNome(null);
        var notasComFiltroVazio = service.GetByNome("");

        // VERIFICA
        Assert.True(notasSemFiltro.Count() >= 2);
        Assert.True(notasComFiltroVazio.Count() >= 2);
    }
}