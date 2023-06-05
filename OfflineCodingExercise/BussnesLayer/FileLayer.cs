using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfflineCodingExercise.Model;

namespace OfflineCodingExercise.BussnesLayer
{
    public class FileLayer : IFileLayer
    {
        public ResponseFile ReadFile( )
        {
            ResponseFile oResponse = new ResponseFile();
            List<string> dataList = new List<string>();
            string pathTxt = "";

            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "|*.txt";
                dialog.Title = "Please select a txt file";

                DialogResult result = dialog.ShowDialog();


                if (result == DialogResult.OK)
                {
                    pathTxt = dialog.FileName;

                    
                    string[] lines = File.ReadAllLines(pathTxt);

  
                    foreach (string line in lines)
                    {

                        string[] elements = line.Split(',');

                        dataList.AddRange(elements);
                    }

                }

                oResponse.Success = true;
                oResponse.Message = pathTxt;
                oResponse.ISBNList = dataList;
            }
            catch (Exception ex)
            {
                oResponse.Success = false;
                oResponse.Message = ex.ToString();
            }

            return oResponse;
        }

        public ResponseFile WriteFile(List<OpenlibraryModel> OpenlibraryModelList)
        {
            ResponseFile oResponse =new ResponseFile();
            try
            {
                string name = "";
                
                SaveFileDialog save = new SaveFileDialog();
                save.RestoreDirectory = true;
                save.AddExtension = true;
                save.DefaultExt = ".csv";
                save.Filter = "txt file|";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(save.FileName))
                    {
                        Type type = typeof(OpenlibraryModel);
                        PropertyInfo[] properties = type.GetProperties();

                        // Escribir el encabezado con los nombres de los campos
                        var columnNames = properties.Select(p =>
                        {
                            var displayNameAttribute = p.GetCustomAttribute<DisplayNameAttribute>();
                            return displayNameAttribute != null ? displayNameAttribute.DisplayName : p.Name;
                        });
                        writer.WriteLine(string.Join(",", columnNames));

                        // Escribir los datos de cada objeto OpenlibraryModel
                        foreach (var item in OpenlibraryModelList)
                        {
                            var fieldValues = properties.Select(p =>
                            {
                                var value = p.GetValue(item)?.ToString() ?? string.Empty;

                                // Escapar el valor si contiene una coma
                                if (value.Contains(","))
                                {
                                    value = "\"" + value + "\"";
                                }

                                return value;
                            });
                            writer.WriteLine(string.Join(",", fieldValues));
                        }
                    }

                    oResponse.Success = true;
                    oResponse.Message = "Complete";
                }


                
            }
            catch (Exception ex)
            {
                oResponse.Success = false;
                oResponse.Message = ex.ToString();
            }

             return oResponse;
        }
    }
}
