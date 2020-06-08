using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSamples.ViewModels
{
    public class ViewBViewModel : BindableBase,IDialogAware
    {
        public ViewBViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }

        public string Title => "test";

        //ViewBTextBox
        private string _viewBTextBox = "XXX";
        public string ViewBTextBox
        {
            get { return _viewBTextBox; }
            set { SetProperty(ref _viewBTextBox, value); }
        }

        //OKButton
        public DelegateCommand OKButton { get; }
        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()//画面が閉じれるかどうか
        {
            return true;
        }

        public void OnDialogClosed()//画面が閉じるときの処理
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)//ひらくときの処理
        {
            ViewBTextBox=parameters.GetValue<string>(nameof(ViewBTextBox));
        }

        private void OKButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewBTextBox), ViewBTextBox);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
        }
    }
}
