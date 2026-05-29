using di.repaso._2026.Backend.Modelo;
using di.repaso._2026.Backend.Repositorio;
using di.repaso._2026.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.repaso._2026.MVVM
{
   public class VMEquipo : MVBase
    {
        //1. Declarar privado
        private Equipo _equipo;
        private EquipoRepositorio _equipoRepository;


        //2. Declarar público
        public Equipo equipo
        {
            get => _equipo ??= new Equipo();
            set => SetProperty(ref _equipo, value);
        }

        //3. Declarar ViewModel con su repositoiro
        public VMEquipo(EquipoRepositorio equipoRepositorio)
        {
            _equipo = new Equipo();
            _equipoRepository = equipoRepositorio;
        }

    }
}
