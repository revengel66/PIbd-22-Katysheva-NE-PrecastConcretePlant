using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecastConcretePlantListImplement.Models;

namespace PrecastConcretePlantListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Reinforced> Reinforceds { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Reinforceds = new List<Reinforced>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
