using System;
using System.Drawing;
using System.Windows.Forms;
using ESWA01CalculadoraDeMedias;

namespace CalculadoraDeMedias01
{
    public partial class FormCalculadora : Form
    {
        private readonly GradeCalculator _calculador = new();
        private double? _mediaSemestral = null;

        public FormCalculadora()
        {
            InitializeComponent();
            Resetar();
        }
        // se foi aprovado ou ficou em exame 
        private void btnSemestral_Click(object sender, EventArgs e)
        {
            if (!TentarObterNota(txtNP1, "NP1", out double np1)) return;
            if (!TentarObterNota(txtNP2, "NP2", out double np2)) return;
            if (!TentarObterNota(txtPIM, "PIM", out double pim)) return;

            var resultado = _calculador.CalculateSemestral(np1, np2, pim);
            _mediaSemestral = resultado.MediaSemestral;
            lblSemestral.Text = resultado.MediaSemestral.ToString("0.0");

            if (resultado.Status == StudentStatus.Aprovado)
            {
                lblStatus.Text = "Aprovado";
                lblStatus.ForeColor = Color.Green;
                HabilitarFinal(false);
            }
            else
            {
                lblStatus.Text = "Em Exame";
                lblStatus.ForeColor = Color.Orange;
                HabilitarFinal(true);
            }
        }

        private void btnLimparSemestral_Click(object sender, EventArgs e)
        {
            Resetar();
        }

        private void btnFinal_Click(object sender, EventArgs e)
        {
            if (_mediaSemestral is null)
            {
                MessageBox.Show("Calcule a média semestral antes.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TentarObterNota(txtExame, "Exame", out double exame)) return;

            var resultado = _calculador.CalculateFinal(_mediaSemestral.Value, exame);
            lblFinal.Text = resultado.MediaFinal.ToString("0.0");

            if (resultado.Status == StudentStatus.Aprovado)
            {
                lblStatus.Text = "Aprovado";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "Reprovado";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void btnLimparFinal_Click(object sender, EventArgs e)
        {
            txtExame.Text = "0,0";
            lblFinal.Text = "0,0";
            lblStatus.ForeColor = Color.Black;
        }

       
        private void txtNota_TextChanged(object sender, EventArgs e)
        {
            if (sender is not TextBox tb) return;
            int pos = tb.SelectionStart;
            string limpo = _calculador.SanitizeInput(tb.Text);
            if (limpo != tb.Text)
            {
                tb.Text = limpo;
                tb.SelectionStart = Math.Max(0, pos - 1);
            }
        }

        private bool TentarObterNota(TextBox tb, string campo, out double valor)
        {
            if (_calculador.TryParseNote(tb.Text, out valor))
                return true;

            MessageBox.Show($"O campo {campo} deve ser um número entre 0,0 e 10,0.",
                "Nota inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tb.Focus();
            return false;
        }

        private void Resetar()
        {
            _mediaSemestral = null;
            txtNP1.Text = "0,0";
            txtNP2.Text = "0,0";
            txtPIM.Text = "0,0";
            txtExame.Text = "0,0";
            lblSemestral.Text = "0,0";
            lblFinal.Text = "0,0";
            lblStatus.Text = "Em Andamento";
            lblStatus.ForeColor = Color.Black;
            HabilitarFinal(false);
        }

        private void HabilitarFinal(bool habilitar)
        {
            txtExame.Enabled = habilitar;
            btnFinal.Enabled = habilitar;
            btnLimparFinal.Enabled = habilitar;
        }
    }
}
