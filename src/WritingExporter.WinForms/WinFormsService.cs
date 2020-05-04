using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleInjector;

namespace WritingExporter.WinForms
{
    public class WinFormsService
    {
        SimpleInjector.Container _container;

        public WinFormsService(SimpleInjector.Container container)
        {
            _container = container;
        }

        public TForm GetForm<TForm>() where TForm : Form
        {
            return _container.GetInstance<TForm>();
        }

    }
}
