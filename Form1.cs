using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e){
        }

        private void groupBox1_Enter(object sender, EventArgs e){
        }

        private void label2_Click(object sender, EventArgs e){
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridView1.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            Conexion.Conectar();

            DataTable dt = new DataTable();

            string consulta = "SELECT * FROM Producto";

            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string agregar_Click = "INSERT INTO Producto(id_producto, nombre_producto, cantidad_producto)" +
                "VALUES (@id_producto, @nombre_producto, @cantidad_producto)";

            SqlCommand cmd1 = new SqlCommand(agregar_Click, Conexion.Conectar());

            cmd1.Parameters.AddWithValue("@id_producto", id_producto.Text);
            cmd1.Parameters.AddWithValue("@nombre_producto", nombre_producto.Text);
            cmd1.Parameters.AddWithValue("@cantidad_producto", cantidad_producto.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Datos agregados con exito (～￣▽￣)～");

            dataGridView1.DataSource = llenar_grid();
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string modificar_Click = "UPDATE Producto SET id_producto=@id_producto, nombre_producto=@nombre_producto, cantidad_producto=@cantidad_producto WHERE id_producto=@id_producto";

            SqlCommand cmd2 = new SqlCommand(modificar_Click, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@id_producto", id_producto.Text);
            cmd2.Parameters.AddWithValue("@nombre_producto", nombre_producto.Text);
            cmd2.Parameters.AddWithValue("@cantidad_producto", cantidad_producto.Text);

            cmd2.ExecuteNonQuery();

            dataGridView1.DataSource = llenar_grid();
        }


        private void eliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string Eliminar = "DELETE FROM Producto WHERE id_producto=@id_producto";

            SqlCommand cmd3 = new SqlCommand(Eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@id_producto", id_producto.Text);

            cmd3.ExecuteNonQuery();

            dataGridView1.DataSource = llenar_grid();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            id_producto.Clear();
            nombre_producto.Clear();
            cantidad_producto.Clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_producto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                nombre_producto.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cantidad_producto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch { 
            }
        }
    }
}
