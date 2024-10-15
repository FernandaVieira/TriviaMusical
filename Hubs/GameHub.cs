using Microsoft.AspNetCore.SignalR;

namespace TriviaMusical.Hubs
{
    public class GameHub : Hub
    {
        // Método chamado pelos clientes para enviar mensagens
        public async Task SendMessage(string user, string message)
        {
            // Envia a mensagem para todos os clientes conectados
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        // Método para notificar todos os jogadores quando o jogo começa
        public async Task StartGame()
        {
            await Clients.All.SendAsync("GameStarted");
        }

        // Método para enviar a pergunta atual para todos os jogadores
        public async Task SendQuestion(string question)
        {
            await Clients.All.SendAsync("ReceiveQuestion", question);
        }

        // Método para processar as respostas dos jogadores
        public async Task SubmitAnswer(string user, string answer)
        {
            // Aqui você pode adicionar lógica para verificar a resposta
            // Por exemplo, você pode atualizar a pontuação do jogador
            await Clients.All.SendAsync("ReceiveAnswer", user, answer);
        }

        // Método para desconectar um jogador
        public override async Task OnDisconnectedAsync(System.Exception? exception)
        {
            // Lógica para quando um jogador se desconecta
            await base.OnDisconnectedAsync(exception);
        }
    }
}
