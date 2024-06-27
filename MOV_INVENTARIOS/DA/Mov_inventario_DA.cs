using Microsoft.Data.SqlClient;
using MOV_INVENTARIOS.Models;
using System.Data;

namespace MOV_INVENTARIOS.DA
{
    public class Mov_inventario_DA
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;

        public static IConfiguration Configuration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory
                ()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            return Configuration.GetConnectionString("DefaultConnection");
        }

        public List<Mov_inventario> GetAll()
        {
            List<Mov_inventario> inventarioList = new List<Mov_inventario>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "dbo.usp_get_Inventarios";
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();

                while (dr.Read())
                {
                    Mov_inventario mov_inventario = new Mov_inventario();
                    mov_inventario.COD_CIA = dr["COD_CIA"].ToString();
                    mov_inventario.COMPANIA_VENTA_3 = dr["COMPANIA_VENTA_3"].ToString();
                    mov_inventario.ALMACEN_VENTA = dr["ALMACEN_VENTA"].ToString();
                    mov_inventario.TIPO_MOVIMIENTO = dr["TIPO_MOVIMIENTO"].ToString();
                    mov_inventario.TIPO_DOCUMENTO = dr["TIPO_DOCUMENTO"].ToString();
                    mov_inventario.NRO_DOCUMENTO = dr["NRO_DOCUMENTO"].ToString();
                    mov_inventario.COD_ITEM_2 = dr["COD_ITEM_2"].ToString();
                    mov_inventario.PROVEEDOR = dr["PROVEEDOR"].ToString();
                    mov_inventario.ALMACEN_DESTINO = dr["ALMACEN_DESTINO"].ToString();
                    mov_inventario.CANTIDAD = dr["CANTIDAD"].ToString();
                    mov_inventario.COMPANIA_DESTINO = dr["COMPANIA_DESTINO"].ToString();
                    mov_inventario.COSTO_UNITARIO = dr["COSTO_UNITARIO"].ToString();
                    mov_inventario.DOC_REF_1 = dr["DOC_REF_1"].ToString();
                    mov_inventario.DOC_REF_2 = dr["DOC_REF_2"].ToString();
                    mov_inventario.FECHA_TRANSACCION = dr["FECHA_TRANSACCION"].ToString();

                    inventarioList.Add(mov_inventario);
                }
                _connection.Close();
            }
            return inventarioList;
        }


        public bool Insert(Mov_inventario model)
        {
            int id = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "dbo.usp_Insert_Inventario";
                _command.Parameters.AddWithValue("@COD_CIA", model.COD_CIA);
                _command.Parameters.AddWithValue("@COMPANIA_VENTA_3", model.COMPANIA_VENTA_3);
                _command.Parameters.AddWithValue("@ALMACEN_VENTA", model.ALMACEN_VENTA);
                _command.Parameters.AddWithValue("@TIPO_MOVIMIENTO", model.TIPO_MOVIMIENTO);
                _command.Parameters.AddWithValue("@TIPO_DOCUMENTO", model.TIPO_DOCUMENTO);
                _command.Parameters.AddWithValue("@NRO_DOCUMENTO", model.NRO_DOCUMENTO);
                _command.Parameters.AddWithValue("@COD_ITEM_2", model.COD_ITEM_2);
                _command.Parameters.AddWithValue("@PROVEEDOR", model.PROVEEDOR);
                _command.Parameters.AddWithValue("@ALMACEN_DESTINO", model.ALMACEN_DESTINO);
                _command.Parameters.AddWithValue("@CANTIDAD", model.CANTIDAD);
                _command.Parameters.AddWithValue("@COMPANIA_DESTINO", model.COMPANIA_DESTINO);
                _command.Parameters.AddWithValue("@COSTO_UNITARIO", model.COSTO_UNITARIO);
                _command.Parameters.AddWithValue("@DOC_REF_1", model.DOC_REF_1);
                _command.Parameters.AddWithValue("@DOC_REF_2", model.DOC_REF_2);
                _command.Parameters.AddWithValue("@FECHA_TRANSACCION", model.FECHA_TRANSACCION);
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();
            }
            return id > 0 ? true : false;
        }


        public List<Mov_inventario> GetByFilter(string fechaI,string fechaF,string tipo,string nro)
        {
            List<Mov_inventario> inventarioList = new List<Mov_inventario>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "dbo.usp_get_Filter_Inventarios";
                _command.Parameters.AddWithValue("@FECHA_INICIO", fechaI);
                _command.Parameters.AddWithValue("@FECHA_FIN", fechaF);
                _command.Parameters.AddWithValue("@TIPO_MOVIMIENTO", tipo);
                _command.Parameters.AddWithValue("@NRO_DOCUMENTO", nro);
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();

                while (dr.Read())
                {
                    Mov_inventario mov_inventario = new Mov_inventario();
                    mov_inventario.COD_CIA = dr["COD_CIA"].ToString();
                    mov_inventario.COMPANIA_VENTA_3 = dr["COMPANIA_VENTA_3"].ToString();
                    mov_inventario.ALMACEN_VENTA = dr["ALMACEN_VENTA"].ToString();
                    mov_inventario.TIPO_MOVIMIENTO = dr["TIPO_MOVIMIENTO"].ToString();
                    mov_inventario.TIPO_DOCUMENTO = dr["TIPO_DOCUMENTO"].ToString();
                    mov_inventario.NRO_DOCUMENTO = dr["NRO_DOCUMENTO"].ToString();
                    mov_inventario.COD_ITEM_2 = dr["COD_ITEM_2"].ToString();
                    mov_inventario.PROVEEDOR = dr["PROVEEDOR"].ToString();
                    mov_inventario.ALMACEN_DESTINO = dr["ALMACEN_DESTINO"].ToString();
                    mov_inventario.CANTIDAD = dr["CANTIDAD"].ToString();
                    mov_inventario.COMPANIA_DESTINO = dr["COMPANIA_DESTINO"].ToString();
                    mov_inventario.COSTO_UNITARIO = dr["COSTO_UNITARIO"].ToString();
                    mov_inventario.DOC_REF_1 = dr["DOC_REF_1"].ToString();
                    mov_inventario.DOC_REF_2 = dr["DOC_REF_2"].ToString();
                    mov_inventario.FECHA_TRANSACCION = dr["FECHA_TRANSACCION"].ToString();

                    inventarioList.Add(mov_inventario);
                }
                _connection.Close();
            }
            return inventarioList;
        }


    }
}

