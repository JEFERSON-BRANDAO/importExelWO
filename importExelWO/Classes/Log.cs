﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Log
    {
        public void Gravar(string Funcao, string Mensagem)
        {
            #region CRIA AQUIVO DE LOG .txt

            string hora = DateTime.Now.Hour.ToString().Length == 1 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString();
            string minuto = DateTime.Now.Minute.ToString().Length == 1 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString();
            string segundo = DateTime.Now.Second.ToString().Length == 1 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString();
            //
            string dataHora = DateTime.Now.Date.ToString("dd-MM-yyyy") + " " + hora + ":" + minuto + ":" + segundo;
            string nomeArquivo = AppDomain.CurrentDomain.BaseDirectory + @"\LOG\HISTORICO.txt";
            //
            if (!System.IO.File.Exists(nomeArquivo))//quando arquivo não exite. Criado pela 1ra vez
            {
                System.IO.File.Create(nomeArquivo).Close();
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(nomeArquivo))
                {

                    string historico = string.Empty;
                    //
                    if (Mensagem.Contains("OK"))
                    {
                        historico = "[" + dataHora + "] - " + Mensagem;
                    }
                    else
                    {
                        historico = string.IsNullOrEmpty(Funcao) ? "[" + dataHora + "] - ERRO: " + Mensagem : "[" + dataHora + "] - ERRO - FUNÇÃO: " + Funcao + ", " + Mensagem;

                    }

                    //
                    sw.WriteLine(historico);
                    sw.Close();
                }
            }
            else
            {
                using (System.IO.StreamWriter sw = System.IO.File.AppendText(nomeArquivo))
                {
                    string historico = string.Empty;
                    //
                    if (Mensagem.Contains("OK"))
                    {
                        historico = "[" + dataHora + "] - " + Mensagem;
                    }
                    else
                    {
                        historico = string.IsNullOrEmpty(Funcao) ? "[" + dataHora + "] - ERRO: " + Mensagem : "[" + dataHora + "] - ERRO - FUNÇÃO: " + Funcao + ", " + Mensagem;

                    }
                    //
                    sw.WriteLine(historico);
                    sw.Close();
                }
            }

            #endregion
        }
    }
}
