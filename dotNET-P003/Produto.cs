namespace dotNET_P003 {
    public class Produto
    {
        public string codigo { get; set; }
        public string nome { get; set; }
        public int quantidade { get; set; }
        public double preco { get; set; }

        public Produto(string codigo, string nome, int quantidade, double preco)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.quantidade = quantidade;
            this.preco = preco;
        }

        public override string ToString()
        {
            return $"Código: {codigo}\nNome: {nome}\nQuantidade: {quantidade}\nPreço: {preco}";
        }
    }
}