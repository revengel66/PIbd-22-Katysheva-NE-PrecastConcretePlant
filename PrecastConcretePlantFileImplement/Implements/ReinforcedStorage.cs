﻿using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantFileImplement.Implements
{
    public class ReinforcedStorage : IReinforcedStorage
    {
        private readonly FileDataListSingleton source;
        public ReinforcedStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<ReinforcedViewModel> GetFullList()
        {
            return source.Reinforceds
            .Select(CreateModel)
            .ToList();
        }
        public List<ReinforcedViewModel> GetFilteredList(ReinforcedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Reinforceds
            .Where(rec => rec.ReinforcedName.Contains(model.ReinforcedName))
            .Select(CreateModel)
            .ToList();
        }
        public ReinforcedViewModel GetElement(ReinforcedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var Reinforced = source.Reinforceds
            .FirstOrDefault(rec => rec.ReinforcedName == model.ReinforcedName || rec.Id
           == model.Id);
            return Reinforced != null ? CreateModel(Reinforced) : null;
        }
        public void Insert(ReinforcedBindingModel model)
        {
            int maxId = source.Reinforceds.Count > 0 ? source.Components.Max(rec => rec.Id)
            : 0;
            var element = new Reinforced
            {
                Id = maxId + 1,
                ReinforcedComponents = new
           Dictionary<int, int>()
            };
            source.Reinforceds.Add(CreateModel(model, element));
        }
        public void Update(ReinforcedBindingModel model)
        {
            var element = source.Reinforceds.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(ReinforcedBindingModel model)
        {
            Reinforced element = source.Reinforceds.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Reinforceds.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Reinforced CreateModel(ReinforcedBindingModel model, Reinforced Reinforced)
        {
            Reinforced.ReinforcedName = model.ReinforcedName;
            Reinforced.Price = model.Price;
            // удаляем убранные
            foreach (var key in Reinforced.ReinforcedComponents.Keys.ToList())
            {
                if (!model.ReinforcedComponents.ContainsKey(key))
                {
                    Reinforced.ReinforcedComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.ReinforcedComponents)
            {
                if (Reinforced.ReinforcedComponents.ContainsKey(component.Key))
                {
                    Reinforced.ReinforcedComponents[component.Key] =
                   model.ReinforcedComponents[component.Key].Item2;
                }
                else
                {
                    Reinforced.ReinforcedComponents.Add(component.Key,
                   model.ReinforcedComponents[component.Key].Item2);
                }
            }
            return Reinforced;
        }
        private ReinforcedViewModel CreateModel(Reinforced Reinforced)
        {
            return new ReinforcedViewModel
            {
                Id = Reinforced.Id,
                ReinforcedName = Reinforced.ReinforcedName,
                Price = Reinforced.Price,
                ReinforcedComponents = Reinforced.ReinforcedComponents
             .ToDictionary(recPC => recPC.Key, recPC =>
             (source.Components.FirstOrDefault(recC => recC.Id ==
            recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
