using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanTriTrongOracle.TabTDV;


namespace QuanTriTrongOracle
{
    public partial class NavTDV : Form
    {
        NavigationControl navigationControl_TDV;
        NavigationButtons navigationButtons_TDV;

        Color btnDefaultColor_TDV = Color.MediumSeaGreen;
        Color btnSelectedtColor_TDV = Color.Chartreuse;

        public NavTDV()
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButton();
        }

        private void InitializeNavigationControl()
        {
            List<UserControl> userControls = new List<UserControl>()
            { new TDV_XemThongTin(), new TDV_XemSinhVien(), new TDV_XemDonVi(), new TDV_XemHocPhan(), new TDV_XemKHMo(),
              new TDV_XemPhanCong(), new TDV_DangKy() };
            navigationControl_TDV = new NavigationControl(userControls, panel2_TDV);
            navigationControl_TDV.Display(0);
        }
        private void InitializeNavigationButton()
        {
            List<Button> buttons = new List<Button>() { Nav_XemThongTin, Nav_XemSinhVien, Nav_XemDonVi, Nav_XemHocPhan,
                                                        Nav_XemKHMo, Nav_XemPhanCong,Nav_DangKy };
            navigationButtons_TDV = new NavigationButtons(buttons, btnDefaultColor_TDV, btnSelectedtColor_TDV);
            navigationButtons_TDV.Hightlight(Nav_XemThongTin);
        }

        private void Nav_XemThongTin_Click(object sender, EventArgs e)
        {
            navigationControl_TDV.Display(0);
            navigationButtons_TDV.Hightlight(Nav_XemThongTin);
        }

        private void Nav_XemSinhVien_Click(object sender, EventArgs e)
        {
            navigationControl_TDV.Display(1);
            navigationButtons_TDV.Hightlight(Nav_XemSinhVien);
        }

        private void Nav_XemDonVi_Click(object sender, EventArgs e)
        {
            navigationControl_TDV.Display(2);
            navigationButtons_TDV.Hightlight(Nav_XemDonVi);
        }
        private void Nav_XemHocPhan_Click(object sender, EventArgs e)
        {
            navigationControl_TDV.Display(3);
            navigationButtons_TDV.Hightlight(Nav_XemHocPhan);
        }

        private void Nav_XemKHMo_Click(object sender, EventArgs e)
        {
            navigationControl_TDV.Display(4);
            navigationButtons_TDV.Hightlight(Nav_XemKHMo);
        }

        private void Nav_XemPhanCong_Click(object sender, EventArgs e)
        {
            navigationControl_TDV.Display(5);
            navigationButtons_TDV.Hightlight(Nav_XemPhanCong);
        }

        private void Nav_DangKy_Click(object sender, EventArgs e)
        {
            navigationControl_TDV.Display(6);
            navigationButtons_TDV.Hightlight(Nav_DangKy);
        }
    }
}
