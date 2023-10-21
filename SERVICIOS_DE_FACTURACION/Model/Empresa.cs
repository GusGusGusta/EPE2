//Se crean los metodos GET y SET para los Clientes
public class D_Empresa{
public int Id { get; set; }
public String? Nombre_Cliente { get; set; }
public String? Apellido_CLiente { get; set; }
public int Edad_CLiente { get; set; }
public String? Rut_CLiente { get; set; }

//Se crean los metodos GET y SET para las Empresas

public String? Nombre_Empresa { get; set; }
public String Rut_Empresa { get; set; }
public String? Giro_Empresa { get; set; }
public float Total_Ventas { get; set; }
public float Ventas_Hechas { get; set; }
public float Iva_Pagar { get; set; }
public float Utilidades_Mes { get; set; }
}