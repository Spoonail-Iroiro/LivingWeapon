using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivingWeapon.MyExt;

namespace LivingWeapon
{
    public class LabelList
    {
        SignatureList _sigList;

        List<Label> _list;

        int _pageNow;

        List<Tuple<Signature, Color>> _highlight;        

        internal LabelList(Form parent, Label labelHead, int page = 1)
        {
            _list = new List<Label>();

            _sigList = Lists.SigList;

            _highlight = new List<Tuple<Signature, Color>>();

            var fontSize = 12F;

            var lineInterval = 26;

            foreach (var i in Enumerable.Range(0, 17))
            {
                var label = new Label();

                label.AutoSize = true;
                label.Font = new System.Drawing.Font("ＭＳ ゴシック", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                label.Location = new System.Drawing.Point(labelHead.Location.X, labelHead.Location.Y + i * lineInterval);
                label.Name = "lblHead" + i.ToString();
                label.Text = "label" + i.ToString();

                label.Visible = true;

                label.BringToFront();

                _list.Add(label);

                parent.Controls.Add(label);
            }

            labelHead.Visible = false;

            SetPage(page);

        }

        internal void AddHighlight(Signature sig, Color col)
        {
            _highlight.Add(new Tuple<Signature, Color>(sig, col));
            Refresh();
        }

        internal void RemoveHighlight(Color col)
        {
            _highlight.RemoveAll(hl => hl.Item2 == col);
            Refresh();
        }

        internal void RemoveHighlight()
        {
            _highlight.Clear();
            Refresh();
        }

        internal void SetPage(int page)
        {
            _pageNow = page;

            var headNo = 17 * (page - 1);

            var charList = Enumerable.Range(0, 17).Select(i => new String((char)('a' + i), 1)).ToList();

            var result = Enumerable.Range(0, 17).Select(co => _sigList.GetSignatureOrNull(headNo + co)).ToList();

            var choiceStr = result.Select((sig, index) =>
            {
                var name = (index == 0 ? "他の名前を考える" : (sig == null ? "*黄金*" : sig.Name));

                return "[{0}] {1}".Args(charList[index], name);
            }).ToList();

            var whole = choiceStr.JoinS("\r\n");

            SetString(whole);

            Refresh();
        }

        private void Refresh()
        {
            NoHighlight();
            PaintHighlight();
        }

        private void PaintHighlight()
        {
            foreach(var hl in _highlight)
            {
                if (hl.Item1.Page == _pageNow)
                {
                    HighlightLabel(hl.Item1.No % 17, hl.Item2);
                }
            }
        }

        private void NoHighlight()
        {
            foreach (var ll in _list)
            {
                ll.BackColor = SystemColors.Control;
            }
        }

        private void SetString(string str)
        {
            var rowStrs = str.Split('\n').ToList();

            var roopCount = Math.Min(_list.Count, rowStrs.Count);

            for (int i = 0; i < roopCount; ++i)
            {
                _list[i].Text = rowStrs[i];
            }
        }

        private void HighlightLabel(int index, Color col)
        {
            _list[index].BackColor = col;
        }

    }
}
