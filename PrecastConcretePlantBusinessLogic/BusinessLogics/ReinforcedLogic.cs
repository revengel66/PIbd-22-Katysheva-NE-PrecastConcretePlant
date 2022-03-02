using System;
using System.Collections.Generic;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;

namespace PrecastConcretePlantBusinessLogic.BusinessLogics
{
    public class ReinforcedLogic : IReinforcedLogic
    {
        private readonly IReinforcedStorage _ReinforcedStorage;
        public ReinforcedLogic(IReinforcedStorage ReinforcedStorage)
        {
            _ReinforcedStorage = ReinforcedStorage;
        }
        public List<ReinforcedViewModel> Read(ReinforcedBindingModel model)
        {
            if (model == null)
            {
                return _ReinforcedStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ReinforcedViewModel> { _ReinforcedStorage.GetElement(model) };
            }
            return _ReinforcedStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ReinforcedBindingModel model)
        {
            var element = _ReinforcedStorage.GetElement(new ReinforcedBindingModel { ReinforcedName = model.ReinforcedName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                _ReinforcedStorage.Update(model);
            }
            else
            {
                _ReinforcedStorage.Insert(model);
            }
        }
        public void Delete(ReinforcedBindingModel model)
        {
            var element = _ReinforcedStorage.GetElement(new ReinforcedBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _ReinforcedStorage.Delete(model);
        }
    }
}
