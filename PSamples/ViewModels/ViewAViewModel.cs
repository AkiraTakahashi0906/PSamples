using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PSamples.Services;
using PSamples.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Unity.Injection;

namespace PSamples.ViewModels
{
    public class ViewAViewModel : BindableBase,INavigationAware
    {
        private IDialogService _dialogService;
        private IMessageService _messageService;

        public ViewAViewModel(IDialogService dialogService)//引数１個　本番コード
            :this(dialogService,new MessageService())
        {

        }
        public ViewAViewModel(IDialogService dialogService,IMessageService messageService)
        {
            _dialogService = dialogService;
            _messageService = messageService;
            OKButton = new DelegateCommand(OKButtonExecute);
            OKButton2 = new DelegateCommand(OKButton2Execute);
        }
        private string _myLabel = string.Empty;
        public string MyLabel
        {
            get { return _myLabel; }
            set { SetProperty(ref _myLabel, value); }
        }

        public DelegateCommand OKButton { get; }
        public DelegateCommand OKButton2 { get; }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            MyLabel = navigationContext.Parameters.GetValue<string>(nameof(MyLabel));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;//ViewAインスタンスを使いまわすかどうか
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)//ナビゲーションがこの画面から離れるときに通過する
        {
        }

        private void OKButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewBViewModel.ViewBTextBox), "Save");
            _dialogService.ShowDialog(nameof(ViewB), p,null);
        }

        private void OKButton2Execute()
        {
            //MessageBox.Show("SAVE");
            if (_messageService.Question("Saveしますか？") == MessageBoxResult.OK)
            {
                _messageService.ShowDialog("Saveしました");
            }
        }

    }
}
