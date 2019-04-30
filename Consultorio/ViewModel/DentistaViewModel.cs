﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Model;

namespace Consultorio.ViewModel
{
    class DentistaViewModel
    {
        public static string CadastroDeNovoDentista(Dentista dentista)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.Dentistas.Add(dentista);
                    ctx.SaveChanges();
                    return ("Salvo novo dentista");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ("error" + e.Message);
            }
        }
    }
}
