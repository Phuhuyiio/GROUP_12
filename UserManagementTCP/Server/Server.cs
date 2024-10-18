namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            ServerTCPConnection conn = new ServerTCPConnection();
            conn.Connect();
        }
    }
}
