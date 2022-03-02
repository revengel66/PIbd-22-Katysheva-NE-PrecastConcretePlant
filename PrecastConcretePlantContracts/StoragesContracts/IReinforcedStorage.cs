using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.ViewModels;

namespace PrecastConcretePlantContracts.StoragesContracts
{
    public interface IReinforcedStorage
    {
        List<ReinforcedViewModel> GetFullList();
        List<ReinforcedViewModel> GetFilteredList(ReinforcedBindingModel model);
        ReinforcedViewModel GetElement(ReinforcedBindingModel model);
        void Insert(ReinforcedBindingModel model);
        void Update(ReinforcedBindingModel model);
        void Delete(ReinforcedBindingModel model);
    }
}
