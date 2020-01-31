using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaPuntoDeVenta.Repositorio;
using SistemaPuntoDeVenta.Modelo;
using SistemaPuntoDeVenta.Reporte;

namespace SistemaPuntoDeVenta.Vista
{
    public partial class UsuarioVista : Form
    {
        private List<Usuario> usuarios = new List<Usuario>();
        public UsuarioVista()
        {
            InitializeComponent();
        }

        private void UsuarioVista_Load(object sender, EventArgs e)
        {
            onRefrescar();
        }

        private void onRefrescar()
        {
            usuarios = UsuarioRepositorio.Instance.findAll();
            comboBox1.Items.Clear();
            UsuarioDatos.Rows.Clear();
            foreach (Usuario us in usuarios)
            {
                comboBox1.Items.Add(us.Id_usuario);
                UsuarioDatos.Rows.Add(us.Id_usuario, us.Nombre_usuario, us.Nombre, us.Contraseña);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario = usuarios.Where( u=> u.Id_usuario == int.Parse(comboBox1.Text)).ToList<Usuario>().First<Usuario>();
            textBox1.Text = usuario.Nombre_usuario;
            textBox2.Text = usuario.Nombre;
            textBox3.Text = usuario.Contraseña;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Nombre_usuario = textBox1.Text;
                usuario.Nombre = textBox2.Text;
                usuario.Contraseña = textBox3.Text;
                UsuarioRepositorio.Instance.save(usuario);
                onRefrescar();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Id_usuario = int.Parse(comboBox1.Text);
                usuario.Nombre_usuario = textBox1.Text;
                usuario.Nombre = textBox2.Text;
                usuario.Contraseña = textBox3.Text;
                UsuarioRepositorio.Instance.update(usuario);
                onRefrescar();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Id_usuario = int.Parse(comboBox1.Text);
                UsuarioRepositorio.Instance.delete(usuario);
                onRefrescar();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new UsuarioImprimir().Show();
        }

        private void UsuarioDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex+"");
        }
    }
}
