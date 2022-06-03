using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    class PartNumber
    {
        public List<string> Codigo()
        {
            string partNumber;
            List<string> lista = new List<string>();

            //ler linha por linha
            string caminho = AppDomain.CurrentDomain.BaseDirectory + @"\CONFIGURACAO\PARTNUMBER.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(caminho);
            while ((partNumber = file.ReadLine()) != null)
            {
                if (partNumber != string.Empty)
                    lista.Add(partNumber);
            }
            //
            file.Close();
            //
            return lista;
        }
    }
}
