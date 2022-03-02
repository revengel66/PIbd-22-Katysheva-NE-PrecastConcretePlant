using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.ViewModels;

namespace PrecastConcretePlantContracts.BusinessLogicsContracts
{
    public interface IReinforcedLogic
    {
        List<ReinforcedViewModel> Read(ReinforcedBindingModel model);
        void CreateOrUpdate(ReinforcedBindingModel model);
        void Delete(ReinforcedBindingModel model);
    }
}
