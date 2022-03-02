using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantContracts.BindingModels
{
    /// <summary>
    /// Данные для смены статуса заказа
    /// </summary>

    public class ChangeStatusBindingModel
    {
        public String ReinforcedName { get; set; }
        public int OrderId { get; set; }
    }
}
