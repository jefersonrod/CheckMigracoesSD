/*
 * Created by SharpDevelop.
 * User: Jeferson
 * Date: 09/03/2019
 * Time: 14:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CheckMigracoes
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabAMigrar;
		private System.Windows.Forms.TabPage tabEmAndamento;
		private System.Windows.Forms.TabPage tabConcluidas;
		private System.Windows.Forms.Button btConcluidas;
		private System.Windows.Forms.DataGridView dgvDadosConcluidas;
		private System.Windows.Forms.Button btAMigrar;
		private System.Windows.Forms.DataGridView dgvDadosAMigrar;
		private System.Windows.Forms.DataGridView dgvDadosEmAndamento;
		private System.Windows.Forms.Button btEmAndamento;
		private System.Windows.Forms.Button btMonitor;
		private System.Windows.Forms.TextBox tbSearch;
		private System.Windows.Forms.Label lbResult;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Label lbCountAMigrar;
		private System.Windows.Forms.Label lbCountEmAndamento;
		private System.Windows.Forms.Label lbLojasConcluidas;
		private System.Windows.Forms.Label lbAMig;
		private System.Windows.Forms.Label lbAnd;
		private System.Windows.Forms.Label lbConc;
		private System.Windows.Forms.Button btStatus;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabAMigrar = new System.Windows.Forms.TabPage();
			this.lbCountAMigrar = new System.Windows.Forms.Label();
			this.btAMigrar = new System.Windows.Forms.Button();
			this.dgvDadosAMigrar = new System.Windows.Forms.DataGridView();
			this.tabEmAndamento = new System.Windows.Forms.TabPage();
			this.lbCountEmAndamento = new System.Windows.Forms.Label();
			this.dgvDadosEmAndamento = new System.Windows.Forms.DataGridView();
			this.btEmAndamento = new System.Windows.Forms.Button();
			this.tabConcluidas = new System.Windows.Forms.TabPage();
			this.lbLojasConcluidas = new System.Windows.Forms.Label();
			this.btConcluidas = new System.Windows.Forms.Button();
			this.dgvDadosConcluidas = new System.Windows.Forms.DataGridView();
			this.btMonitor = new System.Windows.Forms.Button();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.lbResult = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lbAMig = new System.Windows.Forms.Label();
			this.lbAnd = new System.Windows.Forms.Label();
			this.lbConc = new System.Windows.Forms.Label();
			this.btStatus = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabAMigrar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDadosAMigrar)).BeginInit();
			this.tabEmAndamento.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDadosEmAndamento)).BeginInit();
			this.tabConcluidas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDadosConcluidas)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabAMigrar);
			this.tabControl1.Controls.Add(this.tabEmAndamento);
			this.tabControl1.Controls.Add(this.tabConcluidas);
			this.tabControl1.Location = new System.Drawing.Point(13, 67);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(426, 249);
			this.tabControl1.TabIndex = 0;
			// 
			// tabAMigrar
			// 
			this.tabAMigrar.Controls.Add(this.lbCountAMigrar);
			this.tabAMigrar.Controls.Add(this.btAMigrar);
			this.tabAMigrar.Controls.Add(this.dgvDadosAMigrar);
			this.tabAMigrar.Location = new System.Drawing.Point(4, 22);
			this.tabAMigrar.Name = "tabAMigrar";
			this.tabAMigrar.Padding = new System.Windows.Forms.Padding(3);
			this.tabAMigrar.Size = new System.Drawing.Size(418, 223);
			this.tabAMigrar.TabIndex = 0;
			this.tabAMigrar.Text = "A Migrar";
			this.tabAMigrar.UseVisualStyleBackColor = true;
			// 
			// lbCountAMigrar
			// 
			this.lbCountAMigrar.Location = new System.Drawing.Point(303, 8);
			this.lbCountAMigrar.Name = "lbCountAMigrar";
			this.lbCountAMigrar.Size = new System.Drawing.Size(107, 23);
			this.lbCountAMigrar.TabIndex = 2;
			this.lbCountAMigrar.Text = "Total lojas a migrar: ";
			this.lbCountAMigrar.Visible = false;
			// 
			// btAMigrar
			// 
			this.btAMigrar.Location = new System.Drawing.Point(4, 4);
			this.btAMigrar.Name = "btAMigrar";
			this.btAMigrar.Size = new System.Drawing.Size(95, 23);
			this.btAMigrar.TabIndex = 1;
			this.btAMigrar.Text = "Check a migrar";
			this.btAMigrar.UseVisualStyleBackColor = true;
			this.btAMigrar.Click += new System.EventHandler(this.BtAMigrarClick);
			// 
			// dgvDadosAMigrar
			// 
			this.dgvDadosAMigrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDadosAMigrar.Location = new System.Drawing.Point(0, 33);
			this.dgvDadosAMigrar.Name = "dgvDadosAMigrar";
			this.dgvDadosAMigrar.Size = new System.Drawing.Size(415, 194);
			this.dgvDadosAMigrar.TabIndex = 0;
			this.dgvDadosAMigrar.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvDadosAMigrarCellFormatting);
			// 
			// tabEmAndamento
			// 
			this.tabEmAndamento.Controls.Add(this.lbCountEmAndamento);
			this.tabEmAndamento.Controls.Add(this.dgvDadosEmAndamento);
			this.tabEmAndamento.Controls.Add(this.btEmAndamento);
			this.tabEmAndamento.Location = new System.Drawing.Point(4, 22);
			this.tabEmAndamento.Name = "tabEmAndamento";
			this.tabEmAndamento.Padding = new System.Windows.Forms.Padding(3);
			this.tabEmAndamento.Size = new System.Drawing.Size(418, 223);
			this.tabEmAndamento.TabIndex = 1;
			this.tabEmAndamento.Text = "Em Andamento";
			this.tabEmAndamento.UseVisualStyleBackColor = true;
			// 
			// lbCountEmAndamento
			// 
			this.lbCountEmAndamento.Location = new System.Drawing.Point(271, 8);
			this.lbCountEmAndamento.Name = "lbCountEmAndamento";
			this.lbCountEmAndamento.Size = new System.Drawing.Size(139, 23);
			this.lbCountEmAndamento.TabIndex = 2;
			this.lbCountEmAndamento.Text = "Total lojas em Andamento: ";
			this.lbCountEmAndamento.Visible = false;
			// 
			// dgvDadosEmAndamento
			// 
			this.dgvDadosEmAndamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDadosEmAndamento.Location = new System.Drawing.Point(0, 33);
			this.dgvDadosEmAndamento.Name = "dgvDadosEmAndamento";
			this.dgvDadosEmAndamento.Size = new System.Drawing.Size(415, 184);
			this.dgvDadosEmAndamento.TabIndex = 1;
			this.dgvDadosEmAndamento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvDadosEmAndamentoCellFormatting);
			// 
			// btEmAndamento
			// 
			this.btEmAndamento.Location = new System.Drawing.Point(3, 4);
			this.btEmAndamento.Name = "btEmAndamento";
			this.btEmAndamento.Size = new System.Drawing.Size(130, 23);
			this.btEmAndamento.TabIndex = 0;
			this.btEmAndamento.Text = "Check em andamento";
			this.btEmAndamento.UseVisualStyleBackColor = true;
			this.btEmAndamento.Click += new System.EventHandler(this.BtEmAndamentoClick);
			// 
			// tabConcluidas
			// 
			this.tabConcluidas.Controls.Add(this.lbLojasConcluidas);
			this.tabConcluidas.Controls.Add(this.btConcluidas);
			this.tabConcluidas.Controls.Add(this.dgvDadosConcluidas);
			this.tabConcluidas.Location = new System.Drawing.Point(4, 22);
			this.tabConcluidas.Name = "tabConcluidas";
			this.tabConcluidas.Size = new System.Drawing.Size(418, 223);
			this.tabConcluidas.TabIndex = 2;
			this.tabConcluidas.Text = "Concluidas";
			this.tabConcluidas.UseVisualStyleBackColor = true;
			// 
			// lbLojasConcluidas
			// 
			this.lbLojasConcluidas.Location = new System.Drawing.Point(278, 7);
			this.lbLojasConcluidas.Name = "lbLojasConcluidas";
			this.lbLojasConcluidas.Size = new System.Drawing.Size(133, 23);
			this.lbLojasConcluidas.TabIndex = 2;
			this.lbLojasConcluidas.Text = "Total de lojas concluidas: ";
			this.lbLojasConcluidas.Visible = false;
			// 
			// btConcluidas
			// 
			this.btConcluidas.Location = new System.Drawing.Point(4, 4);
			this.btConcluidas.Name = "btConcluidas";
			this.btConcluidas.Size = new System.Drawing.Size(110, 23);
			this.btConcluidas.TabIndex = 1;
			this.btConcluidas.Text = "Check concluidas";
			this.btConcluidas.UseVisualStyleBackColor = true;
			this.btConcluidas.Click += new System.EventHandler(this.BtConcluidasClick);
			// 
			// dgvDadosConcluidas
			// 
			this.dgvDadosConcluidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDadosConcluidas.Location = new System.Drawing.Point(0, 32);
			this.dgvDadosConcluidas.Name = "dgvDadosConcluidas";
			this.dgvDadosConcluidas.Size = new System.Drawing.Size(415, 188);
			this.dgvDadosConcluidas.TabIndex = 0;
			this.dgvDadosConcluidas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvDadosConcluidasCellFormatting);
			// 
			// btMonitor
			// 
			this.btMonitor.Location = new System.Drawing.Point(13, 13);
			this.btMonitor.Name = "btMonitor";
			this.btMonitor.Size = new System.Drawing.Size(75, 23);
			this.btMonitor.TabIndex = 1;
			this.btMonitor.Text = "Monitorar";
			this.btMonitor.UseVisualStyleBackColor = true;
			this.btMonitor.Click += new System.EventHandler(this.BtMonitorClick);
			// 
			// tbSearch
			// 
			this.tbSearch.Location = new System.Drawing.Point(108, 13);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(324, 20);
			this.tbSearch.TabIndex = 2;
			// 
			// lbResult
			// 
			this.lbResult.Location = new System.Drawing.Point(13, 43);
			this.lbResult.Name = "lbResult";
			this.lbResult.Size = new System.Drawing.Size(400, 23);
			this.lbResult.TabIndex = 3;
			this.lbResult.Text = "Verifique o status das migrações, abaixo, selecione a aba e clique no botão Check" +
	"";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1DoubleClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 319);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.ShowItemToolTips = true;
			this.statusStrip1.Size = new System.Drawing.Size(439, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.DoubleClickEnabled = true;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.DoubleClick += new System.EventHandler(this.ToolStripStatusLabel1DoubleClick);
			// 
			// lbAMig
			// 
			this.lbAMig.Location = new System.Drawing.Point(286, 64);
			this.lbAMig.Name = "lbAMig";
			this.lbAMig.Size = new System.Drawing.Size(50, 23);
			this.lbAMig.TabIndex = 6;
			this.lbAMig.Text = "a Mig:";
			// 
			// lbAnd
			// 
			this.lbAnd.Location = new System.Drawing.Point(331, 64);
			this.lbAnd.Name = "lbAnd";
			this.lbAnd.Size = new System.Drawing.Size(62, 23);
			this.lbAnd.TabIndex = 7;
			this.lbAnd.Text = "| And: ";
			// 
			// lbConc
			// 
			this.lbConc.Location = new System.Drawing.Point(376, 63);
			this.lbConc.Name = "lbConc";
			this.lbConc.Size = new System.Drawing.Size(54, 23);
			this.lbConc.TabIndex = 8;
			this.lbConc.Text = "| Conc: ";
			// 
			// btStatus
			// 
			this.btStatus.Location = new System.Drawing.Point(245, 61);
			this.btStatus.Name = "btStatus";
			this.btStatus.Size = new System.Drawing.Size(36, 23);
			this.btStatus.TabIndex = 9;
			this.btStatus.Text = "Stts:";
			this.btStatus.UseVisualStyleBackColor = true;
			this.btStatus.Click += new System.EventHandler(this.BtStatusClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 341);
			this.Controls.Add(this.btStatus);
			this.Controls.Add(this.lbConc);
			this.Controls.Add(this.lbAnd);
			this.Controls.Add(this.lbAMig);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.lbResult);
			this.Controls.Add(this.tbSearch);
			this.Controls.Add(this.btMonitor);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "CheckMigrações";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Resize += new System.EventHandler(this.MainFormResize);
			this.tabControl1.ResumeLayout(false);
			this.tabAMigrar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDadosAMigrar)).EndInit();
			this.tabEmAndamento.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDadosEmAndamento)).EndInit();
			this.tabConcluidas.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDadosConcluidas)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
