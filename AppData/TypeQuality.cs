using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FastType_Proskurin_Sideleva.AppData
{
    public class TypeQuality
    {
        /// <summary>
        /// Возвращает или задает скорость печати
        /// </summary>
        public static decimal Speed { get; set; }

        
        /// <summary>
        /// Расчитывает скорость печати
        /// </summary>
        /// <param name="input">Длина текста</param>
        /// <param name="temp">Скорость печати</param>
        /// <returns></returns>
        public static string CalculateSpeed(TextBox input, int temp)
        {
            return (input.Text.Length / temp * 60).ToString();
        }
    }
}
