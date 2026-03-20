
int horario = 0;
int opcion;
string tipodeimpacto = "";
string decisionfinal = "";
int edad = 0;
int duracion = 0;
int cumplereglas; int clasificacion = 0;
string produccion;  string razon = "";
int programado = 0;
bool cumpleReglasTecnicas; bool produccionvalida;
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
                Console.WriteLine("Evaluar Contenido");

                //  EDAD 
                Console.WriteLine("Ingrese la edad:");
                while (!int.TryParse(Console.ReadLine(), out edad) || edad < 1 || edad > 100)
                {
                    Console.WriteLine("Edad inválida. Ingrese un número entre 1 y 100:");
                }

                // HORARIO 
                Console.WriteLine("Ingrese el horario (0 - 23):");
                while (!int.TryParse(Console.ReadLine(), out horario) || horario < 0 || horario > 23)
                {
                    Console.WriteLine("Horario inválido. Ingrese un número entre 0 y 23:");
                }

                //  CLASIFICACIÓN POR EDAD 
                if (edad >= 1 && edad < 13)
                {
                    produccion = "Todo Publico";
                }
                else if (edad >= 13 && edad < 18)
                {
                    if (horario >= 6 && horario <= 22)
                        produccion = "+13";
                    else
                        produccion = "Horario no permitido";
                }
                else
                {
                    if (horario >= 5 && horario <= 23)
                        produccion = "+18";
                    else
                        produccion = "Horario no permitido";
                }

                Console.WriteLine($"Clasificación por edad: {produccion}");

                //DURACIÓN 
                Console.WriteLine("Ingrese la duración en minutos:");
                while (!int.TryParse(Console.ReadLine(), out duracion) || duracion <= 0)
                {
                    Console.WriteLine("Duración inválida. Ingrese un número positivo:");
                }

                string tipoDuracion;

                if (duracion >= 60 && duracion <= 180)
                    tipoDuracion = "Pelicula";
                else if (duracion >= 20 && duracion <= 90)
                    tipoDuracion = "Serie";
                else if (duracion >= 30 && duracion <= 240)
                    tipoDuracion = "Evento en Vivo";
                else
                    tipoDuracion = "No cumple";

                Console.WriteLine($"Tipo de contenido: {tipoDuracion}");

                // VALIDACIÓN TÉCNICA 
                cumpleReglasTecnicas = (duracion >= 20 && duracion <= 240)
                                    && (horario >= 0 && horario <= 23)
                                    && (produccion != "Horario no permitido")
                                    && (tipoDuracion != "No cumple");

                // IMPACTO
                programado = horario;

                if (produccion == "+18" || duracion > 120 || (programado >= 20 && programado <= 23))
                {
                    tipodeimpacto = "Impacto Alto";
                    contadoralto++;
                }
                else if (produccion == "+13" || (duracion >= 60 && duracion <= 120))
                {
                    tipodeimpacto = "Impacto Medio";
                    contadormeedio++;
                }
                else
                {
                    tipodeimpacto = "Impacto Bajo";
                    contadorbajo++;
                }

                Console.WriteLine($"Tipo de impacto: {tipodeimpacto}");

                //  DECISIÓN FINAL 
                if (!cumpleReglasTecnicas)
                {
                    decisionfinal = "Rechazar";
                    contadorrechazados++;
                    razon = "Incumple regla técnica obligatoria";
                }
                else if (tipodeimpacto == "Impacto Alto")
                {
                    decisionfinal = "Enviar a revisión";
                    contadorrevision++;
                    razon = "Cumple reglas técnicas pero su impacto es alto";
                }
                else if (tipodeimpacto == "Impacto Medio" || tipodeimpacto == "Impacto Bajo")
                {
                    decisionfinal = "Publicar";
                    contadorpublicados++;
                    razon = "Cumple reglas técnicas y su impacto es adecuado";
                }
                else
                {
                    decisionfinal = "Publicar con ajustes";
                    razon = "Modificación menor";
                }

                totalevaluados++;
                Console.WriteLine($"Resultado: {decisionfinal}");
                Console.WriteLine($"Razón: {razon}");
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
                Console.Clear();
                for (int i =0;i < 40; i++)
                {
                    Console.Write("=");
                }
                Console.WriteLine(" Mostrar estadísticas de la sesión ");
                totalevaluados = contadorpublicados + contadorrevision + contadorrechazados;
                double porcentajeaprobacion = 0;
                if (totalevaluados > 0)
                {
                    porcentajeaprobacion = (double)contadorpublicados / totalevaluados * 100;
                }
                Console.WriteLine($"Total evaluados : {totalevaluados}");
                Console.WriteLine($"Total Publicados : {contadorpublicados}");
                Console.WriteLine($"Total en Revision {contadorrevision}");
                Console.WriteLine($"Total Rechazados{contadorrechazados}");
                Console.WriteLine($"Porcentaje de aprobacion: {porcentajeaprobacion}");
                break;
            }
        case 4:
            {
                Console.Clear();
                Console.WriteLine("¿Está seguro que desea reiniciar todas las estadísticas? (S/N)");
                string confirmar = Console.ReadLine().ToUpper();
                if (confirmar == "S")
                {
                    contadorpublicados = 0; 
                    contadorrechazados = 0; 
                    contadorrevision = 0; 
                    totalevaluados = 0; 
                    Console.Write("Reiniciando datos: ");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(".");
                    }

                    Console.WriteLine("\n\n¡Estadísticas reiniciadas con éxito!");
                }
                else
                {
                    Console.WriteLine("Operación cancelada.");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
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