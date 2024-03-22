using QuanTriTrongOracle.Tab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanTriTrongOracle
{
    public partial class NavForm : Form
    {
        NavigationControl navigationControl;
        NavigationButtons navigationButtons;

        Color btnDefaultColor = Color.MediumSeaGreen;
        Color btnSelectedtColor = Color.Chartreuse;
        public NavForm()
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButton();
        }

        private void InitializeNavigationControl()
        {
            List<UserControl> userControls= new List<UserControl>()
            {
                new XemUser(),new XemPriv(),new EditUserRole(),new PhanQuyen(),new ThuHoiQuyen(),new DetailUser() };
            navigationControl = new NavigationControl(userControls,panel2);
            navigationControl.Display(0);
        }
        private void InitializeNavigationButton()
        {
            List<Button> buttons = new List<Button>() { Nav_XemUser, Nav_XemPriv, Nav_EditUserRole, Nav_PhanQuyen, Nav_ThuHoiQuyen, Nav_DetailUser };
            navigationButtons=new NavigationButtons(buttons,btnDefaultColor,btnSelectedtColor);
            navigationButtons.Hightlight(Nav_XemUser);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void EditUserRole_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Nav_XemUser_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
            navigationButtons.Hightlight(Nav_XemUser);
        }

        private void Nav_XemPriv_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
            navigationButtons.Hightlight(Nav_XemPriv);
        }

        private void Nav_EditUserRole_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButtons.Hightlight(Nav_EditUserRole);
        }

        private void Nav_PhanQuyen_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButtons.Hightlight(Nav_PhanQuyen);
        }

        private void Nav_ThuHoiQuyen_Click(object sender, EventArgs e)
        {
            navigationControl.Display(4);
            navigationButtons.Hightlight(Nav_ThuHoiQuyen);
        }

        private void Nav_DetailUser_Click(object sender, EventArgs e)
        {
            navigationControl.Display(5);
            navigationButtons.Hightlight(Nav_DetailUser);
        }
    }
}
