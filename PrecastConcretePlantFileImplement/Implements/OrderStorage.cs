﻿using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantContracts.Enums;
using PrecastConcretePlantFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton source;
        public OrderStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList() => source.Orders.Select(CreateModel).ToList();
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model) => model == null ?
            null : source.Orders.Where(rec => rec.Status.Equals(model.Status)).Select(CreateModel).ToList();
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null) return null;

            var order = source.Orders
            .FirstOrDefault(rec => rec.Status == model.Status || rec.Id == model.Id);

            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            var element = new Order
            {
                Id = maxId + 1,
                Status = OrderStatus.Принят,
                DateCreate = DateTime.Now
            };
            source.Orders.Add(CreateModel(model, element));
        }
        public void Update(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null) throw new Exception("Элемент не найден");

            CreateModel(model, element);
        }
        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ReinforcedId = model.ReinforcedId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private OrderViewModel CreateModel(Order order)
        {

            return new OrderViewModel
            {
                Id = order.Id,
                ReinforcedId = order.ReinforcedId,
                ReinforcedName = source.Reinforceds.FirstOrDefault(rec => rec.Id == order.ReinforcedId)?.ReinforcedName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}