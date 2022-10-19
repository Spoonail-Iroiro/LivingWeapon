using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWeapon
{
    public class SignatureSearch
    {

        public bool searchFinished { get; private set; } = false;

        public int StartLevel { get; private set; }
        public int GoalLevel { get; private set; }
        public SelectedEnchants SelectedEnchants { get; private set; }
        public int RetryN { get; private set; }
        private List<SearchingEnchant> _result;
        public List<SearchingEnchant> Result
        {
            get
            {
                if (!searchFinished) throw new Exception("探索未完了の状態で探索結果にアクセスしようとしました");
                return _result;
            }
            private set { _result = value; }
        }

        public SignatureSearch(int startLevel, int goalLevel, SelectedEnchants selectedEnchants, bool searchImmediately = true)
        {
            this.StartLevel = startLevel;
            this.GoalLevel = goalLevel;
            this.SelectedEnchants = selectedEnchants;

            //すぐに結果を算出
            if (searchImmediately) this.Search();
        }

        public List<SearchingEnchant> Search()
        {
            if (searchFinished) return Result;

            var rtn = new List<SearchingEnchant>();

            var success = DepthSearch2(out rtn);

            if (!success) throw new SignatureSearchFailedException("エンチャントの探索に失敗しました");

            Result = rtn;

            searchFinished = true;

            return rtn;

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
                    RetryN = i;

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
    }

    public class SignatureSearchFailedException : Exception
    {
        public SignatureSearchFailedException():base()
        { }

        public SignatureSearchFailedException(string message):base(message)
        { }

        public SignatureSearchFailedException(string message, Exception innerException):base(message, innerException)
        { }
    }

    class EnchantOrderDFS
    {
        public List<SearchingEnchant> Result { get; private set; }
        public bool SearchCompleted { get; private set; } = false;

        int _goalLevel;
        int _startLevel;
        List<SearchingEnchant> _searchingEnchants;

        public class SearchFailureReport
        {
            public int Level { get; set; }
            public List<int> BranchList { get; set; }
        }

        //探索に最初に失敗した時のレベルと枝
        public SearchFailureReport FirstFailureReport { get; private set; } = null;

        //コンストラクタ
        public EnchantOrderDFS(int startLevel, int goalLevel, List<SearchingEnchant> searchingEnchants)
        {
            Result = new List<SearchingEnchant>();

            _goalLevel = goalLevel;
            _startLevel = startLevel;
            _searchingEnchants = searchingEnchants;
        }

        public bool ExecDFS(out List<SearchingEnchant> result)
        {
            if (SearchCompleted)
            {
                result = Result;
                return true;
            }

            var branchList = Enumerable.Range(0, _searchingEnchants.Count).ToList();

            var level = _goalLevel - 1;

            bool success = ExecDFSpublic(level, branchList);

            SearchCompleted = true;

            result = Result;
            return success;

        }

        private bool ExecDFSpublic(int level, List<int> branchList)
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

                    var success = ExecDFSpublic(level - 1, nextBranchList);

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
