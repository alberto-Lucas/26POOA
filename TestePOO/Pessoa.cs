using System;

namespace TestePOO
{
    //Primeira coisa a ser feita é deixar a classe publica
    //alterar de internal para public
    public class Pessoa
    {
        //Definir os atributos da classe
        //são divididos em 4 partes
        //1 - Nivel de acesso
        //2 - Tipo de dado
        //3 - Nome do atributo
        //4 - Operações do atributo(GET/SET)
        //Get = obter o valor do atributo
        //Set = definir o valor do atributo

        public string Nome { get; set; }
        //Pode utilizar o atalho do Visual Studio
        //para criar os atributos
        //digitar prop e apertar tab
        public string CPF { get; set; }
        public DateTime DtNascimento { get; set; }

        //Implementar o construtor da classe
        //Metodo executado no momento da instanciação do objeto
        //Executa de maneira automatica
        //O construtor é criado com o mesmo nome da classe
        //adicionando os parenteses
        //Ex: Pessoa()
        //Toda classe possui um construtor padrao
        //por tanto só iremos codificar o construtor
        //quando precisarmos de alguma ação personalizada
        //Ex: definir valores padrao para os atributos da classe
        //Obrigatorio o construtor precisa ser publico
        //e não possui tipo de dados
        //ou seja a criação dele é simples
        public Pessoa()
        {
            //Iremos definir valores padrao para
            //os atributos da classe
            //ou seja quando a classe instanciada os atributos
            //ja terão valores definidos
            Nome = "Desconhecido";
            CPF = "000.000.000-00";
            //Data e hora atual do sistema
            DtNascimento = DateTime.Now; 
        }

        //Vamos implementar uma função para exibir o boas vindas
        public string BoasVindas()
        {
            return "Bem vindo, " + Nome;
        }

        //Vou implementar uma propriedade para concatenar
        //o nome e o CPF
        //Por ser propriedade eu posso definir o get e o set
        //neste caso ela será somente leitura
        //possuindo apenas o get
        public string NomeCPF
        {
            get
            {
                return CPF + " - " + Nome;
            }
        }

    }//Chave da Classe
}//Chave do namespace(Arquivo)

