using ProjetoCRUD.Models;
using ProjetoCRUD.Services;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoCRUD.Controllers
{
    //Classe de controle com as regras de negocios
    //para manipular o cadastro de Usuarios
    //Ou seja é aqui que vamos
    //converter o objeto em comando de banco de dados

    //Importar as camdas Models e Services
    //using NomeProjeto.Models;
    //using NomeProjeto.Services;

    //Importar as bibliotecas do SQLServer
    //using System.Data;
    //using System.Data.SqlClient;
    public class UsuarioController
    {
        //Variavel privada global para armazenar a instancia
        //da camada de serviço
        DataBaseService _database = new DataBaseService();

        //Desenvolver os métodos Adicionar, Atualizar,
        //Excluir e Consultar
    }
}
