using PrecastConcretePlantFileImplement.Models;
using PrecastConcretePlantContracts.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace PrecastConcretePlantFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string ReinforcedFileName = "Reinforced.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Reinforced> Reinforceds { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Reinforceds = LoadReinforceds();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveReinforceds();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                var xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ReinforcedId = Convert.ToInt32(elem.Element("PlaneId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToInt32(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ?
                        (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }
            return list;
        }
        private List<Reinforced> LoadReinforceds()
        {
            var list = new List<Reinforced>();
            if (File.Exists(ReinforcedFileName))
            {
                var xDocument = XDocument.Load(ReinforcedFileName);
                var xElements = xDocument.Root.Elements("Reinforced").ToList();
                foreach (var elem in xElements)
                {
                    var reinComp = new Dictionary<int, int>();
                    foreach (var component in
                   elem.Element("ReinforcedComponents").Elements("ReinforcedComponent").ToList())
                    {
                        reinComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Reinforced
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ReinforcedName = elem.Element("ReinforcedName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        ReinforcedComponents = reinComp
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("PlaneId", order.ReinforcedId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveReinforceds()
        {
            if (Reinforceds != null)
            {
                var xElement = new XElement("Reinforceds");
                foreach (var Reinforced in Reinforceds)
                {
                    var compElement = new XElement("ReinforcedComponents");
                    foreach (var component in Reinforced.ReinforcedComponents)
                    {
                        compElement.Add(new XElement("ReinforcedComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Reinforced",
                     new XAttribute("Id", Reinforced.Id),
                     new XElement("ReinforcedName", Reinforced.ReinforcedName),
                     new XElement("Price", Reinforced.Price),
                     compElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ReinforcedFileName);
            }
        }
        public static void Save()
        {
            instance.SaveOrders();
            instance.SaveReinforceds();
            instance.SaveComponents();
        }
    }
}
