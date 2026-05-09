namespace CalculadoraDeMedias01
{
    partial class FormCalculadora
    {
        private System.ComponentModel.IContainer components = null;

        // ── Controles ──────────────────────────────────
        private System.Windows.Forms.Label      lblStatus;

        private System.Windows.Forms.Label      lblNP1;
        private System.Windows.Forms.TextBox    txtNP1;
        private System.Windows.Forms.Label      lblNP2;
        private System.Windows.Forms.TextBox    txtNP2;
        private System.Windows.Forms.Label      lblPIM;
        private System.Windows.Forms.TextBox    txtPIM;
        private System.Windows.Forms.Label      lblSemestralLabel;
        private System.Windows.Forms.Label      lblSemestral;
        private System.Windows.Forms.Button     btnLimparSemestral;
        private System.Windows.Forms.Button     btnSemestral;

        private System.Windows.Forms.Label      lblExame;
        private System.Windows.Forms.TextBox    txtExame;
        private System.Windows.Forms.Label      lblFinalLabel;
        private System.Windows.Forms.Label      lblFinal;
        private System.Windows.Forms.Button     btnLimparFinal;
        private System.Windows.Forms.Button     btnFinal;

        private System.Windows.Forms.Panel      panelSemestral;
        private System.Windows.Forms.Panel      panelFinal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ── FORM ──────────────────────────────────
            this.Text            = "Cálculo de Médias e Status | ESWA+POO";
            this.Size            = new System.Drawing.Size(340, 420);
            this.MinimumSize     = new System.Drawing.Size(340, 420);
            this.MaximizeBox     = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.Padding         = new System.Windows.Forms.Padding(8);

            // ── STATUS (topo) ─────────────────────────
            lblStatus = new System.Windows.Forms.Label
            {
                Text      = "Em Andamento",
                Dock      = System.Windows.Forms.DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height    = 36,
                Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Black,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };

            // ── PANEL SEMESTRAL ───────────────────────
            panelSemestral = new System.Windows.Forms.Panel
            {
                Dock    = System.Windows.Forms.DockStyle.Top,
                Height  = 160,
                Padding = new System.Windows.Forms.Padding(8, 4, 8, 4)
            };

            lblNP1 = MakeLabel("NP1");
            txtNP1 = MakeTextBox(); txtNP1.TextChanged += txtNota_TextChanged;

            lblNP2 = MakeLabel("NP2");
            txtNP2 = MakeTextBox(); txtNP2.TextChanged += txtNota_TextChanged;

            lblPIM = MakeLabel("PIM");
            txtPIM = MakeTextBox(); txtPIM.TextChanged += txtNota_TextChanged;

            lblSemestralLabel = MakeBoldLabel("Semestral");
            lblSemestral      = MakeResultLabel();

            btnLimparSemestral = MakeButton("Limpar");
            btnLimparSemestral.Click += btnLimparSemestral_Click;

            btnSemestral = MakeButton("Semestral");
            btnSemestral.Click += btnSemestral_Click;

            // Layout manual dentro do painel semestral
            LayoutRow(panelSemestral, lblNP1,            txtNP1,   8,   8);
            LayoutRow(panelSemestral, lblNP2,            txtNP2,   8,  36);
            LayoutRow(panelSemestral, lblPIM,            txtPIM,   8,  64);
            LayoutRow(panelSemestral, lblSemestralLabel, lblSemestral, 8, 92);

            btnLimparSemestral.Location = new System.Drawing.Point(60, 124);
            btnSemestral.Location       = new System.Drawing.Point(160, 124);
            panelSemestral.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblNP1, txtNP1, lblNP2, txtNP2, lblPIM, txtPIM,
                lblSemestralLabel, lblSemestral,
                btnLimparSemestral, btnSemestral
            });

            // ── PANEL FINAL ───────────────────────────
            panelFinal = new System.Windows.Forms.Panel
            {
                Dock    = System.Windows.Forms.DockStyle.Top,
                Height  = 100,
                Padding = new System.Windows.Forms.Padding(8, 4, 8, 4)
            };

            lblExame = MakeLabel("Exame");
            txtExame = MakeTextBox(); txtExame.TextChanged += txtNota_TextChanged;

            lblFinalLabel = MakeBoldLabel("Final");
            lblFinal      = MakeResultLabel();

            btnLimparFinal = MakeButton("Limpar");
            btnLimparFinal.Click += btnLimparFinal_Click;

            btnFinal = MakeButton("Final");
            btnFinal.Click += btnFinal_Click;

            LayoutRow(panelFinal, lblExame,     txtExame,  8,  8);
            LayoutRow(panelFinal, lblFinalLabel, lblFinal,  8, 36);

            btnLimparFinal.Location = new System.Drawing.Point(60, 64);
            btnFinal.Location       = new System.Drawing.Point(160, 64);
            panelFinal.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblExame, txtExame,
                lblFinalLabel, lblFinal,
                btnLimparFinal, btnFinal
            });

            // ── ADICIONAR AO FORM (ordem inversa do Dock) ─
            this.Controls.Add(panelFinal);
            this.Controls.Add(panelSemestral);
            this.Controls.Add(lblStatus);
        }

        // ── Fábrica de controles ──────────────────────
        private static System.Windows.Forms.Label MakeLabel(string text)
            => new() { Text = text, Width = 80, TextAlign = System.Drawing.ContentAlignment.MiddleRight };

        private static System.Windows.Forms.Label MakeBoldLabel(string text)
            => new()
            {
                Text      = text,
                Width     = 80,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
            };

        private static System.Windows.Forms.TextBox MakeTextBox()
            => new() { Width = 160, Text = "0,0", TextAlign = System.Windows.Forms.HorizontalAlignment.Right };

        private static System.Windows.Forms.Label MakeResultLabel()
            => new()
            {
                Width       = 160,
                Text        = "0,0",
                TextAlign   = System.Drawing.ContentAlignment.MiddleRight,
                Font        = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };

        private static System.Windows.Forms.Button MakeButton(string text)
            => new() { Text = text, Width = 80, Height = 26 };

        private static void LayoutRow(
            System.Windows.Forms.Control parent,
            System.Windows.Forms.Control label,
            System.Windows.Forms.Control field,
            int x, int y)
        {
            label.Location = new System.Drawing.Point(x, y);
            field.Location = new System.Drawing.Point(x + 88, y);
            label.Height   = 24;
            field.Height   = 24;
        }
    }
}
