using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePlacas.Application.Abstractions
{
    public abstract class Notificacao
    {
        private List<NotificacaoItem> _notificacoes = new List<NotificacaoItem>();
        public IReadOnlyCollection<NotificacaoItem> Todas => _notificacoes.AsReadOnly();


        public void LimparNotificacoes()
        {
            _notificacoes.Clear();
        }

        public bool EhValido() => !_notificacoes.Any();
        public void AddNotificacao(string valor, string propriedade, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                _notificacoes.Add(new NotificacaoItem(propriedade, mensagem));
            }
        }

    }

    public class NotificacaoItem
    {
        public string Propriedade { get; }
        public string Mensagem { get; }

        public NotificacaoItem(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }
    }
}