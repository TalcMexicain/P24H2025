using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HuntToSurviveAI.Services
{
    public class GameClient
    {
        private readonly string _serverIp;
        private readonly int _serverPort;
        private readonly string _teamName;
        private TcpClient _client;
        private NetworkStream _stream;

        public GameClient(string serverIp, int serverPort, string teamName)
        {
            _serverIp = serverIp;
            _serverPort = serverPort;
            _teamName = teamName;
        }

        public async Task ConnectAsync()
        {
            _client = new TcpClient();
            await _client.ConnectAsync(_serverIp, _serverPort);
            _stream = _client.GetStream();

            // Envoyer le nom de l'équipe
            await SendMessageAsync(_teamName);
        }

        public async Task<string> ReceiveMessageAsync()
        {
            if (_stream == null) return null;

            byte[] buffer = new byte[1024];
            int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
        }

        public async Task SendMessageAsync(string message)
        {
            if (_stream == null) return;

            byte[] data = Encoding.ASCII.GetBytes(message + "\n");
            await _stream.WriteAsync(data, 0, data.Length);
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
} 