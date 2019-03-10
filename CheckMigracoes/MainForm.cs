/*
 * Created by SharpDevelop.
 * User: Jeferson
 * Date: 09/03/2019
 * Time: 14:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization.Json;
using System.IO;

namespace CheckMigracoes
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form		
	{
		 #region General Vars   
       string URI = "";
        const int WAITBALLOON = 30;
        const String MINIMIZEINFO = "Ola estou aqui na bandeja.\nDuplo clique no icone para restaurar.";
        const String VERSION = "Check Migrações v.1.1 - by Jeferson R.";
        const String ABOUT = "Check Migrações | by Jeferson R./Disys | 03-2019 | duplo clique para mail-me";
        String lojasFound;
        String urllojasamigrar;
        String urllojasconcluidas;
        String urllojasemandamento;
        String tipoQuery;
        String msgBoxShow = "1";
        int minutesToCheck = 5;
        const String txtConc = "| Conc: ";
        const String txtAnd = "| And: ";
        const String txtAmigr = "a Mig: ";
        public static string msg;
		#endregion	
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.Text = VERSION;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            notifyIcon1.Text = VERSION;
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info; 
            lbConc.Text = txtConc;
            lbAMig.Text = txtAmigr;
            lbAnd.Text = txtAnd;
            ShowCreds();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		#region Functions
		private void StatusMigracoes()
        {
            ShowCreds();                        
            tipoQuery = "amigrar";
            GetStatusMigracoes(urllojasamigrar, tipoQuery);
            tipoQuery = "emandamento";
            GetStatusMigracoes(urllojasemandamento, tipoQuery);
            tipoQuery = "concluidas";
            GetStatusMigracoes(urllojasconcluidas, tipoQuery);
        }
		private async void GetStatusMigracoes(String url, String tipoQueryBusca)
        {
			
            URI = url;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //clienteUri = response.Headers.Location;
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        if (tipoQueryBusca == "concluidas")
                        {
                            var concluidas = new List<Concluidas>();
                            concluidas = JsonConvert.DeserializeObject<Concluidas[]>(ProdutoJsonString).ToList();
                            lbConc.Text = txtConc + concluidas.Count;
                        }
                        if (tipoQueryBusca == "amigrar")
                        {
                        	var amigrar = new List<Amigrar>();
                            amigrar = JsonConvert.DeserializeObject<Amigrar[]>(ProdutoJsonString).ToList();
                            lbAMig.Text = txtAmigr + amigrar.Count;
                        }
                        if (tipoQueryBusca == "emandamento")
                        {
                            var andamento = new List<Emandamento>();
                            andamento = JsonConvert.DeserializeObject<Emandamento[]>(ProdutoJsonString).ToList();
                            lbAnd.Text = txtAnd + andamento.Count;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter a lista de Migrações : " + response.StatusCode);
                    }
                }
            }
        }
        private async void GetAllMigracoes(String url, String tipoQueryBusca)
        {
           
            URI = url;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //clienteUri = response.Headers.Location;
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        if (tipoQueryBusca == "concluidas")
                        {
                            dgvDadosConcluidas.DataSource = JsonConvert.DeserializeObject<Concluidas[]>(ProdutoJsonString).ToList();
                        }
                        if (tipoQueryBusca == "amigrar")
                        {
                            dgvDadosAMigrar.DataSource = JsonConvert.DeserializeObject<Amigrar[]>(ProdutoJsonString).ToList();
                        }
                        if (tipoQueryBusca == "emandamento")
                        {
                            dgvDadosEmAndamento.DataSource = JsonConvert.DeserializeObject<Emandamento[]>(ProdutoJsonString).ToList();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter a lista de Migrações : " + response.StatusCode);
                    }
                }
            }
        }
        private void monitorarLojas()
        {
            
            String lojas = tbSearch.Text;
            if (String.IsNullOrEmpty(lojas))
            {                
                MessageBox.Show("Lojas para monitorar esta vazio, verifique!");
            }else
            {
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromMinutes(minutesToCheck);

                var timer = new System.Threading.Timer((e) =>
                {
                    CheckLojas(lojas, "IN");
                    CheckLojas(lojas, "OUT");
                }, null, startTimeSpan, periodTimeSpan);

                this.WindowState = FormWindowState.Minimized;

            }
            
        }
        private async void CheckLojas(String buscar, String tipo)
        {
            buscar.Replace('.', ',');
            buscar.Replace(' ', ',');
            string[] buscarLojas = buscar.Split(',');            
            
            
            if (tipo == "IN") {
            	URI = urllojasemandamento;
            }
            if (tipo == "OUT") {
            	URI = urllojasconcluidas;
            }
            
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //clienteUri = response.Headers.Location;
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        if (tipo == "IN") {
                        	var migracoes = new List<Emandamento>();
            				migracoes = JsonConvert.DeserializeObject<Emandamento[]>(ProdutoJsonString).ToList();
            				msg = "Checkin: ";
            				foreach (var loja in migracoes)
                        	{
                            	foreach (string lj in buscarLojas)
                            	{
                                	if (loja.CodigoFranquia == lj)
                                	{
                                    	lojasFound = loja.CodigoFranquia + " / " + lojasFound;
                                	}
                            	}
                        	}
            			}
                        if (tipo == "OUT") {
                        	var migracoes = new List<Concluidas>();
            				migracoes = JsonConvert.DeserializeObject<Concluidas[]>(ProdutoJsonString).ToList();
            				msg = "Checkout: ";
            				foreach (var loja in migracoes)
                        	{
                            	foreach (string lj in buscarLojas)
                            	{
                                	if (loja.codigofranquia == lj)
                                	{
                                    	lojasFound = loja.codigofranquia + " / " + lojasFound;
                                	}
                            	}
                        	}
            			}                  

                        

                        if (!(String.IsNullOrEmpty(lojasFound)))
                        {
                        	
                            ShowBalloon(lojasFound, msg);
                            if (msgBoxShow=="1")
                            {
                                ShowMensagem(lojasFound, msg);
                            }
                            toolStripStatusLabel1.Text = msg+lojasFound;                           
                            lojasFound = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter a lista de Migrações : " + response.StatusCode);
                    }
                }
            }
        }               
        
        public void ShowBalloon(string loja, String msg)
        {
            // Display for n seconds.            
            notifyIcon1.BalloonTipText = msg+ loja+"\nAtualize o monitoramento de lojas";
            notifyIcon1.ShowBalloonTip(WAITBALLOON);
        }
        public void ShowMensagem(string loja, String msg)
        {
            MessageBox.Show(msg + loja+ "\nAtualize o monitoramento de lojas");
        }
        private string ConverteData(string dataJson)
        {
            var json = @"""" + dataJson + "\"";

            //Console.WriteLine(json.ToString());
            var output = Newtonsoft.Json.JsonConvert.DeserializeObject<DateTime>(json,
                    new Newtonsoft.Json.JsonSerializerSettings()
                    {
                        DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTime,
                        DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat
                    });

            return output.ToString();
        }
        public void ShowBalloon()
        {
            // Display for n seconds.
            notifyIcon1.BalloonTipText = MINIMIZEINFO;
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(WAITBALLOON);
        }
        public void Bandeja()
        {
            //Aplicação na bandeja - systray            
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            this.ShowInTaskbar = false;
        }
        public void RestauraJanela()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;

        }
        public void OnMinimizeInfoBalloon()
        {            
            ShowBalloon();           
        }
        public void iniConfig()
        {
            // Or specify a specific name in the current dir
            var MyIni = new IniFile("CheckMigracoes.ini");

            urllojasamigrar = MyIni.Read("lojasamigrar", "CheckMigracoesSettings");
            urllojasconcluidas = MyIni.Read("lojasconcluidas", "CheckMigracoesSettings");
            urllojasemandamento = MyIni.Read("lojasemandamento", "CheckMigracoesSettings");
            msgBoxShow = MyIni.Read("msgboxshow", "CheckMigracoesSettings");
            minutesToCheck = Convert.ToInt16(MyIni.Read("minutesToCheck", "CheckMigracoesSettings"));
                        
        }
        public void MailtoJef()
        {
            System.Diagnostics.Process.Start("mailto:jefersonrod@gmail.com");
        }
        public void CheckIniFileExists()
        {
            if (File.Exists("CheckMigracoes.ini"))
            {
                iniConfig();
            }else
            {
                DialogResult result1 = MessageBox.Show("Arquivo CheckMigracoes.ini não encontrado\nDuvidas: Jeferson R/Disys\nDeseja enviar um e-mail?","Erro config.ini", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    MailtoJef();
                    EncerrarApp();
                }
                if (result1 == DialogResult.No)
                {
                    EncerrarApp();
                }

            }
        }
        public void EncerrarApp()
        {
            System.Windows.Forms.Application.Exit();
        }
        public void ShowCreds()
        {
            toolStripStatusLabel1.Text = ABOUT;
            //toolStripStatusLabel1.BackColor = System.Drawing.Color.GhostWhite;
            //toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
        }
        #endregion
		
		#region Buttons
        void BtConcluidasClick(object sender, EventArgs e)
		{
			ShowCreds();
            tipoQuery = "concluidas";
            GetAllMigracoes(urllojasconcluidas, tipoQuery);
		}
        void BtAMigrarClick(object sender, EventArgs e)
		{
			ShowCreds();
            tipoQuery = "amigrar";
            GetAllMigracoes(urllojasamigrar, tipoQuery);
		}
        void BtEmAndamentoClick(object sender, EventArgs e)
		{
			ShowCreds();
            tipoQuery = "emandamento";
            GetAllMigracoes(urllojasemandamento, tipoQuery);
		}       
        
        void BtMonitorClick(object sender, EventArgs e)
		{
			
            ShowCreds();
            monitorarLojas();
		}
		void BtStatusClick(object sender, EventArgs e)
		{
			StatusMigracoes();
		}
        #endregion

        #region Events   
        void DgvDadosConcluidasCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			dgvDadosConcluidas.Columns[0].HeaderText = "Loja";
            dgvDadosConcluidas.Columns[1].HeaderText = "Inicio";
            dgvDadosConcluidas.Columns[1].Name = "dtini";
            dgvDadosConcluidas.Columns[2].HeaderText = "Fim";
            dgvDadosConcluidas.Columns[3].HeaderText = "U.N.";
            dgvDadosConcluidas.Columns[4].HeaderText = "Obs.";

            if (e.ColumnIndex == 1 && e.Value != null)
            {
                e.Value = ConverteData(e.Value.ToString());
                e.FormattingApplied = true;
            }
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                e.Value = ConverteData(e.Value.ToString());
                e.FormattingApplied = true;
            }
            dgvDadosConcluidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;            
            int count = dgvDadosConcluidas.Rows.Count;
            lbLojasConcluidas.Visible = true;
            lbLojasConcluidas.Text = "Total lojas concluidas: "+count.ToString();
            lbConc.Text = txtConc+count.ToString();
		}
        void DgvDadosAMigrarCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			dgvDadosAMigrar.Columns[0].HeaderText = "Loja";
            dgvDadosAMigrar.Columns[1].HeaderText = "U.N.";
            dgvDadosAMigrar.Columns[2].HeaderText = "Hora Prev.";
            dgvDadosAMigrar.Columns[3].HeaderText = "Atraso (mins.)";
                    
            
            if (e.ColumnIndex == 3 && e.Value != null && Convert.ToInt16(e.Value) > 0)
            {                
                e.CellStyle.BackColor = Color.Red;
                e.FormattingApplied = true;
            }
            
            if (e.ColumnIndex == 3 && e.Value != null && (Convert.ToInt16(e.Value) > -15 && Convert.ToInt16(e.Value) <=0))
            {                
                e.CellStyle.BackColor = Color.Yellow;
                e.FormattingApplied = true;
            }
			            
            dgvDadosAMigrar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            int count = dgvDadosAMigrar.Rows.Count;
            lbCountAMigrar.Visible = true;
            lbCountAMigrar.Text = "Total lojas a migrar: "+count.ToString();
            lbAMig.Text = txtAmigr + count.ToString();

		}
        void DgvDadosEmAndamentoCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			
            dgvDadosEmAndamento.Columns[0].HeaderText = "Loja";
            dgvDadosEmAndamento.Columns[1].HeaderText = "U.N.";            
            dgvDadosEmAndamento.Columns[2].HeaderText = "Técnico";
            dgvDadosEmAndamento.Columns[3].HeaderText = "Fone Técnico";
            dgvDadosEmAndamento.Columns[4].HeaderText = "Resp. Loja";
            dgvDadosEmAndamento.Columns[5].HeaderText = "Fone Loja";
            dgvDadosEmAndamento.Columns[6].HeaderText = "Data Cadastro";
            dgvDadosEmAndamento.Columns[7].HeaderText = "Hora de Inicio";

            if (e.ColumnIndex == 6 && e.Value != null)
            {
                e.Value = ConverteData(e.Value.ToString());
                e.FormattingApplied = true;
            }
            
            dgvDadosEmAndamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            int count = dgvDadosEmAndamento.Rows.Count;            
            lbCountEmAndamento.Visible = true;
            lbCountEmAndamento.Text = "Total lojas em andamento: "+count.ToString();
            lbAnd.Text = txtAnd+count.ToString();

		}
       
		void ToolStripStatusLabel1DoubleClick(object sender, EventArgs e)
		{
			//Habilitar evento Double Click para true para funcionar
            MailtoJef();
		}	
		void MainFormLoad(object sender, EventArgs e)
		{
			CheckIniFileExists();
		}
		void MainFormResize(object sender, EventArgs e)
		{
			
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();                
                OnMinimizeInfoBalloon();
            }
		}
		void NotifyIcon1DoubleClick(object sender, EventArgs e)
		{			
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            RestauraJanela();
		}
		
		
        #endregion

	}
}
