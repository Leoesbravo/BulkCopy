using Microsoft.AspNetCore.Http;
using System.Data;
using System.Globalization;

namespace Negocio
{
    public class Carga
    {
        public static DataTable ConvertToDataTable(IFormFile file)
        {
            DataTable dt = new DataTable();
            try
            {
                using (StreamReader reader = new StreamReader(file.OpenReadStream()))
                {
                    //Creamos el header del DT
                    string[] encabezados = reader.ReadLine().Split(',');

                    //Agregamos la columnas al DT
                    foreach (string header in encabezados)
                    {
                        dt.Columns.Add(header.Trim());
                    }

                    //Se leen las demas lineas y las agrega al DT
                    while (!reader.EndOfStream)
                    {                        
                        string[] rows = reader.ReadLine().Split(',');
                        if (rows.Length > 1)
                        {
                            DataRow dataRow = dt.NewRow();

                            dataRow[0] = rows[0].ToString().Trim();
                            dataRow[1] = rows[1].ToString().Trim();
                            dataRow[2] = rows[2].ToString().Trim();
                            if ()
                            string numero = "a321312";
                            //sacar esa letra 
                            numero.Replace("a", "0");
                            dataRow[3] = decimal.Parse(rows[3].ToString().Trim());

                            //Para la fecha
                            //string[] Date = rows[4].Split(' ');
                            //string data = Date[1].Replace('\"', ' ').Trim();
                            //DateTime fechaConvertida = DateTime.ParseExact(data, "dd-MMM-yy", CultureInfo.InvariantCulture);
                            //dataRow[4] = fechaConvertida.ToString("yyyy/MM/dd");

                            //dataRow[4] = rows[4].ToString().Trim();
                            //string[] Date = rows[5].Split(' ');
                            //string data = Date[1].Replace('\"', ' ').Trim();
                            //DateTime fechaConvertida = DateTime.ParseExact(data, "dd-MMM-yy", CultureInfo.InvariantCulture);
                            dataRow[4] = rows[4].ToString();
                            dataRow[5] = rows[5].ToString();
                            dataRow[6] = rows[6].ToString();

                            dt.Rows.Add(dataRow);
                        }                
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo CSV: " + ex.Message);
            }
            return dt;
        }
    }
}
