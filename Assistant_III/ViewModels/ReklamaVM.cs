using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant_III.ViewModels
{
    class ReklamaVM
    {
        public string TextReklama
        {
            get 
            {
                string t;
                
                t = "     Програма розроблена як записник для особистих " + 
                     "нотатків та різного роду документації (в режимі " + 
                     "інтерактивної справки). " + Environment.NewLine;               
                t += "   Версія 3.0.2018 написана мною в грудні 2018 року " + 
                    "для особистого розвитку, та є інтелектуальним " + 
                    "надбанням автора. " + Environment.NewLine;
                t += "   Для коректної роботи встановлено залежність ≧ " + 
                    ".NET Framework 4.6" + Environment.NewLine;
                t += "   Всі права на впровадження нових функцій, " + 
                    "вдосконалення та продаж даного програмного забезпечення " + 
                    "залишаю за собою." + Environment.NewLine + Environment.NewLine;
               
                t += " © <Kuchinik & Co.>, 2018" + Environment.NewLine;
                t += " Кучінік Роман Вікторович" + Environment.NewLine;
                t += " тел. +38(068)104-18-24" + Environment.NewLine;
                return t;
            }
        }

        public string TitleWindow
        {
            get
            {
                return "(Про версію...)";
            }
        }

    }
}
