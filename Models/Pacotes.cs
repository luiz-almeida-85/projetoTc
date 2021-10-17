using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
namespace projetoTc.Models
{
    public class Pacotes
    {
      
      public int id {get; set;}
      public string assunto {get; set;}
      public string noticia {get; set;}
      public string vereador {get; set;}
      public string referencia {get; set;}
      public string data {get; set;}
      public int usuario {get; set;}
        
    }
}