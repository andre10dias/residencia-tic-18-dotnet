namespace dotNET_P003;
public static class App
{
    public static void subtraiQtdeProdutos(Produto p, int qtde) {
        p.quantidade -= qtde;
    }

    public static void cadastrarNovoProduto() 
    {
        string opcao = "s";
        string msg = "";
        bool entradaInvalida;

        do
        {   
            entradaInvalida = false; 
            Console.WriteLine("\n==================== Cadastrar novo produto ====================\n");
            
            try
            {
                Console.Write("\nCódigo: ");
                string codigo = Console.ReadLine()!;

                Produto p = Estoque.getProdutoByCodigo(codigo);
                if (p != null)
                {
                    msg = "Código ja cadastrado.";
                    throw new System.Exception(msg);
                }
                
                Console.Write("Nome: ");
                string nome = Console.ReadLine()!;

                Console.Write("Quantidade: ");
                string quantidade = Console.ReadLine()!;

                Console.Write("Preço: ");
                string preco = Console.ReadLine()!;

                Produto produto = new Produto(codigo, nome, int.Parse(quantidade), int.Parse(preco));
                Estoque.AddProduto(produto);
            }
            catch (System.Exception)
            {
                if (msg == "")
                {
                    msg = "Preencha todos os campos.";
                }

                Console.WriteLine(msg);
                entradaInvalida = true;
                continue;
            }
            finally
            {
                if (entradaInvalida)
                {    
                    Console.Write("Deseja continuar? (s/n): ");
                    opcao = Console.ReadLine()!;
                }
            }

        } while (entradaInvalida && opcao.ToLower() == "s");
    }

    public static void buscarProdutoPorCodigo() 
    {
        Console.WriteLine("\n==================== Buscar produto por código ====================\n");

        Console.Write("\nCódigo: ");
        Produto p = Estoque.getProdutoByCodigo(Console.ReadLine()!);

        if (p != null)
        {
            Console.WriteLine("\nProduto Localizado:\n");
            Console.WriteLine(p.ToString());
        }
        else
        {
            Console.WriteLine("\nProduto não encontrado.\n");
        }
    }

    public static void consultarEstoque() 
    {
        Console.WriteLine("\n==================== Consultar estoque ====================\n");
        Console.WriteLine("\nProdutos no estoque:\n");
        Estoque.listaProdutos.ForEach(p => Console.WriteLine(p.ToString()+"\n"));
    }
}