using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MOV_INVENTARIOS.Models
{
    public class Mov_inventario
    {
        //Key]

        [Required]
        public string COD_CIA { get; set; }

        [Required]
        public string COMPANIA_VENTA_3 { get; set; }

        [Required]
        public string ALMACEN_VENTA { get; set; }

        [Required]
        public string TIPO_MOVIMIENTO { get; set; }

        [Required]
        public string TIPO_DOCUMENTO { get; set; }

        [Required]
        public string NRO_DOCUMENTO { get; set; }

        [Required]
        public string COD_ITEM_2 { get; set; }




        public string PROVEEDOR { get; set; }

        public string ALMACEN_DESTINO { get; set; }

        public string CANTIDAD { get; set; }

        public string COMPANIA_DESTINO { get; set; }

        public string COSTO_UNITARIO { get; set; }

        public string DOC_REF_1 { get; set; }

        public string DOC_REF_2 { get; set; }

        public string FECHA_TRANSACCION { get; set; }

    }
}


