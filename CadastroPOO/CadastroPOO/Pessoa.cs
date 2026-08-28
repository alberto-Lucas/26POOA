using System;

namespace CadastroPOO
{
    public class Pessoa
    {
        //Atributos
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DtNascimento { get; set; }

        //Propriedades
        public string CPFNome
        {
            get
            {
                return CPF + " - " + Nome;
            }
        }

        //Para calcular a idade com base na data de nascimento
        public int Idade
        {
            get
            {
                //Utilizando a data atual
                //vamos realizar o calculo de idade
                //para isso usaremos o metodo
                //Now para recuperar a data e hora
                //atual da maquina
                //e validamores com base no ano, mes e dia
                //a data da pessoa

                DateTime dataAtual = DateTime.Now;

                //Calcular a idade cheia com base no ano
                int idade = dataAtual.Year - DtNascimento.Year;

                //Validar o mes e o dia de nascimento
                //para identificar se ja fez aniversario
                //ou não

                if(dataAtual.Month < DtNascimento.Month ||
                    (dataAtual.Month == DtNascimento.Month &&
                        dataAtual.Day < DtNascimento.Day))
                {
                    //Caso na validação o aniversario
                    //ainda não ocrreu então é preciso
                    //remover um ano da idade
                    idade--; //Idade atual - 1
                }

                return idade;
            }
        }
    }
}
