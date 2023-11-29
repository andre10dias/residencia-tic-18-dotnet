using dotNET_P003;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

string opcao = "";

do
{    
    Console.WriteLine("\n==================== Sistema de Gerenciamento de Estoque ====================\n");

    Console.WriteLine(
        "[ 1 ] Cadastrar novo produto"
        + "\n[ 2 ] Buscar produto por código"
        + "\n[ 3 ] Consultar estoque"
        + "\n[ 4 ] Sair"    
    );

    Console.Write("\nSelecione uma opção: ");
    opcao = Console.ReadLine()!;

    switch (opcao)
    {
        case "1":
            App.cadastrarNovoProduto();
            break;
        case "2":
            App.buscarProdutoPorCodigo();
            break;
        case "3":
            App.consultarEstoque();
            break;
        case "4":
            System.Environment.Exit(0);
            break;
        default:
            Console.WriteLine("\nOpcão inválida.\n");
            break;
    }
} while (opcao != "4");