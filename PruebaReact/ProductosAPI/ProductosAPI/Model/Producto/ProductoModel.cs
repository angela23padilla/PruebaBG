namespace ProductosAPI.Model.Producto
{
    public class Productos { 

        public int ProductoID { get; set; }
        public string Nombre { get; set;}
        public string Descripcion { get; set;}
        public decimal Precio { get; set;}
        public int Stock { get; set;}
        public string Categoria { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Imagen { get; set; }


        public int EstadoID { get; set; }    
        public Boolean Validacion { get; set; }    
    
    }

    public class GrabarProductoModel
    {
       
        public int ProductoID { get; set; }
        public int UsuarioID { get; set; }
        


    }

    public class ModificarProductoModel
    {
        public int ProductoID { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }


    }

    public class EliminarProductoModel
    {
        public int ProductoID { get; set; }
        public int UsuarioID { get; set; }

    }
}
