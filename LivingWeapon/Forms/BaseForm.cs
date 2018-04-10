using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivingWeapon
{
    public partial class BaseForm : Form
    {
        //フォームを閉じた時、戻るのかアプリケーションを終了するのかのフラグ
        protected bool _backFlag = false;

        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
