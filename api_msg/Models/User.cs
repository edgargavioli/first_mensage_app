using System;
using System.Collections.Generic;
using api_msg.Models;

namespace api_msg.Models;

public class User
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public virtual ICollection<Mensagem>? Mensagems { get; set; } = new List<Mensagem>();

    public User(string nome, string senha, string numero)
    {
        Nome = nome;
        Senha = senha;
        Numero = numero;
    }
}
