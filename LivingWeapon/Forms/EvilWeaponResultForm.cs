﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivingWeapon.MyExt;
using System.IO;

namespace LivingWeapon
{
    public partial class EvilWeaponResultForm : BaseForm
    {
        private Form _previousForm;
        private EvilWeaponCalc _result;
        Dictionary<string, Form> _subForms;

        #region コンストラクタとロード

        internal EvilWeaponResultForm()
        {
            InitializeComponent();
        }

        //この前でgoalLevel - startLevel(付けられる個数)がselectedEnchantsの個数と合っていることを保証（Select→Confirmの間）
        internal EvilWeaponResultForm(Form previous, EvilWeaponCalc ecalc) : this()
        {
            _previousForm = previous;

            _result = ecalc;

            _subForms = new Dictionary<string, Form>();

            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
        }

        private void SignatureCombinationResultForm_Load(object sender, EventArgs e)
        {
            txtMain.Text = _result.GetResultStr();

            {
                var table = _result.GetResultTable();

                var form = new DGVForm(table, false);

                form.Hide();

                _subForms["ResultAsList"] = form;
            }
        }

        #endregion


        #region イベントハンドラ
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            _subForms["ResultAsList"].Show();
        }

        private void btnSaveAsFile_Click(object sender, EventArgs e)
        {
            var content = _result.GetResultStr();

            var sfd = new SaveFileDialog();

            sfd.FileName = "result.txt";
            sfd.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";

            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filepath = sfd.FileName;

                    using (var fs = new StreamWriter(filepath, false, Encoding.GetEncoding("Shift_JIS")))
                    {
                        fs.Write(content);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("保存に失敗しました");
            }
        }

        private void btnEnchantInfo_Click(object sender, EventArgs e)
        {
            _subForms["EnchantInfo"].Show();
        }

        private void btnEnchLv_Click(object sender, EventArgs e)
        {
            _subForms["LvEnchantingSignature"].Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Util.ExitApplication();

            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _backFlag = true;

            Close();
        }

        private void SignatureCombinationResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var form in _subForms.Values)
            {
                form.Close();
            }

            if (!_backFlag)
            {
                Util.ExitApplication();
            }
        }



        #endregion

        #region hide
        /*
        private bool SimpleSearchBody(List<SearchingEnchant> searchingEnchants, out List<SearchingEnchant> result, out string log)
        {
            result = new List<SearchingEnchant>();
            var stack = new List<SearchingEnchant>(searchingEnchants);

            log = "";

            ///最も厳しい14→15Level時の選択エンチャントから見ていく
            for (int level = GoalLevel - 1; level >= StartLevel; --level)
            {
                var maxBloodLevel = stack.Max(sEnch => sEnch.GetChoiceSignature(level).BloodLevel);
                var popTarget = stack.First(sEnch => sEnch.GetChoiceSignature(level).BloodLevel == maxBloodLevel);
                stack.Remove(popTarget);
                result.Add(popTarget);
            }

            result.Reverse();

            bool isOK = true;

            for (int i = 0; i < result.Count; ++i)
            {
                //例：13→14(level = 13)
                var level = StartLevel + i;

                isOK = result[i].GetChoiceSignature(level).BloodLevel > level;

                if (!isOK)
                {
                    log += "探索失敗\r\n";
                    log += "検証レベル：{0}\r\n".Args(level);
                    log += Util.GetEnchantInfo(result[i].GetChoiceSignature(level));

                    break;
                }

            }
            resultSigs = result.Select((sEnch, index)
            =>
            {
                var level = StartLevel + index;

                return sEnch.GetChoiceSignature(level);
            }).ToList();
            

            var resultStr = GetResultStr(result);

            log += resultStr;

            return isOK;
        }

        private bool SimpleSearch(out List<SearchingEnchant> result)
        {
            var enchantingSignatures = SelectedEnchants.GetEnchantingSignatureList();

            //簡易検索
            for (int i = 0; i < 100; ++i)
            {
                List<SearchingEnchant> searchingEnchants =
                enchantingSignatures
                .Select(enchSig => new SearchingEnchant(StartLevel, GoalLevel, enchSig))
                .ToList();

                var log = "";

                result = new List<SearchingEnchant>();

                var success = SimpleSearchBody(searchingEnchants, out result, out log);

                if (success)
                {
                    //txtMain.Text += GetResultStr(result);
                    _retryN = i;

                    return true;

                }

                //成功しなかったら次のエンチャント銘セットを試す
                SelectedEnchants.Next();
                enchantingSignatures = SelectedEnchants.GetEnchantingSignatureList();
            }

            result = new List<SearchingEnchant>();
            return false;

        }

        private bool DepthSearch1(out List<SearchingEnchant> result)
        {
            var enchantingSignatures = SelectedEnchants.GetEnchantingSignatureList();

            //ループココから

            for (var i = 0; i < 100; ++i)
            {
                List<SearchingEnchant> searchingEnchants =
                    enchantingSignatures
                    .Select(enchSig => new SearchingEnchant(StartLevel, GoalLevel, enchSig))
                    .ToList();

                var dfs = new EnchantOrderDFS(StartLevel, GoalLevel, searchingEnchants);

                var success = dfs.ExecDFS(out result);

                if (success)
                {
                    _retryN = i;

                    //レベル高い順に並んでいるので逆にする
                    result.Reverse();

                    return true;
                }
                else
                {
                    var report = dfs.FirstFailureReport;

                    //TODO reportを元に新しいエンチャント銘セットを選び直す
                    SelectedEnchants.Next();

                    enchantingSignatures = SelectedEnchants.GetEnchantingSignatureList();

                }
            }

            result = null;

            return false;

        }


        #endregion
    }
    /*
    class EnchantOrderDFS
    {
        public List<SearchingEnchant> Result { get; private set; }
        public bool SearchCompleted { get; private set; } = false;

        int _goalLevel;
        int _startLevel;
        List<SearchingEnchant> _searchingEnchants;

        internal class SearchFailureReport
        {
            internal int Level { get; set; }
            internal List<int> BranchList { get; set; }
        }

        //探索に最初に失敗した時のレベルと枝
        public SearchFailureReport FirstFailureReport { get; private set; } = null;

        //コンストラクタ
        internal EnchantOrderDFS(int startLevel, int goalLevel, List<SearchingEnchant> searchingEnchants)
        {
            Result = new List<SearchingEnchant>();

            _goalLevel = goalLevel;
            _startLevel = startLevel;
            _searchingEnchants = searchingEnchants;
        }

        internal bool ExecDFS(out List<SearchingEnchant> result)
        {
            if (SearchCompleted)
            {
                result = Result;
                return true;
            }

            var branchList = Enumerable.Range(0, _searchingEnchants.Count).ToList();

            var level = _goalLevel - 1;

            bool success = ExecDFSInternal(level, branchList);

            SearchCompleted = true;

            result = Result;
            return success;

        }

        private bool ExecDFSInternal(int level, List<int> branchList)
        {
            var searchedList = new List<int>();

            //ループここから

            while (true)
            {
                //枝の中で探索済みでないもの
                var targetList = branchList.Where(idx => !searchedList.Contains(idx)).ToList();

                //すべての枝が探索済みなら探索失敗
                if (targetList.Count == 0)
                {
                    return false;
                }

                //血吸が発生しないエンチャントを選択
                int pickIndex = -1;

                for (int i = 0; i < _searchingEnchants.Count; ++i)
                {
                    if (!targetList.Contains(i)) continue;

                    if (_searchingEnchants[i].GetChoiceSignature(level).BloodLevel > level)
                    {
                        pickIndex = i;
                        break;
                    }
                }

                //選択候補の銘の中で血吸い回避できるものがない
                if (pickIndex == -1)
                {
                    if (FirstFailureReport == null)
                    {
                        FirstFailureReport = new SearchFailureReport { Level = level, BranchList = branchList };
                    }

                    return false;
                }
                else
                {
                    var nextBranchList = new List<int>(branchList);
                    nextBranchList.Remove(pickIndex);

                    //push
                    Result.Add(_searchingEnchants[pickIndex]);

                    //育成開始レベルの探索が終われば終了
                    if (level == _startLevel) return true;

                    var success = ExecDFSInternal(level - 1, nextBranchList);

                    if (success)
                    {
                        return true;
                    }
                    else
                    {
                        //pop
                        Result.RemoveAt(Result.Count - 1);

                        //探索済み枝に追加
                        searchedList.Add(pickIndex);
                    }

                }
            }

        }



    }*/
        #endregion

        private void chkFont_CheckedChanged(object sender, EventArgs e)
        {
            var font = chkFont.Checked ? new Font("ＭＳ ゴシック", 10) : new Font("Meiryo UI", 9);
            txtMain.Font = font;
        }
    }
}
