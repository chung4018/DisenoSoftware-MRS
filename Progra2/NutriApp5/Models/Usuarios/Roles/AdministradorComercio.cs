using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriApp5.Models.Usuarios.Roles
{
    public class AdministradorComercio : RolUsuario
    {
        //Atributos
        private String[] comerciosAsociados;
        private ICOMERCIOSRepository comerciosRepository = new COMERCIOSRepository();
        //constructor 
        public AdministradorComercio()
        {

        }
        //Metodos 
        public override bool canPublishNotice()
        {
            return false;
        }
        public override bool isAdmin()
        {
            return false;
        }
        public override bool isStoreAdmin()
        {
            return true;
        }
        public override ICollection<int> getStoresAdmin()
        {
            ICollection<int> result = new List<int>();
            IQueryable<COMERCIOS> comercios = comerciosRepository.All;
            foreach (var comercio in comercios)
            {
                if (comercio.ID_USUARIO == LoginControl.Instance.idLogedUser) 
                    result.Add(comercio.ID_COMERCIO);
            }
            return result;
        }

        public override bool isAdminOf(int id)
        {
            ICollection<int> comerciosId = this.getStoresAdmin();
            foreach (var comercio in comerciosId)
            {
                if (comercio == id)
                    return true;
            }
            return false;
        }

        //Getters and Setters
        public String[] ComerciosAsociados
        {
            get { return comerciosAsociados; }
            set { comerciosAsociados = value; }
        }
    }
}