using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MorseEncoder
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            this.CmdEncrypt = new DelegateCommand(this.Encrypt, () => !string.IsNullOrWhiteSpace(this.PlainText));
            this.CmdDecrypt = new DelegateCommand(this.Decrypt, () => !string.IsNullOrWhiteSpace(this.MorseText));
        }

        #region Properties

        private string _plainText;
        public string PlainText
        {
            get
            {
                return _plainText;
            }
            set
            {
                SetProperty(ref _plainText, value);
                (this.CmdEncrypt as DelegateCommand).RaiseCanExecuteChanged();
            }
        }

        private string _gbkText;
        public string GBKText
        {
            get
            {
                return _gbkText;
            }
            set
            {
                SetProperty(ref _gbkText, value);
            }
        }

        private string _morseText;
        public string MorseText
        {
            get
            {
                return _morseText;
            }
            set
            {
                SetProperty(ref _morseText, value);
                (this.CmdDecrypt as DelegateCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// 加密
        /// </summary>
        public ICommand CmdEncrypt { get; private set; }

        /// <summary>
        /// 解密
        /// </summary>
        public ICommand CmdDecrypt { get; private set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void Encrypt()
        {
            StringBuilder sbGBKCodes = new StringBuilder();
            StringBuilder sbMorse = new StringBuilder();
            var words = this.PlainText.ToArray();
            foreach (var s in words)
            {
                var symbol = s.ToString();
                if (Regex.IsMatch(symbol, "[\u4e00-\u9fa5]"))
                {
                    var gbkResult = GBKHelper.ChineseToCoding(symbol);
                    sbGBKCodes.Append(gbkResult).Append("/");
                    var morseResult = MorseHelper.GBK2Morse(gbkResult);
                    sbMorse.Append(morseResult).Append("/   ");
                }
                else
                {
                    sbGBKCodes.Append(s);
                    sbMorse.Append(s);
                }
            }

            this.GBKText = sbGBKCodes.ToString();
            this.MorseText = sbMorse.ToString();
        }

        private void Decrypt()
        {

        }

        #endregion
    }
}
