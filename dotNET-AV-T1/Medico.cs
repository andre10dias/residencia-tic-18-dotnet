namespace dotNET_AV_T1 {
    public class Medico {
        public string Nome { get; set; }
        
        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string Crm { get; set; }

        public Medico(string nome, DateTime dataNascimento, string cpf, string crm) 
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Cpf = cpf;
            this.Crm = crm;
        }
    }

}