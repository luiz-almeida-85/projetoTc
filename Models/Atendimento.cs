using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
namespace projetoTc.Models
{
    public class Atendimento
    {   
        public int id {get; set;}
        public string nome{get; set;}
        public string email{get; set;}
        public string duvida{get; set;}
        
    }
}