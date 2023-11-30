using Microsoft.VisualBasic;

namespace dotNET_P003;
public static class App
{
    #region Mockup de dados para teste

    public static void InicializarMockupEstoque()
    {
        Produto produto1 = new Produto("123", "Feijão", 3, 7.50);
        Estoque.AddProduto(produto1);

        Produto produto2 = new Produto("321", "Arroz", 1, 4.99);
        Estoque.AddProduto(produto2);

        Produto produto3 = new Produto("654", "Ovos", 30, 17.50);
        Estoque.AddProduto(produto3);

        Produto produto4 = new Produto("456", "Frango", 10, 15.00);
        Estoque.AddProduto(produto4);

        Produto produto5 = new Produto("789", "Cuzcuz", 6, 2.55);
        Estoque.AddProduto(produto5);
    }

    #endregion

    #region Métodos menu principal
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

    public static void registrarEntradaSaidaProdutos(bool registrarEntrada = false) 
    {
        string msg = "";
        string opcao = "s";
        int qtdeProdutos = 0;

        string titulo = registrarEntrada ? "Registrar entrada de produtos" : "Registrar saída de produtos";
           
        do
        {
            Console.WriteLine($"\n==================== {titulo} ====================\n");
            Console.WriteLine("\nProdutos no estoque:\n");
            exibirProdutosEstoque();

            qtdeProdutos = Estoque.listaProdutos.Count;

            if (qtdeProdutos > 0)
            { 
                try
                {    
                    Console.Write("\nCódigo: ");
                    string codigo = Console.ReadLine()!;

                    Console.Write("\nQuantidade: ");
                    string quantidade = Console.ReadLine()!;

                    if (codigo != "" && quantidade != "")
                    {    
                        Produto p = Estoque.GetProdutoByCodigo(codigo);
                        if (p != null)
                        {
                            if (quantidade != "0") {
                                if (registrarEntrada) 
                                {
                                    p.quantidade += int.Parse(quantidade);
                                }
                                else
                                {
                                    if (int.Parse(quantidade) < p.quantidade)
                                    {
                                        p.quantidade -= int.Parse(quantidade);
                                    }
                                    else if (int.Parse(quantidade) == p.quantidade)
                                    {
                                        Estoque.listaProdutos.Remove(p);
                                    }
                                    else 
                                    {
                                        msg = "\nQuantidade em estoque insuficiente.\n";
                                        throw new System.Exception();
                                    }
                                }

                                Console.WriteLine("\nEstoque atualizado.\n");
                            }
                        }
                        else
                        {
                            msg = "\nProduto não encontrado.\n";
                            throw new System.Exception();
                        }
                    }
                    else 
                    {
                        msg = "\nPreencha todos os campos.";
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
                    if (qtdeProdutos > 0)
                    {    
                        Console.Write("\nDeseja continuar? (s/n): ");
                        opcao = Console.ReadLine()!;
                    }
                }
            }
        } while (qtdeProdutos > 0 && opcao.ToLower() == "s");

    }

    public static void consultarEstoque() 
    {
        Console.WriteLine("\n==================== Consultar estoque ====================\n");
        Console.WriteLine("\nProdutos no estoque:\n");
        exibirProdutosEstoque();
    }

    private static void exibirProdutosEstoque() {
        string msg = "";

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

    #endregion

    #region Métodos dos relatórios

    public static void exibirRelatorioProdutosEstoque() 
    {
        string msg = "";
        string opcao = "s";

        do
        {    
            Console.WriteLine("\n==================== Relatório de produtos abaixo de um limite ====================\n");
            
            try
            {
                Console.Write("\nLimite de estoque: ");
                string limite = Console.ReadLine()!;

                if (limite != null)
                {    
                    List<Produto> produtos = Estoque.GetQtdeProdutosBelowLimit(int.Parse(limite));

                    if (produtos.Count > 0)
                    {    
                        Console.WriteLine("\nProdutos no estoque abaixo do limite informado:\n");
                        foreach (var p in produtos)
                        {
                            Console.WriteLine(p.ToString()+"\n");
                        }
                    }
                    else
                    {
                        msg = "\nNão existem produtos abaixo do limite informado.\n";
                        throw new System.Exception();
                    }
                }
                else
                {
                    msg = "\nO campo limite é obrigatório.\n";
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
                Console.Write("\nDeseja continuar? (s/n): ");
                opcao = Console.ReadLine()!;
            }
        } while (opcao.ToLower() == "s");
    }

    public static void exibirRelatorioProdutosPorFaixaValores() 
    {
        string msg = "";
        string opcao = "s";

        do
        {    
            Console.WriteLine("\n==================== Relatório de produtos por faixa de valores ====================\n");
            
            try
            {
                Console.Write("\nValor 1: ");
                string valor1 = Console.ReadLine()!;

                Console.Write("\nValor 2: ");
                string valor2 = Console.ReadLine()!;

                if (valor1 != null && valor2 != null)
                {    
                    List<Produto> produtos = Estoque.GetProdutosWherePrecoBetween(double.Parse(valor1), double.Parse(valor2));

                    if (produtos.Count > 0)
                    {    
                        Console.WriteLine($"\nProdutos no estoque com valores entre {valor1} e {valor2}:\n");
                        foreach (var p in produtos)
                        {
                            Console.WriteLine(p.ToString()+"\n");
                        }
                    }
                    else
                    {
                        msg = "\nNão existem produtos dentro da faixa de valores informada.\n";
                        throw new System.Exception();
                    }
                }
                else
                {
                    msg = "\nPreencha todos os campos.\n";
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
                Console.Write("\nDeseja continuar? (s/n): ");
                opcao = Console.ReadLine()!;
            }
        } while (opcao.ToLower() == "s");
    }

    public static void exibirRelatorioValorTotalEstoque() 
    {
        Console.WriteLine("\n==================== Relatório de valor total do estoque ====================\n");

        Console.WriteLine("\nValor total por produto:\n");
        foreach (var p in Estoque.listaProdutos)
        {
            Console.WriteLine(p.codigo + " - " +  p.nome + ":");
            Console.WriteLine("Valor total: " + Estoque.GetTotalPrecoByProduto(p).ToString("C") + "\n");
        }

        Console.WriteLine($"\nO valor total do estoque é de: {Estoque.GetTotalPrecoProdutosInEstoque().ToString("C")}.\n");
    }

    #endregion
}