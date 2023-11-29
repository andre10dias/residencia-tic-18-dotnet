﻿using dotNET_AV_T1;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

List<Medico> listaMedicos = new List<Medico>();
List<Paciente> listaPacientes = new List<Paciente>();

Medico medico1 = new Medico("Jose", DateTime.Parse("01/01/2000"), "12345678910", "12345678910");
Medico medico2 = new Medico("Pedro", DateTime.Parse("01/05/2000"), "12345678345", "12345678456");

Paciente paciente1 = new Paciente("Antonio", DateTime.Parse("23/01/2011"), "87635678910", "Masculino", "Dor de cabeca");
Paciente paciente2 = new Paciente("Maria", DateTime.Parse("10/05/2013"), "1890678345", "Feminino", "Dor de cotovelo");

void criarListaMedicos(Medico medico) 
{   
    bool cpfCadastrado = listaMedicos.Find(m => m.Cpf == medico.Cpf) == null && listaPacientes.Find(m => m.Cpf == medico.Cpf) == null;
    bool crmCadastrado = listaMedicos.Find(m => m.Crm == medico.Crm) == null;
    
    if (listaMedicos.Count == 0 || (!cpfCadastrado && !crmCadastrado))
    {
        listaMedicos.Add(medico);
    }

    if (cpfCadastrado)
    {
        throw new Exception("CPF já cadastrado.");
    }
    
    if (crmCadastrado)
    {
        throw new Exception("CRM já cadastrado.");
    }
}

void criarListaPacientes(Paciente paciente)
{
    bool cpfCadastrado = listaPacientes.Find(p => p.Cpf == paciente.Cpf) == null && listaMedicos.Find(m => m.Cpf == paciente.Cpf) == null;

    if (listaPacientes.Count == 0 || !cpfCadastrado)
    {
        listaPacientes.Add(paciente);
    }
    else
    {
        throw new Exception("CPF já cadastrado.");
    }
}
