using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantListImplement.Models;

namespace PrecastConcretePlantListImplement.Implements
{
    public class ReinforcedStorage : IReinforcedStorage
    {
        private readonly DataListSingleton source;
        public ReinforcedStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ReinforcedViewModel> GetFullList()
        {
            var result = new List<ReinforcedViewModel>();
            foreach (var component in source.Reinforceds)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<ReinforcedViewModel> GetFilteredList(ReinforcedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<ReinforcedViewModel>();
            foreach (var Reinforced in source.Reinforceds)
            {
                if (Reinforced.ReinforcedName.Contains(model.ReinforcedName))
                {
                    result.Add(CreateModel(Reinforced));
                }
            }
            return result;
        }
        public ReinforcedViewModel GetElement(ReinforcedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var Reinforced in source.Reinforceds)
            {
                if (Reinforced.Id == model.Id || Reinforced.ReinforcedName ==
                model.ReinforcedName)
                {
                    return CreateModel(Reinforced);
                }
            }
            return null;
        }
        public void Insert(ReinforcedBindingModel model)
        {
            var tempReinforced = new Reinforced
            {
                Id = 1,
                ReinforcedComponents = new
            Dictionary<int, int>()
            };
            foreach (var Reinforced in source.Reinforceds)
            {
                if (Reinforced.Id >= tempReinforced.Id)
                {
                    tempReinforced.Id = Reinforced.Id + 1;
                }
            }
            source.Reinforceds.Add(CreateModel(model, tempReinforced));
        }
        public void Update(ReinforcedBindingModel model)
        {
            Reinforced tempReinforced = null;
            foreach (var Reinforced in source.Reinforceds)
            {
                if (Reinforced.Id == model.Id)
                {
                    tempReinforced = Reinforced;
                }
            }
            if (tempReinforced == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempReinforced);
        }
        public void Delete(ReinforcedBindingModel model)
        {
            for (int i = 0; i < source.Reinforceds.Count; ++i)
            {
                if (source.Reinforceds[i].Id == model.Id)
                {
                    source.Reinforceds.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Reinforced CreateModel(ReinforcedBindingModel model, Reinforced
        Reinforced)
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
            // требуется дополнительно получить список компонентов для изделия с
            //названиями и их количество
            var ReinforcedComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in Reinforced.ReinforcedComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                ReinforcedComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new ReinforcedViewModel
            {
                Id = Reinforced.Id,
                ReinforcedName = Reinforced.ReinforcedName,
                Price = Reinforced.Price,
                ReinforcedComponents = ReinforcedComponents
            };
        }
    }
}