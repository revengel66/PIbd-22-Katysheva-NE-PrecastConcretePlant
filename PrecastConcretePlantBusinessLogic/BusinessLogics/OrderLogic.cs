using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.Enums;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;

namespace PrecastConcretePlantBusinessLogic.BusinessLogics
{
	public class OrderLogic : IOrderLogic
	{
		private readonly IOrderStorage _orderStorage;
		public OrderLogic(IOrderStorage orderStorage)
		{
			_orderStorage = orderStorage;
		}
		public List<OrderViewModel> Read(OrderBindingModel model)
		{
			if (model == null)
			{
				return _orderStorage.GetFullList();
			}
			if (model.Id.HasValue)
			{
				return new List<OrderViewModel> { _orderStorage.GetElement(model) };
			}
			return _orderStorage.GetFilteredList(model);
		}
		public void CreateOrder(CreateOrderBindingModel model)
		{
			_orderStorage.Insert(new OrderBindingModel
			{
				ReinforcedId = model.ReinforcedId,
				ReinforcedName = model.ReinforcedName,
				Count = model.Count,
				Sum = model.Sum,
				DateCreate = DateTime.Now,
				Status = OrderStatus.Принят
			});
		}
		public void TakeOrderInWork(ChangeStatusBindingModel model)
		{
			var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });

			if (order == null)
			{
				throw new Exception("Заказ не найден");
			}
			if (order.Status != OrderStatus.Принят)
			{
				throw new Exception("Заказ не в статусе \"Принят\"");
			}
			_orderStorage.Update(new OrderBindingModel
			{
				Id = order.Id,
				ReinforcedId = order.ReinforcedId,
				ReinforcedName = order.ReinforcedName,
				Count = order.Count,
				Sum = order.Sum,
				DateCreate = order.DateCreate,
				DateImplement = DateTime.Now,
				Status = OrderStatus.Выполняется
			});
		}
		public void FinishOrder(ChangeStatusBindingModel model)
		{
			var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
			if (order == null)
			{
				throw new Exception("Заказ не найден");
			}
			if (order.Status != OrderStatus.Выполняется)
			{
				throw new Exception("Заказ не в статусе \"Выполняется\"");
			}
			_orderStorage.Update(new OrderBindingModel
			{
				Id = order.Id,
				ReinforcedId = order.ReinforcedId,
				ReinforcedName = order.ReinforcedName,
				Count = order.Count,
				Sum = order.Sum,
				DateCreate = order.DateCreate,
				DateImplement = order.DateImplement,
				Status = OrderStatus.Готов
			});
		}
		public void DeliveryOrder(ChangeStatusBindingModel model)
		{
			var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
			if (order == null)
			{
				throw new Exception("Заказ не найден");
			}
			if (order.Status != OrderStatus.Готов)
			{
				throw new Exception("Заказ не в статусе \"Готов\"");
			}
			_orderStorage.Update(new OrderBindingModel
			{
				Id = order.Id,
				ReinforcedId = order.ReinforcedId,
				ReinforcedName = order.ReinforcedName,
				Count = order.Count,
				Sum = order.Sum,
				DateCreate = order.DateCreate,
				DateImplement = order.DateImplement,
				Status = OrderStatus.Выдан
			});
		}
	}
}
