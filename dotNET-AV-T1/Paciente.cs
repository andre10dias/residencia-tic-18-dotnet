using System.Text.RegularExpressions;

namespace dotNET_AV_T1 {
    public class Paciente {
        public string Nome 
        { 
            get {return Nome;}
            set
            {
                if (string.IsNullOrEmpty(value.Trim())) 
                {
                    throw new ArgumentNullException("O campo Nome é obrigatório.");
                }
            }
        }

        public DateTime? DataNascimento 
        { 
            get {return DataNascimento;}
            set
            {
                if (value == null) 
                {
                    throw new ArgumentNullException("O campo Data de Nascimento é obrigatório.");
                }

                Regex r = new Regex(@"(\d{2}\/\d{2}\/\d{4})");
                string valueAsString = value.ToString()!;
                if (r.Match(valueAsString).Success)
                {
                    throw new ArgumentException("O campo Data de Nascimento precisa ter o formato dd/mm/aaaa.");
                }
            }
        }

        public string Cpf 
        { 
            get {return Cpf;}
            set
            {
                if (string.IsNullOrEmpty(value.Trim())) 
                {
                    throw new ArgumentNullException("O campo CPF é obrigatório.");
                }

                if (!value.All(char.IsDigit))
                {
                    throw new ArgumentException("O campo CPF precisa ter apenas números.");
                }

                if (value.Length != 11)
                {
                    throw new ArgumentException("O campo CPF precisa ter 11 caracteres.");
                }
            }
        }

        public string Sexo 
        { 
            get { return Sexo;}
            set 
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentNullException("O campo Sexo é obrigatório.");
                }

                if (value.ToLower() != "masculino" && value.ToLower() != "feminino")
                {
                    throw new ArgumentException("O campo Sexo precisa ser 'Masculino' ou 'Feminino'.");
                }
            }
        }

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