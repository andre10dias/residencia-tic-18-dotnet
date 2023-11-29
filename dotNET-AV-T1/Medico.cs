namespace dotNET_AV_T1 {
    public class Medico {
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

        public string Crm 
        { 
            get {return Crm;}
            set
            {
                if (string.IsNullOrEmpty(value.Trim())) 
                {
                    throw new ArgumentNullException("O campo CRM é obrigatório.");
                }
            }
        }

        public Medico(string nome, DateTime dataNascimento, string cpf, string crm) 
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Cpf = cpf;
            this.Crm = crm;
        }
    }

}