using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrevisaoTempoINPE;

namespace DemoINPE {
    public partial class Form1 : Form {
        BuscaLocalidades locais;
        int codSelecionado;
        public Form1() {
            InitializeComponent();
        }

        private void gbxPrevisao_VisibleChanged(object sender, EventArgs e) {
            //lblAviso.Visible = !gbxPrevisao.Visible;
        }

        private void lblAviso_VisibleChanged(object sender, EventArgs e) {
            gbxPrevisao.Visible = !lblAviso.Visible;
        }

        private void btnBuscaLocal_Click(object sender, EventArgs e) {
            if (locais != null)
                locais.Dispose();
            lbxResultadoLocalidade.Items.Clear();
            if (string.IsNullOrWhiteSpace(txtBuscaLocal.Text))
                return;
            locais = new BuscaLocalidades(txtBuscaLocal.Text);
            if (locais.ObteveLista) {
                for (int i = 0; i < locais.Cidades.Length; i++) {
                    string results = string.Format("{0}-{1}", locais.Cidades[i], locais.Estados[i]);
                    lbxResultadoLocalidade.Items.Add(results);
                }
                gbxPrevisao.Visible = true;
            }
            else {
                MessageBox.Show("Não foi possivel obter a lista de localidades.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimparCampos();
            }
        }
        private void LimparCampos() {
            txtBuscaLocal.Clear();
            lbxResultadoLocalidade.Items.Clear();
            btnBuscaLocal.Enabled = false;
            btnObterPrevisao.Enabled = false;
            txtCidadeSelecionada.Clear();
            txtCodLocalidade.Clear();
            txtResultadoPrevisao.Clear();
            gbxPrevisao.Visible = false;

        }

        private void lbxResultadoLocalidade_SelectedIndexChanged(object sender, EventArgs e) {
            string selec = txtCidadeSelecionada.Text = locais.Cidades[lbxResultadoLocalidade.SelectedIndex] + "-" + locais.Estados[lbxResultadoLocalidade.SelectedIndex];
            txtCodLocalidade.Text = locais.Codigos[lbxResultadoLocalidade.SelectedIndex];
            codSelecionado = Convert.ToInt32(txtCodLocalidade.Text);
            if (cmbPeriodo.Text != "Selecione o período de previsão para a tempo...")
                btnObterPrevisao.Enabled = true;
        }

        private void cmbPeriodo_SelectionChangeCommitted(object sender, EventArgs e) {
            if (lbxResultadoLocalidade.SelectedItem != null)
                btnObterPrevisao.Enabled = true;

            Text = cmbPeriodo.SelectedIndex.ToString();
        }

        private void txtBuscaLocal_TextChanged(object sender, EventArgs e) {
            gbxPrevisao.Visible = false;
            cmbPeriodo.Text = "Selecione o período de previsão para a tempo...";
            btnBuscaLocal.Enabled = !string.IsNullOrWhiteSpace(txtBuscaLocal.Text);
        }

        private void btnObterPrevisao_Click(object sender, EventArgs e) {
            txtResultadoPrevisao.Clear();
            switch (cmbPeriodo.SelectedIndex) {
                case 0:
                    PrevisaoQuatroDias prev4 = new PrevisaoQuatroDias(codSelecionado);
                    if (prev4.ObtevePrevisao) {
                        lblTituloPrev.Text = string.Format("Previsão para {0}-{1} - Atualizada em: {2}", prev4.Cidade, prev4.Estado, prev4.DataAtualizacao.ToShortDateString());
                        for (int i = 0; i < prev4.DataPrevisao.Length; i++) {

                            txtResultadoPrevisao.Text += string.Format("{0}: {1}", prev4.DataPrevisao[i].ToShortDateString(), prev4.TempoPrevisto[i]);
                            txtResultadoPrevisao.Text += string.Format("\r\n Min: {0}°C - Máx: {1}°C - ÍndiceUV: {2}\r\n\r\n", prev4.TemperaturaMinima[i], prev4.TemperaturaMaxima[i], prev4.IndiceUV[i]);
                            txtResultadoPrevisao.Text += "\r\n--------------------------------------------------------------------------------------------\r\n";
                        }
                    }
                    break;
                case 1:
                    PrevisaoSeteDias prev7 = new PrevisaoSeteDias(codSelecionado);
                    if (prev7.ObtevePrevisao) {
                        lblTituloPrev.Text = string.Format("Previsão para {0}-{1} - Atualizada em: {2}", prev7.Cidade, prev7.Estado, prev7.DataAtualizacao.ToShortDateString());
                        for (int i = 0; i < prev7.DataPrevisao.Length; i++) {

                            txtResultadoPrevisao.Text += string.Format("{0}: {1}", prev7.DataPrevisao[i].ToShortDateString(), prev7.TempoPrevisto[i]);
                            txtResultadoPrevisao.Text += string.Format("\r\n Min: {0}°C - Máx: {1}°C - ÍndiceUV: {2}\r\n\r\n", prev7.TemperaturaMinima[i], prev7.TemperaturaMaxima[i], prev7.IndiceUV[i]);
                            txtResultadoPrevisao.Text += "\r\n--------------------------------------------------------------------------------------------\r\n";
                        }
                    }
                    break;
                case 2:
                    PrevisaoEstendida prevEst = new PrevisaoEstendida(codSelecionado);
                    if (prevEst.ObtevePrevisao) {
                        lblTituloPrev.Text = string.Format("Previsão para {0}-{1} - Atualizada em: {2}", prevEst.Cidade, prevEst.Estado, prevEst.DataAtualizacao.ToShortDateString());
                        for (int i = 0; i < prevEst.DataPrevisao.Length; i++) {

                            txtResultadoPrevisao.Text += string.Format("{0}: {1}", prevEst.DataPrevisao[i].ToShortDateString(), prevEst.TempoPrevisto[i]);
                            txtResultadoPrevisao.Text += string.Format("\r\n Min: {0}°C - Máx: {1}°C\r\n\r\n", prevEst.TemperaturaMinima[i], prevEst.TemperaturaMaxima[i]);
                            txtResultadoPrevisao.Text += "\r\n--------------------------------------------------------------------------------------------\r\n";
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void txtBuscaLocal_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter)
                btnBuscaLocal.PerformClick();
        }
    }
}
