

namespace CRUDMARKET.WEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Almacen
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<decimal> PRECIO { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
    }
}
