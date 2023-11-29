namespace dotNET_AV_T1 {
    public class Paciente {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf 
        { 
            get {return Cpf;}
            set
            {
                if (string.IsNullOrEmpty(value.Trim())) 
                {
                    throw new ArgumentNullException("O campo CPF é obrigatório.");
                }

                if (!Cpf.All(char.IsDigit))
                {
                    throw new ArgumentException("O campo CPF precisa ter apenas números.");
                }

                if (Cpf.Length != 11)
                {
                    throw new ArgumentException("O campo CPF precisa ter 11 caracteres.");
                }
            }
        }

        public string Sexo { get; set; }

        public string Sintomas { get; set; }

        public Paciente(string nome, DateTime dataNascimento, string cpf, string sexo, string sintomas)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Sexo = sexo;
            Sintomas = sintomas;
        }
    }
}