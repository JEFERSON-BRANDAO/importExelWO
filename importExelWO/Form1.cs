using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP.Middleware.Connector;
using System.Data.OleDb;
using System.Globalization;// SAP .NET Connector
using Classes;


// ===============================
// AUTHOR       : JEFFERSON BRANDÃO DA COSTA - ANALISTA/PROGRAMADOR
// CREATE DATE  : 06/07/2017  dd/mm/yyyy
// DESCRIPTION  : baixar wo do sap
// SPECIAL NOTES: Inclusão função automática
// ===============================
// Change History: version 1.0.0.7
// Date: 04/03/2021
//==================================


namespace importExelWO
{
    public partial class Form1 : Form
    {
        int statusConexao = 0;
        internal DataTable dtb = null;

        int segundos = 0;
        int tempo = 0;
        //
        public Form1()
        {
            InitializeComponent();
            //
            #region RODAPÉ

            int anoCriacao = 2017;
            int anoAtual = DateTime.Now.Year;
            string texto = anoCriacao == anoAtual ? " Foxconn CNSBG All Rights Reserved." : "-" + anoAtual + " Foxconn CNSBG All Rights Reserved.";
            //
            lbRodape.Text = "Copyright © " + anoCriacao + texto;

            #endregion
            //  

            lbTotalItens.Visible = false;
            pictureBoxCarregando.Visible = false;
            //
            txtDescricao.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            lbStatus.Text = "DESCONECTADO";
            lbStatus.ForeColor = System.Drawing.Color.Red;
            //
            timerCount.Interval = 1000;
            timerCount.Start();
            //
            dtb = new DataTable();
            dtb = CriaDataTable();

            //Inicia auto ao carregar o programa
            btnSalvar.Enabled = false;
            Ligar();

        }
        // 
        public void ConectarSAP(string modo)
        {
            #region DADOS arquivo.txt
            //
            string IpServer = string.Empty;
            string Number = string.Empty;
            string User = string.Empty;
            string Password = string.Empty;
            string Client = string.Empty;
            string Cust = string.Empty;
            string Bu = string.Empty;
            string Day = string.Empty;
            //
            int ERRO = 0;
            string msgERRO = string.Empty;
            //
            try
            {
                string caminho = AppDomain.CurrentDomain.BaseDirectory + @"\CONFIGURACAO\configSAP.txt";
                string linha;
                int row = 0;
                //
                if (System.IO.File.Exists(caminho))
                {
                    System.IO.StreamReader arqTXT = new System.IO.StreamReader(caminho);
                    //
                    while ((linha = arqTXT.ReadLine()) != null)
                    {
                        if (row == 0)//primeira linha do .txt
                        {
                            for (int indice = 0; indice < linha.Length; indice++)
                            {
                                if (indice > 9)//IP_SERVER:xx.xx.xxx.xxx pega string a partir da décima posição
                                {
                                    IpServer += linha[indice];
                                }
                            }
                        }
                        //
                        if (row == 1)//segunda linha do .txt
                        {
                            for (int indice = 0; indice < linha.Length; indice++)
                            {
                                if (indice > 6)
                                {
                                    Number += linha[indice];
                                }
                            }
                        }
                        //
                        if (row == 2)//terceira linha do .txt
                        {
                            for (int indice = 0; indice < linha.Length; indice++)
                            {
                                if (indice > 4)
                                {
                                    User += linha[indice];
                                }
                            }
                        }
                        //
                        if (row == 3)//quarta linha do .txt
                        {
                            for (int indice = 0; indice < linha.Length; indice++)
                            {
                                if (indice > 8)
                                {
                                    Password += linha[indice];
                                }
                            }
                        }
                        //
                        if (row == 4)//quinta linha do .txt
                        {
                            for (int indice = 0; indice < linha.Length; indice++)
                            {
                                if (indice > 6)
                                {
                                    Client += linha[indice];
                                }
                            }
                        }
                        //
                        if (row == 5)//sexta linha do .txt
                        {
                            for (int indice = 0; indice < linha.Length; indice++)
                            {
                                if (indice > 4)
                                {
                                    Cust += linha[indice];
                                }
                            }
                        }
                        //
                        if (row == 6)//sétima linha do .txt
                        {
                            for (int indice = 0; indice < linha.Length; indice++)
                            {
                                if (indice > 2)
                                {
                                    Bu += linha[indice];
                                }
                            }
                        }
                        //
                        if (row == 7)//oitava linha do .txt
                        {
                            for (int indice = 0; indice < linha.Length; indice++)
                            {
                                if (indice > 3)
                                {
                                    Day += linha[indice];
                                }
                            }
                        }
                        //
                        row++;
                    }
                    //
                    arqTXT.Close();
                }
                else
                {
                    msgERRO = @"Arquivo \CONFIG\nomeBase.txt  não existe. Favor criar.";
                    ERRO++;
                }
            }
            catch (Exception erro)
            {
                msgERRO = erro.Message;
                ERRO++;
            }

            #endregion
            //
            if (ERRO == 0)
            {
                string date = txtDescricao.Text;
                DateTimeFormatInfo ukDtfi = new CultureInfo("pt-BR", false).DateTimeFormat;
                DateTime SqlData = new DateTime();
                DateTime.TryParse(date, ukDtfi, DateTimeStyles.None, out SqlData);
                //
                if (Convert.ToString(SqlData) == "1/1/0001 00:00:00")
                {
                    ERRO++;
                    msgERRO = "ERRO:: Data inválida!";
                }
                //
                if (ERRO == 0)
                {
                    try
                    {
                        #region CONEXÃO COM SAP

                        RfcConfigParameters parms = new RfcConfigParameters();
                        parms.Add(RfcConfigParameters.Name, "R/3");
                        parms.Add(RfcConfigParameters.AppServerHost, IpServer.Trim()); //The SAP host IP
                        parms.Add(RfcConfigParameters.SystemNumber, Number.Trim()); //The SAP instance
                        parms.Add(RfcConfigParameters.User, User.Trim()); //User name
                        parms.Add(RfcConfigParameters.Password, Password.Trim()); //Cipher
                        parms.Add(RfcConfigParameters.Client, Client.Trim()); // Client
                        parms.Add(RfcConfigParameters.Language, "EN"); //Logon language
                        parms.Add(RfcConfigParameters.PoolSize, "5");
                        //parms.Add(RfcConfigParameters.MaxPoolSize, "10");
                        parms.Add(RfcConfigParameters.IdleTimeout, "60");
                        //
                        RfcDestination prd = RfcDestinationManager.GetDestination(parms);
                        RfcRepository repo = prd.Repository;
                        IRfcFunction fn = repo.CreateFunction("ZRFC_SFC_NSG_0001B");
                        //
                        string planta = string.Empty;
                        //
                        if (rbt451F.Checked)
                        {
                            planta = "451F";
                        }
                        else if (rbt451T.Checked)
                        {
                            planta = "451T";
                        }
                        else if (rbt451U.Checked)
                        {
                            planta = "451U";
                        }
                        else if (rbt451R.Checked)
                        {
                            planta = "451R";
                        }
                        else if (rbt461A.Checked)
                        {
                            planta = "461A";
                        }
                        else if (rbt461B.Checked)
                        {
                            planta = "461B";
                        }
                        //
                        fn.SetValue("PLANT", planta.Trim());
                        //fn.SetValue("SCHEDULED_DATE", "20170629");//programado  yyyy-mm-dd
                        fn.SetValue("RLDATE", SqlData.ToString("yyyy-MM-dd").Replace("-", ""));//data da liberação
                        fn.SetValue("COUNT", Day.Trim());
                        fn.SetValue("CUST", Cust.Trim());
                        //
                        fn.Invoke(prd);

                        #endregion

                        IRfcTable tb_WO_HEADER = fn.GetTable("WO_HEADER");
                        IRfcTableView view = (tb_WO_HEADER as ISupportTableView).DefaultView;
                        // this.dataGridView_WO.DataSource = view;
                        //
                        int linhaTabela = view.Table.RowCount;
                        //
                        if (linhaTabela > 0)
                        {
                            lbTotalItens.Visible = true;
                            lbTotalItens.Text = "TOTAL: " + linhaTabela;
                            //usuário visualizar
                            #region PREENCHE GRID COM dataTable

                            int index = 1;
                            //string sfb05 = string.Empty;
                            //
                            foreach (IRfcStructure row_HEADER in tb_WO_HEADER)
                            {
                                string sfb05 = row_HEADER.GetValue("MATNR").ToString();

                                //quando for ordens de retrabalho. Não retorna partnumber
                                #region PROCURANDO PARTNUMBER DE ORDEM DE RETRABALHO

                                if (string.IsNullOrEmpty(sfb05))
                                {
                                    bool partnumber_ = false;
                                    IRfcTable tb_WO_ITEM = fn.GetTable("WO_ITEM");
                                    IRfcTableView view2 = (tb_WO_ITEM as ISupportTableView).DefaultView;
                                    //
                                    foreach (IRfcStructure row_ITEM in tb_WO_ITEM)
                                    {
                                        string AUFNR = row_ITEM.GetValue("AUFNR").ToString();//WO
                                        string REVLV = row_ITEM.GetValue("REVLV").ToString();//RE
                                        string MATNR = row_ITEM.GetValue("MATNR").ToString();//MATERIAL or PARTNUMBER

                                        ////percorre as linhas entre os códigos de material até chegar ao partnumber. Quando REVLV for vázio, é código de material. Senão, é partnumber
                                        //if (!string.IsNullOrEmpty(REVLV))
                                        //{
                                        //    partnumber_ = true;
                                        //}

                                        //
                                        if (row_HEADER.GetValue("AUFNR").ToString() == AUFNR)//WO
                                        {
                                            ////percorre as linhas entre os códigos de material até chegar ao partnumber. Quando REVLV for vázio, é código de material. Senão, é partnumber
                                            //if ((!string.IsNullOrEmpty(REVLV)) || (MATNR.Equals("ARCT05716")))//TGBR ARCT05716
                                            //{
                                            //    partnumber_ = true;
                                            //}

                                            //if (partnumber_)
                                            //{
                                            //    sfb05 = MATNR;
                                            //    break;
                                            //}

                                            PartNumber partnumber = new PartNumber();
                                            int linhaTotal = partnumber.Codigo().Count;
                                            //
                                            for (int linha = 0; linha < linhaTotal; linha++)
                                            {
                                                string codigo = partnumber.Codigo()[linha].Trim().ToUpper();
                                                //
                                                if (MATNR.Equals(codigo))
                                                {
                                                    partnumber_ = true;
                                                    break;
                                                }
                                            }
                                            //
                                            if (partnumber_)
                                            {
                                                sfb05 = MATNR;
                                                break;
                                            }
                                        }

                                    }
                                }

                                #endregion

                                //
                                string wo_ = row_HEADER.GetValue("AUFNR").ToString();
                                string planta_ = row_HEADER.GetValue("WERKS").ToString();
                                string tipo_ = row_HEADER.GetValue("AUART").ToString();
                                string partNumber_ = sfb05;//row.GetValue("MATNR").ToString();
                                string quantidade_ = row_HEADER.GetValue("GAMNG").ToString();

                                //
                                incluirNoDataTable(index, wo_, planta_, tipo_, partNumber_, quantidade_, dtb);
                                index++;
                            }
                            //
                            dataGridView_WO.DataSource = null;
                            dataGridView_WO.DataSource = dtb;

                            ////
                            //dataGridView_WO.Columns[0].HeaderText = "WO";
                            //dataGridView_WO.Columns[1].HeaderText = "PLANTA";
                            //dataGridView_WO.Columns[2].HeaderText = "TIPO";
                            //dataGridView_WO.Columns[3].HeaderText = "PART_NO";
                            //dataGridView_WO.Columns[7].HeaderText = "QUANTIDADE";

                            #endregion
                            //
                            #region Tabela WO_HEADER - SAP

                            int salvos = 0;
                            int naoSalvos = 0;
                            int existentes = 0;

                            //pegando os dados da tabela do SAP
                            foreach (IRfcStructure row in tb_WO_HEADER)
                            {
                                string wo = row.GetValue("AUFNR").ToString();//sfb01
                                string sfb02 = row.GetValue("AUART").ToString();
                                string sfb04 = "1";
                                string sfb05 = row.GetValue("MATNR").ToString();
                                string sfb07 = "00";
                                string quantidade = string.Empty;
                                //
                                if (row.GetValue("GAMNG").ToString().Length > 0)
                                {
                                    int permitir = 0;
                                    string GAMNG = row.GetValue("GAMNG").ToString();
                                    //
                                    for (int linha = 0; linha < GAMNG.Length; linha++)
                                    {
                                        if ((GAMNG[linha].ToString() == ",") || (GAMNG[linha].ToString() == "."))//desconsidera zeros após .xxxxxxxx ou ,xxxxxxxx
                                        {
                                            permitir++;
                                        }
                                        //
                                        if (permitir == 0)
                                            quantidade += GAMNG[linha].ToString();//sfb08
                                    }
                                }
                                else
                                {
                                    quantidade = "0"; //row.GetValue("GAMNG").ToString();//sfb08
                                }
                                //
                                string sfb81 = Convert.ToDateTime(row.GetValue("ERDAT").ToString()).ToString("yyyy-MM-dd");
                                string sfb13 = Convert.ToDateTime(row.GetValue("GSTRS").ToString()).ToString("yyyy-MM-dd");
                                string sfb22 = row.GetValue("KDAUF").ToString();
                                //
                                string ERDAT = Convert.ToDateTime(row.GetValue("ERDAT").ToString()).ToString("yyyy-MM-dd");
                                string Hora = DateTime.Now.Hour.ToString();
                                string minuto = DateTime.Now.Minute.ToString();
                                string segundo = DateTime.Now.Second.ToString();
                                string editDate = ERDAT + " " + Hora + ":" + minuto + ":" + segundo;
                                //
                                if (VerificaWO_Existente(wo, modo) == string.Empty)
                                {
                                    //quando for ordens de retrabalho. Não retorna partnumber
                                    if (string.IsNullOrEmpty(sfb05))
                                    {
                                        bool partnumber_ = false;
                                        IRfcTable tb_WO_ITEM = fn.GetTable("WO_ITEM");
                                        IRfcTableView view2 = (tb_WO_ITEM as ISupportTableView).DefaultView;
                                        //
                                        foreach (IRfcStructure row2 in tb_WO_ITEM)
                                        {
                                            string AUFNR = row2.GetValue("AUFNR").ToString();//WO
                                            string REVLV = row2.GetValue("REVLV").ToString();//RE
                                            string MATNR = row2.GetValue("MATNR").ToString();//MATERIAL or PARTNUMBER

                                            ////percorre as linhas entre os códigos de material até chegar ao partnumber. Quando REVLV for vázio, é código de material. Senão, é partnumber
                                            //if (!string.IsNullOrEmpty(REVLV))
                                            //{
                                            //    partnumber_ = true;
                                            //}
                                            //
                                            if (wo == AUFNR)
                                            {
                                                ////percorre as linhas entre os códigos de material até chegar ao partnumber. Quando REVLV for vázio, é código de material. Senão, é partnumber
                                                //if ((!string.IsNullOrEmpty(REVLV)) || (MATNR.Equals("ARCT05716")))//TGBR ARCT05716
                                                //{
                                                //    partnumber_ = true;
                                                //}

                                                //if (partnumber_)
                                                //{
                                                //    sfb05 = MATNR;
                                                //    break;
                                                //}

                                                PartNumber partnumber = new PartNumber();
                                                int linhaTotal = partnumber.Codigo().Count;
                                                //
                                                for (int linha = 0; linha < linhaTotal; linha++)
                                                {
                                                    string codigo = partnumber.Codigo()[linha].Trim().ToUpper();
                                                    //
                                                    if (MATNR.Equals(codigo))
                                                    {
                                                        partnumber_ = true;
                                                        break;
                                                    }
                                                }
                                                //
                                                if (partnumber_)
                                                {
                                                    sfb05 = MATNR;
                                                    break;
                                                }
                                            }

                                        }
                                    }

                                    //salva na tabela SFB_FILE
                                    string salvou = Salvar(wo, sfb02, sfb04, sfb05, sfb07, quantidade, sfb81, sfb13, sfb22, editDate, modo);
                                    if (salvou == "1")
                                    {
                                        salvos++;

                                        if (modo.Equals("AUTO"))
                                        {
                                            Log log = new Log();
                                            log.Gravar(string.Empty, "OK - WO:" + wo + " - PARTNUMBER:" + sfb05);
                                        }
                                    }
                                    else
                                    {
                                        naoSalvos++;
                                    }
                                }
                                else
                                {
                                    existentes++;
                                }
                            }
                            //
                            if (modo.Equals("MANUAL"))
                            {
                                MessageBox.Show("[" + salvos + " WO salva(s)]" + " [" + existentes + " WO existente(s)] " + " [" + naoSalvos + " WO com Problema para salvar]");
                            }
                            #endregion
                        }
                        else
                        {
                            if (modo.Equals("MANUAL"))
                            {
                                MessageBox.Show("AVISO:: Nenhum registro encontrado", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                    catch (Exception erro)
                    {
                        Desconectado();
                        //
                        if (modo.Equals("AUTO"))
                        {
                            Log log = new Log();
                            log.Gravar("CONEXÃO COM SAP", erro.Message);
                        }
                        else
                        {
                            MessageBox.Show("ERRO:: " + erro.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    Desconectado();
                    //
                    if (modo.Equals("AUTO"))
                    {
                        Log log = new Log();
                        log.Gravar("DATA", msgERRO);
                    }
                    else
                    {
                        MessageBox.Show("ERRO:: " + msgERRO, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                Desconectado();
                //
                if (modo.Equals("AUTO"))
                {
                    Log log = new Log();
                    log.Gravar("DADOS arquivo.txt", msgERRO);
                }
                else
                {
                    MessageBox.Show("ERRO:: " + msgERRO, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public DataTable CriaDataTable()
        {
            #region COLUNAS
            //colunas
            DataTable dtTable = new DataTable();

            // Create DataColumn objects of data types.
            DataColumn coluna;
            coluna = new DataColumn();
            coluna.DataType = Type.GetType("System.String");
            coluna.ColumnName = "#";
            dtTable.Columns.Add(coluna);

            coluna = new DataColumn();
            coluna.DataType = Type.GetType("System.String");
            coluna.ColumnName = "WO";
            dtTable.Columns.Add(coluna);

            coluna = new DataColumn();
            coluna.DataType = Type.GetType("System.String");
            coluna.ColumnName = "PLANTA";
            dtTable.Columns.Add(coluna);

            coluna = new DataColumn();
            coluna.DataType = Type.GetType("System.String");
            coluna.ColumnName = "TIPO";
            dtTable.Columns.Add(coluna);

            coluna = new DataColumn();
            coluna.DataType = Type.GetType("System.String");
            coluna.ColumnName = "PART_NO";
            dtTable.Columns.Add(coluna);

            coluna = new DataColumn();
            coluna.DataType = Type.GetType("System.String");
            coluna.ColumnName = "QUANTIDADE";
            dtTable.Columns.Add(coluna);

            return dtTable;

            #endregion
        }

        private void incluirNoDataTable(int index, string WO, string PLANTA, string TIPO, string PART_NO, string QUANTIDADE, DataTable dtTable)
        {
            #region LINHAS

            DataRow linha = dtTable.NewRow();
            //
            linha["#"] = index;//Guid.NewGuid().ToString();
            linha["WO"] = WO;
            linha["PLANTA"] = PLANTA;
            linha["TIPO"] = TIPO;
            linha["PART_NO"] = PART_NO;
            linha["QUANTIDADE"] = QUANTIDADE;
            //
            dtTable.Rows.Add(linha);

            #endregion
        }

        public void Desconectado()
        {
            lbTotalItens.Visible = false;
            timerCount.Stop();
            this.dataGridView_WO.DataSource = null;
            pictureBoxCarregando.Visible = false;
            lbStatus.Text = "DESCONECTADO";
            lbStatus.ForeColor = System.Drawing.Color.Red;
            dtb.Clear();
        }

        public string VerificaWO_Existente(string wo, string modo)
        {
            #region VERIFICANDO WORK ORDER EXISTENTE

            string msg = string.Empty;
            string resultado = string.Empty;
            //
            OleDbConnect Objconn = new OleDbConnect();
            //
            try
            {
                try
                {
                    Objconn.String_Connection();//string de conexao
                    Objconn.Conectar();
                    Objconn.Parametros.Clear();

                    //add 00 na frente das ordens que começam  **23
                    if (wo.Length == 10)
                        wo = "00" + wo;

                    //add 0000 na frente das ordens que começam  ****33xxxxxx
                    if (wo.Length == 8)
                        wo = "0000" + wo;

                    //
                    //string sql = "select SFB01 from sfb_file where SFB01 = '" + wo + "'";
                    string sql = string.Format("select SFB01 from sfb_file where SFB01 = '{0}'", wo);
                    Objconn.SetarSQL(sql);
                    Objconn.Executar();


                }
                catch (Exception erro)
                {
                    msg = erro.Message;
                    //
                    if (modo.Equals("AUTO"))
                    {
                        Log log = new Log();
                        log.Gravar("VerificaWO_Existente", msg);
                    }
                    else
                    {
                        MessageBox.Show("ERRO:: " + msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            finally
            {
                Objconn.Desconectar();
            }

            //
            if (Objconn.Tabela.Rows.Count > 0)
            {
                resultado = Objconn.Tabela.Rows[0]["SFB01"].ToString();
                msg = resultado.Trim();
            }
            else
            {
                // permitido salvar ordem, pois não existe
                resultado = string.Empty;
                msg = resultado;
            }

            return msg;

            #endregion
        }

        public string Salvar(string wo, string sfb02, string sfb04, string sfb05, string sfb07, string quantidade, string sfb81, string sfb13, string sfb22, string editDate, string modo)
        {
            #region INSERT  sfb_file

            string msg = string.Empty;
            string mensagem = string.Empty;
            //
            OleDbConnect Objconn = new OleDbConnect();
            //
            try
            {
                try
                {
                    Objconn.String_Connection();//string de conexao
                    Objconn.Conectar();
                    Objconn.Parametros.Clear();

                    //add 00 na frente das ordens que começam  **23xxxxxxxx
                    if (wo.Length == 10)
                        wo = "00" + wo;

                    //add 0000 na frente das ordens que começam  ****33xxxxxx
                    if (wo.Length == 8)
                        wo = "0000" + wo;

                    //                    string sql = @"insert into sfb_file (SFB01, SFB02, SFB04, SFB05, SFB07, SFB08, SFB81, SFB13, SFB22, EDIT_DATE)
                    //                                               values('" + wo + "','" + sfb02 + "','" + sfb04 + "','" + sfb05 + "','" + sfb07 + "','" + quantidade + "', '" + sfb81 + "', '" + sfb13 + "', '" + sfb22 + "', '" + editDate + "' )";
                    //                    //   
                    string sql = string.Format("insert into sfb_file (SFB01, SFB02, SFB04, SFB05, SFB07, SFB08, SFB81, SFB13, SFB22, EDIT_DATE) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}' )", wo, sfb02, sfb04, sfb05, sfb07, quantidade, sfb81, sfb13, sfb22, editDate);

                    Objconn.SetarSQL(sql);
                    Objconn.Executar();


                }
                catch (Exception erro)
                {
                    msg = erro.Message;
                    //
                    if (modo.Equals("AUTO"))
                    {
                        Log log = new Log();
                        log.Gravar("INSERT  sfb_file", msg);
                    }
                    else
                    {
                        MessageBox.Show("AVISO::" + msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            finally
            {
                Objconn.Desconectar();
            }
            //
            if (Objconn.Isvalid)
            {
                msg = "1";
            }
            else
            {
                msg = Objconn.Message;
                //
                if (modo.Equals("AUTO"))
                {
                    Log log = new Log();
                    log.Gravar("INSERT sfb_file -Objconn.Isvalid", msg);
                }
                else
                {
                    MessageBox.Show("AVISO::" + msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return msg;

            #endregion
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            lbTotalItens.Text = string.Empty;
            this.dataGridView_WO.DataSource = null;
            dtb.Clear();
            pictureBoxCarregando.Visible = true;
            //
            lbStatus.Text = "CONECTANDO AO SAP...";
            lbStatus.ForeColor = System.Drawing.Color.Blue;
            //
            timerCount.Start();
            statusConexao = 1;

        }

        private void timerCount_Tick(object sender, EventArgs e)
        {

            timerCount.Stop();
            timerCount.Start();
            //
            if (statusConexao == 1)
            {
                if (btnSalvar.Enabled)
                {
                    timerCount.Stop();

                    ConectarSAP("MANUAL");
                    //
                    pictureBoxCarregando.Visible = false;
                    lbStatus.Text = "DESCONECTADO";
                    lbStatus.ForeColor = System.Drawing.Color.Red;
                }
                else//automatico
                {
                    lbtime.Text = segundos.ToString() + ":s";
                    segundos = segundos + 1;

                    //461A
                    if (segundos == tempo)//tempo em segundos
                    {
                        lbTotalItens.Visible = false;
                        //limpa consulta
                        this.dataGridView_WO.DataSource = null;
                        pictureBoxCarregando.Visible = false;
                        dtb.Clear();
                        //altera planta
                        rbt461A.Checked = true;
                        rbt461B.Checked = false;
                        //conecta com sap
                        ConectarSAP("AUTO");

                        //atualiza data
                        txtDescricao.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

                    }

                    //461B
                    if (segundos == (tempo + 10))
                    {
                        lbTotalItens.Visible = false;
                        //limpa consulta
                        this.dataGridView_WO.DataSource = null;
                        pictureBoxCarregando.Visible = false;
                        dtb.Clear();
                        //altara planta
                        rbt461A.Checked = false;
                        rbt461B.Checked = true;
                        //conecta com sap
                        ConectarSAP("AUTO");
                        //
                        segundos = 0;

                        //atualiza data
                        txtDescricao.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

                    }

                }

            }
            else
            {
                this.dataGridView_WO.DataSource = null;
                pictureBoxCarregando.Visible = false;
                //
                lbStatus.Text = "DESCONECTADO";
            }
        }

        public void Clear_ProgressBar()
        {
            //progressBar1.Value = 0;
            lbStatus.Text = string.Empty;
            //
            tempo = GetTempo();
        }

        public int GetTempo()
        {
            #region SEGUNDOS txt

            string arquivo = AppDomain.CurrentDomain.BaseDirectory + @"\CONFIGURACAO\TEMPO.txt";
            string linha;
            int tempo = 0;
            string aux = string.Empty;
            //
            if (System.IO.File.Exists(arquivo))
            {
                System.IO.StreamReader arqTXT = new System.IO.StreamReader(arquivo);
                //
                while ((linha = arqTXT.ReadLine()) != null)
                {
                    for (int index = 0; index < linha.Length; index++)
                    {
                        aux += linha[index];
                    }
                }
                //
                arqTXT.Close();
            }

            tempo = string.IsNullOrEmpty(aux) ? tempo : int.Parse(aux.Trim());
            //
            return tempo;

            #endregion
        }

        public void Ligar()
        {
            lbStatus.Text = "LIGADO";
            lbStatus.Visible = true;
            lbStatus.ForeColor = System.Drawing.Color.Blue;
            timerCount.Start();
            statusConexao = 1;
            //
            Clear_ProgressBar();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            Ligar();
        }

        private void btParar_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;

            lbStatus.Text = "PARADO";
            lbStatus.Visible = true;
            lbStatus.ForeColor = System.Drawing.Color.Red;
            timerCount.Stop();
            //
            lbtime.Text = "0:s";
            segundos = 0;

            //lbStatus.Text = "DESCONECTADO ";
            //lbStatus.ForeColor = System.Drawing.Color.Red;

            tempo = GetTempo();
            Clear_ProgressBar();
        }

        //private void dataGridView_WO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (e.ColumnIndex == 0 || e.Value == null) return;
        //    byte[] array = (byte[])e.Value;
        //    e.Value = string.Empty;
        //    foreach (byte b in array)
        //    {
        //        e.Value += String.Format("{0:x2} ", b);
        //    }
        //}

    }
}
