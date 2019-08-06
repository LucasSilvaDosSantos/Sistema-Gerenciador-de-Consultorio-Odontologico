using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Consultorio.Model
{
    public class Odontograma
    {
        public int Id { get; set; }

        /*
        os dentes seram numerados da esquerda para a direita sendo o 01 referente ao 18 
        do odontograma anatomico e o 32 sendo referente ao 48 do mesmo organograma      
        */
        public string Dente01 { get; set; }
        public string Dente02 { get; set; }
        public string Dente03 { get; set; }
        public string Dente04 { get; set; }
        public string Dente05 { get; set; }
        public string Dente06 { get; set; }
        public string Dente07 { get; set; }
        public string Dente08 { get; set; }
        public string Dente09 { get; set; }
        public string Dente10 { get; set; }


        public string Dente11 { get; set; }
        public string Dente12 { get; set; }
        public string Dente13 { get; set; }
        public string Dente14 { get; set; }
        public string Dente15 { get; set; }
        public string Dente16 { get; set; }
        public string Dente17 { get; set; }
        public string Dente18 { get; set; }
        public string Dente19 { get; set; }
        public string Dente20 { get; set; }


        public string Dente21 { get; set; }
        public string Dente22 { get; set; }
        public string Dente23 { get; set; }
        public string Dente24 { get; set; }
        public string Dente25 { get; set; }
        public string Dente26 { get; set; }
        public string Dente27 { get; set; }
        public string Dente28 { get; set; }
        public string Dente29 { get; set; }
        public string Dente30 { get; set; }


        public string Dente31 { get; set; }
        public string Dente32 { get; set; }

        public Odontograma()
        {
        }

        public Odontograma(string dente01, string dente02, string dente03, string dente04, string dente05, string dente06, string dente07, string dente08, string dente09, 
            string dente10, string dente11, string dente12, string dente13, string dente14, string dente15, string dente16, string dente17, string dente18, string dente19, 
            string dente20, string dente21, string dente22, string dente23, string dente24, string dente25, string dente26, string dente27, string dente28, string dente29, 
            string dente30, string dente31, string dente32)
        {
            Dente01 = dente01;
            Dente02 = dente02;
            Dente03 = dente03;
            Dente04 = dente04;
            Dente05 = dente05;
            Dente06 = dente06;
            Dente07 = dente07;
            Dente08 = dente08;
            Dente09 = dente09;
            Dente10 = dente10;
            Dente11 = dente11;
            Dente12 = dente12;
            Dente13 = dente13;
            Dente14 = dente14;
            Dente15 = dente15;
            Dente16 = dente16;
            Dente17 = dente17;
            Dente18 = dente18;
            Dente19 = dente19;
            Dente20 = dente20;
            Dente21 = dente21;
            Dente22 = dente22;
            Dente23 = dente23;
            Dente24 = dente24;
            Dente25 = dente25;
            Dente26 = dente26;
            Dente27 = dente27;
            Dente28 = dente28;
            Dente29 = dente29;
            Dente30 = dente30;
            Dente31 = dente31;
            Dente32 = dente32;
        }
    }
}
