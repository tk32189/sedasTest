using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedas.Control
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            Assembly asm = typeof(DevExpress.UserSkins.Seda20200611).Assembly;
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);



            InitializeComponent();
        }

        // This code adds the "SkinRegistration" component to the Visual Studio toolbox  
        // Drop this component onto the main application form to be able to change skins at design time  
        public class SkinRegistration : Component
        {
            public SkinRegistration()
            {
                DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.Seda20200611).Assembly);
            }
        }

    }
}
