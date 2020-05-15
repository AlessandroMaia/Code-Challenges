using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaesarCipher
{
    public partial class FormJanelaPrincipal : Form
    {
        Configuracoes p1 = new Configuracoes();
        public FormJanelaPrincipal()
        {
            InitializeComponent();
        }
        private void btnRequisitarJson_Click(object sender, EventArgs e)
        {
            txtJsonOriginal.Text = p1.ObtendoJson();
        }

        private void btnDescriptografar_Click(object sender, EventArgs e)
        {
            p1.DecripitandoSalvandoArquivoJson(txtJsonDescriptografado);
        }

        private void btnResumoCriptografico_Click(object sender, EventArgs e)
        {
            p1.GerandoResumoCriptografico(txtJsonFinalizado);
        }

        private void btnEnviarArquivo_Click(object sender, EventArgs e)
        {
            p1.UploadDoArquivo();
        }
    }
}
