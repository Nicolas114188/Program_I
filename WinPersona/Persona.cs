using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPersona
{
    class Persona
    {
        private string apellido;
        private string nombre;
        private int tipoDocumento;
        private string documento;
        private int estadoCivil;
        private int sexo;
        private bool fallecido;
        public Persona()
        {
            apellido = string.Empty;
            nombre = string.Empty;
            tipoDocumento = 1;
            documento = string.Empty;
            estadoCivil = 1;
            sexo = 1;
            fallecido = false;
        }
        public Persona(string apellido, string nombre, int tipoDocumento, string documento, int estadoCivil, int sexo, bool fallecido)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.tipoDocumento = tipoDocumento;
            this.documento = documento;
            this.estadoCivil = estadoCivil;
            this.sexo = sexo;
            this.fallecido = fallecido;
        }
        public string Apellido 
        { 
            get { return apellido; } 
            set { apellido = value;} 
        }
        public string Nombre 
        { 
            get {return nombre;}
            set {nombre=value;} 
        }
        public int TipoDocumento 
        {
            get {return tipoDocumento; }
            set {tipoDocumento=value;} 
        }
        public string Documento 
        { 
            get {return documento; }
            set {documento=value; } 
        }
        public int EstadoCivil 
        {
            get {return estadoCivil; }
            set {estadoCivil=value; } 
        }
        public int Sexo 
        {
            get {return sexo;}
            set {sexo=value;}
        }
        public bool Fallecido 
        {
            get {return fallecido; }
            set {fallecido=value; } 
        }
        public override string ToString()
        {
            return Nombre + " " + Apellido + " " + Sexo.ToString();
        }
    }
}
