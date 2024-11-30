using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EntityFramework
{
    public partial class frmStatistics : Form
    {
        public frmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void frmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();

            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();

            lblGuideCount.Text = db.Guide.Count().ToString();

            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).ToString();

            lblAvgPrice.Text = string.Format("{0:0.00}", db.Location.Average(x => x.Price)) + " ₺";

            lblLastCountry.Text = db.Location.Select(x => x.Country).ToList().Last();

            lblCappadociaCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTrAvgCapacity.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            lblRomeGuideName.Text = db.Location.Where(x => x.City == "Roma").Select(y => y.Guide.Name + " " + y.Guide.Surname).FirstOrDefault();

            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacity.Text = db.Location.Where(y => y.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMostExpensiveTour.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault();

            var aysegulCinarId = db.Guide.Where(x => x.Name == "Ayşegül" && x.Surname == "Çınar").Select(x => x.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text = db.Location.Count(x => x.GuideId == aysegulCinarId).ToString();
        }
    }
}
