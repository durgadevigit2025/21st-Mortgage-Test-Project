using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _21stMortgageInterviewApplication
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly NumberListModel _numberListModel;

        private string _inputString;
        public string InputString
        {
            get => _inputString;
            set
            {
                _inputString = value;
                OnPropertyChanged(nameof(InputString));
            }
        }

        private string _outputString;
        public string OutputString
        {
            get => _outputString;
            set
            {
                _outputString = value;
                OnPropertyChanged(nameof(OutputString));
            }
        }

        public ICommand FindMaxNumberCommand { get; }
        public ICommand FindOddSumCommand { get; }
        public ICommand FindEvenSumCommand { get; }
        public ICommand CalculateMaxValueCommand { get; }
        public ICommand CalculateEvenOddSumCommand { get; }

        public MainWindowViewModel(NumberListModel numberListModel, RelayCommand findMaxNumberCommand, RelayCommand findOddSumCommand, RelayCommand findEvenSumCommand)
        {
            _numberListModel = numberListModel;
            FindMaxNumberCommand = findMaxNumberCommand;
            FindOddSumCommand = findOddSumCommand;
            FindEvenSumCommand = findEvenSumCommand;
            CalculateMaxValueCommand = new RelayCommand(async param => await CalculateMaxValueAsync());
            CalculateEvenOddSumCommand = new RelayCommand(async param => await CalculateEvenOddSumAsync());
        }

        private bool CanExecuteFindMaxNumber(object parameter)
        {
            _numberListModel.FromString(parameter as string);
            return _numberListModel.GetNumberCount() > 0;
        }

        private void ExecuteFindMaxNumber(object parameter)
        {
            _numberListModel.FromString(parameter as string);
            OutputString = _numberListModel.GetLargestNumber().ToString();
        }

        private bool CanExecuteFindOddSum(object parameter)
        {
            _numberListModel.FromString(parameter as string);
            return _numberListModel.GetNumberCount() > 0;
        }

        private void ExecuteFindOddSum(object parameter)
        {
            _numberListModel.FromString(parameter as string);
            OutputString = _numberListModel.GetSumOfOddNumbers().ToString();
        }

        private bool CanExecuteFindEvenSum(object parameter)
        {
            _numberListModel.FromString(parameter as string);
            return _numberListModel.GetNumberCount() > 0;
        }

        private void ExecuteFindEvenSum(object parameter)
        {
            _numberListModel.FromString(parameter as string);
            OutputString = _numberListModel.GetSumOfEvenNumbers().ToString();
        }

        private async Task CalculateMaxValueAsync()
        {
            var numbers = _numberListModel.ParseNumbers(InputString);
            OutputString = numbers.Any() ? numbers.Max().ToString() : "Invalid input";
            await Task.CompletedTask;
        }

        private async Task CalculateEvenOddSumAsync()
        {
            var numbers = _numberListModel.ParseNumbers(InputString);
            if (numbers.Any())
            {
                var evenSum = numbers.Where(n => n % 2 == 0).Sum();
                var oddSum = numbers.Where(n => n % 2 != 0).Sum();
                OutputString = $"Even Sum: {evenSum}, Odd Sum: {oddSum}";
            }
            else
            {
                OutputString = "Invalid input";
            }
            await Task.CompletedTask;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
