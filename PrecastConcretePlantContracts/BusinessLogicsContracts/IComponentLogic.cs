﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.ViewModels;

namespace PrecastConcretePlantContracts.BusinessLogicsContracts
{
    public interface IComponentLogic
    {
        List<ComponentViewModel> Read(ComponentBindingModel model);
        void CreateOrUpdate(ComponentBindingModel model);
        void Delete(ComponentBindingModel model);

    }
}
