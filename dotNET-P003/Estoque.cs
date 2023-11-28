public class Estoque {
    private static List<Produto> listaProdutos
    {
        get
        {
            if (listaProdutos == null)
            {
                return new List<Produto>();
            }

            return listaProdutos;
        }

        set { listaProdutos = value; }
    }

    public static void AddProduto(Produto p) => listaProdutos.Add(p);
    
    public static void RemoveProduto(Produto p) => listaProdutos.Remove(p);

    public static List<Produto> getProdutos() => listaProdutos;

    public static Produto getProdutoByCodigo(string codigo) => listaProdutos.Find(p => p.Codigo == codigo);

    public static List<Produto> getQtdeProdutosBelowLimit(int limite) => listaProdutos.FindAll(p => p.Quantidade < limite);

    public static List<Produto> getProdutosWherePrecoBetween(double min, double max) => listaProdutos.FindAll(p => p.Preco >= min && p.Preco <= max);

    public static double getTotalPrecoByProduto(Produto p)
    {
        double total = 0;
        Produto produto = getProdutoByCodigo(p.Codigo);

        if (produto != null)
        {
            total = p.Preco * p.Quantidade;
        }

        return total;
    }

    public static double getTotalPrecoProdutosInEstoque() => listaProdutos.Sum(p => p.Preco * p.Quantidade);
}