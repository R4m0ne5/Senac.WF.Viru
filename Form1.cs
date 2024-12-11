using System.Runtime.InteropServices;

namespace Senac.WF.Viru
{
    public partial class Form1 : Form
    {
        // variaveis
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        // metodo que executa o evento de clique
        [DllImport("user32.dll",
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(
            int dwFlags,
            int dx,
            int dy,
            int cButtons,
            int dwExtraInfo);
        // possibilita gerar numeros aleatorios
        private Random random = new();

        private void MoverCursorMouse()
        {
            // obter a largura da tela
            int largura = Screen.PrimaryScreen.Bounds.Width;
            // obter a altura da tela
            int altura = Screen.PrimaryScreen.Bounds.Height;
            // gerar uma posição no eixo x
            int posx = random.Next(largura);
            // gerar uma posição no eixo y
            int posy = random.Next(altura);
            // Posicionar o cursor do mouse na posiçao x,y
            Cursor.Position = new Point(posx, posy);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9999999999999999999999999999999999999; i++)
            {
                MoverCursorMouse();
                Clicar();
                Clicar();
                Thread.Sleep(10);
            }
        }

        private void Clicar()
        {
            // executa o clique completo do mouse
            // pressiona o botao esquerdo
            mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X,Cursor.Position.Y,0,0);
            // solta o botao esquerdo
            mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y,0,0);
        }
    }
}
