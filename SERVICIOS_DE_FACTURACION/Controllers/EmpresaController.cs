using Microsoft.AspNetCore.Mvc;

namespace EPE2_GustamoMiranda.Servicios_De_Facturacion.Controllers;

[ApiController]

//se hace referencia al modelo Empresa
public class Empresa:ControllerBase{

// se realiza un arreglo ingresando con lod daotos requeridos
public D_Empresa [] DatosEmpresa = new D_Empresa []{

new D_Empresa {Id=1,Nombre_Cliente ="Gustavo", Apellido_CLiente = "Miranda", Edad_CLiente = 30 , Rut_CLiente ="18.153.450-8",
Nombre_Empresa="Tottus", Rut_Empresa="78.627.210-6",Giro_Empresa="venta minorista (retail)",Total_Ventas=300,Ventas_Hechas=3000000,Iva_Pagar=570000,Utilidades_Mes=2430000},

new D_Empresa {Id=2,Nombre_Cliente ="Maria", Apellido_CLiente = "Diaz", Edad_CLiente = 30 , Rut_CLiente ="24.537.563-8",
Nombre_Empresa="Lider", Rut_Empresa="78.968.610-6",Giro_Empresa="venta minorista (retail)",Total_Ventas=300,Ventas_Hechas=3000000,Iva_Pagar=570000,Utilidades_Mes=2430000},

new D_Empresa {Id=3,Nombre_Cliente ="Alejandra", Apellido_CLiente = "Ojeda", Edad_CLiente = 30 , Rut_CLiente ="10.307.641-2",
Nombre_Empresa="Santa Isabel", Rut_Empresa="84.671.700-5",Giro_Empresa="venta minorista (retail)",Total_Ventas=300,Ventas_Hechas=3000000,Iva_Pagar=570000,Utilidades_Mes=2430000},

};



//se realiza un consultor para llamar todos los registros 
 [HttpGet]
 [Route("Datos Solicitados 3 Empresas")]
public IActionResult Listar(){

    try {

            if (DatosEmpresa != null){
              for (int x =0; x < DatosEmpresa.Length; x++){
              
                Console.WriteLine(DatosEmpresa[x]);
            }
            //imprimimos el status code 200 que es correcto
            return StatusCode(200, DatosEmpresa);

            }else{
                return StatusCode (401, "No se encontraron daros");
            }

            

    }catch (Exception ){
     
            return StatusCode (401, "No se encontraron daros");

    }
}



//se realiza un consultor para llamar todos los datos de una empresa en particular por medio de su ID
        [HttpGet]
        [Route("Datos de una sola empresa por su Id")]

        public IActionResult ListarEmpresa(int id){

            try{

                if(id > 0 && id <=DatosEmpresa.Length){
                    //imprimimos el status code 200 que es correcto
                    return StatusCode(200,DatosEmpresa[id-1]);


                }else{
                    // se imprime error 
                    return StatusCode(401,"No se ha encontrado el alumno");
                }

            }catch(Exception ex){
                // se imprime error 
                return StatusCode(500, "Error interno por :"+ex);

            }
        }


//se realiza un generador para crear y guardar nuevos registros 
      [HttpPost]
      [Route("Crear Nueva Empresa")]

      public IActionResult Guarda([FromBody] D_Empresa d_Empresa){

        try{
            //imprimimos el status code 200 que es correcto
            return StatusCode(200, DatosEmpresa);

        }catch(Exception ex){
            //imprimimos que no se pudo crear la empresa
            return StatusCode(400, "No se pudo crear la persona por: "+ex);

        }

      } 


     [HttpPut]
    [Route("Editar datos de una Empresa por su Id")]

    public IActionResult EditarEmpresa(int id, [FromBody] D_Empresa d_Empresa){
        //creamos elemento de control para recorrer el arreglo
        if (id > 0 && id <= DatosEmpresa.Length){

            //procedemos a la edicion de la Empresa
                DatosEmpresa[id-1].Nombre_Cliente=d_Empresa.Nombre_Cliente;
                DatosEmpresa[id-1].Apellido_CLiente=d_Empresa.Apellido_CLiente;
                DatosEmpresa[id-1].Edad_CLiente=d_Empresa.Edad_CLiente;
                DatosEmpresa[id-1].Rut_CLiente=d_Empresa.Rut_CLiente;
                DatosEmpresa[id-1].Nombre_Empresa=d_Empresa.Nombre_Empresa;
                DatosEmpresa[id-1].Rut_Empresa = d_Empresa.Rut_Empresa;
                DatosEmpresa[id-1].Giro_Empresa = d_Empresa.Giro_Empresa;
                DatosEmpresa[id-1].Total_Ventas = d_Empresa.Total_Ventas;
                DatosEmpresa[id-1].Ventas_Hechas = d_Empresa.Ventas_Hechas;
                DatosEmpresa[id-1].Iva_Pagar = d_Empresa.Iva_Pagar;
                DatosEmpresa[id-1].Utilidades_Mes = d_Empresa.Utilidades_Mes;

            
            //imprimimos el status code 200 que es correcto
            return StatusCode(200, DatosEmpresa[id-1]);

        }else if(id==0){

            //imprimimos en consola que no se encontro la persona
            Console.WriteLine("Persona No encontrada");
            return StatusCode(404);


        }else{

            //imprimimos que no se pudo editar la persona
            Console.WriteLine("No se pudo editar la persona");
            return StatusCode(400);

        }



    }



//se realiza un consultor para eliminar un registro por medio de su ID
    [HttpDelete]
    [Route("Eliminar una empresa por su Id")]

    public IActionResult ElimniarEmpresa(int id){

        try{

            if(id >0 && id <= DatosEmpresa.Length){

                DatosEmpresa[id-1] = null;
                // se imprime exito en eliminar
                return StatusCode(200, "Se ha eliminado el registro con EXITO!");

            }else{
                // se imprime error de eliminar registro
                return StatusCode(401, "No se pudo borrar el registro o no existe");

            }


        }catch(Exception ex){
            // se imprime error de eliminar registro
            return StatusCode(500, "No se pudo borrar por: "+ex);

        }

    } 


}