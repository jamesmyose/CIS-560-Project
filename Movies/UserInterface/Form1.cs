using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoviesData.Models;
using MoviesData;


namespace UserInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_ActorMovie_Click(object sender, EventArgs e)
        {
            Console.Write("First name of the actor: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name of the actor: ");
            string lastName = Console.ReadLine();
            SqlMoviesRepository a = new SqlMoviesRepository("a");
            IReadOnlyList<Movie> movie = a.ActorMovie(firstName, lastName);

            foreach (Movie i in movie) {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
