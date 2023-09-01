using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenamientoRecursividadWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void OrdenarButton_Click(object sender, EventArgs e)
        {
           
        }
        private void ListarArchivosRecursivo(string directorio)
        {
            try
            {
                string[] archivos = Directory.GetFiles(directorio).OrderBy(fileName => fileName).ToArray();

                foreach (string archivo in archivos)
                {
                    listBoxArchivos.Items.Add("Archivo: " + Path.GetFileName(archivo) + " - Extensión: " + Path.GetExtension(archivo));
                }

                string[] subdirectorios = Directory.GetDirectories(directorio);
                foreach (string subdirectorio in subdirectorios)
                {
                    ListarArchivosRecursivo(subdirectorio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaCarpeta = dialog.SelectedPath;
                    listBoxArchivos.Items.Clear(); // Limpiar lista antes de mostrar resultados
                    ListarArchivosRecursivo(rutaCarpeta);
                }
            }
        }
    }
}

