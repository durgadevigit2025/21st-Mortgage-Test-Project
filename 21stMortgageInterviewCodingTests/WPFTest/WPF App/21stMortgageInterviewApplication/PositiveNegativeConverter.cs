using System;
using System.Globalization;
using System.Windows.Data;

namespace _21stMortgageInterviewApplication
{
    public class PositiveNegativeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                int intValue when intValue > 0 => "Positive",
                int intValue when intValue < 0 => "Negative",
                _ => "Neutral"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
