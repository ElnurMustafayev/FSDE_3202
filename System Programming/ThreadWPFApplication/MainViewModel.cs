using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadWPFApplication
{
    public class MainViewModel : ViewModelBase
    {
        private int progressBarValue;

        public int ProgressBarValue
        {
            get { return progressBarValue; }
            set { Set(ref progressBarValue, value); }
        }

        private RelayCommand buttonClickCommand;

        public RelayCommand ButtonClickCommand
        {
            //get
            //{
            //    if(buttonClickCommand == null)
            //    {
            //        buttonClickCommand = new RelayCommand(() =>
            //        {
            //            ProgressBarValue = new Random().Next(0, 100);
            //        });
            //    }
            //    return buttonClickCommand;
            //}

            //get
            //{
            //    return buttonClickCommand ?? (buttonClickCommand = new RelayCommand(() =>
            //        {
            //            ProgressBarValue = new Random().Next(0, 100);
            //        }));
            //}

            get => buttonClickCommand ??= new RelayCommand(() => {
                ProgressBarValue = new Random().Next(0, 100);
            });
        }


        public MainViewModel()
        {
            this.ProgressBarValue = 30;
        }
    }
}
