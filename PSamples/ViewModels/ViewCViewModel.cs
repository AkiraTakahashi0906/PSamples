using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PSamples.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PSamples.ViewModels
{
    public class ViewCViewModel : BindableBase,IConfirmNavigationRequest
    {

        private IMessageService _messageService;
        private MainWindowViewModel _mainWindowViewModel;

        public ViewCViewModel(MainWindowViewModel mainWindowViewModel) : 
            this(new MessageService(),  mainWindowViewModel)
        {
        }

        public ViewCViewModel(IMessageService messageService, MainWindowViewModel mainWindowViewModel)
        {
            _messageService = messageService;
            _mainWindowViewModel = mainWindowViewModel;

            MyListBox.Add("AAAA");
            MyListBox.Add("BBBB");
            MyListBox.Add("CCCC");

            Areas.Add(new ComboBoxViewModel(1, "横浜"));
            Areas.Add(new ComboBoxViewModel(2, "岐阜"));
            Areas.Add(new ComboBoxViewModel(3, "名古屋"));

            SelectedArea = Areas[1];

            AreaSelectionChanged = new DelegateCommand<object[]>(AreaSelectionChangedExecute);

        }

        //SelectedAreaLabel
        private string  _selectedAreaLabel;
        public string  SelectedAreaLabel
        {
            get { return _selectedAreaLabel; }
            set { SetProperty(ref _selectedAreaLabel, value); }
        }

        //AreaSelectionChanged
        public DelegateCommand<object[]> AreaSelectionChanged { get; }

        //Areas
        private ObservableCollection<ComboBoxViewModel> _areas = new ObservableCollection<ComboBoxViewModel>();
        public ObservableCollection<ComboBoxViewModel> Areas
        {
            get { return _areas; }
            set { SetProperty(ref _areas, value); }
        }

        //SelectedArea
        private ComboBoxViewModel _selectedArea;
        public ComboBoxViewModel SelectedArea
        {
            get { return _selectedArea; }
            set { SetProperty(ref _selectedArea, value); }
        }

        //MyListBox
        private ObservableCollection<string> _myListBox = new ObservableCollection<string>();
        public ObservableCollection<string> MyListBox
        {
            get { return _myListBox; }
            set { SetProperty(ref _myListBox, value); }
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)//画面が閉じる直前に通知
        {
           if ( _messageService.Question("とじますか？")== System.Windows.MessageBoxResult.OK)
            {
                continuationCallback(true);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false; //インスタンス使いまわすか
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        private void AreaSelectionChangedExecute(object[] items)
        {
            SelectedAreaLabel = SelectedArea.Value + ":" + SelectedArea.DisplayValue;
            _mainWindowViewModel.Title = SelectedAreaLabel;
        }
    }
}
