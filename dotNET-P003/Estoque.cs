namespace dotNET_P003;
public static class Estoque {
    public static List<Produto> listaProdutos = new List<Produto>();

    public static void AddProduto(Produto p) => listaProdutos.Add(p);
    
    public static void RemoveProduto(Produto p) => listaProdutos.Remove(p);

    public static Produto GetProdutoByCodigo(string codigo) => listaProdutos.Find(p => p.codigo == codigo)!;

    public static List<Produto> GetQtdeProdutosBelowLimit(int limite) => listaProdutos.Where(p => p.quantidade < limite).ToList();

    public static List<Produto> GetProdutosWherePrecoBetween(double min, double max) => listaProdutos.Where(p => p.preco >= min && p.preco <= max).ToList();

    public static double GetTotalPrecoByProduto(Produto p)
    {
        double total = 0;
        Produto produto = GetProdutoByCodigo(p.codigo);

        if (produto != null)
        {
            total = p.preco * p.quantidade;
        }

        return total;
    }

    public static double GetTotalPrecoProdutosInEstoque() => listaProdutos.Sum(p => p.preco * p.quantidade);
}