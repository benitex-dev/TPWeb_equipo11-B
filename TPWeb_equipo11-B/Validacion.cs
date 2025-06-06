﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TPWeb_equipo11_B
{
    public static class Validacion
    {
        public static bool validaTextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                    return true;
                else
                    return false;

            }


            return false;
        }


        public static bool validaNumeros(object control)
        {
            if(control is TextBox texto)
            {
                if (texto.Text.Length == 8 && texto.Text.All(char.IsDigit))
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}