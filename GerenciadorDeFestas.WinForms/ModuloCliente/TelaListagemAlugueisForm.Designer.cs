﻿namespace GerenciadorDeFestas.WinForms.ModuloCliente
{
    partial class TelaListagemAlugueisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listagem = new TabelaListagemAlugueisControl();
            lblNome = new Label();
            SuspendLayout();
            // 
            // listagem
            // 
            listagem.BackColor = SystemColors.ControlDark;
            listagem.Dock = DockStyle.Bottom;
            listagem.Location = new Point(0, 60);
            listagem.Margin = new Padding(3, 5, 3, 5);
            listagem.Name = "listagem";
            listagem.Size = new Size(914, 503);
            listagem.TabIndex = 0;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblNome.Location = new Point(12, 9);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(95, 37);
            lblNome.TabIndex = 1;
            lblNome.Text = "Nome";
            // 
            // TelaListagemAlugueisForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 563);
            Controls.Add(lblNome);
            Controls.Add(listagem);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaListagemAlugueisForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tela listagem aluguel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabelaListagemAlugueisControl listagem;
        private Label lblNome;
    }
}