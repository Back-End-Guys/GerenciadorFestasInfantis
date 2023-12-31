﻿using GerenciadorDeFestas.Dominio.ModuloTema;

namespace GerenciadorDeFestas.WinForms.ModuloTema
{
    public partial class TabelaTemaControl : UserControl
    {
        public TabelaTemaControl()
        {
            InitializeComponent();

            ConfigurarColunas();

            grid.ConfigurarGridLinhas();

            grid.ConfigurarGridSomenteLeitura();
        }

        public void AtualizarRegistros(List<Tema> temas)
        {
            grid.Rows.Clear();
            foreach (Tema tema in temas)
            {
                grid.Rows.Add(tema.id, tema.nome, tema.valorTotal.ToString("C"), tema.listaItens.Count);
            }
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {temas.Count} tema(s)");
        }

        private void ConfigurarColunas()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "id",
                    HeaderText = "ID"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "nome",
                    HeaderText = "Tema"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "valorTotal",
                    HeaderText = "Valor total"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "qntItens",
                    HeaderText = "Quantidade de itens"
                }
            };

            grid.Columns.AddRange(colunas);
        }

        public int ObterIdSelecionado()
        {
            int id;

            try
            {
                id = Convert.ToInt32(grid.SelectedRows[0].Cells["id"].Value);
            }
            catch
            {
                id = -1;
            }

            return id;
        }
    }
}
