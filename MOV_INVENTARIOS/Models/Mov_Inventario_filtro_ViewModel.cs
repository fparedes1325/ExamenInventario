using System.ComponentModel.DataAnnotations;

namespace MOV_INVENTARIOS.Models
{
    public class Mov_Inventario_filtro_ViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public string FechaI { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public string FechaF { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Nro { get; set; }

        public List<Mov_inventario> Listado { get; set; }
    }
}
