using gestion_Documental.Modelo.DAL;
using gestion_Documental.Modelo.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace gestion_Documental.MVVM
{
    class MVListaConciertos : MVBase
    {
        //conexión a la bd
        private gestiondocumentalEntities gEnt;
        // service de documentos (conciertos)
        private DocumentoServicio documentoService;
        // para el filtro de responsable
        private ResponsableService responsableService;
        // para el filtro de empresa
        private EmpresaService empresaService;
        // elemento seleccionado
        private documentos documento;
        // contenedor para el datagrid
        private ListCollectionView lista;
        // responsable seleccionado para el filtro
        private responsable pResponsable;
        // empresa seleccionada para el filtro
        private empresa pEmpresa;
        // para filtro de fechas
        private DateTime fechaI;
        private DateTime fechaF;

        public MVListaConciertos(gestiondocumentalEntities gEnt)
        {
            this.gEnt = gEnt;
            documentoService = new DocumentoServicio(gEnt);
            responsableService = new ResponsableService(gEnt);
            empresaService = new EmpresaService(gEnt);           
            lista = new ListCollectionView(documentoService.getAll().ToList());
            pEmpresa = new empresa();
            pResponsable = new responsable();

            // inicializamos las fechas para que aparezcan en el datepicker como seleccinadas por defecto
            // fecha inicial el concierto más viejo que tenemos
            fechaI = new DateTime(2015, 05, 20);
            // fecha final iremos poniendo el día en el que nos encontramos
            fechaF = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public DateTime fechaInicial
        {
            get
            {
                return fechaI;
            }
            set
            {
                fechaI = value;
                OnPropertyChanged("fechaInicial");
            }
           
        }

        public DateTime fechaFinal
        {
            get
            {
                return fechaF;
            }
            set
            {
                fechaF = value;
                OnPropertyChanged("fechaFinal");
            }

        }


        public ListCollectionView listaDocumentos
        {
            get
            {
                return lista;
            }
            
        }

        // lista de responsables
        public List<responsable> listaResponsables
        {
            get
            {
                return responsableService.getAll().ToList();
            }
        }

        // responsable seleccionado
        public responsable responsableSeleccionado
        {
            get
            {
                return pResponsable;
            }
            set
            {
                pResponsable = value;
                OnPropertyChanged("responsableSeleccionado");

            }

        }

        // lista de empreasas
        public List<empresa> listaEmpresas
        {
            get
            {
                return empresaService.getAll().ToList();
            }
        }

        // empresa seleccionada

        public empresa empresaSeleccionada
        {
            get
            {
                return pEmpresa;
            }
            set
            {
                pEmpresa = value;
                OnPropertyChanged("empresaSeleccionada");
            }

        }

        // para el documento seleccionado
        public documentos documentoSeleccionado
        {
            get
            {
                return documento;
            }
            set
            {
                documento = value;
                OnPropertyChanged("documentoSeleccionado");
            }
        }

        // filtro para el combo de empresa
        public bool filtroEmpresa(object obj)
        {
            bool correcto = true;

            documentos doc = obj as documentos;

            if (empresaSeleccionada != null && !doc.empresa.razon_social.Equals(empresaSeleccionada.razon_social))
            {
                correcto = false;
            }

            return correcto;
        }


        //filtro para el combo de responsble
        public bool filtroResponsable(object obj)
        {
            bool correcto = true;

            documentos doc = obj as documentos;

            if (responsableSeleccionado != null && !doc.empresa.responsable.nombre.Equals(responsableSeleccionado.nombre))
            {
                correcto = false;
            }
            return correcto;

        }

        // filtro para las fechas
        public bool filtroFecha(object obj)
        {
            bool correcto = false;
            documentos doc = obj as documentos;

            if (doc.fecha_firma >= fechaInicial && doc.fecha_firma <= fechaFinal)
            {
                correcto = true;
            }
            return correcto;
        }







    }
}
