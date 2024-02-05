﻿using SignalR.Chat.Contexto;
using SignalR.Chat.Interfaces;
using SignalR.Chat.Models;

namespace SignalR.Chat.Repository
{
    public class ContatoRepository : RepositoryBase<Contato>, IContato
    {
        public ContatoRepository(ChatContext conn) : base(conn)
        {
        }
    }
}
