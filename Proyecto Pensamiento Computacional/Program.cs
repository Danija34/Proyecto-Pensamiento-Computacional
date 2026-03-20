int horario = 0;
int opcion;
string tipodeimpacto = "";
string decisionfinal = "";
int edad = 0;
int duracion = 0;
int cumplereglas;
string produccion;  string razon = "";
int programado = 0;
bool cumpleReglasTecnicas = false;
int contadorpublicados = 0;   int contadorrechazados = 0;    int contadorrevision = 0; int totalevaluados = 0;
int contadorbajo = 0; int contadormeedio = 0; int contadoralto = 0;
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
                    Console.WriteLine("El tipo de produccion es media o baja ");
                }
                // Clasificacion de impacto
                if (produccion== "Produccion Alta" || duracion >120 ||  programado >=20 && programado <=23)
                {
                    tipodeimpacto = "Impacto Alto";
                }
                else if (produccion=="Produccion Media" || duracion >= 60 && duracion <= 120)
                {
                    tipodeimpacto = "Impacto Medio";
                }
                else if (produccion == "Produccion Baja" || duracion < 60)
                {
                    tipodeimpacto = "Impacto Bajo";
                }
                else
                {
                    tipodeimpacto = "Rechazado";
                }
                // Desicion Final
                if (!cumpleReglasTecnicas)
                {
                    decisionfinal = "Rechazar";
                    contadorrechazados++;
                    razon = "Incumple regla tecnica obligatoria";
                }
                else if(tipodeimpacto=="Impacto Alto")
                {
                    decisionfinal = "Enviar a revision";
                    contadorrevision++;
                    razon = "Si cumple las reglas tecnicas pero su impacto es Alto";
                }
                else if(tipodeimpacto== "Impacto Medio" ||produccion=="Impacto Bajo")
                {
                    decisionfinal = "Publicar";
                    contadorpublicados++;
                        razon = "Cumple todas las reglas tecnicas y su impacto es adecuado";
                }
                else
                {
                    decisionfinal = "Publicar con ajustes";
                    razon = "Modificacion menor en horarios o duracion";
                }
                Console.WriteLine($"Resultado: {decisionfinal}");
                Console.WriteLine($"Razon : {razon}");
                    break;
            }
        case 2:
            {
                Console.Clear();
                Console.WriteLine(" Reglas Obligatoriosas del sistema: ");
                Console.WriteLine("Numero 1. REGLAS DE CLASIFICACION Y HORARIO ");
                Console.WriteLine("Todo Publico: Cualquier Hora del Dia");
                Console.WriteLine("+13 Permitido entre las 6:00 y 22:00 horas");
                Console.WriteLine("+18 Permitido entre las 22:00 y 5:00 horas");
                Console.WriteLine("Numero 2. RANGOS DE DURACION PERMITIDOS");
                Console.WriteLine("Pelicula: 60 a 180 minutos");
                Console.WriteLine("Serie: 20 a 90 minutos");
                Console.WriteLine("Documental: 30 a 120 minutos");
                Console.WriteLine("Evento en vivo: 30 a 240 minutos");
                Console.WriteLine("Numero 3. REGLAS DE NIVEL DE PRODUCCIÓN");
                Console.WriteLine("Produccion baja: Solo para todo publico o +13");
                Console.WriteLine("Produccion Media / Alta: Cualquier Clasificacion");
                Console.WriteLine("Numero 4. CRITERIOS DE DESICIÓN");
                Console.WriteLine("Publicar: cumple tecnica y impacto bajo/medio");
                Console.WriteLine("Revision: Cumple tecnica pero impacto Alto");
                Console.WriteLine("Rechazar: Incumple Reglas");
                Console.ReadKey();
                break;
            }
        case 3:
            {
                Console.WriteLine("Resumen de Procesos");
                Console.WriteLine($"Total Publicados : {contadorpublicados}");
                Console.WriteLine($"Total en Revision {contadorrevision}");
                Console.WriteLine($"Total Rechazados{contadorrechazados}");
                Console.WriteLine("");
                break;
            }
        case 4:
            {

                break;
            }
        case 5:
            {
                Console.WriteLine("Saliendo...");
                break;
            }
        default:
            {
                Console.WriteLine("Opcion Invalida");
                break;
            }
    }
} while (opcion != 5);