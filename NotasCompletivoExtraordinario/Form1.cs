using System;
using System.Windows.Forms;

namespace NotasCompletivoExtraordinario
{
    public partial class Form1 : Form
    {
        int etapa = 1;

        double promedioNormal = 0;
        double promedioCompletivo = 0;
        double promedioExtraordinario = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Ingrese el nombre del estudiante.");
                    return;
                }

                double nota1 = double.Parse(txtNota1.Text);
                double nota2 = double.Parse(txtNota2.Text);
                double nota3 = double.Parse(txtNota3.Text);
                double nota4 = double.Parse(txtNota4.Text);

                if (nota1 < 0 || nota1 > 100 ||
                    nota2 < 0 || nota2 > 100 ||
                    nota3 < 0 || nota3 > 100 ||
                    nota4 < 0 || nota4 > 100)
                {
                    MessageBox.Show("Las notas deben estar entre 0 y 100.");
                    return;
                }

                double promedio = (nota1 + nota2 + nota3 + nota4) / 4;

                // NORMAL
                if (etapa == 1)
                {
                    promedioNormal = promedio;
                    txtPromedioNormal.Text = promedioNormal.ToString("0.00");

                    if (promedioNormal >= 70)
                    {
                        lblResultado.Text =
                            "Estudiante: " + nombre +
                            "\nPromedio Normal: " + promedioNormal.ToString("0.00") +
                            "\nEstado Final: APROBADO";
                    }
                    else
                    {
                        etapa = 2;

                        MessageBox.Show(
                            "El estudiante pasó a COMPLETIVO.\nIngrese las nuevas 4 notas.");

                        txtNota1.Clear();
                        txtNota2.Clear();
                        txtNota3.Clear();
                        txtNota4.Clear();

                        txtNota1.Focus();
                    }
                }

                // COMPLETIVO
                else if (etapa == 2)
                {
                    promedioCompletivo = promedio;
                    txtCompletivo.Text = promedioCompletivo.ToString("0.00");

                    if (promedioCompletivo >= 70)
                    {
                        lblResultado.Text =
                            "Estudiante: " + nombre +
                            "\nPromedio Normal: " + promedioNormal.ToString("0.00") +
                            "\nPromedio Completivo: " + promedioCompletivo.ToString("0.00") +
                            "\nEstado Final: APROBADO POR COMPLETIVO";

                        etapa = 1;
                    }
                    else
                    {
                        etapa = 3;

                        MessageBox.Show(
                            "El estudiante pasó a EXTRAORDINARIO.\nIngrese las nuevas 4 notas.");

                        txtNota1.Clear();
                        txtNota2.Clear();
                        txtNota3.Clear();
                        txtNota4.Clear();

                        txtNota1.Focus();
                    }
                }

                // EXTRAORDINARIO
                else if (etapa == 3)
                {
                    promedioExtraordinario = promedio;
                    txtExtraordinario.Text = promedioExtraordinario.ToString("0.00");

                    if (promedioExtraordinario >= 70)
                    {
                        lblResultado.Text =
                            "Estudiante: " + nombre +
                            "\nPromedio Normal: " + promedioNormal.ToString("0.00") +
                            "\nPromedio Completivo: " + promedioCompletivo.ToString("0.00") +
                            "\nPromedio Extraordinario: " + promedioExtraordinario.ToString("0.00") +
                            "\nEstado Final: APROBADO POR EXTRAORDINARIO";
                    }
                    else
                    {
                        lblResultado.Text =
                            "Estudiante: " + nombre +
                            "\nPromedio Normal: " + promedioNormal.ToString("0.00") +
                            "\nPromedio Completivo: " + promedioCompletivo.ToString("0.00") +
                            "\nPromedio Extraordinario: " + promedioExtraordinario.ToString("0.00") +
                            "\nEstado Final: REPROBADO";
                    }

                    etapa = 1;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese solamente números válidos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtNota4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}