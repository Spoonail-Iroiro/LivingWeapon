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
using System.IO;

namespace LivingWeapon
{
    public partial class SignatureCombinationResultForm : BaseForm
    {
        private Form _previousForm;
        private List<SearchingEnchant> _result;
        int _retryN;
        Dictionary<string, Form> _subForms;

        internal int StartLevel { get; private set; }
        internal int GoalLevel { get; private set; }
        internal SelectedEnchants SelectedEnchants { get; private set; }

        #region コンストラクタとロード

        internal SignatureCombinationResultForm()
        {
            InitializeComponent();
        }

        //この前でgoalLevel - startLevel(付けられる個数)がselectedEnchantsの個数と合っていることを保証（Select→Confirmの間）
        internal SignatureCombinationResultForm(Form previous, int startLevel, int goalLevel, SelectedEnchants selectedEnchants) : this()
        {
            _previousForm = previous;

            StartLevel = startLevel;
            GoalLevel = goalLevel;
            SelectedEnchants = selectedEnchants;
        }

        private void SignatureCombinationResultForm_Load(object sender, EventArgs e)
        {
            var result = new List<SearchingEnchant>();

            DepthSearch2(out result);

            _result = result;

            txtMain.Text = GetResultStr(_result);

            _subForms = new Dictionary<string, Form>();

            {
                var table = GetResultTable(_result);

                var form = new DGVForm(table);

                form.Hide();

                _subForms["ResultAsList"] = form;
            }

            {
                var sigList = _result.Select(sSig => sSig.EnchantingSignature).ToList();

                var form = new LvEnchantingSignatureForm(sigList, StartLevel);

                form.Hide();

                _subForms["LvEnchantingSignature"] = form;
            }

            {
                var tableReal = SelectedEnchants.GetEnchantingSignatureList();
                var tableIdeal = SelectedEnchants.GetIdealEnchantingSignatureList();

                var form = new ShowEnchantInfoForm(tableIdeal, tableReal, _retryN);

                form.Hide();

                _subForms["EnchantInfo"] = form;

            }


        }

        #endregion

        private string GetResultStr(List<SearchingEnchant> result)
        {
            return result.Select((sEnch, index)
=>
            {
                var level = StartLevel + index;

                var choice = sEnch.GetChoiceSignature(level);

                return "{0}=>{1} | {2}, {3}ページ, {4}, {5}, 強度{6}, （血吸{7}）".Args(
                    level.ToString().PadLeft(2),
                    (level + 1).ToString().PadLeft(2),
                    choice.No,
                    choice.Page,
                    choice.Name,
                    sEnch.EnchantingSignature.EnchantStr,
                    sEnch.EnchantingSignature.Value,
                    choice.BloodLevel);
            })
            .JoinS("\r\n") + "\r\n";
        }

        private DataTable GetResultTable(List<SearchingEnchant> result)
        {
            var table = new DataTable();

            table.Columns.Add(new DataColumn("Lv", typeof(int)));
            table.Columns.Add(new DataColumn("LvUp", typeof(int)));
            table.Columns.Add(new DataColumn("No", typeof(int)));
            table.Columns.Add(new DataColumn("ページ", typeof(int)));
            table.Columns.Add(new DataColumn("銘", typeof(string)));
            table.Columns.Add(new DataColumn("選択するエンチャント", typeof(string)));
            table.Columns.Add(new DataColumn("強度", typeof(int)));
            table.Columns.Add(new DataColumn("血吸レベル", typeof(int)));

            var rows = result.Select((sEnch, index) =>
            {
                var level = StartLevel + index;
                var choice = sEnch.GetChoiceSignature(level);

                return new object[]
                {
                    level,
                    level +1,
                    choice.No,
                    choice.Page,
                    choice.Name,
                    sEnch.EnchantingSignature.EnchantStr,
                    sEnch.EnchantingSignature.Value,
                    choice.BloodLevel
                };
            });

            foreach (var row in rows)
            {
                table.Rows.Add(row);
            }


            return table;
        }

        private bool DepthSearch2(out List<SearchingEnchant> result)
        {
            var enchantingSignatures = SelectedEnchants.GetEnchantingSignatureList();

            //ループココから

            for (var i = 0; i < 200; ++i)
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

                    //reportを元に新しいエンチャント銘セットを選び直す
                    for (int rank = 1; rank < 10; ++rank)
                    {
                        //探索中の最初の失敗時の枝
                        foreach (var index in report.BranchList.AsEnumerable().Reverse().ToList())
                        {
                            var pick = SelectedEnchants.GetEnchantingSignature(index, rank);

                            //最初の失敗を回避できないか確認する
                            var pickInfo = new SearchingEnchant(StartLevel, GoalLevel, pick);

                            //最初の失敗を回避できるならば
                            if (pickInfo.GetChoiceSignature(report.Level).BloodLevel > report.Level)
                            {
                                //採用する
                                SelectedEnchants.SetValueRank(index, rank);

                                //2重ループを抜ける
                                goto SEARCHING_ENCHANTSET_FINISH;
                            }
                        }

                    }

                    SEARCHING_ENCHANTSET_FINISH: enchantingSignatures = SelectedEnchants.GetEnchantingSignatureList();

                }
            }

            result = null;

            return false;

        }

        #region イベントハンドラ
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            _subForms["ResultAsList"].Show();
        }

        private void btnSaveAsFile_Click(object sender, EventArgs e)
        {
            var content = GetResultStr(_result);

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
            foreach(var form in _subForms.Values)
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
            /*
            resultSigs = result.Select((sEnch, index)
            =>
            {
                var level = StartLevel + index;

                return sEnch.GetChoiceSignature(level);
            }).ToList();
            */

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



    }
}
