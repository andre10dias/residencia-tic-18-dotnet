using Microsoft.VisualBasic;

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

                if (codigo != "")
                {    
                    Produto p = Estoque.GetProdutoByCodigo(codigo);
                    if (p != null)
                    {
                        msg = "Código ja cadastrado.";
                        throw new System.Exception();
                    }
                }
                
                Console.Write("Nome: ");
                string nome = Console.ReadLine()!;

                Console.Write("Quantidade: ");
                string quantidade = Console.ReadLine()!;

                Console.Write("Preço: ");
                string preco = Console.ReadLine()!;

                if (codigo == "" || nome == "" || quantidade == "" || preco == "")
                {
                    msg = "Preencha todos os campos.";
                    throw new System.Exception();
                }

                Produto produto = new Produto(codigo, nome, int.Parse(quantidade), int.Parse(preco));
                Estoque.AddProduto(produto);
            }
            catch (System.Exception)
            {
                Console.WriteLine(msg);
                entradaInvalida = true;
                continue;
            }
            finally
            {
                if (entradaInvalida)
                {    
                    Console.Write("\nDeseja continuar? (s/n): ");
                    opcao = Console.ReadLine()!;
                }
            }
        } while (entradaInvalida && opcao.ToLower() == "s");
    }

    public static void buscarProdutoPorCodigo() 
    {
        string msg = "";
        string opcao = "s";
        bool naoEncontrado;

        do
        {
            naoEncontrado = false;
            Console.WriteLine("\n==================== Buscar produto por código ====================\n");

            try
            {
                if (Estoque.listaProdutos.Count > 0)
                {    
                    Console.Write("\nCódigo: ");
                    string codigo = Console.ReadLine()!;

                    Produto p = Estoque.GetProdutoByCodigo(codigo);
                    
                    if (p != null)
                    {
                        Console.WriteLine("\nProduto Localizado:\n");
                        Console.WriteLine(p.ToString());
                    }
                    else
                    {
                        msg = "\nProduto não encontrado.\n";
                        naoEncontrado = true;
                        throw new System.Exception();
                    }
                }
                else
                {
                    msg = "\nNão existem produtos cadastrados.\n";
                    throw new System.Exception();
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine(msg);
                continue;
            }
            finally
            {
                if (naoEncontrado)
                {    
                    Console.Write("\nDeseja continuar? (s/n): ");
                    opcao = Console.ReadLine()!;
                }
            }
        } while (naoEncontrado && opcao.ToLower() == "s");
    }

    public static void consultarEstoque() 
    {
        string msg = "";

        Console.WriteLine("\n==================== Consultar estoque ====================\n");
        Console.WriteLine("\nProdutos no estoque:\n");
        try
        {
            if (Estoque.listaProdutos.Count > 0)
            {
                Estoque.listaProdutos.ForEach(p => Console.WriteLine(p.ToString()+"\n"));
            }
            else
            {
                msg = "\nNão existem produtos cadastrados.\n";
                throw new System.Exception();
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine(msg);
        }
    }
}