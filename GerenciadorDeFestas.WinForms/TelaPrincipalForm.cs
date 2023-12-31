using GerenciadorDeFestas.Infra.Dados.Arquivo.Compartilhado;
using GerenciadorDeFestas.Dominio.ModuloAluguel;
using GerenciadorDeFestas.Dominio.ModuloCliente;
using GerenciadorDeFestas.Dominio.ModuloItem;
using GerenciadorDeFestas.Dominio.ModuloTema;
using GerenciadorDeFestas.Infra.Dados.Arquivo.ModuloAluguel;
using GerenciadorDeFestas.Infra.Dados.Arquivo.ModuloCliente;
using GerenciadorDeFestas.Infra.Dados.Arquivo.ModuloItem;
using GerenciadorDeFestas.Infra.Dados.Arquivo.ModuloTema;
using GerenciadorDeFestas.WinForms.ModuloAluguel;
using GerenciadorDeFestas.WinForms.ModuloCliente;
using GerenciadorDeFestas.WinForms.ModuloItem;
using GerenciadorDeFestas.WinForms.ModuloTema;

namespace GerenciadorDeFestas.WinForms
{
    public partial class TelaPrincipalForm : Form
    {
        private static TelaPrincipalForm telaPrincipal;

        private ControladorBase controlador;

        static ContextoDados contexto = new ContextoDados(carregarDados: true);

        private IRepositorioCliente repositorioCliente = new RepositorioClienteEmArquivo(contexto);
        private IRepositorioItem repositorioItem = new RepositorioItemEmArquivo(contexto);
        private IRepositorioTema repositorioTema = new RepositorioTemaEmArquivo(contexto);
        private IRepositorioAluguel repositorioAluguel = new RepositorioAluguelEmArquivo(contexto);

        public TelaPrincipalForm()
        {
            InitializeComponent();
            telaPrincipal = this;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        public static TelaPrincipalForm Instancia
        {
            get
            {
                if (telaPrincipal == null)
                    telaPrincipal = new TelaPrincipalForm();

                return telaPrincipal;
            }
        }

        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            toolBar.Enabled = true;

            labelTipoCadastro.Text = controladorBase.ObterTipoCadastro();

            ConfigurarBarraFerramentas(controlador);

            ConfigurarListagem(controlador);
        }

        private void ConfigurarListagem(ControladorBase controladorBase)
        {
            UserControl listagem = controladorBase.ObterListagem();

            listagem.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(listagem);
        }

        private void ConfigurarBotoesHabilitados(ControladorBase controlador)
        {
            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
            btnPagamento.Enabled = controlador.PagamentoHabilitado;
            btnEndereco.Enabled = controlador.EnderecoHabilitado;
            btnListaAlugueis.Enabled = controlador.ListagemHabilitado;
            btnDesconto.Enabled = controlador.DescontoHabilitado;
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnPagamento.ToolTipText = controlador.ToolTipPagamento;
            btnEndereco.ToolTipText = controlador.ToolTipEndereco;
            btnListaAlugueis.ToolTipText = controlador.ToolTipListarAlugueis;
            btnDesconto.ToolTipText = controlador.ToolTipDesconto;
        }

        private void ConfigurarBarraFerramentas(ControladorBase controlador)
        {
            toolBar.Enabled = true;

            ConfigurarToolTips(controlador);

            ConfigurarBotoesHabilitados(controlador);
        }

        private void clientesMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorCliente(repositorioCliente);

            ConfigurarTelaPrincipal(controlador);
        }

        private void TemasMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTema(repositorioTema, repositorioItem);

            ConfigurarTelaPrincipal(controlador);
        }

        private void ItensMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorItem(repositorioItem);

            ConfigurarTelaPrincipal(controlador);
        }

        private void aluguelMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorAluguel(repositorioAluguel, repositorioCliente, repositorioTema);

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            controlador.Pagamento();
        }

        private void btnEndereco_Click(object sender, EventArgs e)
        {
            controlador.Endereco();
        }

        private void btnListaAlugueis_Click(object sender, EventArgs e)
        {
            controlador.Listar();
        }

        private void btnDesconto_Click(object sender, EventArgs e)
        {
            controlador.Desconto();
        }
    }
}