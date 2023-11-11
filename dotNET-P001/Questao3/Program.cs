/**
* Conversão de tipos de dados
*
* Convertendo um tipo double para um tipo int
* usando o método Convert.
* 
* Como o tipo de dado int aaceita apenas números inteiros,
* a parte fraciorna do número é descartada.
*/

double tipoDouble = 10.3;
int tipoInt = Convert.ToInt32(tipoDouble);

Console.WriteLine(tipoInt);
