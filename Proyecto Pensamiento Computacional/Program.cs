int horario = 0;
int opcion;
int tipo;
int edad = 0;
int duracion = 0;
int cumplereglas = 0;
string produccion;
do
{
    Console.WriteLine("MENU.Opciones:Opciones");
    Console.WriteLine("Opcion 1 : Evaluar nuevo contenido  ");
    Console.WriteLine("Opcion 2 : Mostrar reglas del sistema ");
    Console.WriteLine("Opcion 3 : Mostrar estadísticas de la sesión ");
    Console.WriteLine("Opcion 4 : Reiniciar estadísticas");
    Console.WriteLine("Opcion 5 : Salir");
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            {
                //Reglas clasificacion y horario
                Console.WriteLine("Ingrese la edad");
                 edad = int.Parse(Console.ReadLine());
                int Muestreedad(int edad, int horario)
                {
                    if (edad >= 1 && edad < 13)
                    {
                       produccion="Todo publico";
                    }
                    else if (edad >= 13 && edad < 18)
                        if (horario >= 6 && horario >= 22)
                        {
                            produccion="+13";
                        }
                        else if (edad >= 18)
                            if (horario >= 5 && horario <= 22)
                            {
                                Console.WriteLine("Solo Mayores de 18 años");
                            }
                    cumplereglas = edad + horario;
                    return cumplereglas;
                }
                cumplereglas=Muestreedad(edad,horario);
                Console.WriteLine($"Muestre edad: {cumplereglas}");
                //Reglas de duracion por tipo
                Console.WriteLine("Ingrese la duracion en minutos");
                duracion = int.Parse(Console.ReadLine());
                int ClasificaionDuracion(int duracion)
                {
                    if (duracion >= 60 && duracion <= 180)
                    {
                        Console.WriteLine("Pelicula");
                    }
                    else if (duracion >= 20 && duracion <= 90)
                    {
                        Console.WriteLine("Serie");
                    }
                    else if (duracion >= 30 && duracion <= 240)
                    {
                        Console.WriteLine("Evento en Vivo");
                    }
                    else
                    {
                        Console.WriteLine("No cumple la Validacion Tecnica");
                    }
                    duracion = duracion;
                    return duracion;
                }
                duracion = ClasificaionDuracion(duracion);
                Console.WriteLine($"Clasificacion duracion : {duracion} minutos");
                  if (duracion >=60 && duracion <= 180)
                {
                    Console.WriteLine("Pelicula");
                }
                else if (duracion >=20 && duracion <= 90)
                {
                    Console.WriteLine("Serie");
                }
                else if(duracion >=30 && duracion <= 240)
                {
                    Console.WriteLine("Evento en Vivo");
                }
                else
                {
                    Console.WriteLine("No cumple la Validacion Tecnica");
                }
                //Reglas de produccion 
                Console.WriteLine("Se le mostrara el tipo de produccion");
                produccion = "Produccion Baja";
                if (produccion == "Todo Publico" || produccion == "+13")
                {
                    Console.WriteLine("El tipo de produccion es baja ");
                }
                else
                {
                    Console.WriteLine("El tipo de ´produccion es media o baja ");
                }
                // 
                    break;
            }
        case 2:
            {

                break;
            }
    }
} while (opcion != 5);