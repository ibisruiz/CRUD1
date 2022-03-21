using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD1
{
    class DbConection
    {

        DataClassDataContext db = new DataClassDataContext();


        public List <CRUDTable> Listar()
        {
            List<CRUDTable> list = db.CRUDTables.ToList();
            return list;
        }

        public CRUDTable Obtener(int id)
        {
            CRUDTable objeto = db.CRUDTables.Single(x => x.id_productos == id);
            return objeto;
        }

        public void Agregar(CRUDTable objCT)
        {
            db.CRUDTables.InsertOnSubmit(objCT);
            db.SubmitChanges();
        }
         
        public void Actualizar (CRUDTable objCT)
        {
            CRUDTable objActualizar = db.CRUDTables.Single(x => x.id_productos == objCT.id_productos);
            objActualizar.nombre_producto = objCT.nombre_producto;
            objActualizar.precio_producto = objCT.precio_producto;
            objActualizar.disponibilidad_producto = objCT.disponibilidad_producto;
            objActualizar.descripcion_producto = objCT.descripcion_producto;
            db.SubmitChanges();
        }

        public void Eliminar(int id)
        {
            CRUDTable objEliminar = db.CRUDTables.Single(x => x.id_productos == id);
            db.CRUDTables.DeleteOnSubmit(objEliminar);
            db.SubmitChanges();
        }


    }
}
