using FastType_Proskurin_Sideleva.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastType_Proskurin_Sideleva.AppData
{
    class ModelHelper
    {
        /// <summary>
        /// Контекст данных
        /// </summary>
        private static FastTypeProskurinSidelevaEntities context;

        /// <summary>
        /// Получает контекст данных
        /// </summary>
        /// <returns>Контекст данных</returns>
        public static FastTypeProskurinSidelevaEntities GetContext()
        {
            if (context == null)
            {
                context = new FastTypeProskurinSidelevaEntities();
            }
            return context;
        }
    }
}
