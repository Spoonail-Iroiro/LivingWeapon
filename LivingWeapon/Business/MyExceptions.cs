using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWeapon.Business
{
    public class SignatureListLoadException : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SignatureListLoadException()
            : base()
        {
        }
        /// <summary>
        /// メッセージ文字列を渡すコンストラクタ
        /// </summary>
        /// <param name="message">メッセージ文字列</param>
        public SignatureListLoadException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// メッセージ文字列と発生済み例外オブジェクトを渡すコンストラクタ
        /// </summary>
        /// <param name="message">メッセージ文字列</param>
        /// <param name="innerException">子例外オブジェクト</param>
        public SignatureListLoadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class StaticJsonLoadException : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StaticJsonLoadException()
            : base()
        {
        }
        /// <summary>
        /// メッセージ文字列を渡すコンストラクタ
        /// </summary>
        /// <param name="message">メッセージ文字列</param>
        public StaticJsonLoadException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// メッセージ文字列と発生済み例外オブジェクトを渡すコンストラクタ
        /// </summary>
        /// <param name="message">メッセージ文字列</param>
        /// <param name="innerException">子例外オブジェクト</param>
        public StaticJsonLoadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}
