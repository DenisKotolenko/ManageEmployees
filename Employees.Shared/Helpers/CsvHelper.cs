using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Employees.Shared.Helpers
{
    /// <summary>
    /// Class used for Csv (Coma Separated Values) related manipulation.
    /// </summary>
    [ExcludeFromCodeCoverage] //static classes are not testable. However testing could be done with wrapper.
    public static class CsvHelper
    {
        private static readonly int DataGridButtonsColumOffset = 2;

        /// <summary>
        /// NOTE: Not my code. Source: https://www.c-sharpcorner.com/blogs/export-datagridview-data-to-csv-in-c-sharp
        /// </summary>
        /// <param name="dataGridView">DataGridView for CSV export.</param>
        public static void ExportDataGridToCsv(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count > 0)
            {
                var sfd = new SaveFileDialog
                {
                    Filter = @"CSV (*.csv)|*.csv",
                    FileName = "Output.csv"
                };

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var fileError = false;
                if (File.Exists(sfd.FileName))
                {
                    try
                    {
                        File.Delete(sfd.FileName);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                if (fileError)
                {
                    return;
                }
                {
                    try
                    {
                        int columnCount = dataGridView.Columns.Count - DataGridButtonsColumOffset;
                        var columnNames = string.Empty;
                        var outputCsv = new string[dataGridView.Rows.Count + 1];
                        for (var i = 0; i < columnCount; i++)
                        {
                            columnNames += dataGridView.Columns[i].HeaderText + ",";
                        }
                        outputCsv[0] += columnNames;

                        for (var i = 1; i - 1 < dataGridView.Rows.Count; i++)
                        {
                            for (var j = 0; j < columnCount; j++)
                            {
                                outputCsv[i] += dataGridView.Rows[i - 1].Cells[j].Value + ",";
                            }
                        }

                        File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                        MessageBox.Show("Data Exported Successfully !!!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
}