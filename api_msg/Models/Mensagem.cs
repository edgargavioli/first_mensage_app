using System;
using System.Collections.Generic;

namespace api_msg.Models;

public partial class Mensagem
{
    public int Id { get; set; }

    public string Msg { get; set; } = null!;

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public Mensagem(string msg, int idUser)
    {
        Msg = msg;
        IdUser = idUser;
    }
}
