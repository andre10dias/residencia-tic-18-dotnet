namespace dotNET_P003;

public static class Menu
{
    public static void MenuPrincipal()
    {
        string opcao = "";

        do
        {    
            Console.WriteLine("\n==================== Sistema de Gerenciamento de Estoque ====================\n");

            Console.WriteLine(
                "[ 1 ] Cadastrar novo produto"
                + "\n[ 2 ] Buscar produto por código"
                + "\n[ 3 ] Registrar entrada de produtos"
                + "\n[ 4 ] Registrar saída de produtos"
                + "\n[ 5 ] Consultar estoque"
                + "\n[ 6 ] Relatórios"
                + "\n[ 7 ] Sair"    
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
                    App.registrarEntradaSaidaProdutos(true);
                    break;
                case "4":
                    App.registrarEntradaSaidaProdutos();
                    break;
                case "5":
                    App.consultarEstoque();
                    break;
                case "6":
                    System.Console.WriteLine("\nAinda não implementado.\n");
                    break;
                case "7":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nOpcão inválida.\n");
                    break;
            }
        } while (opcao != "4");
    }
}