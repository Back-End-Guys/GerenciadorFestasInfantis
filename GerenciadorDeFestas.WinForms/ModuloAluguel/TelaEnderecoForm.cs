﻿using GerenciadorDeFestas.Dominio.ModuloAluguel;
using GerenciadorDeFestas.WinForms.Compartilhado;

namespace GerenciadorDeFestas.WinForms.ModuloAluguel
{
    public partial class TelaEnderecoForm : Form
    {
        public TelaEnderecoForm()
        {
            this.ConfigurarDialog();
            InitializeComponent();
        }

        public void ConfigurarTela(Aluguel aluguelSelecionado)
        {
            txtId.Text = aluguelSelecionado.id.ToString();
            txtCep.Text = aluguelSelecionado.Cep;
            txtRua.Text = aluguelSelecionado.nomeRua;
            txtNumero.Text = aluguelSelecionado.numero;
        }
    }
}
