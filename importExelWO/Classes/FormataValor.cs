using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classes
{
    public class FormataValor
    {
        public int VericaFormatacao(string valor)
        {
            int cont = 0;
            //
            string strValor = string.Empty;
            //
            if (string.IsNullOrEmpty(valor))
            {
                strValor = string.Empty;
            }
            else
            {
                if (valor.Length > 0)
                {

                    if (valor.Contains(".")) 
                    {
                        cont++;
                    }
                   
                }
            }
            //
            return cont;
        }
    }
}