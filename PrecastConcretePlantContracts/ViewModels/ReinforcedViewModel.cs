﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PrecastConcretePlantContracts.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class ReinforcedViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string ReinforcedName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ReinforcedComponents { get; set; }
    }
}
