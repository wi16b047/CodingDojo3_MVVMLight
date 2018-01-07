using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;

namespace MVVMLightExample.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        private bool isClickable = false;
        private string text = "";
        private int clickCounter =0;

        RelayCommand clickBtnCommand;
        RelayCommand clickBtnCommand2;

        public int ClickCounter
        {
            get { return clickCounter; }
            set { clickCounter = value; RaisePropertyChanged("ClickCounter"); }
        }

        public bool IsCLickable
        {
            get { return isClickable; }
            set { isClickable = value; }
        }
     

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public RelayCommand ClickBtnCommand
        {
            get
            {
                return clickBtnCommand;
            }

            set
            {
                clickBtnCommand = value;
            }
        }

        public RelayCommand ClickBtnCommand2
        {
            get
            {
                return clickBtnCommand2;
            }

            set
            {
                clickBtnCommand2 = value;
            }
        }

        public MainViewModel()
        {
            ClickBtnCommand = new RelayCommand(new Action(ExecuteClickCount), new Func<bool>(CanExecuteClickCount));
            ClickBtnCommand = new RelayCommand(ExecuteClickCount, CanExecuteClickCount);
            ClickBtnCommand2 = new RelayCommand(ExecuteClickCount, ()=> { if (Text.Length > 3) { return true; } else { return false; } });
        }

        private bool CanExecuteClickCount()
        {
            return IsCLickable;
        }

        private void ExecuteClickCount()
        {
            ClickCounter++;
        }
    }
}