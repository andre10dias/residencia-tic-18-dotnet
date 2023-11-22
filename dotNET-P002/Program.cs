#region métodos utilitários
List<(string titulo, string descricao, DateTime dataVencimento, bool concluida)> listaTarefas = new();

void exibeTotalTarefas(string situacaoTarefa, 
    List<(string titulo, string descricao, DateTime dataVencimento, bool concluida)> listaTarefas) {

    Console.Write($"Total de tarefas {situacaoTarefa}: ");
    if (listaTarefas.Count > 0)
    {
        Console.WriteLine(listaTarefas.Count);
    }
    else
    {
        Console.WriteLine($"Não existem tarefas {situacaoTarefa}.");
    }
}

void criarTarefa(string titulo, string descricao, DateTime dataVencimento)
{
    listaTarefas.Add((titulo, descricao, dataVencimento, false));
}

void excluirTarefa(int indice)
{
    if (indice >= 0 && indice < listaTarefas.Count)
    {
        listaTarefas.RemoveAt(indice);
    }
}

void marcarTarefaConcluida(int indice)
{
    if (indice >= 0 && indice < listaTarefas.Count)
    {
        listaTarefas[indice] = (listaTarefas[indice].Item1, listaTarefas[indice].Item2, listaTarefas[indice].Item3, true);
    }
}

void listarTarefasCriadas()
{
    exibeTotalTarefas("criadas", listaTarefas);
    foreach (var tarefa in listaTarefas)
    {
        Console.WriteLine(
            $"\nTítulo: {tarefa.Item1}\n" +
            $"Descricão: {tarefa.Item2}\n" +
            $"Data de Vencimento: {tarefa.Item3}"
        );
    }
}

void listarTarefasPendentes() {
    List<(string titulo, string descricao, DateTime dataVencimento, bool concluida)> listaTarefasPendentes = new();
    foreach (var tarefa in listaTarefas)
    {
        if (!tarefa.concluida) {
            listaTarefasPendentes.Add(tarefa);
        }
    }

    exibeTotalTarefas("pendentes", listaTarefasPendentes);

    foreach (var tarefa in listaTarefasPendentes)
    {
        Console.WriteLine(
            $"\nTítulo: {tarefa.Item1}\n" +
            $"Descricão: {tarefa.Item2}\n" +
            $"Data de Vencimento: {tarefa.Item3}"
        );
    }
}

void listarTarefasConcluidas() {
    List<(string titulo, string descricao, DateTime dataVencimento, bool concluida)> listaTarefasConcluidas = new();
    foreach (var tarefa in listaTarefas)
    {
        if (tarefa.concluida) {
            listaTarefasConcluidas.Add(tarefa);
        }
    }

    exibeTotalTarefas("concluídas", listaTarefasConcluidas);

    foreach (var tarefa in listaTarefasConcluidas)
    {
        Console.WriteLine(
            $"\nTítulo: {tarefa.Item1}\n" +
            $"Descricão: {tarefa.Item2}\n" +
            $"Data de Vencimento: {tarefa.Item3}"
        );
    }
}
#endregion

#region métodos principais
void novaTarefa() {
    System.Console.Write("\nTítulo: ");
    string titulo = Console.ReadLine();

    System.Console.Write("\nDescricão: ");
    string descricao = Console.ReadLine();

    System.Console.Write("\nData de Vencimento (dd/mm/aaaa): ");
    DateTime dataVencimento = DateTime.Parse(Console.ReadLine());

    criarTarefa(titulo, descricao, dataVencimento);
    System.Console.WriteLine("\nTarefa criada com sucesso!\n");
}

void deletaTarefa() {
    System.Console.Write("\nSelecione a tarefa a ser excluída: ");
    int indice = int.Parse(Console.ReadLine());
    excluirTarefa(indice);
    System.Console.WriteLine("\nTarefa excluída com sucesso!\n");
}

void concluiTarefa() {
    System.Console.Write("\nSelecione a tarefa a ser concluída: ");
    int indice = int.Parse(Console.ReadLine());
    marcarTarefaConcluida(indice);
    System.Console.WriteLine("\nTarefa concluída com sucesso!\n");
}

void menu() {
    System.Console.WriteLine("\nSelecione uma opção:");
    System.Console.WriteLine(
        "\n[ 1 ] Criar tarefa\n" +
        "[ 2 ] Excluir tarefa\n" +
        "[ 3 ] Marcar tarefa como Concluída\n" +
        "[ 4 ] Listar todas as tarefas\n" +
        "[ 5 ] Listar tarefas pendentes\n" +
        "[ 6 ] Listar tarefas concluídas\n" +
        "[ 7 ] Sair do Programa\n"
    );

    System.Console.Write("Opção: ");
    int opcao = int.Parse(Console.ReadLine());

    switch (opcao) {
        case 1:
            System.Console.WriteLine("\nCriar Tarefa");
            novaTarefa();   
            menu();
            break;
        
        case 2:
            System.Console.WriteLine("\nExcluir Tarefa");
            System.Console.WriteLine("\nTarefas criadas:");
            listarTarefasCriadas();
            deletaTarefa();
            menu();
            break;

        case 3:
            System.Console.WriteLine("\nMarcar Tarefa como Concluída");
            System.Console.WriteLine("\nTarefas pendentes:");
            listarTarefasPendentes();
            concluiTarefa();
            menu();
            break;

        case 4:
            System.Console.WriteLine("\nLista de tarefas criadas:");
            listarTarefasCriadas();
            menu();
            break;

        case 5:
            System.Console.WriteLine("\nLista de tarefas pendentes:");
            listarTarefasPendentes();
            menu();
            break;

        case 6:
            System.Console.WriteLine("\nLista de tarefas concluídas:");
            listarTarefasConcluidas();
            menu();
            break;

        case 7:
            System.Environment.Exit(0);
            break;
        
        default:
            System.Console.WriteLine("Opção inválida.");
            menu();
            break;
    }
}
#endregion

#region main
System.Console.WriteLine("Sistema de Gerenciamento de Tarefas");
menu();
#endregion
