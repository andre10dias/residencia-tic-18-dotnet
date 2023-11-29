namespace dotNET_AV_T1 {
    public class Paciente {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string Sexo { get; set; }

        public string Sintomas { get; set; }

        public Paciente(string nome, DateTime dataNascimento, string cpf, string sintomas)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Sintomas = sintomas;
        }
    }
}