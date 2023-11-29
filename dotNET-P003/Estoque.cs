namespace dotNET_P003;
public static class Estoque {
    public static List<Produto> listaProdutos = new List<Produto>();

    public static void AddProduto(Produto p) => listaProdutos.Add(p);
    
    public static void RemoveProduto(Produto p) => listaProdutos.Remove(p);

    public static Produto getProdutoByCodigo(string codigo) => listaProdutos.Find(p => p.codigo == codigo);

    public static List<Produto> getQtdeProdutosBelowLimit(int limite) => listaProdutos.FindAll(p => p.quantidade < limite);

    public static List<Produto> getProdutosWherePrecoBetween(double min, double max) => listaProdutos.FindAll(p => p.preco >= min && p.preco <= max);

    public static double getTotalPrecoByProduto(Produto p)
    {
        double total = 0;
        Produto produto = getProdutoByCodigo(p.codigo);

        if (produto != null)
        {
            total = p.preco * p.quantidade;
        }

        return total;
    }

    public static double getTotalPrecoProdutosInEstoque() => listaProdutos.Sum(p => p.preco * p.quantidade);
}