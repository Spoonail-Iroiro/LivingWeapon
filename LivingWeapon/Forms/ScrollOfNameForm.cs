using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivingWeapon.MyExt;

namespace LivingWeapon
{
    public partial class ScrollOfNameForm : BaseForm
    {
        int _targetPage;

        int _nowPage;
        private int PageNow
        {
            get
            {
                return _nowPage;
            }
            set
            {
                SetPage(value);
            }
        }

        LabelList _llist;

        SignatureList _sigList;

        Signature _searchTarget;
        Signature SearchTarget
        {
            get { return _searchTarget; }
            set
            {
                _searchTarget = value;

                if(value == null)
                {
                    lblSearchTarget.Text = "";
                    _llist.RemoveHighlight(Color.Yellow);
                    return;
                }

                PageNow = value.Page;
                lblSearchTarget.Text = value.Name;

            }
        }

        Signature _goalTarget;

        public ScrollOfNameForm()
        {
            InitializeComponent();

            _llist = new LabelList(this, lblNameList);

            _sigList = Lists.SigList;

            lblPageCountAll.Text = _sigList.SigList.Last().Page.ToString();
        }

        public ScrollOfNameForm(int page):this()
        {
            _targetPage = page;

            PageNow = page;

            lblGoalPage.Text = page.ToString().PadLeft(4);
        }

        public ScrollOfNameForm(Signature sig) : this()
        {
            _targetPage = sig.Page;

            PageNow = sig.Page;

            lblGoalPage.Text = sig.Page.ToString().PadLeft(4);

            lblEnchName.Text = "『{0}』".Args(sig.Name);

            lblAlpha.Text = "選択肢 [{0}]".Args(sig.ChoiceLabelCharOnScrollOfName);

            _goalTarget = sig;

            var col = Color.LightPink;

            _llist.RemoveHighlight(col);
            _llist.AddHighlight(sig, col);
        }

        #region イベントハンドラ

        private void txtPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var page = 0;

                var success = int.TryParse(txtPage.Text, out page);

                if (!success) return;

                PageNow = page;

                e.Handled = true;
            }

        }

        private void btnPageNext_Click(object sender, EventArgs e)
        {
            SearchTarget = null;

            PageNow = PageNow + 1;
        }

        private void btnPageBack_Click(object sender, EventArgs e)
        {
            SearchTarget = null;

            PageNow = PageNow - 1;
        }

        private void btnSearchNext_Click(object sender, EventArgs e)
        {
            Search(true);
        }

        private void btnSearchBack_Click(object sender, EventArgs e)
        {
            Search(false);
        }

        #endregion

        private void SetPage(int page)
        {
            /*
            _sigList = Lists.SigList;

            var headNo = 17 * (page - 1);

            var charList = Enumerable.Range(0, 17).Select(i => new String((char)('a' + i), 1)).ToList();

            var result = Enumerable.Range(0, 17).Select(co => _sigList.GetSignatureOrNull(headNo + co)).ToList();

            var choiceStr = result.Select((sig, index) =>
            {
                var name = (index == 0 ? "他の名前を考える" : (sig == null ? "*黄金*" :  sig.Name));

                return "[{0}] {1}".Args(charList[index], name);
            }).ToList();

            var whole = choiceStr.JoinS("\r\n");
            */

            _nowPage = page;
            txtPage.Text = page.ToString();

            var diff = (_targetPage - PageNow);

            lblLastPage.ForeColor = diff >= 0 ? SystemColors.ControlText : Color.Red;

            lblLastPage.Text = diff.ToString();

            _llist.SetPage(PageNow);


        }

        private void Search(bool isForward)
        {
            var no = (SearchTarget == null ? (17 * (PageNow - 1)) : SearchTarget.No);

            var sig = SearchXward(_sigList.SigList, txtSearch.Text, no, isForward);

            if (sig == null)
            {
                MessageBox.Show("当てはまる銘が見つかりません。");
                return;
            }

            SearchTarget = sig;

            _llist.RemoveHighlight(Color.Yellow);
            _llist.AddHighlight(sig, Color.Yellow);

        }

        Signature SearchXward(List<Signature> sigList, string keyword, int nowNo, bool isForward)
        {
            var rtnSig = isForward ? 
                sigList.Skip(nowNo).FirstOrDefault(sig => sig.Name.Contains(keyword) && sig.Selectable) :
                sigList.Take(nowNo - 1).LastOrDefault(sig => sig.Name.Contains(keyword) && sig.Selectable);

            return rtnSig;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ScrollOfNameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
