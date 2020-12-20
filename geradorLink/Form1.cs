using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace geradorLink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtTelefone.LostFocus += txtTelefone_LostFocus;
        }

        private void btnGerar_Click(object sender, EventArgs e) => Gerar();

        private void Gerar()
        {
            var numero = ParseText(txtTelefone.Text);
            ManipularTelefone(ref numero);
            txtResultado.Text = GerarLink(numero);
            btnCopiar.Enabled = true;
        }

        private string GerarLink(string numero) => "https://web.whatsapp.com/send?phone=55" + numero;

        private string ParseText(string text) => string.Join("", Regex.Split(text, @"\D+"));

        private string ManipularTelefone(ref string telefone)
        {
            if (telefone.Length <= 9)
                telefone = "11" + telefone;
            return telefone;
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResultado.Text))
                Clipboard.SetText(txtResultado.Text);
        }

        private void txtTelefone_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTelefone.Text))
            {
                txtResultado.Text = "";
                btnCopiar.Enabled = false;
            }
            else
                Gerar();
        }
    }
}
