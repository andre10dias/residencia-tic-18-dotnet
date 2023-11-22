#region métodos utilitários
List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaTarefas = new();

void exibeTotalTarefas(string situacaoTarefa, 
    List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaTarefas) {

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

void imprimeTarefas(
    List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaTarefas)
{
    foreach (var tarefa in listaTarefas)
    {
        Console.WriteLine(
            $"\nTítulo: {tarefa.Item1}\n" +
            $"Descricão: {tarefa.Item2}\n" +
            $"Data de Criação: {tarefa.Item4}\n" +
            $"Data de Vencimento: {tarefa.Item3}"
        );
    }
}

void imprimeTarefasSelecao(
    List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaTarefas)
{
    for (int i = 0; i < listaTarefas.Count; i++)
    {
        System.Console.WriteLine($"[ {i+1} ] {listaTarefas[i].Item1}");
    }
}

void criarTarefa(string titulo, string descricao, DateTime dataVencimento)
{
    listaTarefas.Add((titulo, descricao, dataVencimento, DateTime.Now, false));
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
        listaTarefas[indice] = (listaTarefas[indice].Item1, listaTarefas[indice].Item2, 
            listaTarefas[indice].Item3, listaTarefas[indice].Item4, true);
    }
}

List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> retornaListaTarefasConcluidas() {
    List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaTarefasConcluidas = new();
    foreach (var tarefa in listaTarefas)
    {
        if (tarefa.concluida) {
            listaTarefasConcluidas.Add(tarefa);
        }
    }

    return listaTarefasConcluidas;
}

List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> retornaListaTarefasPendentes() {
    List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaTarefasPendentes = new();
    foreach (var tarefa in listaTarefas)
    {
        if (!tarefa.concluida) {
            listaTarefasPendentes.Add(tarefa);
        }
    }

    return listaTarefasPendentes;
}

void listarTarefasCriadas()
{
    exibeTotalTarefas("criadas", listaTarefas);
    imprimeTarefas(listaTarefas);
}

void listarTarefasPendentes() {
    List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaTarefasPendentes = new();
    listaTarefasPendentes = retornaListaTarefasPendentes();
    exibeTotalTarefas("pendentes", listaTarefasPendentes);
    imprimeTarefas(listaTarefasPendentes);
}

void listarTarefasPendentesSelecao() {
    List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaTarefasPendentes = new();
    listaTarefasPendentes = retornaListaTarefasPendentes();
    imprimeTarefasSelecao(listaTarefasPendentes);
}

void listarTarefasConcluidas() {
    List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaTarefasConcluidas = new();
    listaTarefasConcluidas = retornaListaTarefasConcluidas();
    exibeTotalTarefas("concluídas", listaTarefasConcluidas);
    imprimeTarefas(listaTarefasConcluidas);
}

List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> localizarTarefa(string palavraChave) {
    List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaTarefasLocalizadas = new();
    foreach (var tarefa in listaTarefas)
    {
        if (tarefa.titulo.Contains(palavraChave) || tarefa.descricao.Contains(palavraChave))
        {
            listaTarefasLocalizadas.Add(tarefa);
        }
    }
    
    return listaTarefasLocalizadas;
}

int retornaNumerotarefasConcluidas() {
    int totalTarefasConcluidas = 0;

    foreach (var tarefa in listaTarefas)
    {
        if (true == tarefa.concluida)
        {
            totalTarefasConcluidas++;
        }
    }

    return totalTarefasConcluidas;
}

int retornaNumeroTarefasPendentes() {
    int totalTarefasPendentes = 0;

    foreach (var tarefa in listaTarefas)
    {
        if (false == tarefa.concluida)
        {
            totalTarefasPendentes++;
        }
    }

    return totalTarefasPendentes;
}

(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida) retornaTarefaMaisAntiga() {
    var tarefaMaisAntiga = listaTarefas[0];

    foreach (var tarefa in listaTarefas)
    {
        if (tarefa.dataCriacao < tarefaMaisAntiga.dataCriacao)
        {
            tarefaMaisAntiga = tarefa;
        }
    }

    return tarefaMaisAntiga;
}

(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida) retornaTarefaMaisRecente() {
    var tarefaMaisRecente = listaTarefas[0];

    foreach (var tarefa in listaTarefas)
    {
        if (tarefa.dataCriacao > tarefaMaisRecente.dataCriacao)
        {
            tarefaMaisRecente = tarefa;
        }
    }

    return tarefaMaisRecente;
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
    excluirTarefa(indice-1);
    System.Console.WriteLine("\nTarefa excluída com sucesso!\n");
}

void concluiTarefa() {
    System.Console.Write("\nSelecione a tarefa a ser concluída: ");
    int indice = int.Parse(Console.ReadLine());
    marcarTarefaConcluida(indice-1);
    System.Console.WriteLine("\nTarefa concluída com sucesso!\n");
}

void dashboard() {
    System.Console.WriteLine("\nDashboard");
    List<(string titulo, string descricao, DateTime dataVencimento, DateTime dataCriacao, bool concluida)> listaAuxiliar = new();

    System.Console.WriteLine("\nNúmero de tarefas pendentes: " + retornaNumeroTarefasPendentes());
    System.Console.WriteLine("\nNúmero de tarefas concluídas: " + retornaNumerotarefasConcluidas());

    System.Console.WriteLine("\nTarefa mais antiga:");
    listaAuxiliar.Add(retornaTarefaMaisAntiga());
    imprimeTarefas(listaAuxiliar);

    System.Console.WriteLine("\nTarefa mais recente:");
    listaAuxiliar = new();
    listaAuxiliar.Add(retornaTarefaMaisRecente());
    imprimeTarefas(listaAuxiliar);
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
        "[ 7 ] Dashboard\n" +
        "[ 8 ] Sair do Programa\n"
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
            imprimeTarefasSelecao(listaTarefas);
            deletaTarefa();
            menu();
            break;

        case 3:
            System.Console.WriteLine("\nMarcar Tarefa como Concluída");
            System.Console.WriteLine("\nTarefas pendentes:");
            listarTarefasPendentesSelecao();
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
            dashboard();
            menu();
            break;
        
        case 8:
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
