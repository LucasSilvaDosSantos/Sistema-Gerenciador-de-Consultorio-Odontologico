using System.ComponentModel.DataAnnotations;

namespace Consultorio.Model
{
    public class Anamnese
    {
        //[Required] Not Null

        // P** representa o numero da pergunta no questionario da view
        [Required]
        public int Id { get; set; }

        //01. No momento, está em tratamento médico?
        [Required]
        public bool P01 { get; set; }

        //Por quê?
        public string P01ComplementoPq { get; set; }

        //Tel. do Médico:
        public string P01ComplementoTel { get; set; }

        //02. Está tomando algum remédio (receitado ou não)
        [Required]
        public bool P02 { get; set; }

        //Quais?
        public string P02Complemento { get; set; }

        //03. Tem alergia a algum medicamento, Qual?
        [Required]
        public bool P03 { get; set; }

        //Qual?
        public string P03Complemento { get; set; }

        //04. Tem gânglios doloridos em alguma região do corpo?
        [Required]
        public bool P04 { get; set; }

        // 04 regial do corpo
        public string P04Complemento { get; set; }

        //05. Está grávida no momento?
        [Required]
        public bool P05 { get; set; }

        //Mês:
        public string P05Complemento { get; set; }

        //06. As feridas demoram para cicatrizar?
        [Required]
        public bool P06 { get; set; }

        //07. Sangra muito quando se fere ou extrai dente?
        [Required]
        public bool P07 { get; set; }

        //08. É fumante?
        [Required]
        public bool P08 { get; set; }

        //09. Você tem Diabetes? Se tem, é compensada?
        [Required]
        public bool P09 { get; set; }

        //Se tem, é compensada?
        public string P09Complemento { get; set; }

        //10. Tem dificuldade de digestão?
        [Required]
        public bool P10 { get; set; }

        //11. Alguma vez já tomou Penicilina ou outro antibiótico?
        [Required]
        public bool P11 { get; set; }

        //12. Teve alguma reação anormal?
        [Required]
        public bool P12 { get; set; }

        //13. Costuma sentir tontura ou desmaiar com frequência?
        [Required]
        public bool P13 { get; set; }

        //14. É portador de HIV (AIDS)?
        [Required]
        public bool P14 { get; set; }

        //15. Tem contato com pessoas portadoras  de AIDS?
        [Required]
        public bool P15 { get; set; }

        //16. É portador de distúrbios cardíacos?
        [Required]
        public bool P16 { get; set; }

        //17. Tem conhecimento de sua pressão?
        [Required]
        public bool P17 { get; set; }

        // Qual?
        public string P17Complemento { get; set; }

        //18. Sua mandíbula estala quando mastiga?
        [Required]
        public bool P18 { get; set; }

        //19. Sente dor na articulação têmporo-mandibular (perto do ouvido)?
        [Required]
        public bool P19 { get; set; }

        //20. Teve alguma reação anormal com anestesia local para tratar ou extrair dente?
        [Required]
        public bool P20 { get; set; }

        //21. Teve convulsões alguma vez?
        [Required]
        public bool P21 { get; set; }

        //22. Tem problemas no Fígado ou Rim?
        [Required]
        public bool P22 { get; set; }

        //23. Teve Hepatite?
        [Required]
        public bool P23 { get; set; }

        //24. Tem Asma?
        [Required]
        public bool P24 { get; set; }

        //25. Sente sua gengiva inchada ou sangrando?
        [Required]
        public bool P25 { get; set; }

        //26. Teve Sinusite?
        [Required]
        public bool P26 { get; set; }

        //27. Teve Febre Reumática?
        [Required]
        public bool P27 { get; set; }

        public string Obs { get; set; }

        public Anamnese()
        {
        }

        public Anamnese(bool p01, bool p02, bool p03, bool p04, bool p05, bool p06, bool p07, bool p08, bool p09,
            bool p10, bool p11, bool p12, bool p13, bool p14, bool p15, bool p16, bool p17, bool p18, bool p19,
            bool p20, bool p21, bool p22, bool p23, bool p24, bool p25, bool p26, bool p27)
        {
            P01 = p01;
            P02 = p02;
            P03 = p03;
            P04 = p04;
            P05 = p05;
            P06 = p06;
            P07 = p07;
            P08 = p08;
            P09 = p09;
            P10 = p10;
            P11 = p11;
            P12 = p12;
            P13 = p13;
            P14 = p14;
            P15 = p15;
            P16 = p16;
            P17 = p17;
            P18 = p18;
            P19 = p19;
            P20 = p20;
            P21 = p21;
            P22 = p22;
            P23 = p23;
            P24 = p24;
            P25 = p25;
            P26 = p26;
            P27 = p27;
        }

        public Anamnese(bool p01, string p01ComplementoPq, string p01ComplementoTel, bool p02, string p02Complemento, bool p03, string p03Complemento, bool p04, bool p05,
            string p05Complemento, bool p06, bool p07, bool p08, bool p09, string p09Complemento, bool p10, bool p11, bool p12, bool p13, bool p14, bool p15, bool p16, bool p17,
            string p17Complemento, bool p18, bool p19, bool p20, bool p21, bool p22, bool p23, bool p24, bool p25, bool p26, bool p27, string obs)
        {
            P01 = p01;
            P01ComplementoPq = p01ComplementoPq;
            P01ComplementoTel = p01ComplementoTel;
            P02 = p02;
            P02Complemento = p02Complemento;
            P03 = p03;
            P03Complemento = p03Complemento;
            P04 = p04;
            P05 = p05;
            P05Complemento = p05Complemento;
            P06 = p06;
            P07 = p07;
            P08 = p08;
            P09 = p09;
            P09Complemento = p09Complemento;
            P10 = p10;
            P11 = p11;
            P12 = p12;
            P13 = p13;
            P14 = p14;
            P15 = p15;
            P16 = p16;
            P17 = p17;
            P17Complemento = p17Complemento;
            P18 = p18;
            P19 = p19;
            P20 = p20;
            P21 = p21;
            P22 = p22;
            P23 = p23;
            P24 = p24;
            P25 = p25;
            P26 = p26;
            P27 = p27;
            Obs = obs;
        }
    }
}
