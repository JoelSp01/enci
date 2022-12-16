using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace parqueo
{
    public class Acc
    {
        AccesoDatos conectar = new AccesoDatos("enci");
       public DataSet Usuario()
        {
            conectar.Conectar();  
           // conectar.CrearComando("SP_SELECT_CLIENTE");
            //conectar.AsignarParametros("USUARIO", strUsuario, DbType.String);
            //conectar.AsignarParametros("CLAVE", strClave, DbType.String);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }

        //REFISTRAMOS EL USUARIO PARA LOGIN
        public DataSet registrarUsuario(int intEstado, string strNombre, string strUsuario, string strContrasena )
        {
            conectar.Conectar();
            conectar.CrearComando("SP_INSERT_USUARIO");
            conectar.AsignarParametros("estado", intEstado.ToString(), DbType.Int32);
            conectar.AsignarParametros("nombre", strNombre, DbType.String);
            conectar.AsignarParametros("users", strUsuario, DbType.String);
            conectar.AsignarParametros("passwords", strContrasena, DbType.String);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }

        
        //VERIFICAMOS SI EL USUSARIO EXISTE
        public DataSet verificarUs(string strUsuario)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_SELECT_USUARIO");
            conectar.AsignarParametros("users", strUsuario, DbType.String);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }

        //REGISTRAMOS CLIENTE
        public DataSet registrarCliente(int intEstado, string strNombre, string strRuc, string strTelefono, string strCorreo)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_INSERT_CLIENTE");
            conectar.AsignarParametros("estado", intEstado.ToString(), DbType.Int32);
            conectar.AsignarParametros("nombre", strNombre, DbType.String);
            conectar.AsignarParametros("ruc", strRuc, DbType.String);
            conectar.AsignarParametros("telefono", strTelefono, DbType.String);
            conectar.AsignarParametros("correoElectronico", strCorreo, DbType.String);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }

        //OBTENEMOS TODOS LOS CLIENTES PARA PONER EN EL GRID
        public DataSet ObtenerClientes()
        {
            conectar.Conectar();
            conectar.CrearComando("SP_SELECT_CLIENTES");
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }

        //OBTENEMOS EL ID DEL CLIENTE PARA MODIFICAR
        public DataSet ObtenerClienteId(int Id)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_SELECT_CLIENTE_ID");
            conectar.AsignarParametros("id", Id.ToString(), DbType.Int32);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }

        //ELIMINAMOS LOS CLIENTES POR ID
        public DataSet EliminarCliente(int Id)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_DELETE_CLIENTE");
            conectar.AsignarParametros("id", Id.ToString(), DbType.Int32);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }

        //ACTUALIZAMOS EL CLIENTE POR EL ID
        public DataSet actualizarCliente(int id, string strNombre, string strRuc, string strTelefono, string strCorreo)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_UPDATE_CLIENTE");
            conectar.AsignarParametros("id", id.ToString(), DbType.Int32);
            conectar.AsignarParametros("nombre", strNombre, DbType.String);
            conectar.AsignarParametros("ruc", strRuc, DbType.String);
            conectar.AsignarParametros("telefono", strTelefono, DbType.String);
            conectar.AsignarParametros("correoElectronico", strCorreo, DbType.String);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }

        //***************************************************PROVEEDORES******************************

        //OBTENEMOS TODOS LOS PROVEEDORES PARA EL GRID
        public DataSet ObtenerProveedor()
        {
            conectar.Conectar();
            conectar.CrearComando("SP_SELECT_PROVEEDOR_COMPLETO");
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }


        //OBTENEMOS EL ID DEL PROVEEDOR PARA MODIFICAR
        public DataSet ObtenerProveedorId(int Id)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_SELECT_PROVEEDOR_ID");
            conectar.AsignarParametros("id", Id.ToString(), DbType.Int32);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }


        //REGISTRAMOS PROVEEDOR
        public DataSet registrarProveedor(int intEstado, string strNombre, string strRuc, string strRazonSocial)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_INSERT_PROVEEDOR");
            conectar.AsignarParametros("estado", intEstado.ToString(), DbType.Int32);
            conectar.AsignarParametros("nombre", strNombre, DbType.String);
            conectar.AsignarParametros("ruc", strRuc, DbType.String);
            conectar.AsignarParametros("razonSocial", strRazonSocial, DbType.String);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }


        //ACTUALIZAMOS EL PROVEEDOR POR EL ID
        public DataSet actualizarProveedor(int id, string strNombre, string strRuc, string strRazonSocial)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_UPDATE_PROVEEDOR");
            conectar.AsignarParametros("id", id.ToString(), DbType.Int32);
            conectar.AsignarParametros("nombre", strNombre, DbType.String);
            conectar.AsignarParametros("ruc", strRuc, DbType.String);
            conectar.AsignarParametros("razonSocial", strRazonSocial, DbType.String);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }


     

        //ELIMINAMOS LOS PROVEEDORES POR ID
        public DataSet EliminarProveedor(int Id)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_DELETE_PROVEEDOR");
            conectar.AsignarParametros("id", Id.ToString(), DbType.Int32);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }
        //***************************************************MATERIALES******************************
        public DataSet registrarMateriales(int intProvId, int proId, string strDetalle, string strAutorizacion, double dblCantidad, double dblCostoU, double dblCostoT, double dblTotal, int intEstado, int intMatIva)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_INSERT_MATERIALES");  
            conectar.AsignarParametros("provId", intProvId.ToString(), DbType.Int32);
            conectar.AsignarParametros("proId", proId.ToString(), DbType.Int32);
            conectar.AsignarParametros("detalle", strDetalle, DbType.String);
            conectar.AsignarParametros("autorizacion", strAutorizacion, DbType.String);
            conectar.AsignarParametros("cantidad", dblCantidad.ToString(), DbType.Double);
            conectar.AsignarParametros("costoU", dblCostoU.ToString(), DbType.Double);
            conectar.AsignarParametros("costoT", dblCostoT.ToString(), DbType.Double);
            conectar.AsignarParametros("total", dblTotal.ToString(), DbType.Double);
            conectar.AsignarParametros("estado", intEstado.ToString(), DbType.Int32);
            conectar.AsignarParametros("iva", intMatIva.ToString(), DbType.Int32);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }


        public DataSet actualizarMateriales(int intProvId, int proId, string strDetalle, string strAutorizacion, double dblCantidad, double dblCostoU, double dblCostoT, double dblTotal, int intMatIva, int intId)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_UPDATE_MATERIAL");            
            conectar.AsignarParametros("provId", intProvId.ToString(), DbType.Int32);
            conectar.AsignarParametros("proId", proId.ToString(), DbType.Int32);
            conectar.AsignarParametros("detalle", strDetalle, DbType.String);
            conectar.AsignarParametros("autorizacion", strAutorizacion, DbType.String);
            conectar.AsignarParametros("cantidad", dblCantidad.ToString(), DbType.Double);
            conectar.AsignarParametros("costoU", dblCostoU.ToString(), DbType.Double);
            conectar.AsignarParametros("costoT", dblCostoT.ToString(), DbType.Double);
            conectar.AsignarParametros("total", dblTotal.ToString(), DbType.Double);
            conectar.AsignarParametros("iva", intMatIva.ToString(), DbType.Int32);
            conectar.AsignarParametros("id", intId.ToString(), DbType.Int32);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }


        public DataSet SacarCodigoIva(int Id)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_SELECT_ITC_IVA");
            conectar.AsignarParametros("id", Id.ToString(), DbType.Int32);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }


        public DataSet ObtenerMaterial()
        {
            conectar.Conectar();
            conectar.CrearComando("SP_SELECT_MATERIALES");
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }

        public DataSet EliminarMaterial(int id)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_DELETE_MATERIALES");
            conectar.AsignarParametros("id", id.ToString(), DbType.Int32);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }

        public DataSet ObtenerMaterialId(int Id)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_SELECT_MATERIALES_ID");
            conectar.AsignarParametros("id", Id.ToString(), DbType.Int32);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }


        /*
        public DataSet regCliente(int intEstado, string strNombre, string strApellido, string strNumIdentificacion, string strTelefono)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_INSERT_CLIENTE");
            conectar.AsignarParametros("estado", intEstado.ToString(), DbType.Int32);
            conectar.AsignarParametros("nombre", strNombre, DbType.String);
            conectar.AsignarParametros("apellido", strApellido, DbType.String);
            conectar.AsignarParametros("numIdentificacion", strNumIdentificacion, DbType.String);
            conectar.AsignarParametros("telefono", strTelefono, DbType.String);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }
        */

        //public DataSet Usuario(string strUsuario, string strClave)
        //{
        //    conectar.Conectar();
        //    conectar.CrearComando("SP_SELECT_CLIENTE");
        //    //conectar.AsignarParametros("USUARIO", strUsuario, DbType.String);
        //    //conectar.AsignarParametros("CLAVE", strClave, DbType.String);
        //    DataSet dsDatos = conectar.EjecutarDataset();
        //    conectar.Desconectar();
        //    return dsDatos;
        //}

        public DataSet ItemsCatalogo(string strCodigo)
        {
            conectar.Conectar();
            conectar.CrearComando("SP_SELECT_ITEM_CATALOGO_COD");
            conectar.AsignarParametros("codcat", strCodigo, DbType.String);
            DataSet dsDatos = conectar.EjecutarDataset();
            conectar.Desconectar();
            return dsDatos;
        }
    }
}