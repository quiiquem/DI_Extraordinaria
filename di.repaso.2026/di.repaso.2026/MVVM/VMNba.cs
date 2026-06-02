using di.repaso._2026.Backend.Modelo;
using di.repaso._2026.Backend.Repositorio;
using di.repaso._2026.MVVM.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace di.repaso._2026.MVVM
{
    public class VMNba : MVBase
    {
        //1. Declarar privado
        private Equipo _equipo;
        private Jugadore _jugador;
        private Estadistica _estadistica;
        private Partido _partido;
        private string _conferencia;
        private string _division;


        private EquipoRepositorio _equipoRepository;
        private JugadorRepositorio _jugadorRepository;
        private List<Equipo> _listaEquipos;
        private List<Jugadore> _listaJugadores;
        //listas de equipo
        private List<string> _listaConferencias;
        private List<string> _listaDivisiones;
        //listas jugador
        private List<string> _listaPosiciones;
        //listas datagrid (se declaran directamente en público)
        public ListCollectionView listaEquipos_CollectionView { get; set; }

        //2. Declarar público
        public Equipo equipo
        {
            get => _equipo ??= new Equipo();
            set => SetProperty(ref _equipo, value);
        }

        public Jugadore jugador
        {
            get => _jugador ??= new Jugadore();
            set => SetProperty(ref _jugador, value);
        }

        public List<Equipo> listaEquipos
        {
            get => _listaEquipos ??= new List<Equipo>();
            set => SetProperty(ref _listaEquipos, value);
        }

        public List<Jugadore> listaJugadores
        {
            get => _listaJugadores ??= new List<Jugadore>();
            set => SetProperty(ref _listaJugadores, value);
        }

        //Listas equipos
        public List<string> listaConferencias
        {
            get => _listaConferencias ??= _equipoRepository.getConferencias();
            set => SetProperty(ref _listaConferencias, value);
        }

        public List<string> listaDivisiones
        {
            get => _listaDivisiones ??= _equipoRepository.getDivisiones();
            set => SetProperty(ref _listaDivisiones, value);
        }

        //Listas jugador
        public List<string> listaPosiciones
        {
            get => _listaPosiciones ??= _jugadorRepository.getPosiciones();
            set => SetProperty(ref _listaPosiciones, value);
        }

        //3. Declarar ViewModel con su repositoiro
        public VMNba(EquipoRepositorio equipoRepositorio, JugadorRepositorio jugadorRepositorio)
        {
            _equipo = new Equipo();
            _equipoRepository = equipoRepositorio;
            _jugador = new Jugadore();
            _jugadorRepository = jugadorRepositorio;
        }

        //4. Inicializar
        public async Task Inicializar()
        {
            try
            {
                using (var db = new NbaContext())
                {

                    //Inicializar las listas
                    _listaEquipos = await db.Equipos.ToListAsync();
                    _listaJugadores = await db.Jugadores.ToListAsync();

                    //Llamar listas que tengan métodos en repositorios, just in case.
                    _listaConferencias = _equipoRepository.getConferencias();
                    _listaDivisiones = _equipoRepository.getDivisiones();

                    _listaPosiciones = _jugadorRepository.getPosiciones();

                    //DataGrids.
                    listaEquipos_CollectionView = new ListCollectionView(_listaEquipos);
                    OnPropertyChanged(nameof(listaEquipos_CollectionView));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //5. CURL con los objetos de la BD

        //--EQUIPO--

        //guardar o actualizar usando el metodo del repositorio que nos implemento Jero (gracias por todo proyecto intermodular)
        public async Task<bool> GuardarEquipo()
        {
            var equipo_rep = _equipoRepository; //declararlo como variable para poder llamar al metodo como en android

            bool correcto = equipo_rep.NombreUnico(equipo.Nombre); //es un metodo bool y justo lo tenemos asi del proyecto asi que solo es un paso mas

            if (correcto)
                correcto = await AddAsync(_equipoRepository, equipo);
            else
            {
                MessageBox.Show("EL NOMBRE DEL EQUIPO YA EXISTE");
                correcto = false; //si el nombre es repetido a la mierda todo /*await UpdateAsync(_equipoRepository, equipo);*/
            }
            if (correcto)
            {
                _equipo = new Equipo();
                OnPropertyChanged(nameof(equipo));
            }
            else
            {
                MessageBox.Show("HA OCURRIDO UN ERROR AL GUARDAR LOS DATOS");
            }

            return correcto;
        }

        public async Task<bool> EliminarEquipo()
        {
            bool correcto = true;
            return correcto;
        }


        //--JUGADOR--
        
        //Guardar 1 con ID NO AUTOINCREMENTAL
        public async Task<bool> GuardarJugador()
        {
            try
            {
                // Obtener el último ID y sumarle 1
                int ultimo_id = _jugadorRepository.getLastId();
                _jugador.Codigo = ultimo_id + 1;

                // Guardar directamente
                bool correcto = await AddAsync(_jugadorRepository, _jugador);

                if (correcto)
                {
                    _jugador = new Jugadore();
                    OnPropertyChanged(nameof(jugador));
                }
                else
                {
                    MessageBox.Show("HA OCURRIDO UN ERROR AL GUARDAR LOS DATOS");
                }

                return correcto;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
    }
