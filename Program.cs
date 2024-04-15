using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorEventos
{
    class Program
    {
        static List<Evento> eventos = new List<Evento>();

        static void Main(string[] args)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Sistema de Gerenciamento de Eventos\n");
        Console.WriteLine("1. Cadastrar evento");
        Console.WriteLine("2. Listar eventos");
        Console.WriteLine("3. Listar eventos por período");
        Console.WriteLine("4. Editar informações de um evento");
        Console.WriteLine("5. Pesquisar um contato cadastrado");
        Console.WriteLine("6. Sair\n");
        Console.Write("Escolha uma opção: ");
        int opcao = Convert.ToInt32(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                CadastrarEvento();
                break;
            case 2:
                ListarEventos();
                break;
            case 3:
                ListarEventosPorPeriodo();
                break;
            case 4:
                EditarEvento();
                break;
            case 5:
                PesquisarContato();
                break;
            case 6:
                return;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }

        Console.Write("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
static void CadastrarEvento()
{
    Console.Write("Título do evento: ");
    string? titulo = Console.ReadLine();

    string? dataHoraInicialInput = "";
    while (string.IsNullOrEmpty(dataHoraInicialInput))
    {
        Console.Write("Data e hora inicial (dd/MM/yyyy hh:mm): ");
        dataHoraInicialInput = Console.ReadLine();
    }
    if (!DateTime.TryParse(dataHoraInicialInput, out DateTime dataHoraInicial))
    {
        Console.WriteLine("Data e hora inválidas.");
        return;
    }

    string? dataHoraFinalInput = ""; 
    while (string.IsNullOrEmpty(dataHoraFinalInput))
    {
        Console.Write("Data e hora final (dd/MM/yyyy hh:mm): ");
        dataHoraFinalInput = Console.ReadLine(); 
    }
    if (!DateTime.TryParse(dataHoraFinalInput, out DateTime dataHoraFinal))
    {
        Console.WriteLine("Data e hora inválidas.");
        return;
    }

    Console.Write("Descrição do evento: ");
    string? descricao = Console.ReadLine();

    Console.Write("Quantidade aproximada de pessoas: ");
    int quantidadePessoas = 0;
    if (!int.TryParse(Console.ReadLine(), out quantidadePessoas))
    {
        Console.WriteLine("Quantidade inválida.");
        return;
    }

    Console.Write("Público alvo do evento: ");
    string? publicoAlvo = Console.ReadLine();

    Contato contato = new Contato();
    Console.Write("Nome do contato responsável: ");
    contato.Nome = Console.ReadLine();
    Console.Write("Telefone de contato: ");
    contato.Telefone = Console.ReadLine();

    // Gerar um ID único para o evento
    Guid eventId = Guid.NewGuid();
    string? eventCode = eventId.ToString().Substring(0, 6).ToUpper();

    try
    {
        eventos.Add(new Evento { Id = eventCode, Titulo = titulo, DataHoraInicial = dataHoraInicial, DataHoraFinal = dataHoraFinal, Descricao = descricao, QuantidadePessoas = quantidadePessoas, PublicoAlvo = publicoAlvo, ContatoResponsavel = contato });
        Console.WriteLine("Evento cadastrado com sucesso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ocorreu um erro ao cadastrar o evento: " + ex.Message);
    }
}
        static void ListarEventos()
        {
            Console.Clear();
            Console.WriteLine("Lista de eventos:\n");

            if (eventos.Count == 0)
            {
                Console.WriteLine("Nenhum evento cadastrado.");
                return;
            }

            foreach (Evento evento in eventos)
            {
                Console.WriteLine($"ID: {evento.Id}");
                Console.WriteLine($"Título: {evento.Titulo}");
                Console.WriteLine($"Data e hora inicial: {evento.DataHoraInicial:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Data e hora final: {evento.DataHoraFinal:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Descrição: {evento.Descricao}");
                Console.WriteLine($"Quantidade de pessoas: {evento.QuantidadePessoas}");
                Console.WriteLine($"Público alvo: {evento.PublicoAlvo}");
                Console.WriteLine($"Contato responsável: {evento.ContatoResponsavel?.Nome}");
                Console.WriteLine("---------------------------------");
            }
        }

        static void ListarEventosPorPeriodo()
        {
            Console.Clear();
            Console.WriteLine("1. Pesquisar eventos dentro de um período");
Console.WriteLine("2. Escolher uma data específica");
Console.Write("Escolha uma opção: ");
int opcao = Convert.ToInt32(Console.ReadLine());

switch (opcao)
{
    case 1:
        // Código para pesquisar eventos dentro de um período
        Console.Write("Data e hora inicial do período (dd/MM/yyyy hh:mm): ");
            string? dataHoraInicialInput = Console.ReadLine();
            if (!DateTime.TryParse(dataHoraInicialInput, out DateTime dataHoraInicial))
            {
                Console.WriteLine("Data e hora inválidas.");
                return;
            }

            Console.Write("Data e hora final do período (dd/MM/yyyy hh:mm): ");
            string? dataHoraFinalInput = Console.ReadLine();
            if (!DateTime.TryParse(dataHoraFinalInput, out DateTime dataHoraFinal))
            {
                Console.WriteLine("Data e hora inválidas.");
                return;
            }

            var eventosNoPeriodo = eventos.Where(e => e.DataHoraInicial >= dataHoraInicial && e.DataHoraFinal <= dataHoraFinal).ToList();

            Console.Clear();
            Console.WriteLine("Lista de eventos no período:\n");

            if (eventosNoPeriodo.Count == 0)
            {
                Console.WriteLine("Nenhum evento encontrado no período informado.");
                return;
            }

            foreach (Evento evento in eventosNoPeriodo)
            {
                Console.WriteLine($"ID: {evento.Id}");
                Console.WriteLine($"Título: {evento.Titulo}");
                Console.WriteLine($"Data e hora inicial: {evento.DataHoraInicial:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Data e hora final: {evento.DataHoraFinal:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Descrição: {evento.Descricao}");
                Console.WriteLine($"Quantidade de pessoas: {evento.QuantidadePessoas}");
                Console.WriteLine($"Público alvo: {evento.PublicoAlvo}");
                Console.WriteLine($"Contato responsável: {evento.ContatoResponsavel?.Nome}");
                Console.WriteLine("---------------------------------");
            }
        break;
    case 2:
        // Código para escolher uma data específica
        Console.Write("Data e hora específica (dd/MM/yyyy hh:mm): ");
        string? dataHoraInput = Console.ReadLine();
        if (!DateTime.TryParse(dataHoraInput, out DateTime dataHora))
        {
            Console.WriteLine("Data e hora inválidas.");
            return;
        }

        var eventosNoDia = eventos.Where(e => e.DataHoraInicial.Date == dataHora.Date).ToList();

        Console.Clear();
        Console.WriteLine("Lista de eventos no dia:\n");

        if (eventosNoDia.Count == 0)
        {
            Console.WriteLine("Nenhum evento encontrado no dia informado.");
            return;
        }

        foreach (Evento evento in eventosNoDia)
        {
            Console.WriteLine($"ID: {evento.Id}");
            Console.WriteLine($"Título: {evento.Titulo}");
            Console.WriteLine($"Data e hora inicial: {evento.DataHoraInicial:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Data e hora final: {evento.DataHoraFinal:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Descrição: {evento.Descricao}");
            Console.WriteLine($"Quantidade de pessoas: {evento.QuantidadePessoas}");
            Console.WriteLine($"Público alvo: {evento.PublicoAlvo}");
            Console.WriteLine($"Contato responsável: {evento.ContatoResponsavel?.Nome}");
            Console.WriteLine("---------------------------------");
        }
        break;
    default:
        Console.WriteLine("Opção inválida!");
        break;
}
    
    }
    static void EditarEvento()
{
    Console.Write("Digite o ID do evento para editar: ");
    string? id = Console.ReadLine();

    Evento? evento = eventos.FirstOrDefault(e => e.Id == id);

    if (evento == null)
    {
        Console.WriteLine("Evento não encontrado.");
        return;
    }

    while (true)
    {
        Console.Clear();
        Console.WriteLine("Editar evento\n");
        Console.WriteLine($"ID: {evento.Id}");
        Console.WriteLine($"Título: {evento.Titulo}");
        Console.WriteLine($"Data e hora inicial: {evento.DataHoraInicial:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Data e hora final: {evento.DataHoraFinal:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Descrição: {evento.Descricao}");
        Console.WriteLine($"Quantidade de pessoas: {evento.QuantidadePessoas}");
        Console.WriteLine($"Público alvo: {evento.PublicoAlvo}");
        Console.WriteLine($"Contato responsável: {evento.ContatoResponsavel?.Nome}");
        Console.WriteLine("\n1. Editar informações");
        Console.WriteLine("2. Excluir evento");
        Console.WriteLine("3. Voltar ao menu principal");
        Console.WriteLine("4. Exportar evento para arquivo txt");
        Console.Write("Escolha uma opção: ");
        int opcao = Convert.ToInt32(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                EditarInformacoesEvento(evento);
                break;
            case 2:
                ExcluirEvento(evento);
                break;
            case 3:
                return;
            case 4:
                ExportarEvento(evento, "evento.txt");
                Console.WriteLine("Evento exportado com sucesso para o arquivo evento.txt");
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }

        Console.Write("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

static void EditarInformacoesEvento(Evento evento)
{
    Console.Write("Novo título do evento: ");
    evento.Titulo = Console.ReadLine();

    string? dataHoraInicialInput = "";
    while (string.IsNullOrEmpty(dataHoraInicialInput))
    {
        Console.Write("Nova data e hora inicial (dd/MM/yyyy hh:mm): ");
        dataHoraInicialInput = Console.ReadLine();
    }
    if (!DateTime.TryParse(dataHoraInicialInput, out DateTime dataHoraInicial))
    {
        Console.WriteLine("Data e hora inválidas.");
        return;
    }
    evento.DataHoraInicial = dataHoraInicial;

    string? dataHoraFinalInput = "";
    while (string.IsNullOrEmpty(dataHoraFinalInput))
    {
        Console.Write("Nova data e hora final (dd/MM/yyyy hh:mm): ");
        dataHoraFinalInput = Console.ReadLine();
    }
    if (!DateTime.TryParse(dataHoraFinalInput, out DateTime dataHoraFinal))
    {
        Console.WriteLine("Data e hora inválidas.");
        return;
    }
    evento.DataHoraFinal = dataHoraFinal;

    Console.Write("Nova descrição do evento: ");
    evento.Descricao = Console.ReadLine();

    Console.Write("Nova quantidade aproximada de pessoas: ");
    int quantidadePessoas = 0;
    if (!int.TryParse(Console.ReadLine(), out quantidadePessoas))
    {
        Console.WriteLine("Quantidade inválida.");
        return;
    }
    evento.QuantidadePessoas = quantidadePessoas;

    Console.Write("Novo público alvo do evento: ");
    evento.PublicoAlvo = Console.ReadLine();

    Console.Write("Novo nome do contato responsável: ");
    evento.ContatoResponsavel.Nome = Console.ReadLine();

    Console.Write("Novo telefone de contato: ");
    evento.ContatoResponsavel.Telefone = Console.ReadLine();

    Console.WriteLine("Evento atualizado com sucesso!");
}

static void ExcluirEvento(Evento evento)
{
    Console.Clear();
    Console.WriteLine($"Deseja realmente excluir o evento {evento.Titulo} (ID: {evento.Id})? (S/N)");
    string? resposta = Console.ReadLine().ToLower();

    if (resposta == "s")
    {
        eventos.Remove(evento);
        Console.WriteLine("Evento excluído com sucesso!");
    }
    else
    {
        Console.WriteLine("Operação cancelada.");
    }
}
static void PesquisarContato()
{
    Console.Write("Digite o nome do contato para pesquisar: ");
    string? nome = Console.ReadLine();

    var contatosEncontrados = eventos.Where(e => e.ContatoResponsavel?.Nome == nome).ToList();

    Console.Clear();
    Console.WriteLine("Lista de eventos com o contato pesquisado:\n");

    if (contatosEncontrados.Count == 0)
    {
        Console.WriteLine("Nenhum evento encontrado com o contato pesquisado.");
        return;
    }

    foreach (Evento evento in contatosEncontrados)
    {
        Console.WriteLine($"ID: {evento.Id}");
        Console.WriteLine($"Título: {evento.Titulo}");
        Console.WriteLine($"Data e hora inicial: {evento.DataHoraInicial:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Data e hora final: {evento.DataHoraFinal:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Descrição: {evento.Descricao}");
        Console.WriteLine($"Quantidade de pessoas: {evento.QuantidadePessoas}");
        Console.WriteLine($"Público alvo: {evento.PublicoAlvo}");
        Console.WriteLine($"Contato responsável: {evento.ContatoResponsavel?.Nome}");
        Console.WriteLine("---------------------------------");
    }
}
static void ExportarEvento(Evento evento, string caminhoArquivo)
{
    using (StreamWriter escritor = new StreamWriter(caminhoArquivo))
    {
        escritor.WriteLine("ID: " + evento.Id);
        escritor.WriteLine("Título: " + evento.Titulo);
        escritor.WriteLine("Data e Hora Inicial: " + evento.DataHoraInicial.ToString("dd/MM/yyyy HH:mm"));
        escritor.WriteLine("Data e Hora Final: " + evento.DataHoraFinal.ToString("dd/MM/yyyy HH:mm"));
        escritor.WriteLine("Descrição: " + evento.Descricao);
        escritor.WriteLine("Quantidade de Pessoas: " + evento.QuantidadePessoas);
        escritor.WriteLine("Público Alvo: " + evento.PublicoAlvo);
        escritor.WriteLine("Contato Responsável: " + evento.ContatoResponsavel.Nome + " - " + evento.ContatoResponsavel.Telefone);
    }
}
}
    }

 
