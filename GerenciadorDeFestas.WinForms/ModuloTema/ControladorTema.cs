﻿using GerenciadorDeFestas.Dominio.ModuloItem;
using GerenciadorDeFestas.Dominio.ModuloTema;

namespace GerenciadorDeFestas.WinForms.ModuloTema
{
    public class ControladorTema : ControladorBase
    {

        private IRepositorioTema repositorioTema;
        private IRepositorioItem repositorioItem;
        private TabelaTemaControl tabelaTema;
        private ListagemItensControl listagem;

        public ControladorTema(IRepositorioTema repositorioTema, IRepositorioItem repositorioItem)
        {
            this.repositorioTema = repositorioTema;
            this.repositorioItem = repositorioItem;
        }

        public override string ToolTipInserir => "Inserir novo tema";

        public override string ToolTipEditar => "Editar tema existente";

        public override string ToolTipExcluir => "Excluir tema existente";

        public override string ToolTipListarAlugueis => "Listar itens do tema";

        public override bool ListagemHabilitado => true;

        public override void Inserir()
        {
            TelaTemaForm telaTema = new TelaTemaForm(repositorioTema.SelecionarTodos(), repositorioItem.SelecionarTodos());
            telaTema.Text = "Cadastrar tema existente";

            DialogResult opcaoEscolhida = telaTema.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Tema tema = telaTema.ObterTema();

                for (int i = 0; i < tema.listaItens.Count(); i++)
                {
                    tema.listaItens[i].listaTemas.Add(tema);
                }

                tema.CalcularValor();

                repositorioTema.Inserir(tema);
            }

            CarregarTemas();
        }

        public override void Editar()
        {
            Tema temaSelecionado = ObterTemaSelecionado();

            if (temaSelecionado == null)
            {
                MessageBox.Show($"Selecione um tema primeiro", "Edicao de Tema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaTemaForm telaTema = new TelaTemaForm(repositorioTema.SelecionarTodos(), repositorioItem.SelecionarTodos());
            telaTema.Text = "Editar tema existente";

            telaTema.ConfigurarTela(temaSelecionado);

            DialogResult opcaoEscolhida = telaTema.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Tema tema = telaTema.ObterTema();

                tema.CalcularValor();

                repositorioTema.Editar(tema.id, tema);
            }

            CarregarTemas();
        }

        public override void Excluir()
        {
            Tema tema = ObterTemaSelecionado();

            if (tema == null)
            {
                MessageBox.Show($"Selecione um tema primeiro!",
                    "Excluir tema existente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o tema \"{tema.nome}\"?", "Excluir tema existente",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.Yes)
            {
                if (tema.listaAlugueis.Count() > 0)
                {
                    MessageBox.Show("Exclusão inválida! Tema possui aluguel(éis)", "Excluir tema existente",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                for (int i = 0; i < tema.listaItens.Count(); i++)
                {
                    tema.listaItens[i].listaTemas.Remove(tema);
                }

                repositorioTema.Excluir(tema);
            }

            CarregarTemas();
        }

        public override void Listar()
        {
            Tema tema = ObterTemaSelecionado();

            ListagemItensForm telaListagem = new ListagemItensForm();
            telaListagem.Text = "Listagem de itens do tema";

            if (listagem == null)
                listagem = new ListagemItensControl();

            if (tema == null)
            {
                MessageBox.Show($"Selecione um tema primeiro!",
                    "Listagem de itens",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            telaListagem.SetNome(tema);

            telaListagem.CarregarLista(tema.listaItens, tema.valorTotal);

            telaListagem.ShowDialog();
        }

        private Tema ObterTemaSelecionado()
        {
            int id = tabelaTema.ObterIdSelecionado();

            return repositorioTema.SelecionarPorId(id);
        }

        private void CarregarTemas()
        {
            List<Tema> tema = repositorioTema.SelecionarTodos();

            tabelaTema.AtualizarRegistros(tema);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaTema == null)
                tabelaTema = new TabelaTemaControl();

            CarregarTemas();

            return tabelaTema;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Temas";
        }
    }
}
